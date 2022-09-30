using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudprueba.Models;

namespace crudprueba.Controllers
{
    public class PuestosController : Controller
    {
        private DbEvaluacionEntities db = new DbEvaluacionEntities();

        // GET: Puestos
        public ActionResult Index()
        {
            var tblPuestos = db.TblPuestos.Include(t => t.TblEmpresas);
            return View(tblPuestos.ToList());
        }

        // GET: Puestos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPuestos tblPuestos = db.TblPuestos.Find(id);
            if (tblPuestos == null)
            {
                return HttpNotFound();
            }
            return View(tblPuestos);
        }

        // GET: Puestos/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.TblEmpresas, "EmpresaID", "EmpresaCodigo");
            return View();
        }

        // POST: Puestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaID,PuestoID,PuestoCodigo,Nombre,FechaDeBaja")] TblPuestos tblPuestos)
        {
            if (ModelState.IsValid)
            {
                db.TblPuestos.Add(tblPuestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaID = new SelectList(db.TblEmpresas, "EmpresaID", "EmpresaCodigo", tblPuestos.EmpresaID);
            return View(tblPuestos);
        }

        // GET: Puestos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPuestos tblPuestos = db.TblPuestos.Find(id);
            if (tblPuestos == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.TblEmpresas, "EmpresaID", "EmpresaCodigo", tblPuestos.EmpresaID);
            return View(tblPuestos);
        }

        // POST: Puestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaID,PuestoID,PuestoCodigo,Nombre,FechaDeBaja")] TblPuestos tblPuestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPuestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.TblEmpresas, "EmpresaID", "EmpresaCodigo", tblPuestos.EmpresaID);
            return View(tblPuestos);
        }

        // GET: Puestos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPuestos tblPuestos = db.TblPuestos.Find(id);
            if (tblPuestos == null)
            {
                return HttpNotFound();
            }
            return View(tblPuestos);
        }

        // POST: Puestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblPuestos tblPuestos = db.TblPuestos.Find(id);
            db.TblPuestos.Remove(tblPuestos);
            db.SaveChanges();
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
