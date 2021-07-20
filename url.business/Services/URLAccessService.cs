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
	public class URLAccessService : BaseService, IURLAccessService
	{
		private readonly IURLAccessRepository Repository;
		public URLAccessService(IURLAccessRepository repository, INotifier notifier) : base(notifier)
		{
			Repository = repository;
		}
		public async Task<bool> Add(URLAccessModel model)
		{
			if (!ValidationExecute(new URLAccessValidation(), model)) return false;
			if (Repository.Find(p => p.ShortenedURL == model.ShortenedURL && p.DateAccess == model.DateAccess && p.Source == model.Source ).Result.Any())
			{
				Notify("Já existe um(a) URLAccess com os dados informados.");
				return false;
			}
			await Repository.Add(model);
			return true;
		}
		public async Task<bool> Delete(URLAccessModel model)
		{
			if (!ValidationExecute(new URLAccessValidation(), model)) return false;
			await Repository.Delete(model.Id);
			return true;
		}
		public void Dispose()
		{
			Repository?.Dispose();
		}
		public async Task<IEnumerable<URLAccessModel>> Find(Expression<Func<URLAccessModel, bool>> predicado)
		{
			return await Repository.Find(predicado);
		}
		public async Task<IEnumerable<URLAccessModel>> GetAll()
		{
			return await Repository.GetAll();
		}
		public async Task<IEnumerable<URLAccessModel>> GetByShortenedURLId(Guid shortenedurlid)
		{
			return await Repository.GetByShortenedURLId(shortenedurlid);
		}
		public async Task<IEnumerable<URLAccessModel>> GetByDateAccess(DateTime? dateaccess)
		{
			return await Repository.GetByDateAccess(dateaccess);
		}
		public async Task<IEnumerable<URLAccessModel>> GetBySource(string source)
		{
			return await Repository.GetBySource(source);
		}
		public async Task<URLAccessModel> GetId(Guid id)
		{
			return (URLAccessModel)await Repository.GetId(id);
		}
		public async Task ChangeState(Guid id)
		{
			var _model = await this.GetId(id);
			await Repository.ChangeState(_model);
		}
		public async Task<bool> Update(URLAccessModel model)
		{
			if (!ValidationExecute(new URLAccessValidation(), model)) return false;
			if (Repository.Find(p => p.ShortenedURL == model.ShortenedURL && p.DateAccess == model.DateAccess && p.Source == model.Source ).Result.Any())
			{
					Notify("Já existe um(a) URLAccess com os dados informados.");
					return false;
			}
			await Repository.Update(model);
			return true;
		}
	}
}

