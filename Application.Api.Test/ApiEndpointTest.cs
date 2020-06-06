using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Api.Test
{
    public class ApiEndpointTest : ApiTestServer
    {
        public async Task GetAllRegion()
        {
            using(var server = CreateServer())
            {
                var client = server.CreateClient();
                var responseMessage = await client.GetAsync("api/regions");
                responseMessage.EnsureSuccessStatusCode();
            }
        }
    }
}
