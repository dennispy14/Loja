using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Loja.Classes
{
    public partial class Contato : IDisposable
    {
        public void Insert()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Loja;Trusted_Connection=True;"))
            {

                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Insert Into Contato (codigo, dadoscontato, tipo) Values (@codigo, @dadoscontato, @tipo)";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._dadoscontato);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);                    

                    try
                    {
                        cmd.ExecuteNonQuery();
                        this._isNew = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }


            }
        }
        public void Update()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Loja;Trusted_Connection=True;"))
            {

                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Update Contato Set dadoscontato = @dadoscontato, tipo = @tipo Where codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@dadoscontato", this._dadoscontato);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    

                    try
                    {
                        cmd.ExecuteNonQuery();
                        this._isModified = false;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }


            }
        }
        public void Gravar()
        {
            if (this._isNew)
                Insert();
            else if (this._isModified)
                Update();
        }
        public void Apagar()
        {

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Loja;Trusted_Connection=True;"))
            {

                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Delete From Contato Where codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);

                    try
                    {
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }


            }

        }
        public static Int32 Proximo()
        {
            Int32 _return = 0;
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Loja;Trusted_Connection=True;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select Max(codigo) + 1 from Contato";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            _return = dr.GetInt32(0);
                        }
                    }

                }

            }
            return _return;
        }

        public Contato()
        {
            this._isNew = true;
            this._isModified = false;
            this._codigo = Proximo();
        }       
        public static List<Contato> Todos(int Cliente)
        {

            List<Contato> _return = null;

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=Loja;Trusted_Connection=True;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Contato where cliente = @cliente";
                    cmd.Parameters.AddWithValue("@cliente", Cliente);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Contato cont = new Contato();
                                cont._codigo = dr.GetInt32(dr.GetOrdinal("codigo"));
                                cont._dadoscontato = dr.GetString(dr.GetOrdinal("dadoscontato"));
                                cont._tipo = dr.GetString(dr.GetOrdinal("tipo"));
                                cont._cliente = dr.GetInt32(dr.GetOrdinal("cliente"));

                                if (_return == null)
                                    _return = new List<Contato>();

                                cont._isNew = false;

                                _return.Add(cont);
                            }

                        }
                    }

                }

            }

            return _return;
        }

        public void Dispose()
        {
            this.Gravar();
        }
    }
}
