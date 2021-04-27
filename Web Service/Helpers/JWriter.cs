using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web_Service.Models;

namespace Web_Service.Helpers
{
    static public class JWriter<T>
    {
        static public string Write(in T collection, string current_data = null)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            try
            {
                using (Newtonsoft.Json.JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartArray();

                    foreach (var item in (System.Collections.IList)collection)
                    {
                        writer.WriteStartObject();

                        writer.WritePropertyName("Name");
                        writer.WriteValue((item as RestroomInfo).Name);

                        writer.WritePropertyName("AdmArea");
                        writer.WriteValue((item as RestroomInfo).AdmArea);

                        writer.WritePropertyName("District");
                        writer.WriteValue((item as RestroomInfo).District);

                        writer.WritePropertyName("Location");
                        writer.WriteValue((item as RestroomInfo).Location);

                        writer.WritePropertyName("CloseFlag");
                        writer.WriteValue((item as RestroomInfo).CloseFlag);

                        writer.WritePropertyName("WorkingHours");
                        writer.WriteStartArray();
                        foreach (var element in (item as RestroomInfo).WorkingHours)
                        {
                            writer.WriteStartObject();

                            writer.WritePropertyName("DayOfWeek");
                            writer.WriteValue(element.DayOfWeek);

                            writer.WritePropertyName("Hours");
                            writer.WriteValue(element.Hours);

                            writer.WriteEndObject();
                        }
                        writer.WriteEnd();

                        writer.WritePropertyName("PaidService");
                        writer.WriteValue((item as RestroomInfo).PaidService);

                        writer.WritePropertyName("BalanceHolderName");
                        writer.WriteValue((item as RestroomInfo).BalanceHolderName);

                        writer.WriteEndObject();
                    }

                    writer.WriteEnd();

                    if (current_data != "\r\n" && !string.IsNullOrEmpty(current_data))
                    {
                        JArray current_doc = JArray.Parse(current_data);

                        JArray new_data = JArray.Parse(sb.ToString());
                        var child_new_data = new_data.Children();

                        current_doc.Add(child_new_data);

                        return current_doc.ToString();

                    }

                    return sb.ToString();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }
    }
}