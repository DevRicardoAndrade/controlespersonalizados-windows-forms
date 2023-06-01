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
    public class Botao : Button
    {
        //Campos
        private int BordaTamanho = 0;
        private int BordaRadius = 40;
        private Color BordaCor = Color.LightBlue;
        [Category("BotãoPersonalizado")]
        public int bordaTamanho
        {
            get
            {
                return BordaTamanho;
            }
            set
            {
                BordaTamanho = value;
                this.Invalidate();
            }
        }
        [Category("BotãoPersonalizado")]
        public int bordaRadius
        {
            get
            {
                return BordaRadius;
            }
            set
            {
                BordaRadius = value;
                this.Invalidate();
            }
        }
        [Category("BotãoPersonalizado")]
        public Color bordaCor
        {
            get
            {
                return BordaCor;
            }
            set
            {
                BordaCor = value;
                this.Invalidate();
            }
        }
        [Category("BotãoPersonalizado")]
        public Color CorFundo
        {
            get
            {
                    return this.BackColor;
            }
            set
            {
                    this.BackColor = value;
            }
        }
        [Category("BotãoPersonalizado")]
        public Color CorTexto
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }

        //Construtor
        public Botao()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150,40);
            this.BackColor = Color.LightBlue;
            this.FlatAppearance.BorderColor = BordaCor;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Botao_Resize);
        }

        private void Botao_Resize(object sender, EventArgs e)
        {
            if(bordaRadius > this.Height)
            {
                BordaRadius = this.Height;
            }
        }

        //Metodos
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);   
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectSurface = new RectangleF(0,0,this.Width,this.Height);
            RectangleF rectBorder = new RectangleF(1,1,this.Width - 0.8F,this.Height - 1);

            if(BordaRadius > 2)//Botao Arredondado
            {
                using(GraphicsPath pathSurface = GetFigurePath(rectSurface,BordaRadius))
                {
                    using(GraphicsPath pathBorder = GetFigurePath(rectBorder,BordaRadius - 1F))
                    {
                        using(Pen penSurface = new Pen(this.Parent.BackColor, 2))
                        {
                            using(Pen penBorder = new Pen(BordaCor, BordaTamanho))
                            {
                                penBorder.Alignment = PenAlignment.Inset;
                                this.Region = new Region(pathSurface);

                                pevent.Graphics.DrawPath(penSurface, pathSurface);

                                if(BordaTamanho >= 1)
                                {
                                    pevent.Graphics.DrawPath(penBorder, pathBorder);
                                }
                            }
                        }
                    }
                }
            }
            else //Botao Normal
            {
                this.Region = new Region(rectSurface);

                if(BordaTamanho >= 1)
                {
                    using (Pen penBorder = new Pen(BordaCor, BordaTamanho))
                    {
                        penBorder.Alignment= PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}
