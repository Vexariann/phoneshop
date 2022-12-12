using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneshop.Business.Scrapers
{
    public class VodafoneScraper : IScraper
    {
    
        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

     

        public List<Phone> Execute(string url)
        {
            List<Phone> phoneList = new();

            var request = new ChromeDriver();
            request.Navigate().GoToUrl(url);
            Thread.Sleep(3000);
            var html = request.PageSource;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection allPhones = doc.DocumentNode.SelectNodes("//section/div/div/div/a/div/h3");
            foreach (HtmlNode phone in allPhones)
            {
                string singlePhoneName = phone.SelectSingleNode("//a/div/h3/span").InnerHtml;

                string singlePhonePrice = phone.SelectSingleNode("//a/div/div/p").InnerHtml;

                try
                {
                    string[] singlePhoneStringSplit = singlePhoneName.Split(' ', 2);
                    string brand = singlePhoneStringSplit[0];
                    string type = singlePhoneStringSplit[1];
                    decimal.TryParse(singlePhonePrice, out decimal price);

                    Brand brandToAdd = new()
                    {
                        BrandName = brand
                    };

                    Phone phoneToAdd = new()
                    {
                        Brand = brandToAdd,
                        Type = type,
                        Price = price,
                        Stock = 0,
                        Description = "-"
                    };
                    phoneList.Add(phoneToAdd);
                }
                catch
                {
                    throw new ArgumentNullException();
                }
            }
            return phoneList;
        }
    }
}
