using AutoMapper;
using Common;
using Common.AspNetCore;
using Common.Logging;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Request;
using Model.Response;
using Service;
using Service.DependecyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConsejerasParesAPI.Config;

namespace ConsejerasParesAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserService service;
        private readonly IConfigurationLib config;
        private ICustomLog logger;
        private readonly IConfiguration _configuration;
        private readonly AuthConfig _auth;

        public AuthController(IConfiguration configuration, AuthConfig auth)
        {
            _configuration = configuration;
            _auth = auth;
            logger = DependencyFactory.GetInstance<ICustomLog>();
            config = new ConfigurationLib(ConfigManager.GetConfig());
            service = new UserService(config, logger);
        }

        [HttpPost("Login")]
        public EResponseBase<AuthResponseV1> LoginAsync([FromBody] UserRequestV1 request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                EResponseBase<AuthResponseV1> responseJSON = new EResponseBase<AuthResponseV1>();
                responseJSON.Code = 0;

                var requestConvert = Mapper.Map<User>(request);

                EResponseBase<User> eResponse = service.Login(requestConvert);

                if (eResponse.Code == 0)
                {
                    responseJSON.objeto = GetToken(eResponse.objeto);
                }
                else
                {
                    responseJSON.Code = eResponse.Code;
                    responseJSON.Message = eResponse.Message;
                    responseJSON.MessageEN = eResponse.MessageEN;
                }

                logger.Print_Response(responseJSON);
                return responseJSON;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new UtilitariesResponse<AuthResponseV1>(config).setResponseBaseForException(ex);
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }

        private AuthResponseV1 GetToken(User request)
        {
            logger.Print_InitMethod();
            try
            {
                logger.Print_Request(request);
                AuthResponseV1 responseJSON = new AuthResponseV1();
                var key = Encoding.ASCII.GetBytes(_auth.SecretKey);

                // Creamos los claims (pertenencias, características) del usuario
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, request.UserID.ToString()),
                    new Claim("id",request.UserID.ToString()),
                    //new Claim(ClaimTypes.Email, string.IsNullOrEmpty(request.Email)? "" : request.Email),
                    new Claim("username", request.UserName),
                    new Claim("name", string.IsNullOrEmpty(request.FirstName)? "" : request.FirstName),
                    new Claim("fullname",$"{request.FirstName} {request.SecondName} {request.FirstLastName} {request.SecondLastName}".Replace("  "," ")),
                    //new Claim("firstLastName", string.IsNullOrEmpty(request.FirstLastName)? "": request.FirstLastName ),
                    //new Claim("secondLastName", string.IsNullOrEmpty(request.SecondLastName)? "" : request.SecondLastName),
                    //new Claim("roleID", request.RoleID.ToString()),
                    //new Claim("regionID", request.RegionID == null ? "": request.RegionID.ToString()),
                    //new Claim("clinicID", request.ClinicID == null ? "": request.ClinicID.ToString()),
                    //new Claim(ClaimTypes.Role,string.IsNullOrEmpty(request.Role.RoleName)? "" : request.Role.RoleName)
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(8),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                responseJSON.AccessToken = tokenHandler.WriteToken(createdToken);
                responseJSON.TokenType = "Bearer";

                logger.Print_Response(responseJSON);
                return responseJSON;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw ex;
            }
            finally
            {
                logger.Print_EndMethod();
            }
        }
    }
}
