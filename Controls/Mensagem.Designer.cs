namespace Controls
{
    partial class Mensagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensagem));
            this.panelBorda = new System.Windows.Forms.Panel();
            this.Icone = new System.Windows.Forms.PictureBox();
            this.buttonX = new System.Windows.Forms.Button();
            this.btnNao = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSim = new System.Windows.Forms.Button();
            this.Pergunta = new System.Windows.Forms.PictureBox();
            this.Informacao = new System.Windows.Forms.PictureBox();
            this.Erro = new System.Windows.Forms.PictureBox();
            this.Aviso = new System.Windows.Forms.PictureBox();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.panelBorda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pergunta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Informacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aviso)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBorda
            // 
            this.panelBorda.BackColor = System.Drawing.Color.Transparent;
            this.panelBorda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorda.Controls.Add(this.Icone);
            this.panelBorda.Controls.Add(this.buttonX);
            this.panelBorda.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorda.Location = new System.Drawing.Point(0, 0);
            this.panelBorda.Name = "panelBorda";
            this.panelBorda.Size = new System.Drawing.Size(416, 24);
            this.panelBorda.TabIndex = 1;
            this.panelBorda.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorda_MouseDown);
            this.panelBorda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorda_MouseMove);
            this.panelBorda.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorda_MouseUp);
            // 
            // Icone
            // 
            this.Icone.BackColor = System.Drawing.Color.Transparent;
            this.Icone.Location = new System.Drawing.Point(0, 0);
            this.Icone.Name = "Icone";
            this.Icone.Size = new System.Drawing.Size(29, 21);
            this.Icone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icone.TabIndex = 10;
            this.Icone.TabStop = false;
            // 
            // buttonX
            // 
            this.buttonX.BackColor = System.Drawing.Color.Transparent;
            this.buttonX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonX.BackgroundImage")));
            this.buttonX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonX.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonX.FlatAppearance.BorderSize = 0;
            this.buttonX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX.ForeColor = System.Drawing.Color.White;
            this.buttonX.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonX.Location = new System.Drawing.Point(382, 0);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(32, 22);
            this.buttonX.TabIndex = 8;
            this.buttonX.TabStop = false;
            this.buttonX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonX.UseVisualStyleBackColor = false;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // btnNao
            // 
            this.btnNao.BackColor = System.Drawing.Color.Transparent;
            this.btnNao.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNao.Location = new System.Drawing.Point(329, 140);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(75, 23);
            this.btnNao.TabIndex = 3;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = false;
            this.btnNao.Visible = false;
            this.btnNao.Click += new System.EventHandler(this.btnNao_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.Location = new System.Drawing.Point(167, 140);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSim
            // 
            this.btnSim.BackColor = System.Drawing.Color.Transparent;
            this.btnSim.Location = new System.Drawing.Point(248, 140);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(75, 23);
            this.btnSim.TabIndex = 2;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = false;
            this.btnSim.Visible = false;
            this.btnSim.Click += new System.EventHandler(this.btnSim_Click);
            // 
            // Pergunta
            // 
            this.Pergunta.Image = ((System.Drawing.Image)(resources.GetObject("Pergunta.Image")));
            this.Pergunta.Location = new System.Drawing.Point(12, 54);
            this.Pergunta.Name = "Pergunta";
            this.Pergunta.Size = new System.Drawing.Size(100, 94);
            this.Pergunta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pergunta.TabIndex = 5;
            this.Pergunta.TabStop = false;
            this.Pergunta.Visible = false;
            // 
            // Informacao
            // 
            this.Informacao.Image = ((System.Drawing.Image)(resources.GetObject("Informacao.Image")));
            this.Informacao.Location = new System.Drawing.Point(12, 54);
            this.Informacao.Name = "Informacao";
            this.Informacao.Size = new System.Drawing.Size(100, 94);
            this.Informacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Informacao.TabIndex = 6;
            this.Informacao.TabStop = false;
            this.Informacao.Visible = false;
            // 
            // Erro
            // 
            this.Erro.Image = ((System.Drawing.Image)(resources.GetObject("Erro.Image")));
            this.Erro.Location = new System.Drawing.Point(12, 54);
            this.Erro.Name = "Erro";
            this.Erro.Size = new System.Drawing.Size(100, 94);
            this.Erro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Erro.TabIndex = 7;
            this.Erro.TabStop = false;
            this.Erro.Visible = false;
            // 
            // Aviso
            // 
            this.Aviso.BackColor = System.Drawing.Color.Transparent;
            this.Aviso.Image = ((System.Drawing.Image)(resources.GetObject("Aviso.Image")));
            this.Aviso.Location = new System.Drawing.Point(12, 54);
            this.Aviso.Name = "Aviso";
            this.Aviso.Size = new System.Drawing.Size(100, 94);
            this.Aviso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Aviso.TabIndex = 8;
            this.Aviso.TabStop = false;
            this.Aviso.Visible = false;
            // 
            // lblMensagem
            // 
            this.lblMensagem.BackColor = System.Drawing.Color.Transparent;
            this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.Black;
            this.lblMensagem.Location = new System.Drawing.Point(149, 54);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(255, 76);
            this.lblMensagem.TabIndex = 9;
            // 
            // Mensagem
            // 
            this.AcceptButton = this.btnSim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnNao;
            this.ClientSize = new System.Drawing.Size(416, 175);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.Aviso);
            this.Controls.Add(this.Erro);
            this.Controls.Add(this.Informacao);
            this.Controls.Add(this.Pergunta);
            this.Controls.Add(this.btnSim);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnNao);
            this.Controls.Add(this.panelBorda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 175);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 175);
            this.Name = "Mensagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMensagem_Load);
            this.panelBorda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Icone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pergunta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Informacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aviso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBorda;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSim;
        private System.Windows.Forms.PictureBox Pergunta;
        private System.Windows.Forms.PictureBox Informacao;
        private System.Windows.Forms.PictureBox Erro;
        private System.Windows.Forms.PictureBox Aviso;
        private System.Windows.Forms.PictureBox Icone;
        public System.Windows.Forms.Label lblMensagem;
    }
}