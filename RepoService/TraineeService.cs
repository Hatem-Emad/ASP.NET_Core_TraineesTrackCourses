using Microsoft.EntityFrameworkCore;
using WebApplication_Core_Day09.Models;

namespace WebApplication_Core_Day09.RepoService
{
	public class TraineeService : IRepo<Trainee>
	{
		public MainDBContext Context { get; }

		public TraineeService(MainDBContext context)
		{
			Context = context;
		}

		public List<Trainee> GetAll()
		{
			return Context.Trainees.Include(t => t.Track).ToList();
		}

		public Trainee GetByID(int id)
		{
			return Context.Trainees.FirstOrDefault(t => t.TraineeID == id);
		}

		public void Insert(Trainee item)
		{
			Context.Trainees.Add(item);
			Context.SaveChanges();
		}
		public void Delete(Trainee item)
		{
			Context.Trainees.Remove(item);
			Context.SaveChanges();
		}

		public void Update(Trainee item)
		{
			Context.Trainees.Update(item);
			Context.SaveChanges();
		}
	}
}
