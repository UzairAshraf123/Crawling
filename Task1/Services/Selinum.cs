using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace Task1.Services
{
    public class FireFoxSelenium
    {
        IWebDriver fireFoxDriver;

        public FireFoxSelenium()
        {
            fireFoxDriver = new FirefoxDriver();
        }

        public IEnumerable<Models.Model> GetOLXInfo(string url)
        {
            string pageSource = string.Empty;

            fireFoxDriver.Navigate().GoToUrl(url);
            //fireFoxDriver.FindElement(By.Id(inputControl)).SendKeys(accountNo);
            List<Models.Model> list = new List<Models.Model>();
            IEnumerable<string> links = fireFoxDriver.FindElements(By.ClassName("detailsLinkPromoted")).Select(s => s.GetAttribute("href")).ToList();
            foreach (var item in links)
            {
                string previous = fireFoxDriver.Url;
                fireFoxDriver.Navigate().GoToUrl(item);
                Models.Model model = new Models.Model();
                model = GetAdDetail("contact_methods", "xxxx-large", "xx-large", "lheight28", "textContent");
                list.Add(model);
                fireFoxDriver.Navigate().Back();
            }
           
            fireFoxDriver.Quit();

            return list;
        }

        
        public IEnumerable<Models.Model> GetBoleeInfo(string url)
        {
            string pageSource = string.Empty;

            fireFoxDriver.Navigate().GoToUrl(url);
            //fireFoxDriver.FindElement(By.Id(inputControl)).SendKeys(accountNo);
            List<Models.Model> list = new List<Models.Model>();
            IEnumerable<string> links = fireFoxDriver.FindElements(By.XPath("//li/article/div/div/div/a")).Select(s => s.GetAttribute("href")).ToList();
            foreach (var item in links)
            {
                string previous = fireFoxDriver.Url;
                fireFoxDriver.Navigate().GoToUrl(item);
                Models.Model model = new Models.Model()
                {
                    Detail = fireFoxDriver.FindElement(By.ClassName("pre-line")).Text,
                    Name = fireFoxDriver.FindElement(By.ClassName("user_name")).Text,
                    Phone = fireFoxDriver.FindElement(By.ClassName("lh35")).Text,
                    Price = fireFoxDriver.FindElement(By.ClassName("price")).Text,
                    Title = fireFoxDriver.FindElement(By.ClassName("adh")).Text
                };
                list.Add(model);
                fireFoxDriver.Navigate().Back();
            }

            fireFoxDriver.Quit();

            return list;
        }



        public Models.Model GetAdDetail(string number, string price , string name, string title, string description)
        {
            //string pageSource = string.Empty;


            //string inputControl = "";
            //string submitControl = "";

            //fireFoxDriver.Navigate().GoToUrl(url);
            //fireFoxDriver.FindElement(By.Id(inputControl)).SendKeys(accountNo);
            //var number = fireFoxDriver.FindElement(By.Id("contact_methods")).Text;
            //var price = fireFoxDriver.FindElement(By.ClassName("xxxx-large")).Text;
            //var name = fireFoxDriver.FindElement(By.ClassName("xx-large")).Text;
            //var title = fireFoxDriver.FindElement(By.ClassName("lheight28")).Text;
            //var description = fireFoxDriver.FindElement(By.Id("textContent")).Text;


            //string currentHandle = fireFoxDriver.CurrentWindowHandle;

            //PopupWindowFinder finder = new PopupWindowFinder(fireFoxDriver);
            //string popupWindowHandle = finder.Click(fireFoxDriver.FindElement(By.Id(submitControl)));

            //fireFoxDriver.SwitchTo().Window(popupWindowHandle);
            //pageSource = fireFoxDriver.PageSource;

            //fireFoxDriver.Quit();

            return new Models.Model() {
                Detail = fireFoxDriver.FindElement(By.Id(description)).Text,
                Name = fireFoxDriver.FindElement(By.ClassName(name)).Text,
                Phone = fireFoxDriver.FindElement(By.Id(number)).Text,
                Price = fireFoxDriver.FindElement(By.ClassName(price)).Text,
                Title= fireFoxDriver.FindElement(By.ClassName(title)).Text
            };
        }
    }
}