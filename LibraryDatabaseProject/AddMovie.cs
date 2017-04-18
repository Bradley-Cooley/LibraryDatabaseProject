using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDatabaseProject
{
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
        }

        private void insertMovie(object sender, EventArgs e)
        {


            this.Close();
        }

        private void cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
