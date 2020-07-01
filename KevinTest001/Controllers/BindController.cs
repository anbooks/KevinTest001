using KevinTest001.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Controllers
{
    /***
     *#Kevin  asp.net 
     * 
     * asp.net mvc
     * asp.net core mvc
     * 绑定模型机制把获取http的请求的参数 （get，post） action的参数对应的参数进行绑定
     * id参数   index(int id)
     * IBindModel原理底层 
     * ModelState  模型绑定状态
     */
    public class BindController:BaseController
    {
        //localhost:60201/bind/index?id=7&name=张三
        //public IActionResult Index(int id,string name)  #Kevin 多个参数的时候传递比较麻烦
        //public IActionResult Index(Person person)   #Kevin 可以按照Person里面的字段比配传递接收
        //public IActionResult Index([FromBody]Person person)   //#kevin指定只能从页面Body传递，不能从Url来
        
        //默认是get方法
        public IActionResult Index()
        {           
           return View();
        }

        //#支持重载
        /*
        [HttpPost]
        public IActionResult Index([FromForm]Person person)   //http://localhost:60154/bind/index
        {
            return View();
        }
        */

        //#支持重载
        /*
        [HttpPost]
        public IActionResult Index(Person person,List<int> ids)     //获取html页面的列表
        {
            return View();
        }
        */
        [HttpPost]
        public IActionResult Index(Person person)     //获取html页面的列表
        {
            /*
             * if (String.IsNullOrEmpty(person.name))
            {
                return Content("请输入名字");
            }
            */
            ModelState.Remove("name"); //#Kevin 这种就可以去除验证了，使不同页面引用同一模型的时候去掉验证
            bool flag = ModelState.IsValid;  //看前台页面满足模型验证否？
            if (ModelState.IsValid)
            {
                return Content("数据验证不通过");
            }

            return View();
        }


    }
}
