using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.DataFormats;

using static Library2305.Properties.Resources;

namespace Library2305
{
    public partial class DataForm : Form
    {
        public AppForm Id { get; set; }
        protected DataGridView grid;

        public DataForm(AppForm id)
        {
            InitializeComponent();
            Id = id;
            Load += (s, e) => Start();
        }

        void Start()
        {
            Icon = AppIcon;
            Text = Id switch
            {
                AppForm.Authors => AuthorsTitle,
                AppForm.Books => BooksTitle,
                AppForm.Readers => ReadersTitle,
                AppForm.Records => RecordsTitle
            };
            grid = new();
            Controls.Add(grid);
        }
    }
}
