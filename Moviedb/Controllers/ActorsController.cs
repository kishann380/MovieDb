﻿using Moviedb.Models;
using System.Net;
using System.Web.Mvc;
using Moviedb.Repository;

namespace Moviedb.Controllers
{
    public class ActorsController : Controller
    {

        private readonly MovieRepository movieRepository;

        public ActorsController()
        {
            movieRepository = new MovieRepository();
        }
        
        // GET: Actors
        public ActionResult Index()
        {
            return View(movieRepository.GetActors());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = movieRepository.GetActor(id);

            return actor == null ? (ActionResult)HttpNotFound() : (ActionResult)View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            var actor = new Actor();
            return View(actor);
        }

        public ActionResult CreateActor()
        {
            var actor = new Actor();
            return View(actor);
        }

        [HttpPost]
        public ActionResult CreateActor([Bind(Include = "Id,Name,Gender,DOB,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                movieRepository.AddActor(actor);
                movieRepository.SaveChanges();   

                return Json(actor);
            }

            return Json(null);
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,DOB,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                movieRepository.AddActor(actor);
                movieRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Actor actor = movieRepository.GetActor(id);
            return actor == null ? (ActionResult)HttpNotFound() : (ActionResult)View(actor);
 
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,DOB,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                movieRepository.UpdateActor(actor);
                movieRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }
        
        public ActionResult Delete(int id)
        {
            Actor actor = movieRepository.GetActor(id);
            movieRepository.RemoveActor(actor);
            movieRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                movieRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}