using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProductUP.Componets
{
    internal class Navigation
    {
        public static bool isAuth = false;
        public static User AuthUser = null;

        public static MainWindow main;
        public static void NextPage(Page page)
        {
            main.MyFrame.Navigate(page);
        }
    }
}
