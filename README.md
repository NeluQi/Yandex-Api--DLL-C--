# DLL для работы с Yandex API

DLL буду допиливать, это только альфа.</br>
Пока есть YandexTranslate и YandexDictionary</br>
Их документацию можно найти тут <https://tech.yandex.ru/></br>
Читайте официальную документацию.</br>
YandexTranslate и YandexDictionary принимают json ответ и десериализуют в класс.


Как использовать?</br>
1) Подключаем dll</br>
2) using YandexAPI;</br>

```C#

  //Использование Переводчика
            YandexTranslate.objJsonTranslate obj0 = new YandexTranslate.objJsonTranslate(); //Создаем новый obj
            obj0.SetKey("trnsl.1.1.20160930T112745Z.f98151ecc80639c2.3b87f0db6185e6229cf109e8b588eaa66900146c"); //Api ключь
            obj0.SetLang("ru"); //Язык для превода
            obj0.SetText("main");//Текст перевода
            obj0 = YandexTranslate.TranslateText(obj0); // Фукцияя перевода. 
            Console.WriteLine(obj0.text[0]); //Out: главная
            Console.WriteLine(obj0.lang); //Out: en - ru
            Console.WriteLine(obj0.code); //Out: 200
            Console.ReadKey();

 //Использование словоря
            YandexDictionary.objJsonDictionary obj1 = new YandexDictionary.objJsonDictionary(); //новый obj
            obj1.SetKey("dict.1.1.20160929T170023Z.65422067ae841e9f.5903f00d113f6d2aaf7591f7f3a80f4b1b0012a7"); // Настройка-ключь
            obj1.SetLang("ru-en");  // Настройка-язык
            obj1.SetText("Красиво");  // Настройка-слово
            obj1 = YandexDictionary.DictionaryText(obj1); // Запрос
            Console.WriteLine(obj1.def[0].text); //Out: красиво
            Console.WriteLine(obj1.def[0].pos); //Out: наречие
            Console.WriteLine(obj1.def[0].tr[0].pos); //Out: adverb
            Console.WriteLine(obj1.def[0].tr[0].syn[0].text); //Out:nicely
            Console.WriteLine(obj1.def[0].tr[0].syn[1].text); //Out: handsomely
            Console.ReadKey();





```





Читай документацию <https://tech.yandex.ru/dictionary/doc/dg/reference/lookup-docpage/>