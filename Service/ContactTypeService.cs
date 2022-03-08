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
    public class ContactTypeService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public ContactTypeService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<ContactType> Get()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<ContactType> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    var assignment = context.ContactTypes.Where(x => x.Enabled == true).ToList();
                    /*IQueryable<User> query = context.Users.Where(x => x.Enabled == true);*/
                    response = new UtilitariesResponse<ContactType>(config).setResponseBaseForList(assignment);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<ContactType>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }
    }
}
