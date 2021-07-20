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
using url.Enums;

namespace url.business.Services
{
	public class OriginSiteService : BaseService, IOriginSiteService
	{
		private readonly IOriginSiteRepository Repository;
		public OriginSiteService(IOriginSiteRepository repository, INotifier notifier) : base(notifier)
		{
			Repository = repository;
		}
		public async Task<bool> Add(OriginSiteModel model)
		{
			if (!ValidationExecute(new OriginSiteValidation(), model)) return false;
			if (Repository.Find(p => p.Description == model.Description &&  p.URL == model.URL &&  p.UserBaseId == model.UserBaseId && p.State == model.State ).Result.Any())
			{
				Notify("Já existe um(a) OriginSite com os dados informados.");
				return false;
			}
			await Repository.Add(model);
			return true;
		}
		public async Task<bool> Delete(OriginSiteModel model)
		{
			if (!ValidationExecute(new OriginSiteValidation(), model)) return false;
			await Repository.Delete(model.Id);
			return true;
		}
		public void Dispose()
		{
			Repository?.Dispose();
		}
		public async Task<IEnumerable<OriginSiteModel>> Find(Expression<Func<OriginSiteModel, bool>> predicado)
		{
			return await Repository.Find(predicado);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetAll()
		{
			return await Repository.GetAll();
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByDescription(string description)
		{
			return await Repository.GetByDescription(description);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByURL(string url)
		{
			return await Repository.GetByURL(url);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByUserBaseId(Guid userbaseid)
		{
			return await Repository.GetByUserBaseId(userbaseid);
		}
		public async Task<IEnumerable<OriginSiteModel>> GetByState(State state)
		{
			return await Repository.GetByState(state);
		}
		public async Task<OriginSiteModel> GetId(Guid id)
		{
			return (OriginSiteModel)await Repository.GetId(id);
		}
		public async Task ChangeState(Guid id)
		{
			var _model = await this.GetId(id);
			await Repository.ChangeState(_model);
		}
		public async Task<bool> Update(OriginSiteModel model)
		{
			if (!ValidationExecute(new OriginSiteValidation(), model)) return false;
			if (Repository.Find(p => p.Description == model.Description && p.URL == model.URL &&  p.UserBaseId == model.UserBaseId &&  p.State == model.State ).Result.Any())
			{
					Notify("Já existe um(a) OriginSite com os dados informados.");
					return false;
			}
			await Repository.Update(model);
			return true;
		}
	}
}

