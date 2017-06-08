using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task1.Models;
using Task1.Services;
namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ScrapingBrowser Browser = new ScrapingBrowser();
            //Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
            //Browser.AllowMetaRedirect = true;
            //WebPage PageResult = Browser.NavigateToPage(new Uri("https://www.olx.com.pk/item/iphone-6-16-gb-lush-condition-IDWg3Fs.html#f4c2486363;promoted"));
            //HtmlNode TitleNode = PageResult.Html.CssSelect(".large lheight20 fnormal  ").First();
            //new Services.FireFoxSelenium().GetOLXInfo("https://www.olx.com.pk/mobile-phones/");

            return View(new  Services.FireFoxSelenium().GetOLXInfo("https://www.olx.com.pk/mobile-phones/")) ;
        }

        public ActionResult About()
        {
            WebRequest req = WebRequest.Create("https://www.pakwheels.com/used-cars/search/-/featured_1/");
            WebResponse res = req.GetResponse();
            StreamReader stream = new StreamReader(res.GetResponseStream());
            string sHTML = stream.ReadToEnd();
            stream.Close();
            res.Close();
            return View(new Model() { HTML = sHTML });
        }

        public ActionResult Contact()
        {
            return View(new Services.FireFoxSelenium().GetBoleeInfo("http://bolee.com/mobile-phones-pdas-nid-295"));
        }
    }
}