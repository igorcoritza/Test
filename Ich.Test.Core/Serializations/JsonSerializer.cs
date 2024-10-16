namespace Ich.Test.Core.Serializations
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T request)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(request);
        }

        public T Deserialize<T>(string contentJson)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(contentJson) ?? throw new InvalidCastException($"could not convert {contentJson} into {typeof(T).FullName}");
        }
    }
}