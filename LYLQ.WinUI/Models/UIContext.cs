using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLQ.WinUI.Models
{
    public class UIContext
    {
        public static UserModel LoginUser { get; set; }

        public static Task SyncInstockToStockTask;
        
    }
}
