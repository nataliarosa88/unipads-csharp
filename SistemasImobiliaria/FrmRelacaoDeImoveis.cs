using Npgsql;
using SistemasImobiliaria.Controle;
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
    public partial class FrmRelacaoDeImoveis : Form
    {
        internal NpgsqlConnection conexao = null;
        ImoveisCtr imoveisCtr;

        public FrmRelacaoDeImoveis(NpgsqlConnection conexao)
        {
            this.conexao = conexao;
            imoveisCtr = new ImoveisCtr(conexao);
            InitializeComponent();
        }

        private void FrmRelacaoDeImoveis_Load(object sender, EventArgs e)
        {
            ImoveisBindingSource.DataSource = imoveisCtr.getConsultaImoveis();
            this.reportViewer1.RefreshReport();
        }
    }
}
