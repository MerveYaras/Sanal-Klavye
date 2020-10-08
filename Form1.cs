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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool buyuk = false;
        void Enter(GroupBox g,int left,int top)
        {
            Button btnSil = new Button();
            btnSil.Click += Tıkla_Click;
            btnSil.Name = "BackSpace";
            btnSil.Text = "<--";
            btnSil.Width = 100;
            btnSil.Height = 60;
            btnSil.Left = left;
            btnSil.Top = top;
            g.Controls.Add(btnSil);

            Button btnSpace = new Button();
            btnSpace.Click += Tıkla_Click;
            btnSpace.Name = "Space";
            btnSpace.Text = "Space";
            btnSpace.Left = 10;
            btnSpace.Top = top + 60;
            btnSpace.Width = 300;
            btnSpace.Height = 60;
            g.Controls.Add(btnSpace);

            Button btnCapsLock = new Button();
            btnCapsLock.Click += Tıkla_Click;
            btnCapsLock.Name = "CapsLock";
            btnCapsLock.Text = "CapsLock";
            btnCapsLock.Left = 310;
            btnCapsLock.Top = top + 60;
            btnCapsLock.Width = 100;
            btnCapsLock.Height = 60;
            g.Controls.Add(btnCapsLock);
        }

        void DizBüyükHarf(GroupBox g)
        {
            int left = 10;
            int top = 10;
            for (int i = 65; i < 91; i++)
            {
                Button btn = new Button();
                btn.Click += Tıkla_Click;
                btn.Name = i.ToString();
                btn.Text = (Convert.ToChar(i)).ToString();
                btn.Width = 60;
                btn.Height = 60;
                if (left <= 400)
                {
                    btn.Left = left;
                    btn.Top = top;
                    left += 60;
                    if (i == 90)
                    {
                        Enter(g, left, top);
                    }
                    g.Controls.Add(btn);
                }
                else
                {

                    top += 60;
                    left = 10;
                    btn.Left = left;
                    btn.Top = top;
                    left += 60;
                    g.Controls.Add(btn);
                }
            }
        }

        void DizNumaralar(GroupBox g)
        {
            int left2 = 120;
            int top2 = 10;

            for (int i = 57; i >= 48; i--)
            {
                Button btn = new Button();
                btn.Click += Tıkla_Click;
                btn.Name = i.ToString();
                btn.Text = (Convert.ToChar(i)).ToString();
                btn.Width = 60;
                btn.Height = 60;
                if (left2 >= 0)
                {
                    btn.Left = left2;
                    btn.Top = top2;
                    left2 -= 60;
                    g.Controls.Add(btn);
                }
                else
                {
                    top2 += 60;
                    left2 = 120;
                    btn.Left = left2;
                    btn.Top = top2;
                    left2 -= 60;
                    if (i == 48)
                    {
                        btn.Left = 60;
                    }
                    g.Controls.Add(btn);


                }
            }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {

            DizBüyükHarf(groupBox1);
            DizNumaralar(groupBox2);
            
        }

       
       
        private void Tıkla_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Name == "BackSpace" || b.Name == "Space" || b.Name == "CapsLock")
            {
                
                string kelime = textBox1.Text;
                //Back Space
                if (b.Name == "BackSpace") 
                    { if (kelime.Length != 0)
                        {  kelime = kelime.Substring(0, kelime.Length - 1);
                        textBox1.Text = kelime;}
                    }
                //Space
                else if (b.Name == "Space") { textBox1.Text += " "; }
                
                //CapsLock
                else {
                    if (buyuk == false) buyuk = true;
                    else buyuk = false;
                    //büyük-küçük harf butonların textinin ve rengin değişimi
                    if (buyuk==false) 
                        { b.BackColor = Color.Empty; //küçükharf 
                        foreach (var item in groupBox1.Controls)
                        { if (item is Button)
                            { ((Button)item).Text=((Button)item).Text.ToLower(); } }
                        }
                    else
                       { b.BackColor=Color.Green;  //büyükharf

                        foreach (var item in groupBox1.Controls)
                        {
                            if (item is Button)
                            { ((Button)item).Text=((Button)item).Text.ToUpper(); }
                        }
                    }
                    }
            }
            else 
            {
                if (buyuk==false) { textBox1.Text += b.Text.ToLower(); }
                else { textBox1.Text += b.Text; }
                
            
            }

            
            
        }
    }
}
