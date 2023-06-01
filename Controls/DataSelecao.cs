using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public class DataSelecao : DateTimePicker
    {
        //Campos
        //Aparencia do controle
        private Color corSkin = Color.MediumSlateBlue;
        private Color corTexto = Color.White;
        private Color corBorda = Color.PaleVioletRed;
        private int tamanhoBorda = 0;
        //Outros campos
        private bool calendarioAberto = false;
        private Image iconeCalendario = Properties.Resources.CalendarioImagem;
        private RectangleF iconeBotaoArea;
        private const int larguraIcone = 34;
        private const int larguraFlechaIcone = 17;

        public Color CorSkin { get => corSkin;
            set
            {
                corSkin = value;
                if (corSkin.GetBrightness() >= 0.8F)
                    iconeCalendario = Properties.Resources.CalendarioImagemPreto;
                else
                    iconeCalendario = Properties.Resources.CalendarioImagem;
                this.Invalidate();
            }
        }
        public Color CorTexto { get => corTexto; set { corTexto = value; this.Invalidate(); } }
        public Color CorBorda { get => corBorda; set { corBorda = value; this.Invalidate(); } }
        public int TamanhoBorda { get => tamanhoBorda; set { tamanhoBorda = value; this.Invalidate(); } }

        //Construtor
        public DataSelecao()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MinimumSize = new Size(0,35);
            this.Font = new Font(this.Font.Name, 9.5F);
        }

        //Métodos
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            calendarioAberto = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            calendarioAberto = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = this.CreateGraphics())
            using (Pen penBorder = new Pen(corBorda, tamanhoBorda))
            using (SolidBrush skinBrush = new SolidBrush(corSkin))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(corTexto))
            using (StringFormat textFormat = new StringFormat())
            {
                RectangleF clientArea = new RectangleF(0, 0, this.Width - 0.5F, this.Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - larguraIcone, 0, larguraIcone, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;
                //Draw surface
                graphics.FillRectangle(skinBrush, clientArea);
                //Draw text
                graphics.DrawString("   " + this.Text, this.Font, textBrush, clientArea, textFormat);
                //Draw open calendar icon highlight
                if (calendarioAberto == true) graphics.FillRectangle(openIconBrush, iconArea);
                //Draw border 
                if (tamanhoBorda >= 1) graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
                //Draw icon
                graphics.DrawImage(iconeCalendario, this.Width - iconeCalendario.Width - 9, (this.Height - iconeCalendario.Height) / 2);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconeBotaoArea = new RectangleF(this.Width - iconWidth, 0, iconWidth, this.Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (iconeBotaoArea.Contains(e.Location))
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
        }

        //Private methods
        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(this.Text, this.Font).Width;
            if (textWidh <= this.Width - (larguraIcone + 20))
                return larguraIcone;
            else return larguraFlechaIcone;
        }
    }
}

