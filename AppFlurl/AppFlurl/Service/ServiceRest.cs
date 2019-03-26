using AppFlurl.Models;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFlurl.Service
{
    public class ServiceRest
    {
        internal const string BASE_URL = "http://jsonplaceholder.typicode.com/";

        public static async Task<List<User>> ObterUsuarios()
        {
            var res = await BASE_URL
                .AppendPathSegment("users")
                .GetJsonAsync<List<User>>();

            return res;
        }

        public static async Task<Post> ObterPost(string postId)
        {
            var res = await BASE_URL
                .AppendPathSegment($"posts/{postId}")
                .GetJsonAsync<Post>();

            return res;
        }
    }
}
