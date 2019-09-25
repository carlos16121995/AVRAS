using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using MySql.Data.MySqlClient;

namespace avras.web.Models
{
    public class Script
    {
        MySqlConnection _conexao = null;

        public Script()
        {
            
            _conexao = new MySqlConnection(strcon);
        }

        public void Abrir()
        {
            _conexao.Open();
        }

        public void Fechar()
        {
            _conexao.Close();
        }

        /// <summary>
        /// Executa um select com os parametros já definidos
        /// </summary>
        /// <param name="select">String com o select</param>
        /// <param name="msgErro">Menssagem caso ocorra algum erro</param>
        /// <returns>Datatable com o dados</returns>
        public void ExecutarProcedure(string procedure)
        {

            MySqlCommand cmd = new MySqlCommand(procedure, _conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Abrir();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Fechar();
            }
        }

        
    }
}
