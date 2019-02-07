using MercadoAbastos.Models.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MercadoAbastos
{
    public class ComentariosController : Controller
    {
        private IRepositorio db = new Repositorio();

        // GET: Comentarios
        public ActionResult Index()
        {
            var comentario = db.dameComentarios().Include(c => c.Puesto);
            return View(comentario.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.dameComentarios().Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.Numero_Puesto = new SelectList(db.damePuestos(), "Numero_Puesto", "Nombre");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,FechaHoraCreacion,Contenido,Like,Numero_Puesto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.FechaHoraCreacion = DateTime.Now;
                if (db.añadeComentario(comentario))
                {
                    ViewBag.ComentarioKey = "";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ComentarioKey = "El Comentaario tiene un Código que ya existe";
                    return RedirectToAction("Create");
                }
            }

            ViewBag.Numero_Puesto = new SelectList(db.damePuestos(), "Numero_Puesto", "Nombre", comentario.Numero_Puesto);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.dameComentario(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Numero_Puesto = new SelectList(db.damePuestos(), "Numero_Puesto", "Metodos_de_Pago", comentario.Numero_Puesto);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,FechaHoraCreacion,Contenido,Like,Numero_Puesto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.modificaComentario(comentario);
                return RedirectToAction("Index");
            }
            ViewBag.Numero_Puesto = new SelectList(db.damePuestos(), "Numero_Puesto", "Metodos_de_Pago", comentario.Numero_Puesto);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.dameComentario(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Comentario comentario = db.dameComentario(id);

            return RedirectToAction("Index");
        }

        [HandleError]
        [ChildActionOnly]
        public PartialViewResult _ComentariosPorPuesto(int Numero_Puesto)
        {

            //Get the updated list of comments
            var comments = db.dameComentarios(Numero_Puesto);
            //Save the PhotoID in the ViewBag because we'll need it in the view
            ViewBag.Numero_Puesto =Numero_Puesto;
            //Return the view with the new list of comments
            return PartialView(comments.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
