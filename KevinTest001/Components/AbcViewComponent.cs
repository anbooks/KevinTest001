using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Components
{
    /// <summary>
    /// #Kevin 请谅解的控制器，
    /// </summary>
    public class AbcViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //return View();
            //#Kevin 数据库 之类的操作 业务逻辑之类的
            return View(10);
        }
    }
}
