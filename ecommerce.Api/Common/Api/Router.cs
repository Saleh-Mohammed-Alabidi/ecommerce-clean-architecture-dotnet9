namespace ecommerce.Common.Api;

public static class Router
{
    private const string ApiBase = "v1/api";
    
    public static class Cities
    {
        private const string Base = $"{ApiBase}/cities";
        public const string Create = Base;
        public const string Get = Base;
    }
}