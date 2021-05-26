using entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entity
{
    public partial class Form1 : Form
    {
        commerceEntities entity = new commerceEntities();
        List<clien> l = new List<clien>();
        public Form1()
        {
            InitializeComponent();
        }
        void afficher()
        {
            l = entity.clien.ToList<clien>();
            for(int i = 0; i < l.Count; i++)
            {
                dataGridView1.Rows.Add(l[i].idcli, l[i].nom, l[i].prenom);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            afficher();
        }
        void ajjouter()
        {
            clien c = new clien { idcli = int.Parse(textBox1.Text), nom = textBox2.Text, prenom = textBox3.Text };
            
            entity.clien.Add(c);
            entity.SaveChanges();
            dataGridView1.Rows.Clear();
            afficher();
        }
        void supprimer()
        {
           int id = int.Parse(textBox1.Text);
          
            int count = entity.clien.Where(x => x.idcli == id).Count();
            clien a = entity.clien.Where(x => x.idcli == id).First();
            if (count > 0 && textBox1.Text!="")
            {
                
                
                DialogResult dialog = new DialogResult();
               dialog= MessageBox.Show("are you shour to delete this clien", "deleting",MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes) { 
                entity.clien.Remove(a);
                dataGridView1.Rows.Clear();
                entity.SaveChanges();
                afficher();}
            }
            else 
            {
                MessageBox.Show("no susch elements with this id!");
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ajjouter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            supprimer();
        }
    }
}
