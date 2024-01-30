using AutoMapper;
using Restaurant.Auth.UseCases.Abstractions;

namespace Restaurant.Auth.DataAccess.Repositories
{
    public class MainRepository : IMainRepository
    {
        private readonly UmContext _context;

        public IUserRepository Users { get; }

        public MainRepository(UmContext context, IMapper mapper)
        {
            _context = context;
            Users = new UserRepository(context, mapper);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
