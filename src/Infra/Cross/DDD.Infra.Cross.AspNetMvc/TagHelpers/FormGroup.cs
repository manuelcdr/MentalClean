using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Infra.Cross.AspNetMvc.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "app-group-for")]
    public class FormGroup : TagHelper
    {
        public ModelExpression AppGroupFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder builder = new StringBuilder();

            output.Attributes.Add(new TagHelperAttribute("class", "form-group"));

            builder.Append($"<input asp-for='{AppGroupFor.Name}' class='form-control' />");
            builder.Append($"<label asp-for='{AppGroupFor.Name}'></label>");
            builder.Append($"<span asp-validation-for='{AppGroupFor.Name}'></span>");
            builder.Append($"<p app-help-for='{AppGroupFor.Name}'></p>");

            output.Content.SetHtmlContent(builder.ToString());

            base.Process(context, output);
        }
    }


}
