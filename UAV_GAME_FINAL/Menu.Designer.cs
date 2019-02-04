namespace UAV_GAME_FINAL
{
    partial class Menu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Sair = new System.Windows.Forms.Button();
            this.Estatisticas = new System.Windows.Forms.Button();
            this.carregar = new System.Windows.Forms.Button();
            this.NovoJogo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(261, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(377, 67);
            this.label4.TabIndex = 23;
            this.label4.Text = "UAV GAME";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(805, 615);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // Sair
            // 
            this.Sair.BackColor = System.Drawing.Color.DarkRed;
            this.Sair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sair.ForeColor = System.Drawing.SystemColors.Control;
            this.Sair.Location = new System.Drawing.Point(392, 491);
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(123, 45);
            this.Sair.TabIndex = 21;
            this.Sair.Text = "Sair";
            this.Sair.UseVisualStyleBackColor = false;
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // Estatisticas
            // 
            this.Estatisticas.BackColor = System.Drawing.Color.DarkRed;
            this.Estatisticas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Estatisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estatisticas.ForeColor = System.Drawing.SystemColors.Control;
            this.Estatisticas.Location = new System.Drawing.Point(392, 408);
            this.Estatisticas.Name = "Estatisticas";
            this.Estatisticas.Size = new System.Drawing.Size(123, 45);
            this.Estatisticas.TabIndex = 20;
            this.Estatisticas.Text = "Estatísticas";
            this.Estatisticas.UseVisualStyleBackColor = false;
            this.Estatisticas.Click += new System.EventHandler(this.Estatisticas_Click);
            // 
            // carregar
            // 
            this.carregar.BackColor = System.Drawing.Color.DarkRed;
            this.carregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.carregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carregar.ForeColor = System.Drawing.SystemColors.Control;
            this.carregar.Location = new System.Drawing.Point(339, 326);
            this.carregar.Name = "carregar";
            this.carregar.Size = new System.Drawing.Size(224, 45);
            this.carregar.TabIndex = 19;
            this.carregar.Text = "Carregar Jogo Guardado";
            this.carregar.UseVisualStyleBackColor = false;
            // 
            // NovoJogo
            // 
            this.NovoJogo.BackColor = System.Drawing.Color.DarkRed;
            this.NovoJogo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NovoJogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NovoJogo.ForeColor = System.Drawing.SystemColors.Control;
            this.NovoJogo.Location = new System.Drawing.Point(392, 232);
            this.NovoJogo.Name = "NovoJogo";
            this.NovoJogo.Size = new System.Drawing.Size(123, 45);
            this.NovoJogo.TabIndex = 18;
            this.NovoJogo.Text = "Novo Jogo";
            this.NovoJogo.UseVisualStyleBackColor = false;
            this.NovoJogo.Click += new System.EventHandler(this.NovoJogo_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(923, 726);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Sair);
            this.Controls.Add(this.Estatisticas);
            this.Controls.Add(this.carregar);
            this.Controls.Add(this.NovoJogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Menu";
            this.Text = "UAV GAME";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Sair;
        private System.Windows.Forms.Button Estatisticas;
        private System.Windows.Forms.Button carregar;
        private System.Windows.Forms.Button NovoJogo;
    }
}

