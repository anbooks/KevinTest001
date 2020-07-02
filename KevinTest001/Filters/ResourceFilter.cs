using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KevinTest001.Filters
{
    public class ResourceFilter:Attribute,IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //测试别的时候这个地方注释一下，要不就短路了

            /*
             * string  token = context.HttpContext.User.FindFirstValue(ClaimTypes.Sid);  //#kevin 这里没有值
           
            context.Result =new ContentResult() {Content="结束执行"};
            */
        }

    }
}
