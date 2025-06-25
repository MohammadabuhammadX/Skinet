using System.Security.Claims;
namespace API.Extensions
{
    public static class ClaimsPrinciplExtensions
    {
        public static string RetrieveEmailFormPrincipal(this ClaimsPrincipal user)
        {
            return user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        }
    }
}
