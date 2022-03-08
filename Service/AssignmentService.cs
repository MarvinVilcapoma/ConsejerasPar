using Common;
using Common.Logging;
using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class AssignmentService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public AssignmentService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<Assignment> Get()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Assignment> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    var assignment = context.Assignments
                        .Include(i => i.Participant)
                        .Include(i => i.Counselor).ToList();
                    /*IQueryable<User> query = context.Users.Where(x => x.Enabled == true);*/
                    response = new UtilitariesResponse<Assignment>(config).setResponseBaseForList(assignment);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Assignment>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }


        public EResponseBase<Assignment> InsertOrUpdate(Assignment request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Assignment> response;
            try
            {

                using (var context = new ClientDbContext())
                {

                    if (request.AssignmentId > 0)
                    {
                        /* Contact user = context.Contacts
                        .Where(x => x.UserName == request.UserName)
                        .FirstOrDefault();
                        */
                        Assignment assignment = context.Assignments.Find(request.AssignmentId);
                        context.Entry(assignment).State = EntityState.Modified;
                        assignment.ParticipantId = request?.ParticipantId == 0 ? assignment.ParticipantId : request.ParticipantId;
                        assignment.CounselorId = request?.CounselorId == 0 ? assignment.CounselorId : request.CounselorId;
                        context.Assignments.Add(request);
                        context.SaveChanges();
                        response = new UtilitariesResponse<Assignment>(config).setResponseBaseForOK(request);
                    }
                    else
                    {
                        request.CreatedOn = DateTime.Now;
                        request.Enabled = true;
                        context.Assignments.Add(request);
                        context.SaveChanges();
                        response = new UtilitariesResponse<Assignment>(config).setResponseBaseForOK(request);
                    }

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Assignment>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }
    }
}
