using MercadoAbastos.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MercadoAbastos
{
    public class PuestoesController : Controller
    {
        private IRepositorio db = new Repositorio();

        // GET: Puestoes
        public ActionResult Index()
        {
            var puesto = db.damePuestos().Include(p => p.Colaborador);
            return View(puesto.ToList());
        }

        // GET: Puestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = db.damePuestos().Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // GET: Puestoes/Create
        public ActionResult Create()
        {
            ViewBag.DNI = new SelectList(db.dameColaboradores(), "DNI", "Nombre_Completo");
            return View();
        }

        // POST: Puestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Puesto puesto, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                //Is there a photo? If so save it
                if (image != null)
                {
                    puesto.ImageMimeType = image.ContentType;
                    puesto.Foto = new byte[image.ContentLength];
                    image.InputStream.Read(puesto.Foto, 0, image.ContentLength);
                }

                if (db.añadePuesto(puesto))
                {
                    ViewBag.ComentarioKey = "";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ComentarioKey = "El puesto tiene un numero que ya existe";
                    return RedirectToAction("Create");
                }
            }

            ViewBag.DNI = new SelectList(db.dameColaboradores(), "DNI", "Nombre_Completo", puesto.DNI);
            return View(puesto);
        }

        // GET: Puestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = db.damePuestos().Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DNI = new SelectList(db.dameColaboradores(), "DNI", "Nombre_Completo", puesto.DNI);
            return View(puesto);
        }

        // POST: Puestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Puesto puesto, HttpPostedFileBase image)
        {
            if (image != null)
            {
                puesto.ImageMimeType = image.ContentType;
                puesto.Foto = new byte[image.ContentLength];
                image.InputStream.Read(puesto.Foto, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {

                db.modificaPuesto(puesto);
                return RedirectToAction("Index");
            }
            ViewBag.DNI = new SelectList(db.dameColaboradores(), "DNI", "Nombre_Completo", puesto.DNI);
            return View(puesto);
        }

        // GET: Puestoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puesto puesto = db.damePuestos().Find(id);
            if (puesto == null)
            {
                return HttpNotFound();
            }
            return View(puesto);
        }

        // POST: Puestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puesto puesto = db.damePuesto(id);
            db.eliminaPuesto(puesto);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //This action gets the photo file for a given Photo ID
        public FileContentResult GetImg(int Numero_Puesto)
        {
            //Get the right photo
            Puesto requestedPhoto = db.damePuestos().FirstOrDefault(p => p.Numero_Puesto == Numero_Puesto);
            if (requestedPhoto != null)
            {
                return File(requestedPhoto.Foto, requestedPhoto.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult SlideShow()
        {
            return View(db.damePuestos().ToList());
        }
        [ChildActionOnly] //This attribute means the action cannot be accessed from the brower's address bar
        public ActionResult _PhotoGallery(int number = 0)
        {
            //We want to display only the latest photos when a positive integer is supplied to the view.
            //Otherwise we'll display them all
            List<Puesto> puestos;

            if (number == 0)
            {
                puestos = db.damePuestos().ToList();
            }
            else
            {
                puestos = (from p in db.damePuestos()
                           orderby p.Nombre descending
                           select p).Take(number).ToList();
            }

            return PartialView("_PhotoGallery", puestos);
        }
        public ActionResult Galeria()
        {
            return View("GaleriaFotos");
        }
        public ActionResult GaleriaFotosTop5()
        {
            return View("GaleriaFotosTop5");
        }
        public ActionResult GaleriaFotosDown5()
        {
            return View("GaleriaFotosDown5");
        }
        public ActionResult _PhotoGalleryTop5(int number = 5)
        {
            //We want to display only the latest photos when a positive integer is supplied to the view.
            //Otherwise we'll display them all
            List<Puesto> puestos = new List<Puesto>();

            if (number == 0)
            {
                puestos = db.damePuestos().ToList();
            }
            else
            {
                {
                    var puestosAux =
                    from p in db.damePuestos()
                    join c in db.dameComentarios() on p.Numero_Puesto equals c.Numero_Puesto into j1
                    from j2 in j1.DefaultIfEmpty()
                    group j2 by p.Numero_Puesto into grouped
                    select new
                    {
                        numPuesto = grouped.Key,
                        numComentarios = grouped.Count(t => t.Numero_Puesto != null)
                    };

                    var puestosTop = (from p in puestosAux orderby p.numComentarios descending select p).Take(number);

                    foreach (var puestoTop in puestosTop)
                    {
                        puestos.Add(db.damePuesto(puestoTop.numPuesto));
                    }
                }
            }
            return PartialView("_PhotoGallery", puestos);

        }
        public ActionResult _PhotoGalleryDown5(int number = 5)
            {
                //We want to display only the latest photos when a positive integer is supplied to the view.
                //Otherwise we'll display them all
                List<Puesto> puestos = new List<Puesto>();

                if (number == 0)
                {
                    puestos = db.damePuestos().ToList();
                }
                else
                {
                    var puestosAux =
                    from p in db.damePuestos()
                    join c in db.dameComentarios() on p.Numero_Puesto equals c.Numero_Puesto into j1
                    from j2 in j1.DefaultIfEmpty()
                    group j2 by p.Numero_Puesto into grouped
                    select new
                    {
                        numPuesto = grouped.Key,
                        numComentarios = grouped.Count(t => t.Numero_Puesto != null)
                    };

                    var puestosTop = (from p in puestosAux orderby p.numComentarios select p).Take(number);

                    foreach (var puestoTop in puestosTop)
                    {
                        puestos.Add(db.damePuesto(puestoTop.numPuesto));
                    }

                }

                return PartialView("_PhotoGallery", puestos);
            }

        }
    } 
