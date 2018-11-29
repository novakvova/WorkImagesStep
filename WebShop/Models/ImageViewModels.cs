using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class ImageItemViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
    public class ImageAddViewModel
    {        
        public HttpPostedFileBase Image { get; set; }
    }
}