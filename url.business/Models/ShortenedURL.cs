using System;
namespace url.business.Models
{
	public class ShortenedURLModel : Entity
	{
		public Guid OriginSiteId { get; set; } 
		public OriginSiteModel OriginSite { get; set; } 
		public string Link { get; set; } 
		public DateTime? InitialDate { get; set; } 
		public DateTime? ExpiredDate { get; set; } 
	}
}

