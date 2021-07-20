using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using url.business.Models;

namespace url.business.Interfaces.Services
{
    public interface IUserBaseService : IDisposable
    {
        Task<IEnumerable<UserBaseModel>> GetAll();

        Task<UserBaseModel> GetId(Guid id);

        Task<bool> Add(UserBaseModel model);

        Task<bool> Update(UserBaseModel model);

        Task<bool> Delete(UserBaseModel model);
    }
}