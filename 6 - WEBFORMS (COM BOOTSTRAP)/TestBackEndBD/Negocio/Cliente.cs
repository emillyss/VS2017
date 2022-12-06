using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBackEndBD.Negocio
{
    public class Cliente
    {
        private MySqlConnection connection;
        public Cliente()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.Cliente Read(string id)
        {
            return this.Read(id, "", "").FirstOrDefault();
        }

        public List<Classes.Cliente> Read(string id, string nome, string ativo)
        {
            var clientes = new List<Classes.Cliente>();
            try
            {
                connection.Open();
                var commando = new MySqlCommand($"SELECT nome, ativo, id FROM clientes WHERE (1=1) ", connection);
                if (nome.Equals("") == false)
                {
                    commando.CommandText += $" AND nome like @nome";
                    commando.Parameters.Add(new MySqlParameter("nome", $"%{nome}%"));
                }
                if (ativo.Equals("") == false)
                {
                    commando.CommandText += $" AND ativo = @ativo";
                    commando.Parameters.Add(new MySqlParameter("ativo", ativo));
                }
                if (id.Equals("") == false)
                {
                    commando.CommandText += $" AND id = @id";
                    commando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = commando.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Classes.Cliente
                    {
                        Nome = reader.GetString("nome"),
                        Ativo = reader.GetBoolean("ativo"),
                        Id = reader.GetInt32("id")
                    });
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return clientes;
        }

        public bool Create(Classes.Cliente cliente)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO clientes (nome, ativo) VALUES (@nome,1)", connection);
                comando.Parameters.Add(new MySqlParameter("nome", cliente.Nome));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.Cliente cliente)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"UPDATE clientes SET nome = @nome, ativo = @ativo WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("nome", cliente.Nome));
                comando.Parameters.Add(new MySqlParameter("ativo", cliente.Ativo));
                comando.Parameters.Add(new MySqlParameter("id", cliente.Id));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand("DELETE FROM clientes WHERE id = " + id, connection);
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}