using System;
namespace url.business.Models
{
	public class URLAccessModel : Entity
	{
		public Guid ShortenedURLId { get; set; } 
		public ShortenedURLModel ShortenedURL { get; set; } 
		public DateTime? DateAccess { get; set; } 
		public string Source { get; set; } 
	}
}

