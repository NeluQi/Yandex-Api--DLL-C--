using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System;

namespace YandexAPI
{
    public class YandexTranslate //Переводчик
    {
        public class objJsonTranslate
        {
            public int code { get; set; }
            public string lang { get; set; }
            public List<string> text { get; set; }
            public string key;
            public string Text;
            public string Lang;
            public string Format = "plain";
            public string Options = "0";
            public string Version = "v1.5";

            public void SetKey(string SetKey) { key = SetKey;  }
            public void SetText(string SetText) { Text = SetText; }
            public void SetLang(string SetLang) { Lang = SetLang; }
            public void SetFormat(string SetFormat) { Format = SetFormat; }
            public void SetOptions(string SetOptions) { Options = SetOptions; }
            public void SetVersion(string SetVersion) { Version = SetVersion; }
        }

            public static objJsonTranslate TranslateText(objJsonTranslate Obj)
            {
                var Ser = new JavaScriptSerializer();
                objJsonTranslate EndTranslate = Ser.Deserialize<objJsonTranslate>(Encoding.UTF8.GetString(new WebClient().DownloadData("https://translate.yandex.net/api/" + Obj.Version + "/tr.json/translate?key=" + Obj.key + "&text=" + Obj.Text + "&lang=" + Obj.Lang + "&format=" + Obj.Format + "&options=" + Obj.Options)));
                return EndTranslate;
            }
    }
    public class YandexDictionary//Cловарь
    { 

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

        public class objJsonDictionary
        {
            public Head head { get; set; }
            public List<Def> def { get; set; }
            public string Key;
            public string Text;
            public string Lang;
            public void SetKey(string SetKey) { Key = SetKey; }
            public void SetText(string SetText) { Text = SetText; }
            public void SetLang(string SetLang) { Lang = SetLang; }

        }


        public static objJsonDictionary DictionaryText(objJsonDictionary obj)
        {
            var Ser = new JavaScriptSerializer();
            objJsonDictionary EndTranslate = Ser.Deserialize<objJsonDictionary>(Encoding.UTF8.GetString(new WebClient().DownloadData("https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key=" + obj.Key +  "&lang=" + obj.Lang + "&text=" + obj.Text)));
            return EndTranslate;
        }
    }
}
