using System.Web.UI.HtmlControls;

namespace ApiSep.Library.Extensions
{
    public static class HtmlGenericControlExtensions
    {
        public static void MarkInputGroupAsInvalid(this HtmlGenericControl htmlGenericControl)
        {
            htmlGenericControl.Attributes["class"] = "form-group required has-error has-danger";
            htmlGenericControl.Focus();
        }

        public static void MarkInputGroupAsValid(this HtmlGenericControl htmlGenericControl)
        {
            htmlGenericControl.Attributes["class"] = "form-group required";
        }
    }
}
