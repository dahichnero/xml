using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xmlss;
using System.Xml;
using System.Windows.Controls;

namespace XmlWpf.Data
{
    public static class ValuteLoader
    {
        public static List<Valutes> LoadValutes(string XMLText)
        {
            List<Valutes> Valutes = new List<Valutes>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(XMLText);
            var valutes = xmlDocument.DocumentElement;
            foreach (XmlNode valute in valutes)
            {
                Valutes v2 = new Valutes
                {
                    Name = valute["Name"].InnerText,
                    Code = valute["ID"].InnerText,
                    Nominal = Convert.ToInt32(valute["Nominal"].InnerText),
                    Value = Convert.ToDouble(valute["Value"].InnerText),
                    CharCode = valute["CharCode"].InnerText
                };
                Valutes.Add(v2);
            }
            return Valutes;
        }
    }
}
