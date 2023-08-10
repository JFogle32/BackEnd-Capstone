using MyCloset.Models;
using System.Collections.Generic;

namespace MyCloset.Repositories
{
    public interface IGadgetsRepository
    {
        void Add(Gadgets gadget);
        void Delete(int id);
        List<Gadgets> GetAll();
        Gadgets GetById(int id);
        void Update(Gadgets gadget);
    }
}
