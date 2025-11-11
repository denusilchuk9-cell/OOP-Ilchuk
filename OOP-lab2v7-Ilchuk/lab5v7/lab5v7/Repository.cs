using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> : IRepository<T>
{
    private readonly List<T> _data = new();

    public void Add(T item) => _data.Add(item ?? throw new ArgumentNullException(nameof(item)));

    public bool Remove(Predicate<T> match) => _data.RemoveAll(match) > 0;

    public IEnumerable<T> Where(Func<T, bool> predicate) => _data.Where(predicate);

    public T? FirstOrDefault(Func<T, bool> predicate) => _data.FirstOrDefault(predicate);

    public IReadOnlyList<T> All() => _data.AsReadOnly();
}