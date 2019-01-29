using MauritiusGuideBackEnd.utilitaire;
using MauritiusGuideBackEnd.ViewModel;
using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MauritiusGuideBackEnd.Controllers
{
    public class Photo_CheckPointController : BaseController
    {
        public GuideContext _context { get; set; }
        public Photo_CheckPointController()
        {
            _context = new GuideContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int checkPointId)
        {
            var checkpoint = _context.Beacons.Find(checkPointId);

            var data = new PhotoCheckPointViewModel()
            {
                CheckPoint = checkpoint
            };
            return View(data);
        }


        public ActionResult New(int checkPointID)
        {
            var checkPoint = _context.Beacons.SingleOrDefault(m => m.ID == checkPointID);
            ViewModel.PhotoCheckPointViewModel data = new ViewModel.PhotoCheckPointViewModel()
            {
                CheckPoint = checkPoint
            };

            return View(data);
        }

        [HttpPost]
        public ActionResult Create(Photo_CheckPoint photo_CheckPoint)
        {
            PhotoUtil utilPhoto = new PhotoUtil();
            HttpFileCollectionBase image = Request.Files;
            if(image[0].FileName!="")
            {
                photo_CheckPoint.Photo_Code = utilPhoto.EncodeImage(image[0]);
                photo_CheckPoint.Photo_Extension = Path.GetExtension(image[0].FileName);
                if (ModelState.IsValid)
                {
                    _context.Photo_CheckPoints.Add(photo_CheckPoint);
                    _context.SaveChanges();
                    return RedirectToAction("List", "Photo_CheckPoint", new { checkPointID = photo_CheckPoint.CheckPointId });
                }
            }
            var checkPoint = _context.Beacons.SingleOrDefault(m => m.ID == photo_CheckPoint.CheckPointId);
            PhotoCheckPointViewModel data = new PhotoCheckPointViewModel()
            {
                Photo_CheckPoint = photo_CheckPoint,
                CheckPoint = checkPoint
            };
            
            return View("New", data);
        }


        public ActionResult Edit(int ID)
        {
            Photo_CheckPoint photo_CheckPoint = _context.Photo_CheckPoints.Find(ID);
            var checkPointList = _context.Beacons.ToList();
            ViewModel.PhotoCheckPointViewModel data = new ViewModel.PhotoCheckPointViewModel()
            {
                CheckPoints = checkPointList,
                Photo_CheckPoint = photo_CheckPoint
            };
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Photo_CheckPoint photo_CheckPoint)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", photo_CheckPoint);
            }
            else
            {
                PhotoUtil utilPhoto = new PhotoUtil();

                HttpFileCollectionBase image = Request.Files;
                if (image.Count > 0 && image[0].ContentLength > 0)
                {
                    photo_CheckPoint.Photo_Code = utilPhoto.EncodeImage(image[0]);
                    photo_CheckPoint.Photo_Extension = Path.GetExtension(image[0].FileName);
                }
                _context.Entry(photo_CheckPoint).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("List", new RouteValueDictionary(
                 new { controller = "Photo_CheckPoint", action = "List", checkPointId = photo_CheckPoint.CheckPointId }));
        }
    }

}