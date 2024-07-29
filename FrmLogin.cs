using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Symmetry
{
    public partial class FrmLogin : Form
    {
        private bool _login = false;
        public bool IsLogin { get { return _login; } }

        public static EventHandler<bool> LoginHandler = delegate { };

        public FrmLogin()
        {
            InitializeComponent();
        }

        public void Quit()
        {
            textBox1.Text = "";
            _login = false;
            LoginHandler?.Invoke(this, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "2024")
            {
                _login = true;
                this.Hide();
            }
            else
            {
                _login = false;
                MessageBox.Show("验证失败！");
            }
            LoginHandler?.Invoke(this, _login);
        }
    }
}
