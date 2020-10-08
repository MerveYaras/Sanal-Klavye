using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanal_Klavye
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void ItemAd(GroupBox g)
        {
            foreach (var item in g.Controls)
            {
                g.Text = g.Text.ToUpper();
                if (item is GroupBox)
                {
                    ((GroupBox)item).Text = ((GroupBox)item).Text.ToUpper();
                    ItemAd((GroupBox)item);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is GroupBox)
                {
                   ItemAd((GroupBox)item);
                }

            }
        }
    }
}
