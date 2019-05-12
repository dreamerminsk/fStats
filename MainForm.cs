using fStats.Executor;
using fStats.Model;
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

        private BindingList<LeagueTableRow> source = new BindingList<LeagueTableRow>();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_LoadAsync(object sender, EventArgs e)
        {
            dataGridView1.DataSource = source;
            string html = await WikiController.GetPageAsync("https://en.wikipedia.org/wiki/2016–17_Premier_League");
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var tables = doc.DocumentNode.SelectNodes("//table")
                .Where(x => x.Attributes["class"].Value == "wikitable")
                .Where(z => z.SelectNodes(z.XPath + "/tbody/tr[1]/th").Count > 9).ToList();
            Console.WriteLine(tables.Count);
            var rows = tables.Take(1).SelectMany(x => x.SelectNodes(x.XPath + "/tbody/tr")).Skip(1).ToList();
            Console.WriteLine(rows.Count);
            var cells = rows.Select(x =>
            {
                return x.Descendants();
            }).ToList();
            foreach (var cell in cells)
            {
                Console.WriteLine("-------------------------------------------");
                foreach (var item in cell)
                {
                    if ("td".Equals(item.Name) || "th".Equals(item.Name))
                    {
                        Console.WriteLine(item.Name + ": " +  item.InnerText.Trim());
                    }
                }
{}
            }
            return;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
