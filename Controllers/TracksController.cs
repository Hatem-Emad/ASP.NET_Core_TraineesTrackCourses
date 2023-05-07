using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Core_Day09.Models;
using WebApplication_Core_Day09.RepoService;

namespace WebApplication_Core_Day09.Controllers
{
	public class TracksController : Controller
	{
		public IRepo<Track> Repo { get; }

		public TracksController(IRepo<Track> repo)
		{
			Repo = repo;
		}
		// GET: TracksController
		public ActionResult Index()
		{
			return View(Repo.GetAll());
		}

		// GET: TracksController/Details/5
		public ActionResult Details(int id)
		{
			return View(Repo.GetByID(id));
		}

		// GET: TracksController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TracksController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Track track)
		{
			try
			{
				Repo.Insert(track);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TracksController/Edit/5
		public ActionResult Edit(int id)
		{
			return View(Repo.GetByID(id));
		}

		// POST: TracksController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Track track)
		{
			try
			{
				Repo.Update(track);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TracksController/Delete/5
		public ActionResult Delete(int id)
		{
			Track track = Repo.GetByID(id);
			Repo.Delete(track);
			return(RedirectToAction(nameof(Index)));
		}
	}
}
