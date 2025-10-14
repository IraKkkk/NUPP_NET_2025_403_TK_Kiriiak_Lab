using System.Text.Json;

namespace Games.Common;

public class CrudService<T> : ICrudService<T> where T : class
{
    private readonly List<T> _data = new();

    public void Create(T element) => _data.Add(element);

    public T? Read(Guid id)
    {
        var prop = typeof(T).GetProperty("Id");
        return _data.FirstOrDefault(x => prop?.GetValue(x)?.Equals(id) == true);
    }

    public IEnumerable<T> ReadAll() => _data;

    public void Update(T element)
    {
        Remove(element);
        Create(element);
    }

    public void Remove(T element) => _data.Remove(element);

    // Додаткове завдання — серіалізація
    public void Save(string filePath)
    {
        var json = JsonSerializer.Serialize(_data);
        File.WriteAllText(filePath, json);
    }

    public void Load(string filePath)
    {
        if (!File.Exists(filePath)) return;
        var json = File.ReadAllText(filePath);
        var loaded = JsonSerializer.Deserialize<List<T>>(json);
        if (loaded != null)
        {
            _data.Clear();
            _data.AddRange(loaded);
        }
    }
}
