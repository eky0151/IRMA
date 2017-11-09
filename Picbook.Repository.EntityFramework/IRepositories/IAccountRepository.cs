namespace Picbook.Repository.EntityFramework.IRepositories
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using GenericsEFRepository;
    using System.Collections.Generic;

    public interface IAccountRepository : IGenericsEfRepository<Account>
    {
        Task<Account> GetUserByName(string username);

        Task<string> GetProfilPictureById(Guid id);

        Task<IReadOnlyCollection<Album>> GetAlbumsByUserId(Guid id);
    }
}
