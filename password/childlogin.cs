using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password
{
    public partial class childlogin : Form
    {
        public childlogin( string str)
        {
            InitializeComponent();

            load( str);
        }
        protected void load(string str)
        {
            MessageBox.Show(str);
            
        }
    }
}
