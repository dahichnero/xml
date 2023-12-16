using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using xmlwpfval.Model;

namespace xmlwpfval.Data
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
                Valutes v2 = new Valutes();
                v2.Namee= valute["Name"].InnerText;
                v2.Valuee = Convert.ToDouble(valute["Value"].InnerText);
                v2.CharCodee = valute["CharCode"].InnerText;
                v2.Codee = valute["NumCode"].InnerText;
                v2.Nominall = Convert.ToInt32(valute["Nominal"].InnerText);
                Valutes.Add(v2);
            }
            return Valutes;
        }
    }
}
