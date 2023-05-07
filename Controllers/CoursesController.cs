using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Core_Day09.Models;
using WebApplication_Core_Day09.RepoService;

namespace WebApplication_Core_Day09.Controllers
{
	public class CoursesController : Controller
	{
		public IRepo<Course> Repo { get; }

		public CoursesController(IRepo<Course> repo)
		{
			Repo = repo;
		}
		// GET: CoursesController
		public ActionResult Index()
		{
			return View(Repo.GetAll());
		}

		// GET: CoursesController/Details/5
		public ActionResult Details(int id)
		{
			return View(Repo.GetByID(id));
		}

		// GET: CoursesController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CoursesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Course crs)
		{
			try
			{
				Repo.Insert(crs);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CoursesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View(Repo.GetByID(id));
		}

		// POST: CoursesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Course crs)
		{
			try
			{
				Repo.Update(crs);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
		public ActionResult Delete(int id)
		{
			Course crs = Repo.GetByID(id);
			Repo.Delete(crs);
			return RedirectToAction(nameof(Index));
		}

	} 
}
