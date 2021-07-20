using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Interfaces.Repository;
using url.business.Models;
using url.data.Context;
namespace url.data.Repository
{
	public class URLAccessRepository : Repository<URLAccessModel>, IURLAccessRepository
	{
		public URLAccessRepository(URLDbContext dbContext) : base(dbContext) { }
		public async Task<IEnumerable<URLAccessModel>> GetByShortenedURLId(Guid shortenedurlid)
		{
			return await Find(c => c.ShortenedURLId == shortenedurlid);
		}
		public async Task<IEnumerable<URLAccessModel>> GetByDateAccess(DateTime? dateaccess)
		{
			return await Find(c => c.DateAccess == dateaccess);
		}
		public async Task<IEnumerable<URLAccessModel>> GetBySource(string source)
		{
			return await Find(c => c.Source == source);
		}
	}
}

