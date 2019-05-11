using fStats.Executor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fStats
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            string html = await WikiController.GetPageAsync("https://en.wikipedia.org/wiki/2016–17_Premier_League");
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var tables = doc.DocumentNode.SelectNodes("//table")
                .Where(x => x.Attributes["class"].Value == "wikitable")
                .Where(z => z.SelectNodes(z.XPath + "/tbody/tr[1]/th").Count > 9).ToList();
            Console.WriteLine(tables.Count);
            var rows = tables.Take(1).SelectMany(x => x.SelectNodes(x.XPath + "/tbody/tr")).Skip(1).ToList();
            Console.WriteLine(rows.Count);
            return;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
