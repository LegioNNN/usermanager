namespace UserManagement.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool MustChangePassword { get; set; }
        private void InitializeComponent()
        {
            // ... diðer kontroller ...
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // ...
        }

        private void LoadRoles()
        {
            var roles = new List<Role>
            {
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
            };
            cmbRole.DataSource = roles;
            cmbRole.DisplayMember = "RoleName";
            cmbRole.ValueMember = "RoleId";
            cmbRole.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            int roleId = ((Role)cmbRole.SelectedItem).RoleId;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                lblMessage.Text = "Ad Soyad ve Email boþ olamaz!";
                return;
            }

            if (_editingUser == null)
            {
                string[] names = fullName.Split(' ');
                string defaultPassword = names.Length > 1
                    ? $"{names[0][0]}{names[1][0]}1234"
                    : $"{names[0][0]}1234";
                var (hash, salt) = PasswordHelper.CreateHash(defaultPassword);

                _userManager.AddUser(fullName, email, hash, salt, roleId);
                MessageBox.Show("Kullanýcý eklendi. Default þifre ile giriþ yapabilir.");
            }
            else
            {
                _editingUser.FullName = fullName;
                _editingUser.RoleId = roleId;
                _userManager.UpdateUser(_editingUser);
                MessageBox.Show("Kullanýcý güncellendi.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
int roleId = ((Role)cmbRole.SelectedItem).RoleId;
string[] names = fullName.Split(' ');
string defaultPassword = names.Length > 1
    ? $"{names[0][0]}{names[1][0]}1234"
    : $"{names[0][0]}1234";
