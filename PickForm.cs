using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Library2305.Properties.Resources;

namespace Library2305
{
    public partial class PickForm : Form
    {
        public  object? Result { get; set; }
        public ListBox list;

        public PickForm()
        {
            InitializeComponent();
            (Text, Icon) = (AppTitle, AppIcon);

            Size buttonSize = new Size(80, 40);
            Button buttonOk = new()
            {
                Text = "OK",
                Size = buttonSize
            };
            buttonOk.Click += (s, e) => Result = list.SelectedItem;
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Dock = DockStyle.Left;

            Button buttonCancel = new()
            {
                Text = "Cancel",
                Size = buttonSize
            };
            buttonCancel.Click += (s, e) => Result = null;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Dock = DockStyle.Right;

            Panel panel = new Panel();
            panel.Height = buttonSize.Height;

            panel.Controls.Add(buttonOk);
            panel.Controls.Add(buttonCancel);
            panel.Dock = DockStyle.Top;
            Controls.Add(panel);

            AcceptButton = buttonOk;
            CancelButton = buttonCancel;
            Width = buttonSize.Width * 3;

            list = new ();
            list.Dock = DockStyle.Fill;
            list.DoubleClick += (s, e) => buttonOk.PerformClick();
            Controls.Add (list);
        }
    }
}
