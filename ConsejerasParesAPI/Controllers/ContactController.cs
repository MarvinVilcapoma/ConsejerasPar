using AutoMapper;
using Common;
using Common.AspNetCore;
using Common.Logging;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using Security.API.Helpers;
using Service;
using Service.DependecyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConsejerasParesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService service;
        private readonly IConfigurationLib config;
        private ICustomLog logger;
        public RequestUtility RequestUtility { get; set; }
        public RequestHelpers RequestHelpers { get; set; }

        public ContactController()
        {
            logger = DependencyFactory.GetInstance<ICustomLog>();
            config = new ConfigurationLib(ConfigManager.GetConfig());
            service = new ContactService(config, logger);
        }

        [Route("Get")]
        [HttpGet]
        public EResponseBase<ContactResponseV1> Get()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.Get();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<ContactResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<ContactResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        public EResponseBase<ContactResponseV1> InsertOrUpdate([FromBody] ContactRequestV1 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Contact>(request);
                /*int contactID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                requestConvert.ContactId = contactID;
                if (requestConvert.ContactId > 0) requestConvert.ContactId = contactID;*/
                var responseJSON = service.InsertOrUpdate(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<ContactResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<ContactResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("GetByFilters")]
        [HttpPost]
        public EResponseBase<ContactResponseV1> GetByFilters([FromBody] ContactRequestV2 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Contact>(request);
                var responseJSON = service.GetByFilters(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<ContactResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<ContactResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

    }
}
