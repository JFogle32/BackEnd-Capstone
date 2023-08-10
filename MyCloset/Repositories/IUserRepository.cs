using MyCloset.Models;

namespace MyCloset.Repositories
{
    public interface IUserRepository
    {
        void Add(Users user);
        List<Users> GetAll();
        Users GetById(int id);
        void Delete(int id);
        void Update(Users user);
    }
}