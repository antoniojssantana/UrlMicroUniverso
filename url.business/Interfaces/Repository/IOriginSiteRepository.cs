using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Models;
using url.Enums;

namespace url.business.Interfaces.Repository
{
	public interface IOriginSiteRepository : IRepository<OriginSiteModel>
	{
		Task<IEnumerable<OriginSiteModel>> GetByDescription(string description);
		Task<IEnumerable<OriginSiteModel>> GetByURL(string url);
		Task<IEnumerable<OriginSiteModel>> GetByUserBaseId(Guid userbaseid);
		Task<IEnumerable<OriginSiteModel>> GetByState(State state);
	}
}

