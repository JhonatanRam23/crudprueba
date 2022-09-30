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
    public class EmpresasController : Controller
    {
        private DbEvaluacionEntities db = new DbEvaluacionEntities();

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.TblEmpresas.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresas tblEmpresas = db.TblEmpresas.Find(id);
            if (tblEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresas);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpresaID,EmpresaCodigo,Nombre,CorreoElectronico,Telefono")] TblEmpresas tblEmpresas)
        {
            if (ModelState.IsValid)
            {
                db.TblEmpresas.Add(tblEmpresas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmpresas);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresas tblEmpresas = db.TblEmpresas.Find(id);
            if (tblEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresas);
        }

        // POST: Empresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpresaID,EmpresaCodigo,Nombre,CorreoElectronico,Telefono")] TblEmpresas tblEmpresas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpresas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmpresas);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresas tblEmpresas = db.TblEmpresas.Find(id);
            if (tblEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresas);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEmpresas tblEmpresas = db.TblEmpresas.Find(id);
            db.TblEmpresas.Remove(tblEmpresas);
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
