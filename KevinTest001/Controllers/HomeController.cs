using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KevinTest001.Filters;
using KevinTest001.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;   //#Kevin 后来自己添加的

namespace KevinTest001.Controllers
{
    //public class HomeController:Controller   //#Kevin  F12 能点进去的
    public class HomeController : BaseController  //#Kevin 也可以集成一个其他的一个控制类
    {

        //#Kevin 添加短路
        [ResourceFilter]



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

        public IActionResult Login() {
            return Content("Login");      
        }

        public IActionResult DoLogin()
        {
            /*
             * 登录后获得token，这个是一把登录的钥匙，
             * 获取传递的token，用户信息
             * 
             */
            string token = "123456";
            string name = "张三";
            ClaimsIdentity identity = new ClaimsIdentity("Forms");

            identity.AddClaim(new Claim(ClaimTypes.Sid,token));
            identity.AddClaim(new Claim(ClaimTypes.Name,name));

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity); //加密
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal);  //默认的一个cookie的名字，登录后就会保存了


            return Content("登录成功");
        }

        //#Kevin 个人中心
        //[Authorize] //默认不启动，还是要在startup中添加
        [Authorize(AuthenticationSchemes=CookieAuthenticationDefaults.AuthenticationScheme)]  //这样就可以登录后，来到这个页面了
        public IActionResult Center()
        {
            //获取token的值
           string token = User.FindFirstValue(ClaimTypes.Sid);
            //
            return Content("Center");
        }
    }
}
