using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace WolsungHeroCreator
{
    static class XMLDataLoader
    {
        private static XDocument LoadDocument(string fileName)
        {
            XDocument doc = null;
            try
            {
                doc = XDocument.Load(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return doc;
        }



        public static string LoadStateTextData(string fileName, string rootName)
        {
            XDocument doc = LoadDocument(fileName);

            if(doc == null)
            {
                return "Błąd odczytu z pliku";
            }


            var data = from item in doc.Descendants(rootName)
                       select new { text = item.Element("Text").Value };


            string text = "";
            foreach (var element in data)
                text = element.text;


            return text;
        }

        public static string LoadStateTextData(string fileName, string rootName, string nodeName, string attributeName)
        {
            XDocument doc = LoadDocument(fileName);

            if (doc == null)
            {
                return "Błąd odczytu z pliku";
            }

            var data = from item in doc.Descendants(rootName)
                       select item;

            var data2 = from item in data.Descendants<XElement>(nodeName)
                        where item.Attribute("name").Value == attributeName
                        select new { text = item.Element("Text").Value };


            string text = "";
            foreach (var element in data2)
                text = element.text;


            return text;
        }

    }
}
