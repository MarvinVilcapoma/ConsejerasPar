using AutoMapper;
using Common;
using Common.AspNetCore;
using Common.Logging;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using Security.API.Helpers;
using Service;
using Service.DependecyInjection;
using System;
using System.Security.Claims;

namespace ConsejerasParesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentService service;
        private readonly IConfigurationLib config;
        private ICustomLog logger;
        public RequestUtility RequestUtility { get; set; }
        public RequestHelpers RequestHelpers { get; set; }

        public AssignmentController()
        {
            logger = DependencyFactory.GetInstance<ICustomLog>();
            config = new ConfigurationLib(ConfigManager.GetConfig());
            service = new AssignmentService(config, logger);
        }

        [Route("Get")]
        [HttpGet]
        public EResponseBase<AssignmentResponseV1> Get()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.Get();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<AssignmentResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<AssignmentResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        public EResponseBase<AssignmentResponseV1> InsertOrUpdate([FromBody] AssignmentRequestV1 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Assignment>(request);
                /*int assignmentID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);*/
                /*requestConvert.AssignmentId = assignmentID;
                if (requestConvert.AssignmentId > 0) requestConvert.AssignmentId = assignmentID;*/
                var responseJSON = service.InsertOrUpdate(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<AssignmentResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<AssignmentResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }
    }
}
