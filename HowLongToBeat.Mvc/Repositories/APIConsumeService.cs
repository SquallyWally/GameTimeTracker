namespace HowLongToBeat.Mvc.Repositories
{
    public class ApiConsumeService
    {
        public HttpClient Client { get; set; }

        public ApiConsumeService()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5002/");
        }

        public HttpResponseMessage GetAllResponses(string url)
        {
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: url);
            return Client.SendAsync(request).Result;
        }

        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }

        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
    }
}