using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using url.business.Interfaces.Repository;
using url.business.Interfaces.Services;
using url.business.Models;
using url.business.Models.Validations;
using url.business.Notifications;

namespace url.business.Services
{
    public class UserBaseService : BaseService, IUserBaseService
    {
        private readonly IUserBaseRepository Repository;

        public UserBaseService(IUserBaseRepository repository
                                , INotifier notifier) : base(notifier)
        {
            Repository = repository;
        }

        public async Task<bool> Add(UserBaseModel model)
        {
            if (!ValidationExecute(new UserBaseValidation(), model)) return false;

            if (Repository.Find(p => p.Email == model.Email).Result.Any())
            {
                Notify("Já existe uma Usuário com o Email informado.");
                return false;
            }

            if (Repository.Find(p => p.Cpf == model.Cpf).Result.Any())
            {
                Notify("Já existe uma Usuário com o CPF informado.");
                return false;
            }

            await Repository.Add(model);
            return true;
        }

        public async Task<bool> Delete(UserBaseModel model)
        {
            if (!ValidationExecute(new UserBaseValidation(), model)) return false;

            // Buscar locais que possuem dependência com a cidade.
            await Repository.Delete(model.Id);
            return true;
        }

        public void Dispose()
        {
            Repository?.Dispose();
        }

        public async Task<IEnumerable<UserBaseModel>> GetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<UserBaseModel> GetId(Guid id)
        {
            return (UserBaseModel)await Repository.GetId(id);
        }

        public async Task<bool> Update(UserBaseModel model)
        {
            if (!ValidationExecute(new UserBaseValidation(), model)) return false;

            if (Repository.Find(p => p.Email == model.Email && p.Id != model.Id).Result.Any())
            {
                Notify("Já existe uma Usuário com o Email informado.");
                return false;
            }

            if (Repository.Find(p => p.Cpf == model.Cpf && p.Id != model.Id).Result.Any())
            {
                Notify("Já existe uma Usuário com o CPF informado.");
                return false;
            }

            await Repository.Update(model);
            return true;
        }
    }
}