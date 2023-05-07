using WebApplication_Core_Day09.Models;

namespace WebApplication_Core_Day09.RepoService
{
	public class TrackService : IRepo<Track>
	{
		public MainDBContext Context { get; }

		public TrackService(MainDBContext context)
		{
			Context = context;
		}
		public List<Track> GetAll()
		{
			return Context.Tracks.ToList();
		}

		public Track GetByID(int id)
		{
			return Context.Tracks.FirstOrDefault(t => t.TrackID == id);
		}

		public void Insert(Track item)
		{
			Context.Tracks.Add(item);
			Context.SaveChanges();
		}
		public void Delete(Track item)
		{
			Context.Tracks.Remove(item);
			Context.SaveChanges();
		}


		public void Update(Track item)
		{
			Context.Tracks.Update(item);
			Context.SaveChanges();
		}
	}
}
