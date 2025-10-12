using System.Text.Json;
using Core.Classes;
using Core.Interfaces;

namespace DAL.Repository.Json;

public class JsonRepository<T> : FileRepositoryBase<T> where T : IPrimary
{
    protected override string Path { get; }
    
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public JsonRepository(string path)
    {
        Path = path;
    }
    
    protected override List<T> Deserialize(string text) =>
        JsonSerializer.Deserialize<List<T>>(text, _options) ?? new List<T>();

    protected override string Serialize(List<T> list) => JsonSerializer.Serialize(list, _options);
}