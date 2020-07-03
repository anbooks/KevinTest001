using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Models
{
    [Table("test_Person")]
    public class Person
    {
        //和数据库有关的
       /* public string id { get; set; }

        //[Required]  //#Kevin 这个是说字段必须填写的
        [Required(ErrorMessage = "请输入名称")]  //#Kevin 错误提示
        [StringLength(2, ErrorMessage = "长度超过2位")]  //#校验长度
        //[EmailAddress],时间、正则表达式验证等
        public string name { get; set; }
    */  //----------------------------------------------------------------
        public int Id { get; set; }
        [Required]  //#Kevin 这个是说字段必须填写的
        public string Name { get; set; }

        public string Sex { get; set; }
    }
}
