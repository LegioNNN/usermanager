// DAL/UserDAL.cs
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyProject.DAL
{
    public class UserDAL
    {
this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        public User CheckUser(string email, string passwordHash)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_CheckUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(dr["UserId"]),
                        Email = dr["Email"].ToString(),
                        RoleId = Convert.ToInt32(dr["RoleId"]),
                        IsActive = Convert.ToBoolean(dr["IsActive"])
                    };
                }
                return null;
            }
        }
    }
}


using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyProject.DAL
{
    public class UserDAL
    {
        public List<User> GetAllUsers()
        {
            var list = new List<User>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new User
                    {
                        UserId = (int)dr["UserId"],
                        FullName = dr["FullName"].ToString(),
                        Email = dr["Email"].ToString(),
                        RoleId = (int)dr["RoleId"],
                        IsActive = (bool)dr["IsActive"]
                    });
                }
            }
            return list;
        }

        public void DeleteUser(int userId)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public void SetUserActive(int userId, bool isActive)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SetUserActive", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);
                cmd.ExecuteNonQuery();
            }
        }
    }
}


public void AddUser(string fullName, string email, byte[] passwordHash, byte[] salt, int roleId)
{
    using (var conn = DbHelper.GetConnection())
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("sp_AddUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FullName", fullName);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
        cmd.Parameters.AddWithValue("@Salt", salt);
        cmd.Parameters.AddWithValue("@RoleId", roleId);
        cmd.ExecuteNonQuery();
    }
}

public void UpdateUser(User user)
{
    using (var conn = DbHelper.GetConnection())
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserId", user.UserId);
        cmd.Parameters.AddWithValue("@FullName", user.FullName);
        cmd.Parameters.AddWithValue("@RoleId", user.RoleId);
        cmd.ExecuteNonQuery();
    }
}


using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyProject.DAL
{
    public class UserDAL
    {
        public List<User> GetAllUsers()
        {
            var list = new List<User>();
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAllUsers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new User
                    {
                        UserId = (int)dr["UserId"],
                        FullName = dr["FullName"].ToString(),
                        Email = dr["Email"].ToString(),
                        RoleId = (int)dr["RoleId"],
                        IsActive = (bool)dr["IsActive"]
                    });
                }
            }
            return list;
        }
    }
}
