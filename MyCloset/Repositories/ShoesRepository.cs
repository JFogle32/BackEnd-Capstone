using MyCloset.Models;
using MyCloset.Utils;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MyCloset.Repositories
{
    public class ShoesRepository : BaseRepository, IShoesRepository
    {
        public ShoesRepository(IConfiguration config) : base(config) { }

        public List<Shoes> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Shoes";
                    var reader = cmd.ExecuteReader();

                    var shoes = new List<Shoes>();
                    while (reader.Read())
                    {
                        shoes.Add(new Shoes
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Size = DbUtils.GetString(reader, "Size"),
                            Status = DbUtils.GetBoolean(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        });
                    }
                    reader.Close();
                    return shoes;
                }
            }
        }

        public Shoes GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Shoes WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Shoes shoe = null;
                    if (reader.Read())
                    {
                        shoe = new Shoes()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Size = DbUtils.GetString(reader, "Size"),
                            Status = DbUtils.GetBoolean(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        };
                    }

                    reader.Close();
                    return shoe;


                }
            }
        }



                    public void Add(Shoes shoe)
                    {
                        using (var conn = Connection)
                        {
                            conn.Open();
                            using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"
    INSERT INTO Shoes (Name, Size, Status, Image, Notes, UserId)
    OUTPUT INSERTED.ID
    VALUES (@Name, @Size, @Status, @Image, @Notes, @UserId)";

                                DbUtils.AddParameter(cmd, "@Name", shoe.Name);
                                DbUtils.AddParameter(cmd, "@Size", shoe.Size);
                                DbUtils.AddParameter(cmd, "@Status", shoe.Status);
                                DbUtils.AddParameter(cmd, "@Image", shoe.Image);
                                DbUtils.AddParameter(cmd, "@Notes", shoe.Notes);
                                DbUtils.AddParameter(cmd, "@UserId", shoe.UserId);

                                shoe.Id = (int)cmd.ExecuteScalar();
                            }
                        }
                    }

                    public void Update(Shoes shoe)
                    {
                        using (var conn = Connection)
                        {
                            conn.Open();
                            using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"
    UPDATE Shoes
    SET Name = @Name, 
        Size = @Size,
        Status = @Status,
        Image = @Image,
        Notes = @Notes,
        UserId = @UserId
    WHERE Id = @Id";

                                DbUtils.AddParameter(cmd, "@Name", shoe.Name);
                                DbUtils.AddParameter(cmd, "@Size", shoe.Size);
                                DbUtils.AddParameter(cmd, "@Status", shoe.Status);
                                DbUtils.AddParameter(cmd, "@Image", shoe.Image);
                                DbUtils.AddParameter(cmd, "@Notes", shoe.Notes);
                                DbUtils.AddParameter(cmd, "@UserId", shoe.UserId);
                                DbUtils.AddParameter(cmd, "@Id", shoe.Id);

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
                                cmd.CommandText = "DELETE FROM Shoes WHERE Id = @Id";
                                DbUtils.AddParameter(cmd, "@Id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
