﻿using ConFin.modelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemasImobiliaria.Modelo;
using System.Windows.Forms;
using System.Data;

namespace SistemasImobiliaria.Dao
{
    class ImoveisDao
    {
       
        private NpgsqlConnection conexao = Conexao.getConexao();
        private Filtro filtro = new Filtro();
        

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

        public bool delete(Imoveis imoveis)
        {
            bool excluiu = false;
            try
            {
                String sql = "delete from imoveis where i_imoveis = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = imoveis.i_imoveis;
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

        public List<Imoveis> retrieveByField(Filtro filtro)
        {
            DataTable dt = new DataTable();
            List<Imoveis> convertedList = new List<Imoveis>();
            try
            {
                String sql = "SELECT * FROM imoveis";
                String nomeCampoOrdenacao = "i_imoveis";
                switch (filtro.campo)
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
                switch (filtro.tipo)
                {
                    case 0:
                        sql += " like '%" + filtro.descricao + "%'";
                        break;
                    case 1:
                        sql += " like '" + filtro.descricao + "%'";
                        break;
                    case 2:
                        sql += " like '%" + filtro.descricao + "'";
                        break;
                    case 3:
                        sql += " = '" + filtro.descricao + "'";
                        break;
                    case 4:
                        sql += " >= '" + filtro.descricao + "'";
                        break;
                    default:
                        sql += " <= '" + filtro.descricao + "'";
                        break;
                }
                sql += " order by " + nomeCampoOrdenacao;
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = sql;
                NpgsqlDataAdapter dat = new NpgsqlDataAdapter(cmd);
                dat.Fill(dt);

            convertedList = (from imovel in dt.AsEnumerable()
                                     select new Imoveis()
                                     {
                                         i_imoveis = Convert.ToInt32(imovel["i_imoveis"]),
                                         endereco = Convert.ToString(imovel["endereco"]),
                                         cidade = Convert.ToString(imovel["cidade"]),
                                         estado = Convert.ToString(imovel["estado"])
                                     }).ToList();

            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de SQL:" + erro.Message);
                Console.WriteLine("Erro de SQL:" + erro.Message);
            }

            return convertedList;
        }

        public List<Imoveis> retrieveAll()
        {
            DataTable dt = new DataTable();
            List<Imoveis> convertedList = new List<Imoveis>();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "select * from imoveis";
                NpgsqlDataAdapter dat = new NpgsqlDataAdapter(cmd);
                dat.Fill(dt);
                convertedList = (from imovel in dt.AsEnumerable()
                                 select new Imoveis()
                                 {
                                     i_imoveis = Convert.ToInt32(imovel["i_imoveis"]),
                                     endereco = Convert.ToString(imovel["endereco"]),
                                     cidade = Convert.ToString(imovel["cidade"]),
                                     estado = Convert.ToString(imovel["estado"])
                                 }).ToList();
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro de SQL:" + erro.Message);
                Console.WriteLine("Erro de SQL:" + erro.Message);
            }

            return convertedList;
        }
    }
}
