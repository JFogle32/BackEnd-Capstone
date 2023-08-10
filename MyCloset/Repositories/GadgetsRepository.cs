using MyCloset.Models;
using MyCloset.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;




namespace MyCloset.Repositories
{
    public class GadgetsRepository : BaseRepository, IGadgetsRepository
    {
        public GadgetsRepository(IConfiguration config) : base(config) { }

        public List<Gadgets> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, Status, Image, Notes, UserId FROM Gadgets";

                    var reader = cmd.ExecuteReader();
                    var gadgets = new List<Gadgets>();

                    while (reader.Read())
                    {
                        gadgets.Add(new Gadgets()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Status = DbUtils.GetBoolean(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        });
                    }

                    reader.Close();

                    return gadgets;
                }
            }
        }

        public Gadgets GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name, Status, Image, Notes, UserId FROM Gadgets WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Gadgets gadget = null;
                    if (reader.Read())
                    {
                        gadget = new Gadgets()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Status = DbUtils.GetBoolean(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        };
                    }

                    reader.Close();

                    return gadget;
                }
            }
        }

        public void Add(Gadgets gadget)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Gadgets (Name, Status, Image, Notes, UserId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Name, @Status, @Image, @Notes, @UserId)";

                    DbUtils.AddParameter(cmd, "@Name", gadget.Name);
                    DbUtils.AddParameter(cmd, "@Status", gadget.Status);
                    DbUtils.AddParameter(cmd, "@Image", gadget.Image);
                    DbUtils.AddParameter(cmd, "@Notes", gadget.Notes);
                    DbUtils.AddParameter(cmd, "@UserId", gadget.UserId);

                    gadget.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Gadgets gadget)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Gadgets
                                        SET Name = @Name, Status = @Status, Image = @Image, Notes = @Notes, UserId = @UserId
                                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Name", gadget.Name);
                    DbUtils.AddParameter(cmd, "@Status", gadget.Status);
                    DbUtils.AddParameter(cmd, "@Image", gadget.Image);
                    DbUtils.AddParameter(cmd, "@Notes", gadget.Notes);
                    DbUtils.AddParameter(cmd, "@UserId", gadget.UserId);
                    DbUtils.AddParameter(cmd, "@Id", gadget.Id);

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
                    cmd.CommandText = "DELETE FROM Gadgets WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
