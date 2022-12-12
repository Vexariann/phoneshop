using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.Business.Scrapers
{
    public class BelsimpelScraper : IScraper
    {

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        // //*[local-name()='section'][starts-with(@class, 'SegmentItemContainerstyle__StyledSegmentItemContainer')]//*[local-name()='div'][starts-with(@class, 'HardwareFloatstyle__StyledHardwareFloat')]//*[local-name()='div'][starts-with(@class, 'GridHeaderstyle__HeaderContainer')]

        // Get all phone names

        //*[local-name()='section'][starts-with(@class, 'SegmentItemContainerstyle__StyledSegmentItemContainer')]
        //*[local-name()='div'][starts-with(@class, 'HardwareFloatstyle__StyledHardwareFloat')]
        //*[local-name()='div'][starts-with(@class, 'GridHeaderstyle__HeaderContainer')]
        //*[local-name()='h3'][starts-with(@class, 'GridHeaderstyle__Title')]
        //*

        // get all prices

        //*[local-name()='section'][starts-with(@class, 'SegmentItemContainerstyle__StyledSegmentItemContainer')]
        //*[local-name()='div'][starts-with(@class, 'HardwareCtaBoxstyle__HardwareCtaBoxContainer')]
        //*[local-name()='div'][starts-with(@class, 'HardwareCtaBoxstyle__PricingContainer')]
        //*[local-name()='span'][last()]

        public List<Phone> Execute(string url)
        {
            List<Phone> phoneList = new();

            var request = new ChromeDriver();
            request.Navigate().GoToUrl(url);
            Thread.Sleep(3000);
            var html = request.PageSource;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection allPhones = doc.DocumentNode.SelectNodes("//*[local-name()='section'][starts-with(@class, 'SegmentItemContainerstyle__StyledSegmentItemContainer')]");
            foreach (HtmlNode phone in allPhones)
            {
                string singlePhoneName = phone.SelectSingleNode(".//*[local-name()='div'][starts-with(@class, 'HardwareFloatstyle__StyledHardwareFloat')]" +
                    "//*[local-name()='div'][starts-with(@class, 'GridHeaderstyle__HeaderContainer')]" +
                    "//*[local-name()='h3'][starts-with(@class, 'GridHeaderstyle__Title')]" +
                    "//*").InnerHtml;

                string singlePhonePrice = phone.SelectSingleNode(".//*[local-name()='div'][starts-with(@class, 'HardwareCtaBoxstyle__HardwareCtaBoxContainer')]" +
                    "//*[local-name()='div'][starts-with(@class, 'HardwareCtaBoxstyle__PricingContainer')]" +
                    "//*[local-name()='span'][last()]").InnerHtml;

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
