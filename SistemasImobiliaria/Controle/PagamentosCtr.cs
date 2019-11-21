﻿using Npgsql;
using SistemasImobiliaria.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasImobiliaria.Controle
{
    class PagamentosCtr
    {
        public static DataTable getConsultaPagamentos(NpgsqlConnection conexao)
        {
            DataTable dt = new DataTable();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "select * from pagamentos";
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

        public static DataTable getConsultaPagamentos(NpgsqlConnection conexao, int campo, int tipo, String descricao)
        {
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM pagamentos";
                String nomeCampoOrdenacao = "i_pagamentos";
                switch (campo)
                {
                    case 0:
                        sql += " where cast (i_pagamentos as varchar(20)) ";
                        nomeCampoOrdenacao = "i_pagamentos";
                        break;
                    case 1:
                        sql += " where parcelas ";
                        nomeCampoOrdenacao = "parcelas";
                        break;
                    case 2:
                        sql += " where valor ";
                        nomeCampoOrdenacao = "valor";
                        break;
                    default:
                        sql += " where tipo ";
                        nomeCampoOrdenacao = "tipo";
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
                        sql += " >= '%" + descricao + "'";
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

        public static bool setIncluiPagamentos(NpgsqlConnection conexao, Pagamentos pagamentos)
        {
            bool incluiu = false;
            try
            {
                String sql = "insert into pagamentos(i_pagamentos,parcelas, valor, tipo) values(@i_pagamentos,@parcelas, @valor, @tipo)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@i_pagamentos", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagamentos.i_pagamentos;
                cmd.Parameters.Add("@parcelas", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagamentos.parcelas;
                cmd.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Double).Value = pagamentos.valor;
                cmd.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pagamentos.tipo;

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

        public static bool setExcluiPagamentos(NpgsqlConnection conexao, int codigo)
        {
            bool excluiu = false;
            try
            {
                String sql = "delete from pagamentos where i_pagamentos = @codigo";
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

        public static bool setAlteraPagamentos(NpgsqlConnection conexao, Pagamentos pagamentos)
        {
            bool alterou = false;
            try
            {
                String sql = "update pagamentos set parcelas = @parcelas, valor = @valor, tipo = @tipo where i_pagamentos = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@parcelas", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagamentos.parcelas;
                cmd.Parameters.Add("@valor", NpgsqlTypes.NpgsqlDbType.Double).Value = pagamentos.valor;
                cmd.Parameters.Add("@tipo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = pagamentos.tipo;
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = pagamentos.i_pagamentos;

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
    }
}

