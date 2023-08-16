using DapperCRUD.Repository.Interface;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DapperCRUD.Data.Extensions
{
    public class CurrentValues
    {
        public CurrentValues()
        {
        }
        public CurrentValues(ICollection<string> values)
        {
            Values = values;
        }

        public ICollection<string> Values { get; set; }

        //public ICollection<string> ValuesAndEncodedValues { get; set; }
    }


    [HtmlTargetElement("customoptions", Attributes = "asp-entity-name")]
    public class CustomOptionTagHelper : TagHelper
    {
        private readonly IBankRepository _bankRepository;

        public CustomOptionTagHelper(
            IHtmlGenerator generator,
            IBankRepository bankRepository)
        {
            _bankRepository=bankRepository;
            Generator = generator;
        }

        
        [HtmlAttributeName("asp-entity-name")]
        public string EntityName { get; set; }

        [HtmlAttributeNotBound]
        public IHtmlGenerator Generator { get; set; }

        [HtmlAttributeName("asp-showdefaultitem")]
        public bool ShowDefaultItem { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
            // Is this <options /> element a child of a <select/> element the SelectTagHelper targeted?
            object formDataEntry;
            context.Items.TryGetValue(typeof(SelectTagHelper), out formDataEntry);
            ICollection<string> selectedValues = null;
            var encodedValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (formDataEntry != null)
            {
                //selectedValues = ((Microsoft.AspNetCore.Mvc.TagHelpers.Internal.CurrentValues)formDataEntry).Values;
                selectedValues = (formDataEntry.Adapt<CurrentValues>()).Values;


                if (selectedValues != null && selectedValues.Count != 0)
                {
                    foreach (var selectedValue in selectedValues)
                    {
                        encodedValues.Add(Generator.Encode(selectedValue));
                    }
                }
            }
            var items = GetItems();
            if (items == null) return;

            if (ShowDefaultItem)
                output.Content.AppendHtml($"<option value=''>{ "انتخاب کنید"}</option>");

            foreach (var item in items)
            {
                bool selected = (selectedValues != null && selectedValues.Contains(item.Value)) ||
                                   encodedValues.Contains(item.Value);
                var selectedAttr = selected || item.Selected ? "selected='selected'" : "";
                    output.Content.AppendHtml(item.Value != null
                        ? $"<option value='{item.Value}' {selectedAttr}>{item.Text}</option>"
                        : $"<option>{item.Text}</option>");
                


            }
        }

    

        private IEnumerable<SelectListItem> GetItems( )
        {
            if (string.Equals(this.EntityName, "BankModel", StringComparison.OrdinalIgnoreCase))
                return _bankRepository.GetAllAsync().Result.Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = r.Name });
            else
                return null;
        }
    }

}
