using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentacion
{
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            circularProgressBar.Value += 1;
            circularProgressBar.Text = circularProgressBar.Value.ToString();
            if (circularProgressBar.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if(this.Opacity == 0)
            {
                timer2.Stop();
                this.Close();
            }
        }

        private void FrmBienvenida_Load(object sender, EventArgs e)
        {
            labelUserName.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            this.Opacity = 0.0;
            circularProgressBar.Value = 0;
            circularProgressBar.Minimum = 0;
            circularProgressBar.Maximum = 100;
            timer1.Start();
        }
    }
}
