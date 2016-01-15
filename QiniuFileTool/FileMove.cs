using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QiniuFileTool
{
    public partial class frmFileMove : Form
    {
        private SetQiniuKeies()
        {

        }


        public frmFileMove()
        {
            InitializeComponent();
        }

        private void frmFileMove_Load(object sender, EventArgs e)
        {

        }

        private void btnStartMove_Click(object sender, EventArgs e)
        {
            Qiniu.RS.RSClient rsClient;
        }

        private void btnFetchFile_Click(object sender, EventArgs e)
        {
            Qiniu.PreFetch.PreFetchClient fetchClient = new Qiniu.PreFetch.PreFetchClient();
            
        }
    }
}
