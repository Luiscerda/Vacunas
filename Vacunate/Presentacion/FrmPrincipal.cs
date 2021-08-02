using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            hideSubMenu();
            LoadUserData();
            ManagePermissions();
        }
        #region Funcionalidades del formulario
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        private Form formularioActivo = null;
        private void AbrirFormularios(Form formularioHijo)
        {
            if (formularioActivo != null)
                formularioActivo.Close();
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formularioHijo);
            panelFormularios.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FrmPacientes"] == null)
                btnUsers.BackColor = Color.FromArgb(4,41,68);
            if (Application.OpenForms["FrmEmpleados"] == null)
                btnPacientes.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void btnRegistrarPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FrmPacientes());
            hideSubMenu();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            //panelSubmenuPacientes.Visible = false;
            //panelSubmenuEmpleados.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AbrirFormularios(new FrmEditarPerfil());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FrmUsuarios());
            //showSubMenu(panelSubmenuEmpleados);
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FrmPacientes());
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FrmEmpleados());
        }

        private void btnVacunas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FrmVacunas());
        }

        private void LoadUserData()
        {
            labelRol.Text = UserLoginCache.Rol;
            labelFirst.Text = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            labelEmail.Text = UserLoginCache.Email;
        }
        private void ManagePermissions()
        {
            if (UserLoginCache.Rol == Roles.Paciente)
            {
                btnUsers.Enabled = false;
                btnPacientes.Enabled = false;
            }
        }
    }
}
