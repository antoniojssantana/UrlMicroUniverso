using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Interfaces.Repository;
using url.business.Models;
using url.data.Context;
using url.Enums;

namespace url.data.Repository
{
	public class OriginSiteRepository : Repository<OriginSiteModel>, IOriginSiteRepository
	{
		public OriginSiteRepository(URLDbContext dbContext) : base(dbContext) { }
		public async Task<IEnumerable<OriginSiteModel>> GetByDescription(string description)
		{
			return await Find(c => c.Description == description);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByURL(string url)
		{
			return await Find(c => c.URL == url);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByUserBaseId(Guid userbaseid)
		{
			return await Find(c => c.UserBaseId == userbaseid);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByState(State state)
		{
			return await Find(c => c.State == state);
		}
	}
}

