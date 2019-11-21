﻿using Npgsql;
using SistemasImobiliaria.Controle;
using SistemasImobiliaria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasImobiliaria
{
    public partial class FrmConsultaPagamentos : Form
    {
        internal NpgsqlConnection conexao = null;

        public FrmConsultaPagamentos(NpgsqlConnection conexao)
        {
            InitializeComponent();
            comboBoxCampo.SelectedIndex = 0;
            comboBoxTipo.SelectedIndex = 0;
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            if (textBoxDescricao.Text.Length > 0)
            {
                dataGridView1.DataSource = PagamentosCtr.getConsultaPagamentos(conexao, comboBoxCampo.SelectedIndex, comboBoxTipo.SelectedIndex, textBoxDescricao.Text);
            }
            else
            {
                dataGridView1.DataSource = PagamentosCtr.getConsultaPagamentos(conexao);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmIncluiPagamentos form = new FrmIncluiPagamentos(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int codigoPagamento = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool excluido = PagamentosCtr.setExcluiPagamentos(conexao, codigoPagamento);
            if (excluido)
            {
                MessageBox.Show("Pagamento excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao excluir pagamento!");
            }
            atualizaTela();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int codigoPagamento = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int parcelas = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            double valor = double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            String tipo = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            Pagamentos pagamentos = new Pagamentos();
            pagamentos.i_pagamentos = codigoPagamento;
            pagamentos.parcelas = parcelas;
            pagamentos.valor = valor;
            pagamentos.tipo = tipo;

            bool alterou = PagamentosCtr.setAlteraPagamentos(conexao, pagamentos);
            if (alterou)
            {
                MessageBox.Show("Pagamento alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao alterar pagamento");
            }
            atualizaTela();
        }

        private void FrmConsultaPagamentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                atualizaTela();
            }
        }

        private void textBoxDescricao_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                atualizaTela();
            }
        }
    }
}
