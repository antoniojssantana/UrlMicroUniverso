using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Models;
namespace url.business.Interfaces.Services
{
	public interface IURLAccessService : IDisposable
	{
		Task <IEnumerable<URLAccessModel>> GetAll();
		Task <URLAccessModel> GetId(Guid id);
		Task <IEnumerable<URLAccessModel>> GetByShortenedURLId(Guid shortenedurlid);
		Task <IEnumerable<URLAccessModel>> GetByDateAccess(DateTime? dateaccess);
		Task <IEnumerable<URLAccessModel>> GetBySource(string source);
		Task <IEnumerable<URLAccessModel>> Find(Expression<Func<URLAccessModel, bool>> predicado);
		Task ChangeState(Guid id);
		Task<bool> Add(URLAccessModel model);
		Task<bool> Update(URLAccessModel model);
		Task<bool> Delete(URLAccessModel model);
	}
}

