using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Core_Day09.Models;
using WebApplication_Core_Day09.RepoService;

namespace WebApplication_Core_Day09.Controllers
{
	public class TraineesController : Controller
	{
		public IRepo<Trainee> Repo { get; }
		public IRepo<Track> Repotrack { get; }

		public TraineesController(IRepo<Trainee> repo, IRepo<Track> repotrack)
		{
			Repo = repo;
			Repotrack = repotrack;
		}
		// GET: TraineesController
		public ActionResult Index()
		{
			return View(Repo.GetAll());
		}

		// GET: TraineesController/Details/5
		public ActionResult Details(int id)
		{
			return View(Repo.GetByID(id));
		}

		// GET: TraineesController/Create
		public ActionResult Create()
		{
			ViewBag.tracks = Repotrack.GetAll();
			return View();
		}

		// POST: TraineesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Trainee trainee)
		{
			try
			{
				Repo.Insert(trainee);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TraineesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: TraineesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TraineesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: TraineesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
