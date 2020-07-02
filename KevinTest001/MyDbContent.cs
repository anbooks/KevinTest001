using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001
{
    //数据库上下文
    public class MyDbContent:DbContext
    {
        public MyDbContent(DbContextOptions options) : base(options)
        {

        }
    }
}
