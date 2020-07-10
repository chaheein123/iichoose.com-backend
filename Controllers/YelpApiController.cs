using System;
using ichoose_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ichoose_api
{
  // /api => this route gets the images
  [Route("api")]
  [ApiController]
  public class YelpApiController : ControllerBase
  {
    [HttpPost]
    public  ActionResult SplashAPI([FromBody]FoodsData FoodsList)
    {

      foreach (var yoyo in FoodsList.Foods)
      {
        Console.WriteLine(yoyo);
      }
      return Ok("www");
    }
  }



}
