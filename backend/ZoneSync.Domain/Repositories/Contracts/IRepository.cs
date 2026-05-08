namespace ZoneSync.Domain.Repositories.Contracts;

public interface IRepository<TModel>
{
    void Add(TModel model);
    void AddRange(IEnumerable<TModel> models);
    IReadOnlyList<TModel> GetAll();
    TModel? FirstOrDefault(Func<TModel, bool> condition);
    List<TModel> Where(Func<TModel, bool> condition);
    int Count { get; }
}
