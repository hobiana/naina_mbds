using MauritiusGuideBackEnd.utilitaire;
using MauritiusGuideBackEnd.ViewModel;
using MauritiusGuideWS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MauritiusGuideBackEnd.Controllers
{
    public class CheckPointController : BaseController
    {

        public GuideContext _context { get; set; }

        public CheckPointController()
        {
            _context = new GuideContext();
        }

        // GET: CheckPoint
        public ActionResult List(int placeId)
        {

            var place = _context.Places.SingleOrDefault(m => m.ID == placeId);
            ViewModel.CheckPointViewModel view = new ViewModel.CheckPointViewModel()
            {
                Place = place
            };
            return View(view);
        }

        public ActionResult Edit(int ID)
        {
            CheckPoint check = _context.Beacons.Find(ID);
            var PlacesList = _context.Places.ToList();
            ViewModel.CheckPointViewModel view = new ViewModel.CheckPointViewModel()
            {
                Places = PlacesList,
                CheckPoint = check
            };
            return View(view);
        }

        [HttpPost]
        public ActionResult Update(CheckPoint checkPoint)
        {
            if (!ModelState.IsValid)
            {
               
                return View("Edit", checkPoint);
            }
            else
            {
                _context.Entry(checkPoint).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("List", new RouteValueDictionary(
                 new { controller = "CheckPoint", action = "List", PlaceId = checkPoint.PlaceId }));
        }

        public ActionResult New(int placeId)
        {
            var Place = _context.Places.SingleOrDefault(m => m.ID==placeId);
            ViewModel.CheckPointViewModel view = new ViewModel.CheckPointViewModel()
            {
                Place = Place
            };

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(CheckPoint checkPoint)
        {
            HttpFileCollectionBase image = Request.Files;
           
            if (ModelState.IsValid)
            {
                checkPoint.Active = true;
                _context.Beacons.Add(checkPoint);
                _context.SaveChanges();
                if(image[0].FileName!="")
                {
                    SavePhotoCheckPoint(image, checkPoint.ID);
                }
               
                               
                return RedirectToAction("List", "Checkpoint", new { PlaceId = checkPoint.PlaceId });
            }
            return View("New", checkPoint);
        }

        public void SavePhotoCheckPoint(HttpFileCollectionBase images,int checkPointId)
        {
            PhotoUtil utilPhoto = new PhotoUtil();
            List<Photo_CheckPoint> listCheckPoint = new List<Photo_CheckPoint>();
            for(int i=0;i<images.Count;i++)
            {
                string imageEncoded = utilPhoto.EncodeImage(images[i]);
                Photo_CheckPoint photo_CheckPoint = new Photo_CheckPoint()
                {
                    CheckPointId = checkPointId,
                    Photo_Code = imageEncoded,
                    Photo_Extension = Path.GetExtension(images[i].FileName),
                    Photo_Path = Path.GetFileNameWithoutExtension(images[i].FileName)
                };
                listCheckPoint.Add(photo_CheckPoint);
            }
            _context.Photo_CheckPoints.AddRange(listCheckPoint);
            _context.SaveChanges();
        }

        public ActionResult TestPhoto(string imageencoded)
        {
            ViewBag.Base64String = "data:image / png; base64," + imageencoded;
            return View((Object)imageencoded);
        }
    }
}