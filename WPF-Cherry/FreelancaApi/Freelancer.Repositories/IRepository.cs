using System.Linq;

namespace Freelancer.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Get(int id);

        T Add(T item);

        void Delete(int id);

        void Update(int id, T item);
    }
}
