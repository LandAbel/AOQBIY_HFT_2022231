using System.Linq;

namespace AOQBIY_HFT_2022231.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
    }
}