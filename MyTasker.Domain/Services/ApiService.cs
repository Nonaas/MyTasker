namespace MyTasker.Domain.Services
{
    public class ApiService
    {
        public string ApiKey { private get; set; }
        public PodcastAPI.Client Client { private get; set; }


        public ApiService(string key)
        {
            ApiKey = key;

            try
            {
                Client = new PodcastAPI.Client(ApiKey);

                var parameters = new Dictionary<string, string>();
                parameters.Add("q", "startup");
                parameters.Add("type", "podcast");

                var result = Client.Search(parameters).Result;
                var jsonObject = result.ToJSON<dynamic>();
                Console.WriteLine($"Json Object: {jsonObject}");

                var freeQuota = result.GetFreeQuota();
                Console.WriteLine($"Free Quota: {freeQuota}");

                var usage = result.GetUsage();
                Console.WriteLine($"Usage: {usage}");

                var nextBillingDate = result.GetNextBillingDate();
                Console.WriteLine($"Next Billing Date: {nextBillingDate}");
            }
            catch (PodcastAPI.Exceptions.AuthenticationException ex)
            {
                Console.WriteLine($"Authentication Issue: {ex.Message}");
            }
            catch (PodcastAPI.Exceptions.InvalidRequestException ex)
            {
                Console.WriteLine($"Invalid Request: {ex.Message}");
            }
            catch (PodcastAPI.Exceptions.RateLimitException ex)
            {
                Console.WriteLine($"Rate Limit: {ex.Message}");
            }
            catch (PodcastAPI.Exceptions.NotFoundException ex)
            {
                Console.WriteLine($"Not Found: {ex.Message}");
            }
            catch (PodcastAPI.Exceptions.ListenApiException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Application Exception: {ex}");
            }
        }

        public async Task<string> SearchPodcast(string searchQuery)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("q", searchQuery);
            parameters.Add("type", "podcast");

            var result = await Client.Search(parameters);

            var jsonObject = result.ToJSON<dynamic>();

            Console.WriteLine($"Json Object: {jsonObject}");

            return jsonObject;
        }
    }
}
