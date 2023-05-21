using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Library2305.Properties.Resources;

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
            DataError += (s, e) =>
            {
                e.ThrowException = false; // Отключаем выбрасывание исключения
                MessageBox.Show("Data entry error!", AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                CurrentCell = this[e.ColumnIndex, e.RowIndex]; // Возвращаем фокус на текущую ячейку
            };

        }
    }
}
