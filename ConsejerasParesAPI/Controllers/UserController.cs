using AutoMapper;
using Common;
using Common.AspNetCore;
using Common.Logging;
using Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Request;
using Model.Response;
using Security.API.Helpers;
using Service;
using Service.DependecyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsejerasParesAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "SecurityKey")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService service;
        private readonly IConfigurationLib config;
        private ICustomLog logger;
        public RequestUtility RequestUtility { get; set; }
        public RequestHelpers RequestHelpers { get; set; }

        public UserController()
        {
            logger = DependencyFactory.GetInstance<ICustomLog>();
            config = new ConfigurationLib(ConfigManager.GetConfig());
            service = new UserService(config, logger);
        }

        [Route("Get")]
        [HttpGet]
        public EResponseBase<UserResponseV1> Get()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.Get();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("GetCounselors")]
        [HttpGet]
        public EResponseBase<UserResponseV1> GetCounselors()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.GetCounselors();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("GetParticipants")]
        [HttpGet]
        public EResponseBase<UserResponseV1> GetParticipants()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.GetParticipants();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("GetNutritionists")]
        [HttpGet]
        public EResponseBase<UserResponseV1> GetNutritionists()
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(null);
                var responseJSON = service.GetNutritionists();
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("GetParticipantsForCounselor/{id}")]
        [HttpGet]
        public EResponseBase<AssignmentResponseV1> GetParticipantsForCounselor(int Id)
        {
            logger.Print_InitMethod();
            try
            {
                //string CurrentCounselorId = User.FindFirst("id")?.Value;
                //var responseJSON = service.GetParticipantsForCounselor(int.Parse(CurrentCounselorId));
                var responseJSON = service.GetParticipantsForCounselor(Id);
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


        [Route("GetParticipantsForAssignments")]
        [HttpGet]
        public EResponseBase<AssignmentResponseV1> GetParticipantsForAssignments()
        {
            logger.Print_InitMethod();
            try
            {
                //string CurrentCounselorId = User.FindFirst("id")?.Value;
                var responseJSON = service.GetParticipantsForAssignments();
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




        [Route("GetByFilters")]
        [HttpPost]
        public EResponseBase<UserResponseV2> GetByFilters([FromBody] UserRequestV2 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<User>(request);
                var responseJSON = service.GetByFilters(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV2>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV2>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }


        [Route("GetByFiltersCounselors")]
        [HttpPost]
        public EResponseBase<CounselorResponseV2> GetByFiltersCounselors([FromBody] CounselorRequestV2 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Counselor>(request);
                var responseJSON = service.GetByFiltersCounselors(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<CounselorResponseV2>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<CounselorResponseV2>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("GetByFiltersParticipants")]
        [HttpPost]
        public EResponseBase<UserResponseV2> GetByFiltersParticipants([FromBody] UserRequestV2 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Participant>(request);
                var responseJSON = service.GetByFiltersParticipants(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV2>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV2>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("RegisterUser")]
        [HttpPost]
        public EResponseBase<UserResponseV3> RegisterUser([FromBody] UserRequestV3 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<User>(request);
                var responseJSON = service.RegisterUser(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<UserResponseV3>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<UserResponseV3>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        [Route("RegisterParticipant")]
        [HttpPost]
        public EResponseBase<ParticipantResponseV1> RegisterParticipant([FromBody] ParticipantRequestV1 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Participant>(request);
                var responseJSON = service.RegisterParticipant(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<ParticipantResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<ParticipantResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        

        [Route("RegisterCounselor")]
        [HttpPost]
        public EResponseBase<CounselorResponseV1> RegisterCounselor([FromBody] CounselorRequestV1 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Counselor>(request);
                var responseJSON = service.RegisterCounselor(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<CounselorResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<CounselorResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }


        [Route("RegisterNutritionist")]
        [HttpPost]
        public EResponseBase<NutritionistResponseV1> RegisterNutritionist([FromBody] NutritionistRequestV1 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                var requestConvert = Mapper.Map<Nutritionist>(request);
                var responseJSON = service.RegisterNutritionist(requestConvert);
                logger.Print_Response(responseJSON);
                var response = Mapper.Map<EResponseBase<NutritionistResponseV1>>(responseJSON);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<NutritionistResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }



    }
}
