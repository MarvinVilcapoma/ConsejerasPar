using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ConfigurationLib : IConfigurationLib
    {
        public IConfiguration Configuration { get; set; }



        public ConfigurationLib(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }


        public int CodigoExito => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoExito"]);
        public string MensajeExitoES => Configuration.GetSection("AppConfiguration")["MensajeExitoES"];
        public string MensajeExitoEN => Configuration.GetSection("AppConfiguration")["MensajeExitoEN"];

        public int CodigoErrorNoDataFound => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorNoDataFound"]);
        public string NoDataFoundES => Configuration.GetSection("AppConfiguration")["NoDataFoundES"];
        public string NoDataFoundEN => Configuration.GetSection("AppConfiguration")["NoDataFoundEN"];

        public int CodigoParametrosNoValido => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoParametrosNoValido"]);
        public string MensajeParametrosNoValidoEN => Configuration.GetSection("AppConfiguration")["MensajeParametrosNoValidoEN"];
        public string MensajeParametrosNoValidoES => Configuration.GetSection("AppConfiguration")["MensajeParametrosNoValidoES"];

        public int CodigoGastoRepetido => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoGastoRepetido"]);
        public string MensajeGastoRepetidoEN => Configuration.GetSection("AppConfiguration")["MensajeGastoRepetidoEN"];
        public string MensajeGastoRepetidoES => Configuration.GetSection("AppConfiguration")["MensajeGastoRepetidoES"];

        public int CodigoErrorBD => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorBD"]);
        public string MensajeErrorBDEN => Configuration.GetSection("AppConfiguration")["MensajeErrorBDEN"];
        public string MensajeErrorBDES => Configuration.GetSection("AppConfiguration")["MensajeErrorBDES"];


        public int CodigoErrorTimeOut => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorTimeOut"]);
        public string MensajeErrorTimeOutEN => Configuration.GetSection("AppConfiguration")["MensajeErrorTimeOutEN"];
        public string MensajeErrorTimeOutES => Configuration.GetSection("AppConfiguration")["MensajeErrorTimeOutES"];

        public int CodigoErrorNoEspecificado => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorNoEspecificado"]);
        public string MensajeErrorNoEspecificadoEN => Configuration.GetSection("AppConfiguration")["MensajeErrorNoEspecificadoEN"];
        public string MensajeErrorNoEspecificadoES => Configuration.GetSection("AppConfiguration")["MensajeErrorNoEspecificadoES"];

        public int CodigoErrorNoFound => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorNoFound"]);
        public string MensajeErrorNoFoundEN => Configuration.GetSection("AppConfiguration")["MensajeErrorNoFoundEN"];
        public string MensajeErrorNoFoundES => Configuration.GetSection("AppConfiguration")["MensajeErrorNoFoundES"];

        public int CodigoErrorNoAuthorized => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorNoAuthorized"]);
        public string MensajeErrorNoAuthorizedEN => Configuration.GetSection("AppConfiguration")["MensajeErrorNoAuthorizedEN"];
        public string MensajeErrorNoAuthorizedES => Configuration.GetSection("AppConfiguration")["MensajeErrorNoAuthorizedES"];



        public int SecondsTimeOutBD => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["SecondsTimeOutBD"]);
        public int SecondsTimeOutWS => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["SecondsTimeOutWS"]);
        public bool LogSQLQueries => Convert.ToBoolean(Configuration.GetSection("AppConfiguration")["LogSQLQueries"]);


        public int CodigoLogin => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoLogin"]);
        public string MensajeLoginES => Configuration.GetSection("AppConfiguration")["MensajeLoginES"];

        public int CodigoExisteUsuario => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoExisteUsuario"]);
        public string MensajeExisteUsuarioES => Configuration.GetSection("AppConfiguration")["MensajeExisteUsuarioES"];


        public string LDAP => Configuration.GetSection("ActiveDirectory")["LDAP"];
        public string Domain => Configuration.GetSection("ActiveDirectory")["Domain"];

        public string myconn => Configuration.GetSection("ConnectionStrings")["myconn"];
        public string userNameWicService => Configuration.GetSection("WicApiServices")["userNameWicService"];
        public string passwordWicService => Configuration.GetSection("WicApiServices")["passwordWicService"];
        public string urlBase => Configuration.GetSection("WicApiServices")["urlBase"];
        public string urlServer => Configuration.GetSection("WicApiServices")["urlServer"];
        public string Prefix => Configuration.GetSection("WicApiServices")["Prefix"];
        public string TokenType => Configuration.GetSection("WicApiServices")["TokenType"];
        public string TokenController => Configuration.GetSection("WicApiServices")["TokenController"];
        public string StatusController => Configuration.GetSection("WicApiServices")["StatusController"];
        public string DetailsController => Configuration.GetSection("WicApiServices")["DetailsController"];

        public int CodigoDataExists => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoDataExists"]);
        public string MensajeDataExistsEN => Configuration.GetSection("AppConfiguration")["MensajeDataExistsEN"];
        public string MensajeDataExistsES => Configuration.GetSection("AppConfiguration")["MensajeDataExistsES"];


        public int CodigoMissingParameters => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoMissingParameters"]);
        public string MensajeMissingParametersEN => Configuration.GetSection("AppConfiguration")["MensajeMissingParametersEN"];
        public string MensajeMissingParametersES => Configuration.GetSection("AppConfiguration")["MensajeMissingParametersES"];

        public string MessageUserRegisterES => Configuration.GetSection("EmailConfiguration")["MessageUserRegisterES"];
        public string MessageUserRegisterEN => Configuration.GetSection("EmailConfiguration")["MessageUserRegisterEN"];
        public string MessageUserBlockedES => Configuration.GetSection("EmailConfiguration")["MessageUserBlockedES"];
        public string MessageUserBlockedEN => Configuration.GetSection("EmailConfiguration")["MessageUserBlockedEN"];

        public int CodigoBadCredentials => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoBadCredentials"]);
        public string MensajeBadCredentialsES => Configuration.GetSection("AppConfiguration")["MensajeBadCredentialsES"];
        public string MensajeBadCredentialsEN => Configuration.GetSection("AppConfiguration")["MensajeBadCredentialsEN"];

        public int CodigoAccountSuspended => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoAccountSuspended"]);
        public string MensajeAccountSuspendedES => Configuration.GetSection("AppConfiguration")["MensajeAccountSuspendedES"];
        public string MensajeAccountSuspendedEN => Configuration.GetSection("AppConfiguration")["MensajeAccountSuspendedEN"];

        public string FilePath => Configuration.GetSection("FileUrls")["FilePath"];


        //Word
        public string WordPathES => Configuration.GetSection("WordConfiguration")["WordPathES"];
        public string WordPathEN => Configuration.GetSection("WordConfiguration")["WordPathEN"];


        public int CodigoUserNoExist => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoUserNoExist"]);
        public string MensajeUserNoExistEN => Configuration.GetSection("AppConfiguration")["MensajeUserNoExistEN"];
        public string MensajeUserNoExistES => Configuration.GetSection("AppConfiguration")["MensajeUserNoExistES"];


        public int CodigoUserExist => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoUserExist"]);
        public string MensajeUserExistEN => Configuration.GetSection("AppConfiguration")["MensajeUserExistEN"];
        public string MensajeUserExistES => Configuration.GetSection("AppConfiguration")["MensajeUserExistES"];

        public int CodigoPasswordNoCoincide => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoPasswordNoCoincide"]);
        public string MensajePasswordNoCoincideES => Configuration.GetSection("AppConfiguration")["MensajePasswordNoCoincideES"];
        public string MensajePasswordNoCoincideEN => Configuration.GetSection("AppConfiguration")["MensajePasswordNoCoincideEN"];

        public int CodigoRoleRegionObligatory => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoRoleRegionObligatory"]);
        public string MensajeRoleRegionObligatoryES => Configuration.GetSection("AppConfiguration")["MensajeRoleRegionObligatoryES"];
        public string MensajeRoleRegionObligatoryEN => Configuration.GetSection("AppConfiguration")["MensajeRoleRegionObligatoryEN"];

        public int CodigoRoleClinicaObligatory => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoRoleClinicaObligatory"]);
        public string MensajeRoleClinicaObligatoryES => Configuration.GetSection("AppConfiguration")["MensajeRoleClinicaObligatoryES"];
        public string MensajeRoleClinicaObligatoryEN => Configuration.GetSection("AppConfiguration")["MensajeRoleClinicaObligatoryEN"];


        public int CodigoExistsComment => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoExistsComment"]);
        public string MensajeExistsCommentES => Configuration.GetSection("AppConfiguration")["MensajeExistsCommentES"];

        public string MensajeExistsCommentEN => Configuration.GetSection("AppConfiguration")["MensajeExistsCommentEN"];

        public int CodigoErrorInsertComment => Convert.ToInt16(Configuration.GetSection("AppConfiguration")["CodigoErrorInsertComment"]);
        public string MensajeErrorInsertCommentES => Configuration.GetSection("AppConfiguration")["MensajeErrorInsertCommentES"];

        public string MensajeErrorInsertCommentEN => Configuration.GetSection("AppConfiguration")["MensajeErrorInsertCommentEN"];


    }
}
