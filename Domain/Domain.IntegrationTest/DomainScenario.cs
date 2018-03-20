using Domain.API.Model;
using Domain.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.IntegrationTest
{
    public class DomainScenario : DomainBase
    {
        [Fact]
        public async Task Post_OTBRE_property_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildOTBRE(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                                   .PostAsync(Post.Domain, content);

                response.EnsureSuccessStatusCode();
            }
        }
        [Fact]
        public async Task Post_property_null_and_response_400_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(JsonConvert.SerializeObject(null), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                                   .PostAsync(Post.Domain, content);

                Assert.True(HttpStatusCode.BadRequest == response.StatusCode);
            }
        }

        [Fact]
        public async Task Post_property_and_response_400_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildNull(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                                   .PostAsync(Post.Domain, content);

                Assert.True(HttpStatusCode.BadRequest == response.StatusCode);
            }
        }


        [Fact]
        public async Task Post_LRE_property_and_response_OK_status_code()
        {
            using (var server = CreateServer())
            {
                var content = new StringContent(BuildLRE(), UTF8Encoding.UTF8, "application/json");
                var response = await server.CreateClient()
                                   .PostAsync(Post.Domain, content);

                response.EnsureSuccessStatusCode();
            }
        }



        string BuildOTBRE()
        {
            var comparer = new PropertyComparerDTO()
            {
                DatabaseProperty = new PropertyDTO()
                {
                    Name = "Super High Apartments, Sydney",
                    Address = "32 Sir John Young Crescent, Sydney NSW"
                },

                AgencyProperty = new PropertyDTO()
                {
                    Name = "*Super*-High! APARTMENTS (Sydney)",
                    Address = "32 Sir John-Young Crescent, Sydney, NSW."
                },
                Provider = "OTBRE"

            };
            return JsonConvert.SerializeObject(comparer);
        }

        string BuildNull()
        {
            var comparer = new PropertyComparerDTO()
            {
                

            };
            return JsonConvert.SerializeObject(comparer);
        }
        string BuildLRE()
        {
            var comparer = new PropertyComparerDTO()
            {
                DatabaseProperty = new PropertyDTO()
                {
                    AgencyCode = "21212er222",
                    Latitude = -33.9014586,
                    Longitude = 151.206287
                },

                AgencyProperty = new PropertyDTO()
                {
                    AgencyCode = "21212er222",
                    Latitude = -33.901191,
                    Longitude = 151.207628
                },
                Provider = "LRE"

            };
            return JsonConvert.SerializeObject(comparer);
        }
        string BuildCRE()
        {
            var comparer = new PropertyComparerDTO()
            {
                DatabaseProperty = new PropertyDTO()
                {
                    Name = "The Summit Apartments"
                },

                AgencyProperty = new PropertyDTO()
                {
                    Name = "Apartments Summit The"
                },
                Provider = "CRE"

            };
            return JsonConvert.SerializeObject(comparer);
        }
    }
}
