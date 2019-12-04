﻿using SistemasImobiliaria.Controle;
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
    public partial class FrmConsultaImoveis : Form
    {
        ImoveisCtr imoveisCtr;

        public FrmConsultaImoveis()
        {
            InitializeComponent();
            comboBoxCampo.SelectedIndex = 0;
            comboBoxTipo.SelectedIndex = 0;
            imoveisCtr = new ImoveisCtr();
            atualizaTela();
        }

        private void atualizaTela()
        {
            if (textBoxDescricao.Text.Length > 0)
            {
                dataGridView1.DataSource = imoveisCtr.getConsultaImoveis(comboBoxCampo.SelectedIndex, comboBoxTipo.SelectedIndex, textBoxDescricao.Text);
            }
            else
            {
                dataGridView1.DataSource = imoveisCtr.getConsultaImoveis();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmIncluiImoveis form = new FrmIncluiImoveis();
            form.ShowDialog();
            atualizaTela();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int imovelID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            String endereco = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String cidade = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String estado = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            Imoveis imoveis = new Imoveis();
            imoveis.i_imoveis = imovelID;
            imoveis.estado = estado;
            imoveis.cidade = cidade;
            imoveis.endereco = endereco;

            bool excluido = imoveisCtr.setExcluiImoveis(imoveis);
            if (excluido)
            {
                MessageBox.Show("Imóvel excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao excluir imóvel!");
            }
            atualizaTela();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int codigoImovel = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            String endereco = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String cidade = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String estado = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            Imoveis imoveis = new Imoveis();
            imoveis.i_imoveis = codigoImovel;
            imoveis.endereco = endereco;
            imoveis.cidade = cidade;
            imoveis.estado = estado;

            bool alterou = imoveisCtr.setAlteraImoveis(imoveis);
            if (alterou)
            {
                MessageBox.Show("Imóvel alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao alterar imóvel!");
            }
            atualizaTela();
        }

        private void textBoxDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                atualizaTela();
            }
        }

        private void FrmConsultaImoveis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                atualizaTela();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmRelacaoDeImoveis form = new FrmRelacaoDeImoveis();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmRelAlugueisPorImovel form = new FrmRelAlugueisPorImovel();
            form.Show();
        }
    }
}
