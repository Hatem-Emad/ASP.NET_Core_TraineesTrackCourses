using System.ComponentModel.DataAnnotations;

namespace WebApplication_Core_Day09.Models
{
	public class Track
	{
		[Key] public int TrackID { get; set; }

		[Required]
		[MaxLength(50)]
		public required string Title { get; set; }
		[MaxLength(150)]
		public string? Description { get; set; }
		
		public virtual ICollection<Trainee> Trainees { get; set; } = new HashSet<Trainee>();
	}
}
