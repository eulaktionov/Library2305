using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2305
{
    public class CustomGrid : DataGridView
    {
        public CustomGrid()
        {
            EditMode = DataGridViewEditMode.EditOnEnter;
            AllowUserToAddRows = true;
            AllowUserToDeleteRows = true;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Dock = DockStyle.Fill;
            DataError += (s, e) => MessageBox.Show(e.ToString());
        }

        public virtual void Customize()
        {
            Columns["Id"].DisplayIndex = 0;
            Columns["Id"].ReadOnly = true;
            Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public virtual DataGridViewComboBoxColumn ConvertToCombo<T>
            (string colName, List<T> source,
            string headerText,
            string valueName, string memberName)
        {
            Columns.Remove(colName);

            DataGridViewComboBoxColumn col = new ();

            col.DataPropertyName = colName;

            col.DataSource = source;
            col.ValueMember = valueName;
            col.DisplayMember = memberName;
            col.HeaderText = headerText;

            Columns.Add(col);
            return col;
        }
    }
}
