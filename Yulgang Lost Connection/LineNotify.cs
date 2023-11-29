using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yulgang_Lost_Connection
{
    internal class LineNotify
    {
        private string token;
        public LineNotify(string token)
        {
            this.token = token;
        }

        private RestClient client()
        {
            var authenticator = new JwtAuthenticator(this.token);
            var options = new RestClientOptions("https://notify-api.line.me")
            {
                Authenticator = authenticator
            };

            return new RestClient(options);
        }

        public async void test()
        {
            Debug.WriteLine("TEST");

            var request = new RestRequest("/api/notify")
                .AddParameter("message", "ทดสอบการส่งข้อความจาก Yulgang Lost Connect", ParameterType.RequestBody)
                .AddHeader("Content-Type", "multipart/form-data");

            try
            {
                var response = await this.client().PostAsync(request);
                var body = response.Content;
                Debug.WriteLine(body);

            }catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
        }

        public async Task<bool> send(string message ,Image image = null)
        {
            var request = new RestRequest("/api/notify")
                .AddParameter("message", message, ParameterType.RequestBody)
                .AddHeader("Content-Type", "multipart/form-data");

            if(image != null)
            {
                request.AddFile("imageFile", (byte[])new ImageConverter().ConvertTo(image, typeof(byte[])), "image.png", "image/png");
            }

            try
            {
                var response = await this.client().PostAsync(request);
                var body = response.Content;

                if (body.Contains("\"ok\""))
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                return false;
            }

            return false;
        }
    }
}
