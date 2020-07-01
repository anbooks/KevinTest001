using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KevinTest001.Models;
using Microsoft.AspNetCore.Mvc;   //#Kevin 后来自己添加的

namespace KevinTest001.Controllers
{
    //public class HomeController:Controller   //#Kevin  F12 能点进去的
    public class HomeController: BaseController  //#Kevin 也可以集成一个其他的一个控制类
    {
        //#Kevin 建立一个方法 ,返回视图
        public IActionResult Index()
        {
            // return Content("您好！");
            //------------------------------------
            //#Kevin 先找/Views/Home/Index.cshtml
            //#Kevin 再找/Views/Shared/Index.cshtml
            //#Kevin  /Pages/Shared/Index.cshtml
            //return View();
            //----------------------------------
            //#Kevin 业务逻辑1
            //int d = 1 + 1;
            // return View(d);
            //----------------------------------
            //#Kevin 业务逻辑1  这个地方得自动修补一下引入using KevinTest001.Models;
            UserModel user = new UserModel() { Name="Kevin"};
            ViewBag.sex = "男";   //#Kevin 也能用这种方式传    ViewBag 接收任意字段
            return View(user);

        }

        //#Kevin 测试/home/print 路径输出的东西
        public IActionResult Print()
        {
            return Content("打印东西");
            // return View();
        }
    }
}
