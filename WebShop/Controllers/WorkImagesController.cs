using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using WebShop.Models.Entities;

namespace WebShop.Controllers
{
    public class WorkImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WorkImagesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Image
        public ActionResult Index()
        {
            string path = Url.Content(ConfigurationManager.AppSettings["ImagesPath"]);
            var model = _context.ListImages.Select(i => new ImageItemViewModel
            {
                Id = i.Id,
                Path = path + i.Name
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ImageAddViewModel model)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["ImagesPath"]);
            var imageName = Guid.NewGuid().ToString()+".jpg";
            model.Image.SaveAs(path + imageName);
            ListImage image = new ListImage()
            {
                Name = imageName
            };
            _context.ListImages.Add(image);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}