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
    public class ContactTypeController : ControllerBase
    {
        private readonly ContactTypeService service;
        private readonly IConfigurationLib config;
        private ICustomLog logger;
        public RequestUtility RequestUtility { get; set; }
        public RequestHelpers RequestHelpers { get; set; }

        public ContactTypeController()
        {
            logger = DependencyFactory.GetInstance<ICustomLog>();
            config = new ConfigurationLib(ConfigManager.GetConfig());
            service = new ContactTypeService(config, logger);
        }

        [Route("Get")]
        [HttpGet]
        public EResponseBase<ContactTypeResponseV1> Get()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.Get();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<ContactTypeResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<ContactTypeResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }
    }
}
