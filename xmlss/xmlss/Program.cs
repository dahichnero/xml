using System.Xml;
using xmlss;

XmlDocument doc = new XmlDocument();//1
doc.Load("valutes.xml");//2

var valutes = doc.DocumentElement;//3
double min = 0;
double max = 0;
Valutes minv = new Valutes();
Valutes maxv = new Valutes();
List<Valutes> v = new List<Valutes>();//4
foreach (XmlNode valute in valutes)//5
{
    Console.WriteLine($"Id: {valute.Attributes["ID"].InnerText}");
    Console.WriteLine($"Name: {valute["Name"].InnerText}");
    Console.WriteLine($"CharCode: {valute["CharCode"].InnerText}");
    Console.WriteLine($"Курс: {valute["Value"].InnerText}");

    /*Valutes v2 = new Valutes { 
        Id = valute.Attributes["ID"].InnerText,
        Name= valute["Name"].InnerText,
        Valut= Convert.ToDouble(valute["Value"].InnerText),
        NumCode = Convert.ToInt32(valute["NumCode"].InnerText),
        CharCode = valute["CharCode"].InnerText
    };
    v.Add(v2);*/

    min = Convert.ToDouble(valute["Value"].InnerText);
    max = Convert.ToDouble(valute["Value"].InnerText);
}
Console.WriteLine("Введите валюту поиска:");
string va=Console.ReadLine();
foreach (XmlNode valute in valutes)
{
    if (valute["CharCode"].InnerText == va)
    {
        Console.WriteLine($"Id: {valute.Attributes["ID"].InnerText}");
        Console.WriteLine($"Name: {valute["Name"].InnerText}");
        Console.WriteLine($"CharCode: {valute["CharCode"].InnerText}");
        Console.WriteLine($"Курс: {valute["Value"].InnerText}");
        break;
    }
}


Console.WriteLine("Min Max");
foreach (XmlNode valute in valutes)
{
    double m= Convert.ToDouble(valute["Value"].InnerText);
    if (m < min)
    {
        min = m;
        minv.Id = valute.Attributes["ID"].InnerText;
        minv.Name = valute["Name"].InnerText;
        minv.Valut = Convert.ToDouble(valute["Value"].InnerText);
        minv.NumCode = Convert.ToInt32(valute["NumCode"].InnerText);
        minv.CharCode = valute["CharCode"].InnerText;
    }
    if (m > max)
    {
        max = m;
        maxv.Id = valute.Attributes["ID"].InnerText;
        maxv.Name = valute["Name"].InnerText;
        maxv.Valut = Convert.ToDouble(valute["Value"].InnerText);
        maxv.NumCode = Convert.ToInt32(valute["NumCode"].InnerText);
        maxv.CharCode = valute["CharCode"].InnerText;
    }
}
Console.WriteLine($"Минимальная валюта: {minv.Name} {minv.NumCode} {minv.Valut} {minv.NumCode} {minv.CharCode}");
Console.WriteLine($"Максимальная валюта: {maxv.Name} {maxv.NumCode} {maxv.Valut} {maxv.NumCode} {maxv.CharCode}");
