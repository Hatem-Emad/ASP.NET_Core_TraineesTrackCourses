using WebApplication_Core_Day09.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication_Core_Day09.RepoService
{
	public class CourseService : IRepo<Course>
	{
		public MainDBContext Context { get; }
		public CourseService(MainDBContext context)
		{
			Context = context;
		}

		public List<Course> GetAll()
		{
			return Context.Courses.ToList();
		}

		public Course GetByID(int id)
		{
			return Context.Courses.FirstOrDefault(c => c.CourseID == id);
		}

		public void Insert(Course item)
		{
			Context.Courses.Add(item);
			Context.SaveChanges();
		}
		public void Delete(Course item)
		{
			Context.Courses.Remove(item);
			Context.SaveChanges();
		}

		public void Update(Course item)
		{
			Context.Courses.Update(item);	//test it...	sh3'ala
			Context.SaveChanges();
			//Course crs = Context.Courses.FirstOrDefault(c =>c.CourseID == id);
			//crs.Topic = item.Topic;
			//crs.Grade = item.Grade;
		}
	}
}
