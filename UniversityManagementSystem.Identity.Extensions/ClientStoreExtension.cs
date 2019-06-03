using System.Threading.Tasks;
using IdentityServer4.Stores;

namespace UniversityManagementSystem.Identity.Extensions
{
    public static class ClientStoreExtension
    {
        public static async Task<bool> IsPkceClientAsync(this IClientStore store, string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId)) return false;

            var client = await store.FindEnabledClientByIdAsync(clientId);
            return client?.RequirePkce == true;
        }
    }
}