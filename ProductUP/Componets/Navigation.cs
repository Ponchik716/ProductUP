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
        public static List<Nav> navs = new List<Nav>();

        public static MainWindow main;
        public static void NextPage(Nav nav)
        {
            Update(nav);
            navs.Add(nav);
        }
        public static void BackPage()
        {
            if (navs.Count > 1)
            {
                navs.Remove(navs[navs.Count - 1]);
                Update(navs[navs.Count - 1]);
            }
        }
        private static void Update(Nav nav)
        {
            
            main.BackBtn.Visibility = navs.Count > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            main.ExitBtn.Visibility = isAuth == true ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            main.MyFrame.Navigate(nav.Page);
        }

    }
    class Nav
    {

        public Page Page { get; set; }
        public Nav(Page Page)
        {
            this.Page = Page;
        }
    }

}
