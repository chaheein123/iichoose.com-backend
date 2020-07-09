using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
// This is a simple web API with no database. Don't really need MVC structure...
namespace ichoose_api
{
  // /api => this route gets the images
  [Route("api")]
  [ApiController]
  public class YelpApiController : ControllerBase
  {
    [HttpPost]
    public  ActionResult SplashAPI(jsonData foodsList)
    {

      Console.WriteLine(foodsList.Foods);
      foreach (var yoyo in foodsList.Foods)
      {
        Console.WriteLine(yoyo);
      }

      return Ok("www");
    }
  }

  public class jsonData
  {
    public List<string> Foods { get; set; }
  }

}
