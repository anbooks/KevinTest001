using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Models
{
    public class Person
    {
        public string id { get; set; }

        //[Required]  //#Kevin 这个是说字段必须填写的
        [Required(ErrorMessage = "请输入名称")]  //#Kevin 错误提示
        [StringLength(2, ErrorMessage = "长度超过2位")]  //#校验长度
        //[EmailAddress],时间、正则表达式验证等
        public string name { get; set; }
    }
}
