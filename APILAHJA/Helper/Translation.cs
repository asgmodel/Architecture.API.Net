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





    }
}
