using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_Core_Day09.Models
{
	public enum Gender
	{
		Male, Female
	}
	public class Trainee
	{
		[Key] public int TraineeID { get; set; }
		[Required]
		[MaxLength(100)]
		public required string Name { get; set; }
		public Gender Gender { get; set; }
		public string? MobileNo { get; set; }
		
		[DataType(DataType.Date)]
		public string? BirthDate { get; set; }
		[ForeignKey("Track")]
		public int? TrackRefID { get; set; }
		public virtual Track? Track { get; set; }

		public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
	}
	
}
