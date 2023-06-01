using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Controls
{
    public partial class Mensagem : Form
    {
        public static TipoMensagem Tipo { get; set; }
        public static string Texto { get; set; }
        public enum TipoMensagem { Aviso, Erro, Informacao, Pergunta }
        public Mensagem(TipoMensagem tipo, string texto)
        {
            InitializeComponent();
            Texto = texto;
            Tipo = tipo;
        }

        private void frmMensagem_Load(object sender, EventArgs e)
        {
            switch (Tipo)
            {
                case TipoMensagem.Aviso:
                    Aviso.Visible = true;
                    btnOk.Visible = true;
                    SystemSounds.Beep.Play();
                    lblMensagem.Text = Texto;
                    break;
                case TipoMensagem.Erro:
                    Erro.Visible = true;
                    btnOk.Visible = true;
                    SystemSounds.Hand.Play();
                    lblMensagem.Text = Texto;
                    break;
                case TipoMensagem.Informacao:
                    Informacao.Visible = true;
                    btnOk.Visible = true;
                    SystemSounds.Exclamation.Play();
                    lblMensagem.Text = Texto;
                    break;
                case TipoMensagem.Pergunta:
                    Pergunta.Visible = true;
                    btnNao.Visible = true;
                    btnSim.Visible = true;
                    SystemSounds.Question.Play();
                    lblMensagem.Text = Texto;
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
        bool mover = false;
        Point Posicao_Inicial;
        private void panelBorda_MouseDown(object sender, MouseEventArgs e)
        {
            mover = true;
            Posicao_Inicial = new Point(e.X, e.Y);
        }

        private void panelBorda_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void panelBorda_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                Point Nova_Posicao = PointToScreen(e.Location);
                Location = new Point(Nova_Posicao.X - this.Posicao_Inicial.X, Nova_Posicao.Y - Posicao_Inicial.Y);

            }
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
