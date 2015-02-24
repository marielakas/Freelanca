using System;

namespace FreeLancaVS2012.Helpers
{
    public class NavigationSuccessArgs:EventArgs
    {
        public string PageName { get; set; }

        public NavigationSuccessArgs(string pageName)
            : base()
        {
            this.PageName = pageName;
        }
    }
}
