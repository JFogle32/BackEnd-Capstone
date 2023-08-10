using MyCloset.Models;
using System.Collections.Generic;

namespace MyCloset.Repositories
{
    public interface IClothesRepository
    {
        List<Clothes> GetAll();
        Clothes GetById(int id);
        void Add(Clothes clothes);
        void Update(Clothes clothes);
        void Delete(int id);
    }
}