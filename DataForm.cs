using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.SqlServer.Server;

using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

using static Library2305.Properties.Resources;

namespace Library2305
{
    public partial class DataForm : Form
    {
        public AppForm Id { get; set; }
        protected Data? data;
        protected CustomGrid grid;

        public DataForm(AppForm id, Data? data)
        {
            InitializeComponent();
            Id = id;
            this.data = data;
            grid = new();
            Controls.Add(grid);
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
                AppForm.Records => RecordsTitle,
                _=> AppTitle
            };
            grid.DataSource = Id switch
            {
                AppForm.Authors => data?.Authors.Local.ToBindingList(),
                AppForm.Books => data?.Books.Local.ToBindingList(),
                AppForm.Readers => data?.Readers.Local.ToBindingList(),
                AppForm.Records => data?.Records.Local.ToBindingList(),
                _=> null
            };
            Customize();
        }

        public virtual void Customize()
        {
            grid.Customize();
        }
    }
}
