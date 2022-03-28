using Common;
using Common.Logging;
using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Service
{
    public class UserService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public UserService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<User> Login(User request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {

                using (var context = new ClientDbContext())
                {
                    User user = context.Users.Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();

                    if (user != null)
                    {
                        response = new UtilitariesResponse<User>(config).setResponseBaseForObj(user);
                    }
                    else
                    {
                        response = new UtilitariesResponse<User>(config).setResponseBaseForBadCredentials(request);
                    }
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<User> Get()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    var users = context.Users.ToList();
                    /*IQueryable<User> query = context.Users.Where(x => x.Enabled == true);*/
                    response = new UtilitariesResponse<User>(config).setResponseBaseForList(users);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }
            
            return response;
        }

        public EResponseBase<Counselor> GetCounselors()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Counselor> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var users = context.Participant.ToList();*/
                    IQueryable<Counselor> query = context.Counselors.Where(x => x.Enabled == true);
                    response = new UtilitariesResponse<Counselor>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Counselor>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Participant> GetParticipants()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Participant> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var users = context.Participant.ToList();*/
                    IQueryable<Participant> query = context.Participants.Where(x => x.Enabled == true);
                    response = new UtilitariesResponse<Participant>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Participant>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Nutritionist> GetNutritionists()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Nutritionist> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var users = context.Participant.ToList();*/
                    IQueryable<Nutritionist> query = context.Nutritionists.Where(x => x.Enabled == true);
                    response = new UtilitariesResponse<Nutritionist>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Nutritionist>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Assignment> GetParticipantsForCounselor(int CounselorId)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Assignment> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var participants = context.Assignments.ToList();*/
                    IQueryable<Assignment> query = context.Assignments.Where(x => x.Enabled == true && x.CounselorId == CounselorId) 
                        .Include(x=>x.Participant);
                    response = new UtilitariesResponse<Assignment>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Assignment>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }


        public EResponseBase<Assignment> GetParticipantsForAssignments()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Assignment> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var participants = context.Assignments.ToList();*/
                    IQueryable<Assignment> query = context.Assignments.Where(x => x.Enabled == true && x.Participant != null)
                        .Include(x => x.Participant);
                    response = new UtilitariesResponse<Assignment>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Assignment>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<User> GetByFilters(User request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var users = context.Users.ToList();*/
                    IQueryable<User> query = context.Users
                        /*.Include(x => x.Participant)*/
                        .Where(x => x.Enabled == true);

                    if (!string.IsNullOrEmpty(request.FirstName)) query = query.Where(x => x.FirstName.Contains(request.FirstName));
                    if (!string.IsNullOrEmpty(request.SecondName)) query = query.Where(x => x.SecondName.Contains(request.SecondName));
                    if (!string.IsNullOrEmpty(request.FirstLastName)) query = query.Where(x => x.FirstLastName.Contains(request.FirstLastName));
                    if (!string.IsNullOrEmpty(request.SecondLastName)) query =query.Where(x => x.SecondLastName.Contains(request.SecondLastName));
                    if (!string.IsNullOrEmpty(request.Email)) query = query.Where(x => x.Email.Contains(request.Email));
                    /*if (!string.IsNullOrEmpty(request.WicId)) query = query.Where(x => x.WicId.Contains(request.WicId));*/

                    response = new UtilitariesResponse<User>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Counselor> GetByFiltersCounselors(Counselor request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Counselor> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    IQueryable<Counselor> query = context.Counselors
                        .Where(x => x.Enabled == true);

                    if (!string.IsNullOrEmpty(request.FirstName)) query = query.Where(x => x.FirstName.Contains(request.FirstName));
                    if (!string.IsNullOrEmpty(request.SecondName)) query = query.Where(x => x.SecondName.Contains(request.SecondName));
                    if (!string.IsNullOrEmpty(request.FirstLastName)) query = query.Where(x => x.FirstLastName.Contains(request.FirstLastName));
                    if (!string.IsNullOrEmpty(request.SecondLastName)) query = query.Where(x => x.SecondLastName.Contains(request.SecondLastName));
                    if (!string.IsNullOrEmpty(request.Email)) query = query.Where(x => x.Email.Contains(request.Email));
                    if (!string.IsNullOrEmpty(request.WicId)) query = query.Where(x => x.WicId.Contains(request.WicId));

                    response = new UtilitariesResponse<Counselor>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Counselor>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Participant> GetByFiltersParticipants(Participant request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Participant> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    /*var users = context.Users.ToList();*/
                    IQueryable<Participant> query = context.Participants
                        /*.Include(x => x.Participant)*/
                        .Where(x => x.Enabled == true && x.Discriminator == "Participant");

                    if (!string.IsNullOrEmpty(request.FirstName)) query = query.Where(x => x.FirstName.Contains(request.FirstName));
                    if (!string.IsNullOrEmpty(request.SecondName)) query = query.Where(x => x.SecondName.Contains(request.SecondName));
                    if (!string.IsNullOrEmpty(request.FirstLastName)) query = query.Where(x => x.FirstLastName.Contains(request.FirstLastName));
                    if (!string.IsNullOrEmpty(request.SecondLastName)) query = query.Where(x => x.SecondLastName.Contains(request.SecondLastName));
                    if (!string.IsNullOrEmpty(request.Email)) query = query.Where(x => x.Email.Contains(request.Email));
                    if (!string.IsNullOrEmpty(request.WicId)) query = query.Where(x => x.WicId.Contains(request.WicId));

                    response = new UtilitariesResponse<Participant>(config).setResponseBaseForList(query);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Participant>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<User> RegisterUser(User request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<User> response;
            try
            {

                using (var context = new ClientDbContext())
                {

                    request.CreatedOn = DateTime.Now;
                    request.Enabled = true;
                    context.Users.Add(request);
                    context.SaveChanges();
                    response = new UtilitariesResponse<User>(config).setResponseBaseForOK(request);

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<User>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Participant> RegisterParticipant(Participant request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Participant> response;
            try
            {

                using (var context = new ClientDbContext())
                {

                     request.CreatedOn = DateTime.Now;
                     request.Enabled = true;
                     context.Participants.Add(request);
                     context.SaveChanges();
                     response = new UtilitariesResponse<Participant>(config).setResponseBaseForOK(request);

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Participant>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Counselor> RegisterCounselor(Counselor request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Counselor> response;
            try
            {

                using (var context = new ClientDbContext())
                {

                    request.CreatedOn = DateTime.Now;
                    request.Enabled = true;
                    context.Counselors.Add(request);
                    context.SaveChanges();
                    response = new UtilitariesResponse<Counselor>(config).setResponseBaseForOK(request);

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Counselor>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

        public EResponseBase<Nutritionist> RegisterNutritionist(Nutritionist request)
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Nutritionist> response;
            try
            {

                using (var context = new ClientDbContext())
                {

                    request.CreatedOn = DateTime.Now;
                    request.Enabled = true;
                    context.Nutritionists.Add(request);
                    context.SaveChanges();
                    response = new UtilitariesResponse<Nutritionist>(config).setResponseBaseForOK(request);

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Nutritionist>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }

    }
}
