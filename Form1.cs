using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyDll;

namespace DllCombine
{
    public partial class Form1 : Form
    {
        private int C;

        public Form1()
        {
            InitializeComponent();

            MyDll.MyDll D = new MyDll.MyDll();

            C = D.B + 1;
        }
    }
}
