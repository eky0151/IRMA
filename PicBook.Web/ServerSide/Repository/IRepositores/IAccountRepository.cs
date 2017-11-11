using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PicBook.Web.ServerSide.Entities;
using PicBook.Web.ServerSide.Repository.GenericsEFRepository;

namespace PicBook.Web.ServerSide.Repository.IRepositores
{
  public interface IAccountRepository : IGenericsEfRepository<Account>
    {
        Task<Account> GetUserByName(string username);

        Task<string> GetProfilPictureById(Guid id);

        Task<IReadOnlyCollection<Album>> GetAlbumsByUserId(Guid id);
    }
}
