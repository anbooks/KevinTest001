using KevinTest001.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Controllers
{
    public class EFController:Controller
    {
        private MyDbContext _myDbContext;

        public EFController(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }



        //创建一个委托像一个函数，方法，不过没有具体的
        //delegate
        //o=>o.Name=="张三"  一种委托的写法
        //LINQ 和SQL转换，差不多

        public IActionResult Index()
        {
            // var i = 1;
            var a = new { A = "张三" };   //匿名对象

            ////添加一个对象
            //_myDbContext.Persons.Add(new Person()
            //    {
            //    Name="张三",
            //   Sex="男"
 
            //});

            //_myDbContext.Persons.Add(new Person()
            //{
            //    Name = "张三1",
            //    Sex = "男"

            //});
            ////
            //int i= _myDbContext.SaveChanges();


            //删除
           // _myDbContext.Persons.Remove(_myDbContext.Persons.Find(1));   //找到1的这条


            var item = _myDbContext.Persons.Find(2);
            item.Name = "李四";     //改值
            int j = _myDbContext.SaveChanges();


            //var list= _myDbContext.Persons.ToList();
            var list = _myDbContext.Persons.Where(o=>o.Name=="李四").ToList();   //_myDbContext.Persons.各种where.ToList();
           // var list = _myDbContext.Persons.Where(o => o.Name == "李四").FirstOrDefault();   //第一个 对象
            // return View();
            return Content("a");
        }

    }
}
