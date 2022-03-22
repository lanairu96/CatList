using Infrastructure.Contexts;
using Domain.Models;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CatRepository : BaseRepository<Cat, int>, ICatRepository
    {
        public CatRepository(AppDbContext context) : base(context) { }   
    }
}
