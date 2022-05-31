using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Library_Management.Classes
{
    public class CallUserClss
    {
        public static  void AddUserClass(Grid grd, UserControl uc)
        {
            if(grd.Children.Count > 0)
            { grd.Children.Clear(); 
              grd.Children.Add(uc);
            }
            else { grd.Children.Add(uc); }
        }
    }
}
