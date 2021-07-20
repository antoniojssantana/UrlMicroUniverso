using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Models;
using url.Enums;

namespace url.business.Interfaces.Services
{
	public interface IOriginSiteService : IDisposable
	{
		Task <IEnumerable<OriginSiteModel>> GetAll();
		Task <OriginSiteModel> GetId(Guid id);
		Task <IEnumerable<OriginSiteModel>> GetByDescription(string description);
		Task <IEnumerable<OriginSiteModel>> GetByURL(string url);
		Task <IEnumerable<OriginSiteModel>> GetByUserBaseId(Guid userbaseid);
		Task <IEnumerable<OriginSiteModel>> GetByState(State state);
		Task <IEnumerable<OriginSiteModel>> Find(Expression<Func<OriginSiteModel, bool>> predicado);
		Task ChangeState(Guid id);
		Task<bool> Add(OriginSiteModel model);
		Task<bool> Update(OriginSiteModel model);
		Task<bool> Delete(OriginSiteModel model);
	}
}

