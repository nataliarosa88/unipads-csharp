﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SistemasImobiliaria.Modelo;
using System.Windows.Forms;
using System.Data;

namespace SistemasImobiliaria.Dao
{
    class ImoveisDao
    {
        private NpgsqlConnection conexao;

        public ImoveisDao(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool create(Imoveis imoveis)
        {
            bool incluiu = false;
            try
            {
                String sql = "insert into imoveis(i_imoveis,endereco, cidade, estado) values(@i_imoveis,@endereco, @cidade, @estado)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@i_imoveis", NpgsqlTypes.NpgsqlDbType.Integer).Value = imoveis.i_imoveis;
                cmd.Parameters.Add("@endereco", NpgsqlTypes.NpgsqlDbType.Varchar).Value = imoveis.endereco;
                cmd.Parameters.Add("@cidade", NpgsqlTypes.NpgsqlDbType.Varchar).Value = imoveis.cidade;
                cmd.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar).Value = imoveis.estado;

                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de SQL:" + erro.Message);
                Console.WriteLine("Erro de SQL:" + erro.Message);
            }
                return incluiu;
        }

        public bool update(Imoveis imoveis)
        {
            bool alterou = false;
            try
            {
                String sql = "update imoveis set endereco = @endereco,cidade = @cidade, estado =@estado where i_imoveis = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@endereco", NpgsqlTypes.NpgsqlDbType.Varchar).Value = imoveis.endereco;
                cmd.Parameters.Add("@cidade", NpgsqlTypes.NpgsqlDbType.Varchar).Value = imoveis.cidade;
                cmd.Parameters.Add("@estado", NpgsqlTypes.NpgsqlDbType.Varchar).Value = imoveis.estado;
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = imoveis.i_imoveis;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql:" + erro.Message);
                Console.WriteLine("Erro de sql:" + erro.Message);
            }
            return alterou;
        }

        public bool delete(int codigo)
        {
            bool excluiu = false;
            try
            {
                String sql = "delete from imoveis where i_imoveis = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = codigo;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de sql:" + erro.Message);
                Console.WriteLine("Erro de sql:" + erro.Message);
            }
            return excluiu;
        }

        public DataTable retrieveByField(int campo, int tipo, string descricao)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM imoveis";
                String nomeCampoOrdenacao = "i_imoveis";
                switch (campo)
                {
                    case 0:
                        sql += " where cast (i_imoveis as varchar(20)) ";
                        nomeCampoOrdenacao = "i_imoveis";
                        break;
                    case 1:
                        sql += " where endereco ";
                        nomeCampoOrdenacao = "endereco";
                        break;
                    case 2:
                        sql += " where cidade ";
                        nomeCampoOrdenacao = "cidade";
                        break;
                    default:
                        sql += " where estado ";
                        nomeCampoOrdenacao = "estado";
                        break;
                }
                switch (tipo)
                {
                    case 0:
                        sql += " like '%" + descricao + "%'";
                        break;
                    case 1:
                        sql += " like '" + descricao + "%'";
                        break;
                    case 2:
                        sql += " like '%" + descricao + "'";
                        break;
                    case 3:
                        sql += " = '" + descricao + "'";
                        break;
                    case 4:
                        sql += " >= '" + descricao + "'";
                        break;
                    default:
                        sql += " <= '" + descricao + "'";
                        break;
                }
                sql += " order by " + nomeCampoOrdenacao;
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = sql;
                NpgsqlDataAdapter dat = new NpgsqlDataAdapter(cmd);
                dat.Fill(dt);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de SQL:" + erro.Message);
                Console.WriteLine("Erro de SQL:" + erro.Message);
            }

            return dt;
        }

        public DataTable retrieveAll()
        {
            DataTable dt = new DataTable();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "select * from imoveis";
                NpgsqlDataAdapter dat = new NpgsqlDataAdapter(cmd);
                dat.Fill(dt);
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de SQL:" + erro.Message);
                Console.WriteLine("Erro de SQL:" + erro.Message);
            }

            return dt;
        }
    }
}
