using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Marker_New
{
    public partial class TextForm : Form
    {
        
        public TextForm()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DATA.Comment = txtComment.Text;
            this.Close();
        }

        private void TextForm_Load(object sender, EventArgs e)
        {
            txtComment.Focus();
        }
    }
}
