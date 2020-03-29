using System.Web.UI.WebControls;

namespace ApiSep.Library.Extensions
{
    public static class LinkButtonExtensions
    {
        public static void MakeButtonGreen(this LinkButton linkButton)
        {
            linkButton.CssClass = "btn btn-success btn-block";
        }

        public static void MakeButtonRed(this LinkButton linkButton)
        {
            linkButton.CssClass = "btn btn-danger btn-block";
        }

        public static void DisableButton(this LinkButton linkButton)
        {
            linkButton.CssClass = "btn btn-danger btn-block btn-disabled";
            linkButton.Enabled = false;
        }

        public static void EnableButton(this LinkButton linkButton)
        {
            linkButton.CssClass = "btn btn-default btn-block";
            linkButton.Enabled = true;
        }

        
    }
}
