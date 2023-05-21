using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            grid.CellDoubleClick += (s, e) => EditCell(e.ColumnIndex, e.RowIndex);
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
            grid.Columns["Id"].DisplayIndex = 0;
            grid.Columns["Id"].ReadOnly = true;
            grid.Columns["Id"].DefaultCellStyle.Alignment 
                = DataGridViewContentAlignment.MiddleRight;
        }

        public virtual void EditCell(int columnIndex, int rowIndex)
        {

        }
    }

    public class RecordForm : DataForm
    {
        public RecordForm(AppForm id, Data? data) 
            : base(id, data) 
        {
            grid.RowLeave += (sender, e) =>
            {
                if(e.RowIndex == grid.NewRowIndex)
                {
                    grid.NotifyCurrentCellDirty(true);
                    grid.BindingContext?[grid.DataSource, grid.DataMember].EndCurrentEdit();
                    grid.NotifyCurrentCellDirty(false);
                }
            };
        }

        public override void Customize()
        {
            base.Customize();
            grid.Columns["Book"].ReadOnly = true;
            grid.Columns["Reader"].ReadOnly = true;
            grid.Columns["ReceiveDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            grid.Columns["ReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        public override void EditCell(int columnIndex, int rowIndex)
        {
            var pickForm = new PickForm();
            if (columnIndex == 1) 
            {
                pickForm.list.DataSource = data?.Books?.Local?.ToBindingList();
            }
            else
            if(columnIndex == 2)
            {
                pickForm.list.DataSource = data?.Readers.Local.ToBindingList();
            }
            else
            {
                return;
            }

            pickForm.ShowDialog();
            if (pickForm.Result is not null)
            {
                grid.Rows[rowIndex].Cells[columnIndex].Value
                    = pickForm.Result;
            }
            if(columnIndex == grid.Columns.Count - 1)
            {
                grid.CurrentCell = grid[columnIndex - 1, rowIndex];
            }
            else
            {
                grid.CurrentCell = grid[columnIndex + 1, rowIndex];
            }
        }
    }
}
