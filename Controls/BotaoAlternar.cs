using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Controls
{
    public class BotaoAlternar : CheckBox
    {
        //Campos
        private Color corFundoAtivo = Color.MediumSlateBlue;
        private Color corAtivo = Color.WhiteSmoke;
        private Color corFundoInativo = Color.Gray;
        private Color corInativo = Color.Gainsboro;
        private bool estiloSolido = true;
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {

            }
        } 
        public Color CorFundoAtivo {
            get 
            {
                return corFundoAtivo; 
            }

            set 
            {
                corFundoAtivo = value;
                this.Invalidate();
            } 
        }
        public Color CorAtivo {
            get
            {
                return corAtivo;
            }

            set
            {
                corAtivo = value;
                this.Invalidate();
            }
        }
        public Color CorFundoInativo {
            get
            {
                return corFundoInativo;
            }

            set
            {
                corFundoInativo = value;
                this.Invalidate();
            }
        }
        public Color CorInativo {
            get
            {
                return corInativo;
            }

            set
            {
                corInativo = value;
                this.Invalidate();
            }
        }
        [DefaultValue(true)]
        public bool EstiloSolido
        {
            get
            {
                return estiloSolido;
            }
            set
            {
                estiloSolido = value;
                this.Invalidate();
            }
        }


        //Construtor
        public BotaoAlternar()
        {
            this.MinimumSize = new Size(45, 22);
        }
        //Metodos
        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(this.Width-arcSize-2,0,arcSize,arcSize); 
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            if (this.Checked)
            {
                if (estiloSolido)
                {
                    pevent.Graphics.FillPath(new SolidBrush(corFundoAtivo), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(corFundoAtivo, 2), GetFigurePath());
                }
                
                pevent.Graphics.FillEllipse(new SolidBrush(corAtivo),new Rectangle(this.Width-this.Height+1,2,toggleSize,toggleSize));
            }
            else
            {
                if (estiloSolido)
                {
                    pevent.Graphics.FillPath(new SolidBrush(corFundoInativo), GetFigurePath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(corFundoInativo, 2), GetFigurePath());
                }

                pevent.Graphics.FillEllipse(new SolidBrush(corInativo), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
