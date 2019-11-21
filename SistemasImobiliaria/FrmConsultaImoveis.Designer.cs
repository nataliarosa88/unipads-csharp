﻿namespace SistemasImobiliaria
{
    partial class FrmConsultaImoveis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.i_imoveis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCampo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.i_imoveis,
            this.endereco,
            this.cidade,
            this.estado});
            this.dataGridView1.Location = new System.Drawing.Point(18, 105);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(838, 451);
            this.dataGridView1.TabIndex = 0;
            // 
            // i_imoveis
            // 
            this.i_imoveis.DataPropertyName = "i_imoveis";
            this.i_imoveis.HeaderText = "ID do Imóvel";
            this.i_imoveis.Name = "i_imoveis";
            // 
            // endereco
            // 
            this.endereco.DataPropertyName = "endereco";
            this.endereco.HeaderText = "Endereço";
            this.endereco.Name = "endereco";
            // 
            // cidade
            // 
            this.cidade.DataPropertyName = "cidade";
            this.cidade.HeaderText = "Cidade";
            this.cidade.Name = "cidade";
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 575);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 66);
            this.button1.TabIndex = 1;
            this.button1.Text = "Incluir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 575);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 66);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remover";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 575);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 66);
            this.button3.TabIndex = 3;
            this.button3.Text = "Alterar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Location = new System.Drawing.Point(460, 40);
            this.textBoxDescricao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(394, 26);
            this.textBoxDescricao.TabIndex = 15;
            this.textBoxDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDescricao_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Descrição:";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Contém",
            "Inicia com",
            "Termina com",
            "Igual",
            "Maior ou igual",
            "Menor ou igual"});
            this.comboBoxTipo.Location = new System.Drawing.Point(237, 38);
            this.comboBoxTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(204, 28);
            this.comboBoxTipo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo:";
            // 
            // comboBoxCampo
            // 
            this.comboBoxCampo.FormattingEnabled = true;
            this.comboBoxCampo.Items.AddRange(new object[] {
            "ID do Imóvel",
            "Endereco",
            "Cidade",
            "Estado"});
            this.comboBoxCampo.Location = new System.Drawing.Point(16, 38);
            this.comboBoxCampo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCampo.Name = "comboBoxCampo";
            this.comboBoxCampo.Size = new System.Drawing.Size(202, 28);
            this.comboBoxCampo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Campos:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 651);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 66);
            this.button4.TabIndex = 16;
            this.button4.Text = "Relatório de Imóveis";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(200, 651);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(351, 66);
            this.button5.TabIndex = 17;
            this.button5.Text = "Relatório de Aluguéis por Imóvel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FrmConsultaImoveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(874, 735);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCampo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmConsultaImoveis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Imóveis";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmConsultaImoveis_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCampo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_imoveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}