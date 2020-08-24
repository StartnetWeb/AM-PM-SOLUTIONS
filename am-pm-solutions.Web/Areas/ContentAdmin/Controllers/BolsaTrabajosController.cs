using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using am_pm_solutions.DAL;
using am_pm_solutions.Entities;
using PagedList;

namespace am_pm_solutions.Web.Areas.ContentAdmin.Controllers
{
    [Authorize]
    public class BolsaTrabajosController : Controller
    {
        private AmPmContext db = new AmPmContext();

        // GET: ContentAdmin/BolsaTrabajos
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var bolsa = db.BolsaTrabajo.OrderByDescending(x => x.Fecha).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                bolsa = bolsa.Where(x => x.NombreApellido.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            return View(bolsa.ToPagedList(pageNumber, pageSize));
        }

        // GET: ContentAdmin/BolsaTrabajos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaTrabajo bolsaTrabajo = db.BolsaTrabajo.Find(id);
            if (bolsaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(bolsaTrabajo);
        }

        // GET: ContentAdmin/BolsaTrabajos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContentAdmin/BolsaTrabajos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,NombreApellido,Localidad,Provincia,Email,NombreArchivoCV")] BolsaTrabajo bolsaTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.BolsaTrabajo.Add(bolsaTrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bolsaTrabajo);
        }

        // GET: ContentAdmin/BolsaTrabajos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaTrabajo bolsaTrabajo = db.BolsaTrabajo.Find(id);
            if (bolsaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(bolsaTrabajo);
        }

        // POST: ContentAdmin/BolsaTrabajos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,NombreApellido,Localidad,Provincia,Email,NombreArchivoCV")] BolsaTrabajo bolsaTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolsaTrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolsaTrabajo);
        }

        // GET: ContentAdmin/BolsaTrabajos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BolsaTrabajo bolsaTrabajo = db.BolsaTrabajo.Find(id);
            if (bolsaTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(bolsaTrabajo);
        }

        // POST: ContentAdmin/BolsaTrabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BolsaTrabajo bolsaTrabajo = db.BolsaTrabajo.Find(id);
            db.BolsaTrabajo.Remove(bolsaTrabajo);
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
