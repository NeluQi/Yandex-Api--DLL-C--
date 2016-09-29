using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;

namespace YandexAPI
{
    public class YandexTranslate //Переводчик
    {
        public string key;
        public class objJsonTranslate
        {
            public int code { get; set; }
            public string lang { get; set; }
            public List<string> text { get; set; }

        }

        public static objJsonTranslate TranslateText(string key, string Text, string Lang, string Format="plain", string Options="0", string v = "v1.5") {
                var Ser = new JavaScriptSerializer();
                objJsonTranslate EndTranslate = Ser.Deserialize<objJsonTranslate>(Encoding.UTF8.GetString(new WebClient().DownloadData("https://translate.yandex.net/api/" + v + "/tr.json/translate?key=" + key + "&text=" + Text + "&lang=" + Lang + "&format=" + Format + "&options=" + Options)));
                return EndTranslate;
        }
    }
    public class YandexDictionary { //Cловарь

        public class Head
        {
        }

        public class Syn
        {
            public string text { get; set; }
        }

        public class Mean
        {
            public string text { get; set; }
        }

        public class Tr2
        {
            public string text { get; set; }
        }

        public class Ex
        {
            public string text { get; set; }
            public List<Tr2> tr { get; set; }
        }

        public class Tr
        {
            public string text { get; set; }
            public string pos { get; set; }
            public List<Syn> syn { get; set; }
            public List<Mean> mean { get; set; }
            public List<Ex> ex { get; set; }
        }

        public class Def
        {
            public string text { get; set; }
            public string pos { get; set; }
            public List<Tr> tr { get; set; }
        }

        public class RootObject
        {
            public Head head { get; set; }
            public List<Def> def { get; set; }
        }


        public static RootObject DictionaryText(string key,string text, string lang)
        {
            var Ser = new JavaScriptSerializer();
            RootObject EndTranslate = Ser.Deserialize<RootObject>(Encoding.UTF8.GetString(new WebClient().DownloadData("https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key=" + key +  "&lang=" + lang + "&text=" + text)));
            return EndTranslate;
        }
         



    }
}
