using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JournalInfo.Models;

namespace Journal.Models
{
    public class HomeController : Controller
    {
        private JournalContext db = new JournalContext();

        //login

       public ActionResult Login()
        {
            //if session is not null
            if (Session["Id"] != null)
            {
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Login data)
        {

            //look up username to match up with pass
            if (ModelState.IsValid)
            {


                var lookupLogin = db.Logins.Where(x => x.login == data.login).SingleOrDefault();

                if (lookupLogin != null && lookupLogin.Password == data.Password)
                {

                    Session["Id"] = lookupLogin.login;
                    return RedirectToAction("index");

                }

                else
                {
                    Response.Write("Incorrect username and password combination");
                }

            }

            return View(data);

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login");
        }

        // GET: Home
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                return View(db.JournalEntries.ToList());
            }

            return RedirectToAction("login");


        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalData journalData = db.JournalEntries.Find(id);
            if (journalData == null)
            {
                return HttpNotFound();
            }
            return View(journalData);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,BodyData,JournalDate")] JournalData journalData)
        {
            if (ModelState.IsValid)
            {
                db.JournalEntries.Add(journalData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(journalData);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalData journalData = db.JournalEntries.Find(id);
            if (journalData == null)
            {
                return HttpNotFound();
            }
            return View(journalData);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Title,BodyData,JournalDate")] JournalData journalData)
        //{
        //    if (ModelState.IsValid)
        //    {



        //        journalData.JournalDate = Convert.ToDateTime(DateTime.Now.ToString());
        //        db.Entry(journalData).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(journalData);
        //}

        public ActionResult Edit(int? id, JournalData journaldata)
        {
            if (ModelState.IsValid)
            {

                var journalDataEdit = db.JournalEntries.Where(x => x.ID == id).SingleOrDefault();


                    journalDataEdit.Title = journaldata.Title;
                    journalDataEdit.BodyData = journaldata.BodyData;

                db.SaveChanges();

                return RedirectToAction("Index");
               

            }
            return View(journaldata);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JournalData journalData = db.JournalEntries.Find(id);
            if (journalData == null)
            {
                return HttpNotFound();
            }
            return View(journalData);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JournalData journalData = db.JournalEntries.Find(id);
            db.JournalEntries.Remove(journalData);
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
