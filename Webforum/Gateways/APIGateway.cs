using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webforum.Areas.Identity.Data.Entites;

namespace Webforum.Gateways
{
    public class APIGateway
    {
        public async Task<List<Posts>> GetPostsAPI(string ThreadID)
        {
            var URI = "https://localhost:44395/api/FetchConvo";
            var Posts = new List<Posts>();

            var postValues = new Dictionary<string, string>
            {
                { "threadID", ThreadID }
            };

            var json = JsonConvert.SerializeObject(postValues, Formatting.Indented);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            
                using(HttpResponseMessage HttpRespone = await client.PostAsync(URI, stringContent))
                {
                if (HttpRespone.IsSuccessStatusCode)
                {
                    Posts = await HttpRespone.Content.ReadFromJsonAsync<List<Posts>>();
                }
               
                }
            
             return Posts;
        }
    }
}
