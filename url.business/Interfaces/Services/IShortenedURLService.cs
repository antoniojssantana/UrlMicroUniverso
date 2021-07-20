using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Models;
namespace url.business.Interfaces.Services
{
	public interface IShortenedURLService : IDisposable
	{
		Task <IEnumerable<ShortenedURLModel>> GetAll();
		Task <ShortenedURLModel> GetId(Guid id);
		Task <IEnumerable<ShortenedURLModel>> GetByOriginSiteId(Guid originsiteid);
		Task <IEnumerable<ShortenedURLModel>> GetByLink(string link);
		Task <IEnumerable<ShortenedURLModel>> GetByInitialDate(DateTime? initialdate);
		Task <IEnumerable<ShortenedURLModel>> GetByExpiredDate(DateTime? expireddate);
		Task <IEnumerable<ShortenedURLModel>> Find(Expression<Func<ShortenedURLModel, bool>> predicado);
		Task ChangeState(Guid id);
		Task<bool> Add(ShortenedURLModel model);
		Task<bool> Update(ShortenedURLModel model);
		Task<bool> Delete(ShortenedURLModel model);
	}
}

