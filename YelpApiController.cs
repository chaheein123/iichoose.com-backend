using System;
using System.Net.Http;
using System.Threading.Tasks;
using ichoose_api.Models;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Hosting;

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

      Console.WriteLine(resultData.latitude);
      Console.WriteLine(resultData.longitude);
      Console.WriteLine(resultData.searchKey);
      var request = new HttpRequestMessage(HttpMethod.Get, "https://api.yelp.com/v3/businesses/search?term=korean&location=milpitas");
      request.Headers.Add("Authorization", "Bearer DqqvJj3BbphPQC61RYWyhK3WbmKfKi-s0sFkT9goODs3_2HYuuvI-_-eZ6PMM-eYcT2hXDCCDOFfivF7UKgfeMESjH6P4iDcGyIxekBwzSB6Aw2rHOs0zbBg4L-iXXYx");
      var client = _clientFactory.CreateClient();
      var response = await client.SendAsync(request);





      //HttpResponseMessage response = await client.SendAsync(request);


      Console.WriteLine(response);









      return Ok("www");
    }
  }



}
