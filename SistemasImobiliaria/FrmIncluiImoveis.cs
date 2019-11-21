using Npgsql;
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
    public partial class FrmIncluiImoveis : Form
    {
        internal NpgsqlConnection conexao = null;
        ImoveisCtr imoveisCtr;

        public FrmIncluiImoveis(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
            imoveisCtr = new ImoveisCtr(conexao);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int imovelID = int.Parse(tbImovel.Text);
            String estado = tbEstado.Text;
            String cidade = tbCidade.Text;
            String endereco = tbEndereco.Text;

            Imoveis imoveis = new Imoveis();
            imoveis.i_imoveis = imovelID;
            imoveis.estado = estado;
            imoveis.cidade = cidade;
            imoveis.endereco = endereco;

            bool incluiu = imoveisCtr.setIncluiImoveis(imoveis);
            if (incluiu)
            {
                MessageBox.Show("Imóvel cadastrado com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar imóvel!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
