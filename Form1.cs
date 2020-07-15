using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ReadPdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PDF files|*.pdf", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PdfReader pdfreader = new PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= pdfreader.NumberOfPages; i++)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(pdfreader,i));
                        }
                        rtbPdf.Text = sb.ToString();
                        pdfreader.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message,"Importante",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
