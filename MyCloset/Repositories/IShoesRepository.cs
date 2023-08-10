using MyCloset.Models;
using System.Collections.Generic;

namespace MyCloset.Repositories
{
    public interface IShoesRepository
    {
        List<Shoes> GetAll();

        Shoes GetById(int id);

        void Add(Shoes shoe);

        void Update(Shoes shoe);

        void Delete(int id);
    }
}