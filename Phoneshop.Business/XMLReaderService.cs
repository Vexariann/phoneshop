using Phoneshop.Domain.Models;
using System.Xml.Linq;

namespace Phoneshop.Business
{
    public class XMLReaderService
    {
        public static List<Phone> OpenXMLFile(string input)
        {
            List<Phone> phoneList = new();

            XDocument xDoc = XDocument.Load(input);
            IEnumerable<XElement> results = xDoc.Elements("Phones").Elements("Phone");
            foreach (XElement result in results)
            {
                Brand brand = new()
                {
                    BrandName = result.Element("Brand").Value
                };
                Phone phone = new()
                {
                    Brand = brand,
                    Type = result.Element("Type").Value,
                    Price = int.Parse(result.Element("Price").Value),
                    Description = result.Element("Description").Value.Trim(),
                    Stock = 1
                };

                phoneList.Add(phone);
            }
            return phoneList;
        }
    }
}
