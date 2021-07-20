using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using url.business.Interfaces.Repository;
using url.business.Interfaces.Services;
using url.business.Models;
using url.business.Models.Validations;
using url.business.Notifications;

namespace url.business.Services
{
    public class ShortenedURLService : BaseService, IShortenedURLService
	{
        private readonly IShortenedURLRepository Repository;
		public ShortenedURLService(IShortenedURLRepository repository, INotifier notifier) : base(notifier)
		{
			Repository = repository;
		}
		public async Task<bool> Add(ShortenedURLModel model)
		{
			if (!ValidationExecute(new ShortenedURLValidation(), model)) return false;
			if (Repository.Find(p => p.OriginSite == model.OriginSite && p.Link == model.Link).Result.Any())
			{
				Notify("Já existe um(a) ShortenedURL com os dados informados.");
				return false;
			}
			await Repository.Add(model);
			return true;
		}
		public async Task<bool> Delete(ShortenedURLModel model)
		{
			if (!ValidationExecute(new ShortenedURLValidation(), model)) return false;
			await Repository.Delete(model.Id);
			return true;
		}
		public void Dispose()
		{
			Repository?.Dispose();
		}
		public async Task<IEnumerable<ShortenedURLModel>> Find(Expression<Func<ShortenedURLModel, bool>> predicado)
		{
			return await Repository.Find(predicado);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetAll()
		{
			return await Repository.GetAll();
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByOriginSiteId(Guid originsiteid)
		{
			return await Repository.GetByOriginSiteId(originsiteid);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByLink(string link)
		{
			return await Repository.GetByLink(link);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByInitialDate(DateTime? initialdate)
		{
			return await Repository.GetByInitialDate(initialdate);
		}
		public async Task<IEnumerable<ShortenedURLModel>> GetByExpiredDate(DateTime? expireddate)
		{
			return await Repository.GetByExpiredDate(expireddate);
		}
		public async Task<ShortenedURLModel> GetId(Guid id)
		{
			return (ShortenedURLModel)await Repository.GetId(id);
		}
		public async Task ChangeState(Guid id)
		{
			var _model = await this.GetId(id);
			await Repository.ChangeState(_model);
		}
		public async Task<bool> Update(ShortenedURLModel model)
		{
			if (!ValidationExecute(new ShortenedURLValidation(), model)) return false;
			if (Repository.Find(p => p.OriginSite == model.OriginSite &&  p.Link == model.Link).Result.Any())
			{
					Notify("Já existe um(a) ShortenedURL com os dados informados.");
					return false;
			}
			await Repository.Update(model);
			return true;
		}
	}
}

