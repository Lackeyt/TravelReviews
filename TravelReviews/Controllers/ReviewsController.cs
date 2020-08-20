using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelReviews.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TravelReviews.Controllers
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews); ///capital M model referes to what's passed into the view
    }

    [HttpPost]
    public IActionResult Index(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review); //single review object -- capital M refers to a single review object
    }

    public IActionResult Edit(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public IActionResult Details(int id, Review review)
    {
      review.ReviewId = id;
      Review.Put(review);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Review.Delete(id);
      return RedirectToAction("Index");
    }

  //   public IActionResult Create(int id, )
  }
}