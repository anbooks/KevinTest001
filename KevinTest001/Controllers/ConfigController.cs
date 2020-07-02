using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace KevinTest001.Controllers
{
    //属于整一个对象
    public class ConfigController : Controller
    {

        private MyOprations myOprations;

        public ConfigController(IOptions<MyOprations> options)
        {
            myOprations = options.Value;
        }



        public IActionResult Index()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            //加载配置文件
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = configurationBuilder.Build();

            string connectString = configuration.GetConnectionString("DefaultConnection");
            // return View();
            //http://localhost:49609/Config/index

            var name = configuration.GetValue<string>("name");
            var name2 = configuration["name"];
            var name3 = configuration["person:age"];

            var name4 = configuration["person1:0:age"];
            var name5 = configuration["person2:0:age:0:abc"];
            //return Content(connectString);
            //return Content(name4);

            return Content(myOprations.name);
        }
       
    }
}
