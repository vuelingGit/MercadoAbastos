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
    public class ColaboradorsController : Controller
    {
        private IRepositorio db = new Repositorio();
        

        // GET: Colaboradors
        public ActionResult Index()
        {
            return View(db.dameColaboradores());
        }

        // GET: Colaboradors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.dameColaborador(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // GET: Colaboradors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colaboradors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DNI,Nombre_Completo,Correo_Electronico,Contraseña")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                if (db.añadeColaborador(colaborador))
                {
                    ViewBag.ComentarioKey = "";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ComentarioKey = "El Colaborador tiene un Código que ya existe";
                    return RedirectToAction("Create");
                }
            }

            return View(colaborador);
        }

        // GET: Colaboradors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.dameColaborador(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaboradors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DNI,Nombre_Completo,Correo_Electronico,Contraseña")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                db.modificaColaborador(colaborador);
                return RedirectToAction("Index");
            }
            return View(colaborador);
        }

        // GET: Colaboradors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.dameColaborador(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: Colaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Colaborador colaborador = db.dameColaborador(id);
            db.eliminaColaborador(colaborador);
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
    }
}
