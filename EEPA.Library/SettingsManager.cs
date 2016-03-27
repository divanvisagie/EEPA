using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EEPA.Library
{
    internal class SettingsManager
    {
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()};
        public static Formatting JsonFormatting = Formatting.None;
    }
}
