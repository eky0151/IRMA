using System.Linq;

namespace Picbook.Repository.EntityFramework.Repositories
{
    using System;
    using Entities;
    using IRepositories;
    using GenericsEFRepository;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AccountRepository : GenericEfRepository<Account>, IAccountRepository
    {
        public AccountRepository(PicBookContext ctx)
            :base(ctx)
        { }

        public async Task<string> GetProfilPictureById(Guid id)
        {
            var profil = await GetById(id);
            return profil.ProfileImageUrl;
        }

        public async Task<IReadOnlyCollection<Album>> GetAlbumsByUserId(Guid id)
        {
            var profil = await GetById(id);
            return profil.Album.ToList();
        }

        public async Task<Account> GetUserByName(string username)
        {
            return await Context.Set<Account>().FindAsync(username);
        }

        public override async Task<Account> GetById(Guid id)
        {
            return await Context.Set<Account>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
