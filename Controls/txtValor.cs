using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Controls
{
    public class txtValor : TextBox
    {
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.Text == "")
            {
                return;
            }
            try
            {
                decimal valor = Convert.ToDecimal(this.Text);
                this.Text = String.Format("{0:N2}", valor);
            }
            catch
            {
                MessageBox.Show("Valor inválido","Valor inválido",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Text = "";
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if(e.KeyChar == 8 || e.KeyChar == 44)
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
