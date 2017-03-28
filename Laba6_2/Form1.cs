using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6_2
{
    public partial class Form1 : Form
    {
        private List<Round> collection;
             

        public Form1()
        {
            InitializeComponent();
        }

        
       private void button1_Click(object sender, EventArgs e)
        {
            Random ran= new Random();
            collection = new List<Round>();
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                collection.Add(new Round(ran.Next(1,20)));
            }
           listBox1.DataSource = collection;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Round> collectionTemp = new List<Round>();
            collectionTemp.AddRange(collection);
            collectionTemp.Sort((a,b) =>
            {
                if (a.Rad > b.Rad)
                {
                    return 1;
                }
                else if (a.Rad < b.Rad)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });
            listBox2.DataSource = collectionTemp;
            listBox2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Round> collectionTemp = new List<Round>();
            collectionTemp.AddRange(collection);
           collectionTemp.Sort((a, b) =>
            {
                if (a.Rad > b.Rad)
                {
                    return -1;
                }
                else if (a.Rad < b.Rad)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            listBox2.DataSource = collectionTemp;
            listBox2.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query_1 = from i in collection
                          where i.Rad > 3
                          select i;
            listBox2.DataSource = query_1.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var query_2 = (from i in collection
                           select i).Take(3);
            listBox2.DataSource = query_2.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var query_3 = from i in collection
                          where i.Rad < 4
                          select i;
            listBox2.DataSource = query_3.ToList();
        }
    }
}
