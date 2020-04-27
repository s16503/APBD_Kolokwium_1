using Kolokwium_1.Models;
using Kolokwium_1.Responses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_1.Services
{
    public class SqlServerDbService : IMedicamentsDbService
    {
        private string myConnection = "Data Source=db-mssql;Initial Catalog=s16503;Integrated Security=True;";
        public GetMedicamentResponse getMedicament(int id)
        {
            List<Prescription> prescList = new List<Prescription>();
            using (var con = new SqlConnection(myConnection))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                com.Parameters.AddWithValue("IdMedicament", id);
                com.CommandText = "SELECT * FROM Medicament WHERE IdMedicament =@IdMedicament;";
                con.Open();

                var dr = com.ExecuteReader();


                Medicament medicament;
                if (dr.Read())
                {
                    medicament = new Medicament
                    {
                        IdMed = id,
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Type = dr["Type"].ToString()
                    };

                }
                else
                    throw new Exception("Nie znaleziono laku o takim id!");


                com.CommandText = " SELECT Prescription_Medicament.Dose as dose, Prescription_Medicament.Details as details, Prescription.IdPrescription as idPresc, Prescription.Date as date, DueDate as dueDate, IdPatient as idPatient, IdDoctor as idDoctor FROM Prescription JOIN Prescription_Medicament ON Prescription.IdPrescription = Prescription_Medicament.IdPrescription WHERE IdMedicament = @IdMedicament;";

                dr.Close();
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Prescription p = new Prescription
                    {
                        IdPresc = (int)dr["idPresc"],
                        Date = dr["date"].ToString(),
                        DueDate = dr["dueDate"].ToString(),
                        IdPatient = (int)dr["idPatient"],
                        IdDoctor = (int)dr["idDoctor"],
                        Dose = (int)dr["dose"],
                        Details = dr["dose"].ToString()
                    };

                    prescList.Add(p);
                }

                //var tran = con.BeginTransaction("SampleTransaction");
                //com.Transaction = tran;

                //var dr = com.ExecuteReader();

                GetMedicamentResponse resp = new GetMedicamentResponse
                {
                    Medicament = medicament,
                    Prescriptions = prescList

                };


                return resp;
            }
            
        }


        public string DeletePatient(string id)
        {

            using (var con = new SqlConnection(myConnection))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                com.Parameters.AddWithValue("IdPatient", id);
                com.CommandText = "DELETE Patient WHERE Patient.IdPatient = @IdPatient;";

                con.Open();
                var tran = con.BeginTransaction("SampleTransaction");
                com.Transaction = tran;

                com.ExecuteNonQuery();

                com.CommandText = "DELETE Prescription WHERE Prescription.IdPatient = @IdPatient;";

                com.ExecuteNonQuery();


                tran.Commit();

            }

            return "nie zdążyłem :(";

            }
        }
}
