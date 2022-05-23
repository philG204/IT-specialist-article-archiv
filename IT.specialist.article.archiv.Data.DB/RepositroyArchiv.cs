using IT_specialist_article_archiv.Models;
using IT_specialist_article_archiv.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Data.OleDb;

namespace IT.specialist.article.archiv.Data.DB
{
    public class RepositroyArchiv : IRepositroyArchiv
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delte(Archiv obj)
        {
            throw new NotImplementedException();
        }

        public Archiv Get(int id)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ArchivDB.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Archiv", connection);
                var Dr = cmd.ExecuteReader();

                if (Dr.HasRows)
                {
                    Archiv archiv = new Archiv();
                    archiv.Id = Convert.ToInt16(Dr.GetValue(0));
                    archiv.PageNumber = Convert.ToInt16(Dr.GetValue(5));
                    archiv.Realese = Convert.ToDateTime(Dr.GetValue(4));

                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Mitarbeiter INNER JOIN Archiv_Mitarbieter ON Archiv_Mitarbeiter.Mitarbeiter_id = Mitarbeiter.Mitarbeiter_id WHERE Archiv_id = ?", connection);
                    cmd2.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(0) });
                    var Edr = cmd.ExecuteReader();

                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(Edr.GetValue(0));
                    employee.Name = Convert.ToString(Edr.GetValue(1));
                    employee.Surename = Convert.ToString(Edr.GetValue(2));
                    employee.Housenumber = Convert.ToString(Edr.GetValue(3));
                    employee.Street = Convert.ToString(Edr.GetValue(4));
                    employee.City = Convert.ToString(Edr.GetValue(5));
                    employee.Postcode = Convert.ToInt64(Edr.GetValue(6));
                    employee.Phonnumber = Convert.ToInt64(Edr.GetValue(7));
                    employee.Email = Convert.ToString(Edr.GetValue(8));

                    archiv.EmployeeDate = Convert.ToDateTime(Edr.GetValue(11));
                    archiv.Employee = employee;

                    OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM Archiv_Themenbereich INNER JOIN Themenbereich ON Archiv_Themenbereich.Bereich_ID = Themenbereich.Bereich_ID WHERE Archiv_id = ?", connection);
                    cmd3.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(0) });
                    var Adr = cmd.ExecuteReader();

                    SubjectArea area = new SubjectArea();
                    area.Id = Convert.ToInt32(Adr.GetValue(0));
                    area.Name = Convert.ToString(Adr.GetValue(1));

                    archiv.Area = area;

                    OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM Quelle INNER JOIN Archiv_Quelle ON Archiv_Quelle.Quelle_Id = Quelle.Quelle_Id WHERE Archiv_id = ?", connection);
                    cmd4.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(0) });
                    var Sdr = cmd.ExecuteReader();

                    Source source = new Source();
                    source.Id = Convert.ToInt32(Sdr.GetValue(0));
                    source.Name = Convert.ToString(Sdr.GetValue(1));
                    source.AuthorName = Convert.ToString(Sdr.GetValue(2));

                    archiv.Source = source;

                    OleDbCommand cmd5 = new OleDbCommand("SELECT * FROM Suchbegriff WHERE Suchgebriff_id = ?", connection);
                    cmd5.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(3) });
                    var STdr = cmd.ExecuteReader();

                    SearchTerm searchTerm = new SearchTerm();
                    searchTerm.Id = Convert.ToInt32(Sdr.GetValue(0));
                    searchTerm.Name = Convert.ToString(Sdr.GetValue(1));

                    archiv.Term = searchTerm;

                    OleDbCommand cmd6 = new OleDbCommand("SELECT * FROM Geraet WHERE Geraete_id = ?", connection);
                    cmd6.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(2) });
                    var Ddr = cmd.ExecuteReader();

                    Device device = new Device();
                    device.Id = Convert.ToInt32(Sdr.GetValue(0));
                    device.Name = Convert.ToString(Sdr.GetValue(1));

                    archiv.Device = device;

                    return archiv;
                }
                else
                {
                    return null;
                }              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<Archiv> GetAll()
        {
            try
            {
                ObservableCollection<Archiv> collection = new ObservableCollection<Archiv>();
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ArchivDB.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Archiv", connection);
                var Dr = cmd.ExecuteReader();

                while (Dr.Read())
                {
                    Archiv archiv = new Archiv();
                    archiv.Id = Convert.ToInt16(Dr.GetValue(0));
                    archiv.PageNumber = Convert.ToInt16(Dr.GetValue(5));
                    archiv.Realese = Convert.ToDateTime(Dr.GetValue(4));

                    OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Mitarbeiter INNER JOIN Archiv_Mitarbieter ON Archiv_Mitarbeiter.Mitarbeiter_id = Mitarbeiter.Mitarbeiter_id WHERE Archiv_id = ?", connection);
                    cmd2.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(0)});
                    var Edr = cmd.ExecuteReader();

                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(Edr.GetValue(0));
                    employee.Name = Convert.ToString(Edr.GetValue(1));
                    employee.Surename = Convert.ToString(Edr.GetValue(2));
                    employee.Housenumber = Convert.ToString(Edr.GetValue(3));
                    employee.Street = Convert.ToString(Edr.GetValue(4));    
                    employee.City = Convert.ToString(Edr.GetValue(5));
                    employee.Postcode = Convert.ToInt64(Edr.GetValue(6));
                    employee.Phonnumber = Convert.ToInt64(Edr.GetValue(7));
                    employee.Email = Convert.ToString(Edr.GetValue(8));

                    archiv.EmployeeDate = Convert.ToDateTime(Edr.GetValue(11));
                    archiv.Employee = employee;

                    OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM Archiv_Themenbereich INNER JOIN Themenbereich ON Archiv_Themenbereich.Bereich_ID = Themenbereich.Bereich_ID WHERE Archiv_id = ?", connection);
                    cmd3.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(0) });
                    var Adr = cmd.ExecuteReader();

                    SubjectArea area = new SubjectArea();
                    area.Id = Convert.ToInt32(Adr.GetValue(0));
                    area.Name = Convert.ToString(Adr.GetValue(1));

                    archiv.Area = area;

                    OleDbCommand cmd4 = new OleDbCommand("SELECT * FROM Quelle INNER JOIN Archiv_Quelle ON Archiv_Quelle.Quelle_Id = Quelle.Quelle_Id WHERE Archiv_id = ?", connection);
                    cmd4.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(0) });
                    var Sdr = cmd.ExecuteReader();

                    Source source = new Source();
                    source.Id = Convert.ToInt32(Sdr.GetValue(0));
                    source.Name = Convert.ToString(Sdr.GetValue(1));
                    source.AuthorName = Convert.ToString(Sdr.GetValue(2));

                    archiv.Source = source;

                    OleDbCommand cmd5 = new OleDbCommand("SELECT * FROM Suchbegriff WHERE Suchgebriff_id = ?", connection);
                    cmd5.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(3) });
                    var STdr = cmd.ExecuteReader();

                    SearchTerm searchTerm = new SearchTerm();
                    searchTerm.Id = Convert.ToInt32(Sdr.GetValue(0));
                    searchTerm.Name = Convert.ToString(Sdr.GetValue(1));

                    archiv.Term = searchTerm;

                    OleDbCommand cmd6 = new OleDbCommand("SELECT * FROM Geraet WHERE Geraete_id = ?", connection);
                    cmd6.Parameters.Add(new OleDbParameter { Value = Dr.GetValue(2) });
                    var Ddr = cmd.ExecuteReader();

                    Device device= new Device();
                    device.Id = Convert.ToInt32(Sdr.GetValue(0));
                    device.Name = Convert.ToString(Sdr.GetValue(1));    

                    archiv.Device = device;

                    collection.Add(archiv);

                }
                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save(Archiv obj)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ArchivDB.accdb");
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("INSERT INTO Archiv (Archiv_id, Quellen_id, Geraet_id, Suchbegriff_id, Erscheinungsdatum, Seitenzahl) VALUES (?, ?, ?, ?, ?, ?)", connection);
                cmd.Parameters.Add(new OleDbParameter { Value = obj.Id});
                cmd.Parameters.Add(new OleDbParameter { Value = obj.Source.Id});
                cmd.Parameters.Add(new OleDbParameter { Value = obj.Device.Id });
                cmd.Parameters.Add(new OleDbParameter { Value = obj.Term.Id });
                cmd.Parameters.Add(new OleDbParameter { Value = obj.Realese });
                cmd.Parameters.Add(new OleDbParameter { Value = obj.PageNumber });
                cmd.ExecuteNonQuery();
               

                OleDbCommand cmd2 = new OleDbCommand("INSERT INTO Archiv_Mitarbeiter (Archiv_id, Mitarbeiter_id, Mitarbeiter_datum) VALUES (?, ?, ?)", connection);
                cmd2.Parameters.Add(new OleDbParameter { Value = obj.Id});
                cmd2.Parameters.Add(new OleDbParameter { Value = obj.Employee.Id });
                cmd2.Parameters.Add(new OleDbParameter { Value = obj.EmployeeDate });
                cmd2.ExecuteNonQuery();

                OleDbCommand cmd3 = new OleDbCommand("INSERT INTO Archiv_Themenbereich (Archiv_id, Bereich_id) VALUES (?, ?)", connection);
                cmd3.Parameters.Add(new OleDbParameter { Value = obj.Id});
                cmd3.Parameters.Add(new OleDbParameter { Value = obj.Area.Id });
                cmd3.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
    }
}
