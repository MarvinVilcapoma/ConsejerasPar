using AutoMapper;
using Common;
using Common.AspNetCore;
using Common.Logging;
using Microsoft.AspNetCore.Mvc;
using Model.Response;
using Security.API.Helpers;
using Service;
using Service.DependecyInjection;
using System;

namespace ConsejerasParesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferredController : ControllerBase
    {
        private readonly ReferredService service;
        private readonly IConfigurationLib config;
        private ICustomLog logger;
        public RequestUtility RequestUtility { get; set; }
        public RequestHelpers RequestHelpers { get; set; }

        public ReferredController()
        {
            logger = DependencyFactory.GetInstance<ICustomLog>();
            config = new ConfigurationLib(ConfigManager.GetConfig());
            service = new ReferredService(config, logger);
        }

        [Route("Get")]
        [HttpGet]
        public EResponseBase<ReferredResponseV1> Get()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.Get();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<ReferredResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<ReferredResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }
    }
}
