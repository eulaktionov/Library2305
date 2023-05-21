using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

using static Library2305.Properties.Resources;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library2305
{
    public partial class StartForm : System.Windows.Forms.Form
    {
        AppMenu? menu;
        readonly Data? data;

        public StartForm()
        {
            InitializeComponent();

            data = new ContextFactory().CreateDbContext(Array.Empty<string>());
            data?.Authors.Load();
            data?.Books.Load();
            data?.Readers.Load();
            data?.Records.Load();

            Load += (s, e) => Start();
            FormClosing += (s, e) => e.Cancel = !Save();
        }

        void Start()
        {
            (Text, Icon) = (AppTitle, AppIcon);
            MakeMenu();
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
            (menu!.Items[0] as ToolStripMenuItem)?
                .DropDownItems[0].PerformClick();
        }

        void MakeMenu()
        {
            menu = new()
            {
                Open = OpenInnerForm,
                Save = Save,
                Exit = () => Close()
            };
            Controls.Add(menu);
        }

        void OpenInnerForm(AppForm id)
        {
            DataForm? form = MdiChildren?
                .Select(f => f as DataForm)
                .FirstOrDefault(f => f!.Id == id);

            if(form == null)
            {
                form = id switch
                {
                    AppForm.Records => new RecordForm(id, data),
                    _ => new DataForm(id, data)
                };
                form.MdiParent = this;
                form.Show();
            }

            if(form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Activate();
        }

        bool Save()
        {
            try
            {
                data?.SaveChanges();
                Debug.WriteLine("Save data!");
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.InnerException?.Message);
                return false;
            }
        }
    }
}