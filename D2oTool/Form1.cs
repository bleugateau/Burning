using Burning.DofusProtocol.Data.D2o;
using Burning.DofusProtocol.Datacenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace D2oTool
{
    public partial class Form1 : Form
    {
        public OpenFileDialog OpenFileDialog { get; set; }
        public D2oReader Reader { get; set; }

        public string DataName { get; set; }
        public Form1()
        {
            InitializeComponent();
            OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.DefaultExt = "d2o";
            OpenFileDialog.Title = "Open your Dofus 2 file";
            OpenFileDialog.Filter = "Dofus 2 file (*.d2o)|*.d2o";
            //????
            this.dataList.View = View.Details;
        }

        public void LoadD2o(string path, string name)
        {
            this.Reader = new D2oReader(path);

            this.DataName = name.Split('.')[0];

            Invoke(new Action(() =>
            {
                this.Text = name;
                this.countLabel.Text = this.Reader.IndexCount + " line(s) draw.";
                this.dataList.Clear();
            }));



            List<string> itemContent = new List<string>();
            bool headersFilled = false;
            foreach (var obj in this.Reader.ReadObjects())
            {
                try
                {
                    var className = obj.Value.GetType().Name;

                    if (path.Contains("Items.d2o") && className != "Item")
                        continue;

                    //var obj = this.reader.ReadObject(i); //obj from d2o
                    var fields = obj.Value.GetType().GetFields(); //fields
                    itemContent = new List<string>(); //reset

                    for (int f = 0; f < fields.Length; f++)
                    {
                        if (!headersFilled)
                        {
                            Invoke(new Action(() => { this.dataList.Columns.Add(fields[f].Name); }));
                            
                        }
                            

                        var fieldValue = fields[f].GetValue(obj.Value);
                        string content = JsonConvert.SerializeObject(fieldValue);

                        if (content.Length == 0)
                        {
                            content = "NULL";
                        }

                        itemContent.Add(content);

                        if (f == fields.Length - 1)
                        {
                            Invoke(new Action(() => { this.dataList.Items.Add(new ListViewItem(itemContent.ToArray())); }));
                        }
                    }

                    if (!headersFilled)
                        headersFilled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.pathOfFile.Text = OpenFileDialog.FileName;
                //read d2o

                Task.Run(() => this.LoadD2o(OpenFileDialog.FileName, OpenFileDialog.SafeFileName));
            }
        }
    }
}
