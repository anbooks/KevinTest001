using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Services
{
    //public class MyService

        /// <summary>
        ///使用类的时候可以通过接口取调用
        /// </summary>
    public class MyService: IService
    {
        public string getName()
        {
            return "张三";
        }
    }


    //public class OService
    public class OService:IService
    {
        public string getName()
        {
            return "李四";
        }
    }

    public interface IService
    {
        string getName();
    }


}
