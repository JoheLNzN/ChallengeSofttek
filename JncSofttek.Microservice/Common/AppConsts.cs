namespace JncSofttek.Microservice.Common
{
    public static class AppConsts
    {
        public const string CLAIM_USER_EMAIL_ADDRESS = "CLAIMEmailAddress";
        public const string CLAIM_USER_ROLE = "CLAIMRole";

        public const string EXCEPTION_TOKEN_INVALID = "El token de sesión es nulo o vacío.";

        #region "Status Code"

        public const string STATUS_CODE_400_BAD_REQUEST =
           "La solicitud no es válida";
        public const string STATUS_CODE_400_BAD_REQUEST_INCORRECT_CREDENTIALS =
            "Las credenciales de acceso son incorrectas";
        public const string STATUS_CODE_500_INTERNAL_SERVER_ERROR =
            "Lo sentimos, se produjo un error inesperado al realizar la solicitud, por favor inténtelo de nuevo más tarde";

        #endregion

        #region "Validations"

        public const string VALIDATION_ERROR_REQUIRED = "El campo '{0}' es requerido";
        public const string VALIDATION_ERROR_INVALID_EMAIL = "El '{0}' tiene un formato inválido";
        public const string VALIDATION_ERROR_INVALID_LENGTH = "El campo '{0}' tiene una longitud inválida";

        // Custom
        public const string VALIDATION_ERROR_INVALID_RANGE_STOCK =
            "El campo 'Stock' debe comprender entre el rango de 1 a 10";
        public const string VALIDATION_ERROR_INVALID_RANGE_PRICE =
            "El campo 'Price' debe tener un valor mayor a o igual a 1.";

        #endregion
    }
}
