using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
    }

    public class UserObject
    {
        public string name;
        public string password;
        public UserObject(string a,string b)
        {
            name = a;password = b;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }

        [HttpPost]
        [EnableCors("LoginCors")]
        public bool GetSomeResult([FromBody]User BodyData)
        {
            var DB = new List<UserObject>()
            {
                new UserObject("vuducvi","123456"),
                new UserObject("phanhuudat","123456"),
                new UserObject("caothai","123456"),
                new UserObject("phanvanquan","123456")
            };
            bool result = DB.Exists(i => i.name == BodyData.name && i.password == BodyData.password);
            return result;
        }
    }
}
