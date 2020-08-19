using System.Threading.Tasks;
using RestSharp;

namespace TravelReviews.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post (string newReview)
    //All post reuqests must have header and body so API can register data types and correctly register an argument for the controller
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put (int id, string newReview) // must have ID here - this makes it different from Post b/c we are modifying a record that already exists
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews/{id}", Method.PUT);
      request.AddHeader("Content-Type", "applictaion/json");
      request.AddJsonBody(newReview);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete (int id)
    //Doesn't need a body - only the id
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"reviews/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "applications/json");
      var response = await client.ExecuteTaskAsync(request);
    }
    
  }
}