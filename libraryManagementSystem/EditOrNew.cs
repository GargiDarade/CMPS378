using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace libraryManagementSystem
{
    public partial class editOrNew : Form
    {
        public editOrNew()
        {
            InitializeComponent();
        }

        private void buttonSbmit_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Visible = false;
        }
    }
}
