namespace WebApplication_Core_Day09.RepoService
{
	public interface IRepo<T>
	{
		public List<T> GetAll();
		public T GetByID(int id);
		public void Insert (T item);
		public void Delete (T item);
		public void Update (T item);

	}
}
