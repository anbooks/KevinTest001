using KevinTest001.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Controllers
{
    public class DIController:Controller
    {

        //public IActionResult Index()
        //{
        //    /*
        //    MyService myService = new MyService();     //这个控制器严重依赖与这个service
        //    OService myService2 = new OService();
        //    myService.getName();
        //    myService2.getName();
        //    */


        //    IService myService = new MyService();
        //    myService.getName();    //z这个写法和上面也没有啥本质区别


        //    return View();
        //}

        private IService _service;

        private MyDbContent _myDbContext;
        //public DIController(IService service)
        public DIController(IService service,MyDbContent myDbContent)
        {
            this._service = service;
            this._myDbContext = myDbContent;
        }

        public IActionResult Index()
        {
            //_service.getName();
            //return View();
            //http://localhost:49609/Di/index
            return Content(_service.getName());
        }



    }
}
