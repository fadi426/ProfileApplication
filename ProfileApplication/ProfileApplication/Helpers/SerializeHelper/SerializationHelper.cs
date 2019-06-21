using Newtonsoft.Json;

namespace ProfileApplication.Helper
{
    public class SerializationHelper
    {
        public string Serialize(object obj, bool useLongNames)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            if (useLongNames)
            {
                settings.ContractResolver = new LongNameContractResolver();
            }

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}