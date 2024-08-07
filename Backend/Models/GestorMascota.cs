using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class GestorMascota
    {
        public List<Mascota> getMascota() 
        {
            List<Mascota> lista = new List<Mascota>();
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            { 
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_getMascotaAll";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) 
                {
                    int id = dr.GetInt32(0);
                    int idmascota = dr.GetInt32(1);
                    string nombre_mascota = dr.GetString(2).Trim();

                    Mascota mascota = new Mascota(id, idmascota, nombre_mascota);
                    lista.Add(mascota);
                }

                dr.Close();
                conn.Close();

            }
            return lista;
        }

        public bool addMascota(Mascota mascota)
        { 
            bool respuesta = false;
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.CommandText = "sp_addMascota";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idraza", mascota.idraza);
                cmd.Parameters.AddWithValue("@nombre_mascota", mascota.nombre_mascota);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
                finally 
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return respuesta;

            }
        }

        public bool updateMascota(int id,Mascota mascota)
        {
            bool respuesta = false;
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.CommandText = "sp_updateMascota";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idmascota", id);
                cmd.Parameters.AddWithValue("@idraza", mascota.idraza);
                cmd.Parameters.AddWithValue("@nombre_mascota", mascota.nombre_mascota);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return respuesta;

            }
        }

        public bool deleteMascota(int id)
        {
            bool respuesta = false;
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.CommandText = "sp_deleteMascota";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idmascota", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return respuesta;

            }
        }
    }
}