namespace Ich.Test.Core.Serializations;

public interface IJsonSerializer
{
    string Serialize<T>(T request);
    T Deserialize<T>(string contentJson);
}