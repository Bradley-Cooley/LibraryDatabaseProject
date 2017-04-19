using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDatabaseProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*using (var context = new LibraryModel())
            {
                var item = from i in context.items
                           where i.genre == "Comedy"
                           select i;

                foreach (var i in item)
                {
                    Console.WriteLine(i.Item_title);
                }
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
