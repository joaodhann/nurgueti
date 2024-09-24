﻿using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace nurgueti
{
    public class Banco
    {
        //Criando as variáveis publicas para conexão e consulta usadas em todo o projeto
        //Connection responsável pela conexão com o MySQL
        public static MySqlConnection Conexao;
        //Command responsável pela conexão com o MySQL
        public static MySqlCommand Comando;
        //Adapter responsável pelas instruções SQL a serem executadas
        public static MySqlDataAdapter Adaptador;
        //DataTable responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;


        public static void AbrirConexao()
        {
            try
            {
                //Estabelece os parâmetros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                //Abre a conexão com o banco de dados 
                Conexao.Open();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
            
        public static void FecharConexao()
        {
            try
            {
                //Fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);      
            }
        
        }

        public static void CriarBanco()
        {
            try
            {
                // Chama a função para abertura de conexão com o banco
                AbrirConexao();

                //Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATA BASE IF NOT EXISTS vendas; USE vendas", Conexao);
                //Executa a Query no MySQL (Raio do Workbench)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades" +
                                          "(id integer auto_increment primary key, " +
                                          "nome char(40), " +
                                          "uf char (02))", Conexao);
                Comando.ExecuteNonQuery();

                //Chama a função para o fechamento de conexão com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            
            }
    }
}
