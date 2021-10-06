using System;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using CascadeDropDownList.Common;

namespace CascadeDropDownList.CustomModels
{
    [Serializable]
    public class CascadeDropDownListViewModel : DropDownListViewModel
    {
        public string SecondDropDownListFieldName { get; set; }

        public string SecondDropDownListLabel { get; set; }

        public string SecondDropDownListTextField { get; set; }

        public string SecondDropDownListValueField { get; set; }

        protected override void InitItemProperties(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            base.InitItemProperties(item);

            SecondDropDownListFieldName = item?.Fields[Constants.SecondDropDownListFieldName]?.Value;
            SecondDropDownListLabel = item?.Fields[Constants.SecondDropDownListLabel]?.Value;
            SecondDropDownListTextField = item?.Fields[Constants.SecondDropDownListTextField]?.Value;
            SecondDropDownListValueField = item?.Fields[Constants.SecondDropDownListValueField]?.Value;
        }

        protected override void UpdateItemFields(Item item)
        {
            Assert.ArgumentNotNull(item, "item");
            base.UpdateItemFields(item);

            var secondDropDownListFieldName = item.Fields[Constants.SecondDropDownListFieldName];
            if (secondDropDownListFieldName != null)
            {
                secondDropDownListFieldName.SetValue(SecondDropDownListFieldName, true);
            }

            var secondDropDownListLabel = item.Fields[Constants.SecondDropDownListLabel];
            if (secondDropDownListLabel != null)
            {
                secondDropDownListLabel.SetValue(SecondDropDownListLabel, true);
            }

            var secondDropDownListTextField = item.Fields[Constants.SecondDropDownListTextField];
            if (secondDropDownListTextField != null)
            {
                secondDropDownListTextField.SetValue(SecondDropDownListTextField, true);
            }

            var secondDropDownListValueField = item.Fields[Constants.SecondDropDownListValueField];
            if (secondDropDownListValueField != null)
            {
                secondDropDownListValueField.SetValue(SecondDropDownListValueField, true);
            }
        }
    }
}