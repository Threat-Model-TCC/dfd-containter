using ThreatModelDfdService.Model.Entity;

namespace ThreatModelDfdService.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    T Create(T t);

    Task<T> CreateAsync(T t);

    T FindById(long id);

    List<T> FindAll();

    void Update(T t);

    void Delete(T t);

    bool Exists(long id);
}
