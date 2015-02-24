using System;
using System.Collections.Generic;
using System.Linq;


namespace FreeLancaVS2012.Helpers
{
    public class SearchSuccessArgs
    {
         public string Query { get; set; }

         public SearchSuccessArgs(string query)
            : base()
        {
            this.Query = query;
        }
    }
}
