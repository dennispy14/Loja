using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

public static class MetodosExtensao
{
    public static int Metade(this int valor)
    {
        return valor / 2;
    }
    public static double Juros(this double Valor)
    {
        return Valor + 20;
    }
    public static string PrimeiraMaiscula(this string Valor)
    {
        return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
    }

    public static string PrimeiraMaiscula(this string Valor, bool UltimasMinusculas)
    {
        if (UltimasMinusculas)
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
        }
        else
        {
            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1);

        }
           
        
    }
}


namespace Loja.Classes
{
    public partial class Cliente : IDisposable
    {

        public void Insert()
        {
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
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
                    cmd.CommandText = "Insert Into Cliente (Codigo, Nome, Tipo, DataCadastro) Values (@codigo, @nome, @tipo, @datacadastro)";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._dataCadastro);

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
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
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
                    cmd.CommandText = "Update Cliente Set Nome = @nome, Tipo = @tipo, DataCadastro = @datacadastro Where Codigo = @codigo";
                    cmd.Connection = cn;

                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._dataCadastro);

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
        public static Int32 Proximo()
        {
            Int32 _return = 0;
            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
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
                    cmd.CommandText = "Select Max(Codigo) + 1 from Cliente";
                    
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
        public void Apagar()
        {

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
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
                    cmd.CommandText = "Delete From Cliente Where Codigo = @codigo";
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
        public void Dispose()
        {
            this.Gravar();
        }
        public static List<Cliente> Todos()
        {

            List<Cliente> _return = null;

            using (SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
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
                    cmd.CommandText = "Select * from Cliente";
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while(dr.Read())
                            {
                                Cliente cli = new Cliente();
                                cli._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                                cli._nome = dr.GetString(dr.GetOrdinal("Nome"));
                                cli._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                                cli._dataCadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));

                                if (_return == null)
                                    _return = new List<Cliente>();

                                cli._isNew = false;

                                _return.Add(cli);
                            }             
                            
                        }
                    }
                   
                }

            }

            return _return;
        }
        public Cliente()
        {
            this._isNew = true;
            this._isModified = false;
            this._codigo = Proximo();
        }
        public Cliente(int codigo)
        {
            using(SqlConnection cn = new SqlConnection("Server=.\\sqlexpress;Database=loja;Trusted_Connection=True;"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Cliente where Codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._nome = dr.GetString(dr.GetOrdinal("Nome"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                            this._dataCadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));
                        }
                    }
                    this._isNew = false;
                    this._isModified = false;
                }

            }
        }
    }
}
