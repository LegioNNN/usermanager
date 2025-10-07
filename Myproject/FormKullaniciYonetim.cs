using MyProject.Entities;   // User, Role
using MyProject.BLL;        // UserManager
using MyProject.Helpers;    // DbHelper, PasswordHelper
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyProject.UI
{
    public partial class FormKullaniciYonetim : Form
    {
        private UserManager _userManager = new UserManager();
        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnToggleActive;
        private List<User> _users;

        public FormKullaniciYonetim()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            _users = _userManager.GetAllUsers();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new FormUserEdit();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            var user = (User)dgvUsers.CurrentRow.DataBoundItem;
            var frm = new FormUserEdit(user);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            var user = (User)dgvUsers.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Kullanıcı {user.FullName} silinsin mi?", "Sil", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _userManager.DeleteUser(user.UserId);
                LoadUsers();
            }
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            var user = (User)dgvUsers.CurrentRow.DataBoundItem;
            bool newStatus = !user.IsActive;
            _userManager.SetUserActive(user.UserId, newStatus);
            LoadUsers();
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(154, 12);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.Size = new System.Drawing.Size(360, 150);
            this.dgvUsers.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(129, 224);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(117, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Kullanıcı ekle";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(294, 224);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(135, 23);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "Kullanıcı Düzenle";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(129, 296);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Kullanıcı Sil";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnToggleActive
            // 
            this.btnToggleActive.Location = new System.Drawing.Point(294, 296);
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size = new System.Drawing.Size(135, 23);
            this.btnToggleActive.TabIndex = 4;
            this.btnToggleActive.Text = "Aktif/Pasif Yap";
            this.btnToggleActive.UseVisualStyleBackColor = true;
            this.btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);
            // 
            // FormKullaniciYonetim
            // 
            this.ClientSize = new System.Drawing.Size(572, 400);
            this.Controls.Add(this.btnToggleActive);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dgvUsers);
            this.Name = "FormKullaniciYonetim";
            this.Load += new System.EventHandler(this.FormKullaniciYonetim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        private void FormKullaniciYonetim_Load(object sender, EventArgs e)
        {

        }
    }
}
