using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KevinTest001.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace KevinTest001
{
    public class Startup
    {
        //获取配置文件
        //其中一种写法
        //public Startup( )
        //{
        //    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

        //    //加载配置文件
        //    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

        //     configuration = configurationBuilder.Build();
        //}

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        private IConfiguration configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940





        public void ConfigureServices(IServiceCollection services)
        {
            //#Kevin 添加一些服务 把和MVC相关的服务都添加一下
            services.AddMvc();


            //#Kevin 手动开启过滤器服务,加cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,o=> {
                o.LoginPath = new PathString("/Home/Login");   //跳转到登录页面
            });
            //http://localhost:49609/Home/Login?ReturnUrl=%2Fhome%2Fcenter  就跳到这里了

            services.Configure<MyOprations>(configuration.GetSection("person"));  //把配置文件的内容对象加载过来

            //每个调用创建一个实例
            services.AddTransient<IService, MyService>();//Myservice的对象给Iservice接口使用
                                                         // services.AddTransient<IService, OService>();//这样就能访问李四了

            //一个请求域一个实例
            services.AddScoped<IService, OService>();
            //单例
            services.AddSingleton<IService, OService>();

            //ORM 添加数据库连接操作  ,右键，NUt管理，浏览，efcore，选择版本可能不同  2.2.0本项目安装的
            services.AddDbContextPool<MyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //#Kevin y允许使用静态文件
            // app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() {
                //#Kevin 写个目录  获取当前根目录
                //  FileProvider =new PhysicalFileProvider(Directory.GetCurrentDirectory())   //这样的就所有的根目录下都能访问，这样不太好

                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),  //#Kevin 只能限定在Images文件夹下。
                RequestPath = new PathString("/Images")

            });

            //#Kevin 添加路由，让程序能找到控制器、找到方法、找到   默认路由，什么都不输入的时候找home的index方法
            app.UseMvcWithDefaultRoute();

            //#Kevin  启用用户验证机制
            app.UseAuthentication();
            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
