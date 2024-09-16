using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceTask2_WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // I should clear the richtextboxes first,
            //before continueing with the button click event
            richTextBox1.Clear();
            richTextBox2.Clear();

            unsafe
            {
                // Create 3 integer variables, which are needed for 
                //pointers of type int to point to
                int a = 10, b = 20, c = 30;

                // Create pointers to these variables
                int* pointar1 = &a;
                int* pointar2 = &b;
                int* pointar3 = &c;

                // After a button is pressed,
                //I should display text content and addresses of the pointers
                richTextBox1.AppendText("3 Pointers:\n");
                richTextBox1.AppendText($"Value of the int variable named 'a': {a}, Address: {(IntPtr)pointar1}\n");
                richTextBox1.AppendText($"Value of teh int variable named 'b': {b}, Address: {(IntPtr)pointar2}\n");
                richTextBox1.AppendText($"Value of the int variable named 'c': {c}, Address: {(IntPtr)pointar3}\n");

                // I need to create an array of 12 integers, which
                //which this would be used by the 2nd richtaxtbox
                int[] arr = new int[12];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = (i + 1); // * 10;  // Populate the array with 12 numbers
                }

                fixed (int* ptrArr = arr)
                {
                    // mext i will isplay the array elements and their addresses in RichTextBox2
                    richTextBox2.AppendText("Array of 12 Integers:\n");
                    for (int i = 0; i < arr.Length; i++)
                    {
                        int* currentPtr = ptrArr + i;  // Pointer on left is given a job to
                                                       // points  to each element of the array
                        richTextBox2.AppendText($"Value at index {i}: {arr[i]}, Address: {(IntPtr)currentPtr}\n");
                    }
                }
            }
        }


    }
}
