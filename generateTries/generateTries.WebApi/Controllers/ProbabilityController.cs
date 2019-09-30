using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generateTries.WebApi.Controllers
{
    [Route("api/probabilities/[controller]")]
    [ApiController]
    public class ProbabilityController : Controller
    {
        
        // GET: Probability
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("{speed}")]
        public async Task<ActionResult> CalculateProbability(int speed)
        {
            var probability = await CalculateProbability(speed);
            return probability;
        }

        // GET: Probability/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Probability/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Probability/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Probability/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Probability/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Probability/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}