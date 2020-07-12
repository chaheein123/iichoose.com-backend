using System;
using System.Net.Http;
using System.Threading.Tasks;
using ichoose_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ichoose_api
{
  // /api => this route gets the images
  [Route("api")]
  [ApiController]
  public class YelpApiController : ControllerBase
  {
    private readonly IHttpClientFactory _clientFactory;

    public YelpApiController(IHttpClientFactory clientFactory)
    {
      _clientFactory = clientFactory;
    }

    [HttpPost]
    public async Task<ActionResult> YelpApiAsync([FromBody] ResultData resultData)
    {
      YelpResponse yelpResponse;

      var request = new HttpRequestMessage(
        HttpMethod.Get,
        $"?term={resultData.searchKey}&latitude={resultData.latitude}&longitude={resultData.longitude}"
      );
      var client = _clientFactory.CreateClient("yelp");
      var response = await client.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        yelpResponse = await response.Content.ReadAsAsync<YelpResponse>();
        //Console.WriteLine(yelpResponse.name, " ha");
        Console.WriteLine(yelpResponse.businesses.Count + " yoyoyo");
        return Ok(yelpResponse.businesses);
      }
      return Ok("www");
    }
  }
}
