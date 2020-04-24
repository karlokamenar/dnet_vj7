using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dnet_vj7
{
    public partial class Form1 : Form
    {
        Database1Entities baza = new Database1Entities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.gradoviTableAdapter.Fill(this.database1DataSet.gradovi);
            comboBox1.DataSource = baza.drzave.ToList<drzave>();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Naziv";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gradovi grad = new gradovi();
            grad.naziv = textBox1.Text; 
            grad.broj_stanovnika = Int32.Parse(textBox2.Text);
            grad.drzava_id = comboBox1.SelectedIndex;
            grad.drzave = (drzave)comboBox1.SelectedItem;
            baza.gradovi.Add(grad);
            baza.SaveChanges();
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = printgradovi();
        }

        String printgradovi()
        {
            string s = "";
            List<gradovi> l = baza.gradovi.ToList();
            for (int i = 0; i < l.Count; i++)
                s += l.ElementAt(i).naziv + "\n";
            return s;
        }
    }

}
