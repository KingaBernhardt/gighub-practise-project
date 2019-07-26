﻿using Gighub.Models;
using Gighub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gighub.Controllers
{
    public class GigsController : Controller
    {
        private readonly AppDbContext _context;
        public GigsController()
        {
            _context = new AppDbContext();
        }
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artistId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == artistId);
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);
            var gig = new Gig()
            {
                Artist = artist,
                DateTime = DateTime.Parse(String.Format("{0}, {1}", viewModel.Date, viewModel.Genre)),
                Genre = genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}