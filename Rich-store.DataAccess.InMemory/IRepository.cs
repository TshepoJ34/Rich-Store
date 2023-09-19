using Rich_store.Core.Models;
using System.Linq;

namespace Rich_store.DataAccess.InMemory
{
    public interface IInMemoryRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Comit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}