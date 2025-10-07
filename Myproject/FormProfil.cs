using MyProject.Entities;   // User, Role
using MyProject.BLL;        // UserManager
using MyProject.Helpers;    // DbHelper, PasswordHelper
using System;
using System.Windows.Forms;

namespace MyProject.UI
{
    public partial class FormProfil : Form
    {
        private User _user;
        private Label lblWelcome;

        public FormProfil(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {
            // Rol adını string olarak almak için basit bir switch
            string v = _user.RoleId switch
            {
                1 => "Admin",
                2 => "User",
                _ => "Bilinmeyen"
            };
            string roleName = v;

            lblWelcome.Text = $"Hoşgeldin {roleName} {_user.FullName}";
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(30, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(100, 16);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Hoşgeldin ...";
            // 
            // FormProfil
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblWelcome);
            this.Name = "FormProfil";
            this.Text = "Profil";
            this.Load += new System.EventHandler(this.FormProfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
