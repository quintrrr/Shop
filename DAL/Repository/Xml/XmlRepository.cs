using System.Xml.Serialization;
using Core.Classes;
using Core.Interfaces;

namespace DAL.Repository.Xml;

public class XmlRepository<T> : FileRepositoryBase<T> where T : IPrimary
{
    protected override string Path { get; }

    public XmlRepository(string path)
    {
        Path = path;
    }
    
    protected override List<T> Deserialize(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return new List<T>();
        var ser = new XmlSerializer(typeof(List<T>));
        using var sr = new StringReader(text);
        return (ser.Deserialize(sr) as List<T>) ?? new List<T>();
    }

    protected override string Serialize(List<T> list)
    {
        var xmlSerializer = new XmlSerializer(typeof(List<T>));
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, list);
        return stringWriter.ToString();
    }
}