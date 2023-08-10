using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MyCloset.Models;
using Microsoft.Extensions.Configuration;
using MyCloset.Repositories;

namespace MyCloset.Repositories
{
    public class UsersRepository : BaseRepository, IUserRepository
    {


        public UsersRepository(IConfiguration configuration) : base(configuration)
        {


        }

        public List<Users> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT Id, UserName, Email, Password
                            FROM [Users]";

                    var reader = cmd.ExecuteReader();

                    var users = new List<Users>();
                    while (reader.Read())
                    {
                        users.Add(new Users()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Password = reader.GetString(reader.GetOrdinal("Password"))
                        });
                    }

                    reader.Close();
                    return users;
                }
            }
        }

        public Users GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT Id, UserName, Email, Password
                            FROM [Users]
                           WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", id);

                    var reader = cmd.ExecuteReader();

                    Users user = null;
                    if (reader.Read())
                    {
                        user = new Users()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Password = reader.GetString(reader.GetOrdinal("Password"))
                        };
                    }

                    reader.Close();
                    return user;
                }
            }
        }

        public void Add(Users user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO [Users] (UserName, Email, Password)
                        OUTPUT INSERTED.ID
                        VALUES (@UserName, @Email, @Password)";

                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Users user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE [Users]
                           SET UserName = @UserName,
                               Email = @Email,
                               Password = @Password
                         WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Users] WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
