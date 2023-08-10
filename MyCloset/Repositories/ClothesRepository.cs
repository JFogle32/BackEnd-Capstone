using MyCloset.Models;
using MyCloset.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace MyCloset.Repositories
{
    public class ClothesRepository : BaseRepository, IClothesRepository
    {
        public ClothesRepository(IConfiguration config) : base(config) { }

        public List<Clothes> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clothes";
                    var reader = cmd.ExecuteReader();

                    var clothesList = new List<Clothes>();
                    while (reader.Read())
                    {
                        clothesList.Add(new Clothes
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Size = DbUtils.GetString(reader, "Size"),
                            Status = DbUtils.GetBoolean(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Material = DbUtils.GetString(reader, "Material"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")

                        });
                    }
                    reader.Close();
                    return clothesList;
                }
            }
        }

        public Clothes GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Clothes WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();
                    Clothes clothes = null;

                    if (reader.Read())
                    {
                        clothes = new Clothes
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Size = DbUtils.GetString(reader, "Size"),
                            Status = DbUtils.GetBoolean(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Material = DbUtils.GetString(reader, "Material"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")

                        };
                    }
                    reader.Close();
                    return clothes;
                }
            }
        }

        public void Add(Clothes clothes)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Clothes (Name, Size, Status, Image, Material, Notes, UserId)
                        OUTPUT INSERTED.ID
                        VALUES (@Name, @Size, @Status, @Image, @Material, @Notes, @UserId)";

                    DbUtils.AddParameter(cmd, "@Name", clothes.Name);
                    DbUtils.AddParameter(cmd, "@Size", clothes.Size);
                    DbUtils.AddParameter(cmd, "@Status", clothes.Status);
                    DbUtils.AddParameter(cmd, "@Image", clothes.Image);
                    DbUtils.AddParameter(cmd, "@Material", clothes.Material);
                    DbUtils.AddParameter(cmd, "@Notes", clothes.Notes);
                    DbUtils.AddParameter(cmd, "@UserId", clothes.UserId);

                    clothes.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Clothes clothes)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Clothes
                        SET Name = @Name, 
                            Size = @Size,
                            Status = @Status,
                            Image = @Image,
                            Material = @Material,
                            Notes = @Notes,
                            UserId = @UserId
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Name", clothes.Name);
                    DbUtils.AddParameter(cmd, "@Size", clothes.Size);
                    DbUtils.AddParameter(cmd, "@Status", clothes.Status);
                    DbUtils.AddParameter(cmd, "@Image", clothes.Image);
                    DbUtils.AddParameter(cmd, "@Material", clothes.Material);
                    DbUtils.AddParameter(cmd, "@Notes", clothes.Notes);
                    DbUtils.AddParameter(cmd, "@UserId", clothes.UserId);
                    DbUtils.AddParameter(cmd, "@Id", clothes.Id);

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
                    cmd.CommandText = "DELETE FROM Clothes WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}