using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CurrencyConverter3.Models;

namespace CurrencyConverter3.Controllers
{
    public class CurrencyController : Controller
    {
		static XmlToCurrencyListConverter XmlConverter = new XmlToCurrencyListConverter();
		static List<Currency> CurrencyList = XmlConverter.GetCurrencyList();

        public ActionResult Index()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            foreach (Currency Currency in CurrencyList)
            {
                Items.Add(new SelectListItem { Text = Currency.Name, Value = Currency.Name });
            }

            ViewBag.FromCurrencyType = Items;
            ViewBag.ToCurrencyType = Items;
            return View(CurrencyList);
        }

        [HttpPost]
        public ActionResult Convert()
        {
            FreeConverter Converter = new FreeConverter(CurrencyList);
            double OriginalAmount = Double.Parse(Request["OriginalAmountText"]);
            string OriginalName = Request["FromCurrencyType"];
            string TargetName = Request["ToCurrencyType"];
            double TargetAmount = Converter.Convert(TargetName, OriginalName, OriginalAmount);

            StringBuilder Result = new StringBuilder();
            Result.Append(OriginalAmount + " " + OriginalName + " = " + TargetAmount + " " + TargetName);

            return Content(Result.ToString());
        }
    }
}
