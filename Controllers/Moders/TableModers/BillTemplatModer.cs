﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Moders.TableModers
{
   public class BillTemplatModer
    {
       public int TIID { get; set; }
       public String TIName { get; set; }
       public byte[] TIBackground { get; set; }
       public int TIWidth { get; set; }
       public int TIHeight { get; set; }
       public int TITTID { get; set; }
       public int TICodeLegth { get; set; }

       public byte[] TIIcon { get; set; }

    }
}
