using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projent_NOTZA.Models
{


    public partial class VProductBook
    {

        [Display(Name = "ID สินค้า")]
        [Required(ErrorMessage = "กรุณาป้อนเลข ID")]
        public int Product_BookId { get; set; }

        [Display(Name = "ชื่อสินค้า")]
        [Required(ErrorMessage = "กรุณาป้อนชื่อสินค้า")]
        public string Product_Name { get; set; }

        [Display(Name = "ราคา")]
        [Required(ErrorMessage = "กรุณาป้อนราคาสิค้า")]
        public string Product_Price { get; set; }

        [Display(Name = "จำนวน")]
        [Required(ErrorMessage = "กรุณาป้อนจำนวน")]
        public string Product_Num { get; set; }


    }
    [MetadataType(typeof(VProductBook))]
    public partial class ProductBook { }


 


    public partial class VUser
    {
        [Display(Name = "รหัส")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int User_Id { get; set; }

        [Display(Name = "ชื่อ")]
        [Required(ErrorMessage = "กรุณาป้อนชื่อ(ID)")]
        public string User_Name { get; set; }

        [Display(Name = "รหัส")]
        [Required(ErrorMessage = "กรุณาป้อนรหัสผ่าน")]
        public string User_Password { get; set; }

        [Display(Name = "ชื่อเล่น")]
        [Required(ErrorMessage = "กรุณาป้อนชื่อเล่น")]
        public string User_Nickname { get; set; }

        [Display(Name = "ที่อยู่")]
        [Required(ErrorMessage = "กรุณาที่อยู่")]
        public string User_Address { get; set; }

        [Display(Name = "เบอร์โทร")]
        [Required(ErrorMessage = "กรุณาป้อนเบอร์โทร")]
        public string User_Tel { get; set; }

        [Display(Name = "อีเมล์")]
        [Required(ErrorMessage = "กรุณาป้อนอีเมล์")]
        public string User_Email { get; set; }
    }
    [MetadataType(typeof(VUser))]
    public partial class User { }




    public partial class VAdmin
    {
        [Display(Name = "รหัส")]
        [Required(ErrorMessage = "กรุณาป้อนรหัส")]
        public int Admin_Password { get; set; }
        [Display(Name = "ID")]
        [Required(ErrorMessage = "กรุณากรอก ID")]
        public string Admin_Username { get; set; }
    }


    
    public partial class VTypeBook
    {


        [Display(Name = "รหัส")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int Type_Id { get; set; }


        [Display(Name = "ชื่อสินค้า")]
        [Required(ErrorMessage = "กรุณาป้อนประเภท")]
        public string Type_Name { get; set; }
    }
    [MetadataType(typeof(VTypeBook))]
    public partial class TypeBook { }


    public partial class VPublisherBook
    {
        [Display(Name = "รหัส")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int Publisher_id { get; set; }

        [Display(Name = "ชื่อสินค้า")]
        [Required(ErrorMessage = "กรุณาป้อนชื่อ")]
        public string Publisher_name { get; set; }
    }
    [MetadataType(typeof(VPublisherBook))]
    public partial class PublisherBook { }



}