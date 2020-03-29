using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApiSep.Library.Helpers
{
    public class ThemeHelper
    {
        public static void AddCss(string path, Page page)
        {
            Literal cssFile = new Literal() { Text = @"<link href=""" + page.ResolveUrl(path) + @""" type=""text/css"" rel=""stylesheet"" />" };
            page.Header.Controls.Add(cssFile);
        }

    }
}
