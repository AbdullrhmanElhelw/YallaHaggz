namespace YallaHaggz.WebApi.Contracts;

internal static class ApiRoutes
{
    private const string BaseUrl = "api/v1";

    public static class Auth
    {
        public const string Login = BaseUrl + "/auth/login";
        public const string Register = BaseUrl + "/auth/register";
        public const string Refresh = BaseUrl + "/auth/refresh";
        public const string ChangePassword = BaseUrl + "/auth/change-password";
        public const string ResetPassword = BaseUrl + "/auth/reset-password";
        public const string ForgotPassword = BaseUrl + "/auth/forgot-password";
    }

    public static class Governorates
    {
        public const string List = BaseUrl + "/governorates";
    }

    public static class Cities
    {
        public const string List = BaseUrl + "/governorates/{id}/cities";
    }

    public static class Sports
    {
        public const string List = BaseUrl + "/sports";
    }
}