using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_Core_Day09.Models
{
	public class Course
	{
		[Key] public int CourseID { get; set; }
		[Required]
		public required string Topic { get; set; }
		
		[Range(50, 100)]
		public int? Grade { get; set; }

		public virtual ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
	}
}
