using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Interfaces.Repository;
using url.business.Models;
using url.data.Context;
namespace url.data.Repository
{
	public class ShortenedURLRepository : Repository<ShortenedURLModel>, IShortenedURLRepository
	{
		public ShortenedURLRepository(URLDbContext dbContext) : base(dbContext) { }
		public async Task<IEnumerable<ShortenedURLModel>> GetByOriginSiteId(Guid originSiteId)
		{
			return await Find(c => c.OriginSiteId == originSiteId);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByLink(string link)
		{
			return await Find(c => c.Link == link);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByInitialDate(DateTime? initialdate)
		{
			return await Find(c => c.InitialDate == initialdate);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByExpiredDate(DateTime? expireddate)
		{
			return await Find(c => c.ExpiredDate == expireddate);
		}
	}
}

