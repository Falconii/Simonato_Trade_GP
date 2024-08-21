using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trade_GP
{
    public partial class FormAviso : Form
    {
        public string Mensagem { get; set; }

        public FormAviso(string mensagem)
        {
            InitializeComponent();
            Mensagem = mensagem;

        }


        private void FormAviso_Load(object sender, EventArgs e)
        {
            if (Mensagem != "") lbMensagem.Text = Mensagem;
        }
    }
}
