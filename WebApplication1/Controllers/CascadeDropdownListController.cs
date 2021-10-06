using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CascadeDropDownList.Controllers
{
    public class CascadeDropdownListController : SitecoreController
    {
        [HttpGet]
        public JsonResult SelectItems(string selectedItemValue, string textField, string valueField)
        {
            if (string.IsNullOrEmpty(selectedItemValue))
                return new JsonResult();

            if (Sitecore.Context.Database == null)
                return new JsonResult();

            var parentItem = Sitecore.Context.Database.GetItem(ID.Parse(selectedItemValue));

            if (parentItem == null)
                return new JsonResult();

            var items = parentItem.GetChildren().Select(x => new SelectListItem { Text = GetValueForStandardFields(textField, x) ?? x.Fields[textField].Value, Value = GetValueForStandardFields(valueField, x) ?? x.Fields[valueField].Value });

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        private string GetValueForStandardFields(string fieldName, Item item)
        {
            if (fieldName.Equals("__ID", StringComparison.OrdinalIgnoreCase))
                return item.ID.ToString();

            if (fieldName.Equals("__ItemName", StringComparison.OrdinalIgnoreCase))
                return item.Name;

            return null;
        }
    }
}