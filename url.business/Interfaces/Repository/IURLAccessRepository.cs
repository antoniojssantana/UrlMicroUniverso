using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Models;
namespace url.business.Interfaces.Repository
{
	public interface IURLAccessRepository : IRepository<URLAccessModel>
	{
		Task<IEnumerable<URLAccessModel>> GetByShortenedURLId(Guid shortenedurlid);
		Task<IEnumerable<URLAccessModel>> GetByDateAccess(DateTime? dateaccess);
		Task<IEnumerable<URLAccessModel>> GetBySource(string source);
	}
}

