using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DDD.Infra.Cross.AspNetMvc.TagHelpers
{
    [HtmlTargetElement("span", Attributes = "app-help-for")]
    [HtmlTargetElement("p", Attributes = "app-help-for")]
    public class HelpText : TagHelper
    {
        public ModelExpression AppHelpFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var helpText = AppHelpFor.Metadata.Description;

            if (string.IsNullOrEmpty(helpText))
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "p";
            output.Content.Append(helpText);

            var @class = output.Attributes["class"]?.Value ?? "";
            output.Attributes.SetAttribute("class", @class + " help-block");
        }
    }
}
