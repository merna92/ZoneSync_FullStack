using ZoneSync.Domain.Repositories.Contracts;

namespace ZoneSync.Domain.Repositories;

public class InMemoryRepository<TModel> : IRepository<TModel>
{
    private readonly List<TModel> models = [];

    public int Count { get { return models.Count; } }

    public void Add(TModel model)
    {
        models.Add(model);
    }

    public void AddRange(IEnumerable<TModel> models)
    {
        foreach (TModel model in models)
            Add(model);
    }

    public IReadOnlyList<TModel> GetAll()
    {
        return models;
    }

    public TModel? FirstOrDefault(Func<TModel, bool> condition)
    {
        return models.FirstOrDefault(condition);
    }

    public List<TModel> Where(Func<TModel, bool> condition)
    {
        return models.Where(condition).ToList();
    }
}
