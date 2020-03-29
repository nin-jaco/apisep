using System.Web.UI.HtmlControls;

namespace ApiSep.Library.Extensions
{
    public static class HtmlButtonExtensions
    {
        public static void SetDisabled(this HtmlButton button)
        {
            button.Attributes["class"] = "btn btn-support5 btn-block btn-labeled disabled";
        }

        public static void SetEnabled(this HtmlButton button)
        {
            button.Attributes["class"] = "btn btn-support5 btn-block btn-labeled";
        }
    }
}
