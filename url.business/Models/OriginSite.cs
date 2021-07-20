using System;
using url.Enums;
namespace url.business.Models
{
	public class OriginSiteModel : Entity
	{
		public string Description { get; set; } 
		public string URL { get; set; } 
		public Guid UserBaseId { get; set; } 
		public UserBaseModel UserBase { get; set; } 
		public State State { get; set; } 
	}
}

