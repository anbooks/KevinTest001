using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Filters
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        //重写一下，把错误信息记录下来
        public override void OnException(ExceptionContext context)
        {
            //这里可以写异常处理
            context.Result = new ContentResult() { Content = "系统发生错误" };
        }
       
    }
}
