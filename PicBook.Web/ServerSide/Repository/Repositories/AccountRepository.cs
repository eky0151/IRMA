using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PicBook.Web.ServerSide.Entities;
using PicBook.Web.ServerSide.Repository.GenericsEFRepository;
using PicBook.Web.ServerSide.Repository.IRepositores;

namespace PicBook.Web.ServerSide.Repository.Repositories
{
    internal class AccountRepository : GenericEfRepository<Account>, IAccountRepository
    {
        public AccountRepository(PicBookDbContext ctx)
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
