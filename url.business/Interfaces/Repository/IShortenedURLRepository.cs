using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Models;
namespace url.business.Interfaces.Repository
{
	public interface IShortenedURLRepository : IRepository<ShortenedURLModel>
	{
		Task<IEnumerable<ShortenedURLModel>> GetByOriginSiteId(Guid originsiteid);
		Task<IEnumerable<ShortenedURLModel>> GetByLink(string link);
		Task<IEnumerable<ShortenedURLModel>> GetByInitialDate(DateTime? initialdate);
		Task<IEnumerable<ShortenedURLModel>> GetByExpiredDate(DateTime? expireddate);
	}
}

