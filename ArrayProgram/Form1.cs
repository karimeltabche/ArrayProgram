/*=========================
FileName: ArrayProgram
FileType: Visual C#
Author: Karim El-Tabche
Created On: 5/18/2016 12:27:11 PM
Last Modified On: 5/18/2016 1:36:45 PM
Description: This is an example on how
             Arrays work
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
                int[] temps = { 65, 71, 49, 87, 32, 62 };// assign values of array
                StreamWriter outputFile;
                outputFile = File.CreateText("temps.txt");//creates an ouput file called temps.txt

                for (int i=0; i<temps.Length;++i)
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
                inputFile = File.OpenText("temps.txt");//creates inputFile
                int i = 0;
                while(i < temps.Length && !inputFile.EndOfStream) // reads file to the end
                {
                    temps[i] = int.Parse(inputFile.ReadLine());
                    ++i;
                }
                inputFile.Close();//close file after done reading

                foreach(int temperature in temps)
                {
                    lstValue.Visible = true;//displays list box when get value button clicked
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
            lstValue.Visible = false;//Set listBox to invisible when form loads
            string[] students = { "Sue", "Joe", "Mike", "Eve" };//create an array of string
            showNames(students);//Call function
        }

        private void showNames(string[] studentArray)//New Function
        {
            foreach(string name in studentArray)//Reads through the array line by line
            {
                lstValue.Items.Add(name);//adds each line to list box
            }
        }
    }
}
