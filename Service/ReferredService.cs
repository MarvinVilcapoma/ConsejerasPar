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
    public class ReferredService
    {
        public ICustomLog Logger { get; set; }
        private readonly IConfigurationLib config;
        public ITransaction Transaction { get; set; }

        public ReferredService(IConfigurationLib _config, ICustomLog _customLog)
        {
            config = _config;
            Logger = _customLog;
        }

        public EResponseBase<Referred> Get()
        {
            Logger.InitializeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, Transaction);
            EResponseBase<Referred> response;
            try
            {
                using (var context = new ClientDbContext())
                {
                    var assignment = context.Referreds
                        .Include(i => i.Nutritionist)
                        .Include(i => i.Assignment)
                        .Include(i => i.Assignment.Participant)
                        .Include(i => i.Assignment.Counselor).ToList();
                    /*IQueryable<User> query = context.Users.Where(x => x.Enabled == true);*/
                    response = new UtilitariesResponse<Referred>(config).setResponseBaseForList(assignment);
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Referred>(config).setResponseBaseForException(e);
                Logger.Error(e.Message);
            }

            return response;
        }
    }
}
