namespace AzureML.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    public class RecommendationController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Recommendation
        public async Task<ActionResult> Get( string id )
        {
            if( string.IsNullOrWhiteSpace( id ) )
            {
                return this.RedirectToAction( "Index" );
            }

            var result = await InvokeRecommenderService( id );
            return this.View( result );
        }

        private static async Task<List<List<string>>> InvokeRecommenderService(
            string userId)
        {
            using (var client = new HttpClient())
            {
                var scoreData = new ScoreData
                                    {
                                        FeatureVector = new Dictionary<string, string> {{ "userID", userId }},
                                        GlobalParameters =
                                            new Dictionary<string, string>
                                                {
                                                    {
                                                        "Maximum number of items to recommend to a user",
                                                        "5"
                                                    },
                                                }
                                    };

                var scoreRequest = new ScoreRequest { Id = "score00001", Instance = scoreData };

                #region API KEY
                const string apiKey = "NotARealKey"; // Replace this with the API key for the web service
                #endregion

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress =
                    new Uri(
                        "https://ussouthcentral.services.azureml.net/workspaces/b283a38bc4d94a5ca304b8827468734e/services/f1ff9c78f28e43e7930dc39fc7bce318/scoremultirow");
                var response = await client.PostAsJsonAsync(string.Empty, scoreRequest);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<List<string>>>(result);
                }
                
                throw new InvalidOperationException();
            }
        }
    }

    public class ScoreRequest
    {
        public string Id { get; set; }

        public ScoreData Instance { get; set; }
    }

    public class ScoreData
    {
        public Dictionary<string, string> FeatureVector { get; set; }

        public Dictionary<string, string> GlobalParameters { get; set; }
    }
}