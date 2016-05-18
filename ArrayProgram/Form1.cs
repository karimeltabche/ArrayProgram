/*=========================
FileName: ArrayProgram
FileType: Visual C#
Author: Karim El-Tabche
Created On: 5/18/2016 12:27:11 PM
Last Modified On: 5/18/2016 1:18:45 PM
Description: This is a recap on Arrays
             and how they work
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ArrayProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int[] temps = { 65, 71, 49, 87, 32, 62 };
                StreamWriter outputFile;
                outputFile = File.CreateText("temps.txt");

                for(int i=0; i<temps.Length;++i)
                {
                    outputFile.WriteLine(temps[i]);

                }
                outputFile.Close();
                label1.Text = "File Created";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int[] temps = new int[6];
                StreamReader inputFile;
                inputFile = File.OpenText("temps.txt");
                int i = 0;
                while(i < temps.Length && !inputFile.EndOfStream)
                {
                    temps[i] = int.Parse(inputFile.ReadLine());
                    ++i;
                }
                inputFile.Close();

                foreach(int temperature in temps)
                {
                    lstValue.Visible = true;
                    lstValue.Items.Add(temperature);
                    button2.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstValue.Visible = false;
        }
    }
}
