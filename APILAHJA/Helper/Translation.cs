using Newtonsoft.Json;

namespace APILAHJA.Helper.Translation   
{


    public class TranslationView<T>
    {
        public T Value { get; set; }
        public string LG { get; set; }
    }
    public interface ITranslationData
    {
        Dictionary<string, string> Value { get; set; }
    }
    public  class TranslationData: ITranslationData
    {

        public Dictionary<string, string> Value { get; set; }




    }



    public class HelperTranslation
    {


        public static Dictionary<string, string> ConvertTextToTranslationData(string textTranslation)
        {
            return string.IsNullOrEmpty(textTranslation)
                ? new Dictionary<string, string>()
                : JsonConvert.DeserializeObject<Dictionary<string, string>>(textTranslation);
        }


        public static TranslationData ConvertToTranslationData(string textTranslation)
        {
            return new TranslationData
            {
                Value = ConvertTextToTranslationData(textTranslation)
            };
        }

        public static string CoverTranslationDataToText(TranslationData translationData)
        {
            return JsonConvert.SerializeObject(translationData.Value);
        }


        public static string getTranslationValueByLG(string textTranslation, string lg)
        {
            return ConvertTextToTranslationData(textTranslation)[lg];
        }

        public static string ConvertTranslationDataToText(Dictionary<string, string> translationData)
        {
            return JsonConvert.SerializeObject(translationData);
        }





        public static object MapToTranslationData<S, D>(S src, D dest, object destMember)
        {
            // Ensure that neither src nor dest are null
            if (src == null || dest == null)
            {
                return destMember;
            }

            // Try to get the property name in model based on the value of destMember
            var name = dest.GetType().GetProperties()
                            .FirstOrDefault(p => p.GetValue(dest) == destMember)?.Name;

            if (string.IsNullOrEmpty(name))
            {
                return destMember; // If property name is not found or it's null, return destMember as is
            }

            // Try to get the property value from src using the identified name
            var item = src.GetType().GetProperty(name)?.GetValue(src);

            // Check if item is of type ITranslationData
            if (item is ITranslationData translationData)
            {
                return ConvertTranslationDataToText(translationData.Value); // Convert ITranslationData to text
            }
            // Check if destMember is of type ITranslationData
            else if (destMember is ITranslationData)
            {
                // Convert the string to ITranslationData
                return ConvertToTranslationData((string)item);
            }

            // If item is not null, return its value
            if (item != null)
            {
                return item;
            }

            // If destMember is not null and types match, return item
            if (destMember != null && item?.GetType() == destMember?.GetType())
            {
                return item;
            }

            // In case none of the above conditions are met, return destMember as is
            return destMember;
        }


    }
}
