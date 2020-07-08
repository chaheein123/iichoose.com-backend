using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
// This is a simple web API with no database. I do not really need MVC structure to organize my code.
namespace ichoose_api
{
  // /api => this route gets the images
  [Route("api")]
  [ApiController]
  public class YelpApiController : ControllerBase
  {
    [HttpGet]
    public  ActionResult SplashAPI()
    {

      Console.WriteLine("yoyoyoyo");
      //Console.WriteLine(data);

      return Ok("hi, kjkj");
    }
    


    
  }
}
