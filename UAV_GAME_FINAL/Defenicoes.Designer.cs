namespace UAV_GAME_FINAL
{
    partial class Defenicoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Defenicoes));
            this.Colunas = new System.Windows.Forms.TextBox();
            this.Tipo2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.EscolherPosicao = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Linhas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Jogar = new System.Windows.Forms.Button();
            this.Nome2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Nome1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tipo1 = new System.Windows.Forms.ComboBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.Veiculos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Colunas
            // 
            this.Colunas.Enabled = false;
            this.Colunas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Colunas.Location = new System.Drawing.Point(456, 505);
            this.Colunas.Name = "Colunas";
            this.Colunas.Size = new System.Drawing.Size(49, 24);
            this.Colunas.TabIndex = 87;
            this.Colunas.Text = "10";
            this.Colunas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tipo2
            // 
            this.Tipo2.DisplayMember = "1";
            this.Tipo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tipo2.FormattingEnabled = true;
            this.Tipo2.Items.AddRange(new object[] {
            "Humano",
            "Máquina"});
            this.Tipo2.Location = new System.Drawing.Point(731, 266);
            this.Tipo2.Name = "Tipo2";
            this.Tipo2.Size = new System.Drawing.Size(133, 26);
            this.Tipo2.TabIndex = 86;
            this.Tipo2.ValueMember = "1";
            this.Tipo2.SelectedIndexChanged += new System.EventHandler(this.Tipo2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(582, 534);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(269, 36);
            this.label12.TabIndex = 85;
            this.label12.Text = "Caso não clique na opção em cima, os veículos serão colocados aleatoriamente no m" +
    "apa.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EscolherPosicao
            // 
            this.EscolherPosicao.BackColor = System.Drawing.Color.Green;
            this.EscolherPosicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EscolherPosicao.Cursor = System.Windows.Forms.Cursors.Default;
            this.EscolherPosicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EscolherPosicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EscolherPosicao.ForeColor = System.Drawing.Color.White;
            this.EscolherPosicao.Location = new System.Drawing.Point(601, 504);
            this.EscolherPosicao.Name = "EscolherPosicao";
            this.EscolherPosicao.Size = new System.Drawing.Size(237, 27);
            this.EscolherPosicao.TabIndex = 84;
            this.EscolherPosicao.Text = "Escolher posição dos veículos";
            this.EscolherPosicao.UseVisualStyleBackColor = false;
            this.EscolherPosicao.Click += new System.EventHandler(this.EscolherPosicao_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(234, 543);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(216, 27);
            this.label10.TabIndex = 82;
            this.label10.Text = "Número de Veículos";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(234, 504);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 27);
            this.label11.TabIndex = 81;
            this.label11.Text = "Número de Colunas";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Linhas
            // 
            this.Linhas.Enabled = false;
            this.Linhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Linhas.Location = new System.Drawing.Point(456, 467);
            this.Linhas.Name = "Linhas";
            this.Linhas.Size = new System.Drawing.Size(49, 24);
            this.Linhas.TabIndex = 80;
            this.Linhas.Text = "10";
            this.Linhas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(234, 466);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 27);
            this.label9.TabIndex = 79;
            this.label9.Text = "Número de Linhas";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Jogar
            // 
            this.Jogar.BackColor = System.Drawing.Color.LimeGreen;
            this.Jogar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Jogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jogar.ForeColor = System.Drawing.Color.Black;
            this.Jogar.Location = new System.Drawing.Point(802, 611);
            this.Jogar.Name = "Jogar";
            this.Jogar.Size = new System.Drawing.Size(121, 44);
            this.Jogar.TabIndex = 78;
            this.Jogar.Text = "Jogar";
            this.Jogar.UseVisualStyleBackColor = false;
            this.Jogar.Click += new System.EventHandler(this.Jogar_Click);
            // 
            // Nome2
            // 
            this.Nome2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome2.Location = new System.Drawing.Point(731, 310);
            this.Nome2.Name = "Nome2";
            this.Nome2.Size = new System.Drawing.Size(232, 24);
            this.Nome2.TabIndex = 77;
            this.Nome2.Text = "Jogador 2";
            this.Nome2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(596, 307);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 27);
            this.label8.TabIndex = 76;
            this.label8.Text = "Nome:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Nome1
            // 
            this.Nome1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome1.Location = new System.Drawing.Point(284, 310);
            this.Nome1.Name = "Nome1";
            this.Nome1.Size = new System.Drawing.Size(232, 24);
            this.Nome1.TabIndex = 75;
            this.Nome1.Text = "Jogador 1";
            this.Nome1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(149, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 27);
            this.label7.TabIndex = 74;
            this.label7.Text = "Nome";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(596, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 27);
            this.label6.TabIndex = 73;
            this.label6.Text = "Tipo de Jogador";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(149, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 27);
            this.label5.TabIndex = 72;
            this.label5.Text = "Tipo de Jogador";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(318, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(445, 64);
            this.label4.TabIndex = 71;
            this.label4.Text = "Defenições do Novo Jogo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.DarkRed;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(390, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 36);
            this.label3.TabIndex = 70;
            this.label3.Text = "Campo de Guerra";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkRed;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(169, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 35);
            this.label2.TabIndex = 69;
            this.label2.Text = "Jogador 1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(668, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 35);
            this.label1.TabIndex = 68;
            this.label1.Text = "Jogador 2";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tipo1
            // 
            this.Tipo1.DisplayMember = "1";
            this.Tipo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tipo1.FormattingEnabled = true;
            this.Tipo1.Items.AddRange(new object[] {
            "Humano",
            "Máquina"});
            this.Tipo1.Location = new System.Drawing.Point(284, 262);
            this.Tipo1.Name = "Tipo1";
            this.Tipo1.Size = new System.Drawing.Size(133, 26);
            this.Tipo1.TabIndex = 67;
            this.Tipo1.ValueMember = "1";
            this.Tipo1.SelectedIndexChanged += new System.EventHandler(this.Tipo1_SelectedIndexChanged);
            // 
            // ComboBox1
            // 
            this.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.DropDownWidth = 240;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.IntegralHeight = false;
            this.ComboBox1.ItemHeight = 20;
            this.ComboBox1.Items.AddRange(new object[] {
            "Amarelo",
            "Vermelho",
            "Verde",
            "Azul",
            "Violeta",
            "Branco",
            "Azul",
            "Magenta"});
            this.ComboBox1.Location = new System.Drawing.Point(284, 353);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(232, 26);
            this.ComboBox1.TabIndex = 7;
            this.ComboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox1_DrawItem);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(149, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 27);
            this.label13.TabIndex = 88;
            this.label13.Text = "Cor do Jogador";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(596, 352);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 27);
            this.label14.TabIndex = 89;
            this.label14.Text = "Cor do Jogador";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBox2
            // 
            this.ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.DropDownWidth = 240;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.IntegralHeight = false;
            this.ComboBox2.ItemHeight = 20;
            this.ComboBox2.Items.AddRange(new object[] {
            "Amarelo",
            "Vermelho",
            "Verde",
            "Azul",
            "Violeta",
            "Branco",
            "Azul",
            "Magenta"});
            this.ComboBox2.Location = new System.Drawing.Point(730, 353);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(233, 26);
            this.ComboBox2.TabIndex = 90;
            this.ComboBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox2_DrawItem);
            // 
            // Veiculos
            // 
            this.Veiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Veiculos.Location = new System.Drawing.Point(456, 546);
            this.Veiculos.Name = "Veiculos";
            this.Veiculos.Size = new System.Drawing.Size(49, 24);
            this.Veiculos.TabIndex = 91;
            this.Veiculos.Text = "16";
            this.Veiculos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Defenicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1113, 757);
            this.Controls.Add(this.Veiculos);
            this.Controls.Add(this.ComboBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Colunas);
            this.Controls.Add(this.Tipo2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.EscolherPosicao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Linhas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Jogar);
            this.Controls.Add(this.Nome2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Nome1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tipo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Defenicoes";
            this.Text = "UAV GAME";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Defenicoes_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Colunas;
        private System.Windows.Forms.ComboBox Tipo2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button EscolherPosicao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Linhas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Jogar;
        private System.Windows.Forms.TextBox Nome2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Nome1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Tipo1;
        private System.Windows.Forms.ComboBox ComboBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ComboBox2;
        private System.Windows.Forms.TextBox Veiculos;
    }
}