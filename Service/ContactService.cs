using Common;
using Common.Logging;
using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ContactService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public ContactService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<Contact> Get()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Contact> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    var assignment = context.Contacts.Where(x => x.Enabled == true)
                        .Include(i => i.ContactType)
                        .Include(i => i.Assignment)
                        .Include(i => i.Assignment.Participant)
                        .Include(i => i.Assignment.Counselor).ToList();
                    /*IQueryable<User> query = context.Users.Where(x => x.Enabled == true);*/
                    response = new UtilitariesResponse<Contact>(config).setResponseBaseForList(assignment);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Contact>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }


        public EResponseBase<Contact> InsertOrUpdate(Contact request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Contact> response;
            try
            {

                using (var context = new ClientDbContext())
                {

                    /*if (request.ContactId > 0)
                    {
                        Contact contact = context.Contacts.Find(request.ContactId);
                        context.Entry(contact).State = EntityState.Modified;
                        contact.AssignmentId = request?.AssignmentId == 0 ? contact.AssignmentId : request.AssignmentId;
                        contact.ContactTypeId = request?.ContactTypeId == 0 ? contact.ContactTypeId : request.ContactTypeId;
                        contact.StartDate = request.StartDate;
                        contact.EndDate = request.EndDate;
                        contact.Description = string.IsNullOrEmpty(request.Description) ? contact.Description : request.Description;
                        context.Contacts.Add(request);
                        context.SaveChanges();
                        response = new UtilitariesResponse<Contact>(config).setResponseBaseForOK(request);
                    }
                    else
                    {*/
                        request.CreatedOn = DateTime.Now;
                        request.Enabled = true;
                        context.Contacts.Add(request);
                        context.SaveChanges();
                        response = new UtilitariesResponse<Contact>(config).setResponseBaseForOK(request);
                    /*}*/

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Contact>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Contact> GetByFilters(Contact request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Contact> response;
            try
            {
                using (var context = new ClientDbContext())
                {

                    IQueryable<Contact> queryContact = context.Contacts.Where(x => x.Enabled == true)
                        .Include(i => i.Assignment)
                        .Include(i => i.Assignment.Counselor)
                        .Include(i => i.Assignment.Participant)
                        .Include(i => i.ContactType);


                    if (request.Assignment.ParticipantId > 0 || request.Assignment != null) queryContact = queryContact.Where(x => x.Assignment.Participant.Enabled == true && x.Assignment.ParticipantId == request.Assignment.ParticipantId);
                    if (request.Assignment.CounselorId > 0 || request.Assignment != null) queryContact = queryContact.Where(x => x.Assignment.Counselor.Enabled == true && x.Assignment.CounselorId == request.Assignment.CounselorId);
                    if (request.ContactTypeId > 0) queryContact = queryContact.Where(x => x.ContactType.Enabled == true && x.ContactTypeId == request.ContactTypeId);


                    var query = queryContact.OrderBy(x => x.AssignmentId).ToList();

                    response = new UtilitariesResponse<Contact>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Contact>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }
    }
}