using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        class LabelVM : INotifyPropertyChanged
        {
            private string lText_;
            public string lText { get { return lText_; } set { lText_ = value; NotifyPropertyChanged(); } }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        LabelVM textVm;
        public Form1()
        {
            InitializeComponent();

            dgvBallotUsages.ColumnCount = 7;
            dgvBallotUsages.Columns[0].Name = "";

            List<LabelVM> l = new List<LabelVM>
            {
                new LabelVM{lText = "asdfsadf" },
                new LabelVM{lText = "bbbbbbbbbb" },
            };
            Binding b = label1.DataBindings.Add("Text", l, "lText");
            label1.BindingContext[l].Position = 1;

            textVm = new LabelVM { lText = "shawn" };
            textBox1.DataBindings.Add("Text", textVm, "lText");
            textBox1.BindingContext[textVm].CurrentItemChanged += Form1_CurrentItemChanged;
        }

        private void Form1_CurrentItemChanged(object sender, EventArgs e)
        {
            Console.WriteLine("You are in the BindingManagerBase.CurrentItemChanged event: " + textVm.lText);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textVm.lText = "sdfsfd";
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
