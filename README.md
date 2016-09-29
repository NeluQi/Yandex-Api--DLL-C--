# DLL для работы с Yandex API

DLL буду допиливать, это только альфа.</br>
Пока есть YandexTranslate и YandexDictionary</br>
Их документацию можно найти тут <https://tech.yandex.ru/></br>
Читайте официальную документацию.</br>
YandexTranslate и YandexDictionary принимают json ответ и десериализуют в класс.

```C#
/////////YandexTranslate
        public class objJsonTranslate
        {
            public int code { get; set; }
            public string lang { get; set; }
            public List<string> text { get; set; }

        }
        
/////////YandexDictionary
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
```




### TranslateText
Макет:
```C#
YandexTranslate.TranslateText(string key, string Text, string Lang, string Format="plain", string Options="0", string v = "v1.5");
```
key,Text,Lang обязательные параметры. </br>
key - Ключ API</br>
Text - Текст</br>
Lang - Язык</br>
v - Версия api (Она есть в ссылке в документации от яндекса)</br>
Подробнее - читайте в документации по API переводчика


Как использовать?</br>
1) Подключаем dll</br>
2) using YandexAPI;</br>

Создаём объект:
```C#
YandexTranslate.objJsonTranslate NameObj;
```
Перевод текста:
```C#
NameObj = YandexTranslate.TranslateText("ВАШ КЛЮЧЬ API", "САМ ТЕКСТ", "ЯЗЫК");
```
Пример:
```C#
YandexTranslate.objJsonTranslate NameObj;
NameObj = YandexTranslate.TranslateText("***", "Time", "ru");

Console.WriteLine(NameObj.code);
Console.WriteLine(NameObj.lang);
Console.WriteLine(NameObj.text[0]);

///Out
200
en-ru
Время
///
```
Что-бы вывести сам текст используйте  <ИМЯ ОБЕКТА>.text[0]

### DictionaryText (Словарь)
Макет:
```C#
DictionaryText(string key,string text, string lang);
```
key - Ключ API</br>
Text - Текст</br>
Lang - Язык</br>

```C#
YandexDictionary.RootObject Name;

Name = YandexDictionary.DictionaryText("ВАШ КЛЮЧЬ API", "ТЕКСТ", "ЯЗЫК");
```
Пример:
```C#
YandexDictionary.RootObject Name;
Name = YandexDictionary.DictionaryText("dict.1.1.20160929T142445Z.8834f19ec92c0662.c5d7e66114692584198dac3a3c09a7ffb2e28262", "Экономика","ru-en");

Console.WriteLine(Name.def[0].text);
Console.WriteLine(Name.def[0].tr[0].pos);
Console.WriteLine(Name.def[0].tr[0].mean[0].text);
Console.ReadKey();

///Out
экономика
noun
хозяйство
///
```
Читай документацию <https://tech.yandex.ru/predictor/doc/dg/reference/complete-docpage/>