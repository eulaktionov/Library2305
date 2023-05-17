using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

using static Library2305.Properties.Resources;

namespace Library2305
{
    public partial class StartForm : System.Windows.Forms.Form
    {
        AppMenu menu;
        Data data;

        public StartForm()
        {
            InitializeComponent();
            Load += (s, e) => Start();
            FormClosed += (s, e) => End();
        }

        void Start()
        {
            (Text, Icon) = (AppTitle, AppIcon);
            MakeMenu();
            IsMdiContainer = true;
            data = new ContextFactory().CreateDbContext(null);
            Author author = data.Authors.FirstOrDefault();
            MessageBox.Show(author.LastName);
            //WindowState = FormWindowState.Maximized;
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
            DataForm form = 
                MdiChildren.Select(f => f as DataForm).
                FirstOrDefault(f => f.Id == id);

            if(form == null)
            {
                form = new(id);
                form.MdiParent = this;
                form.Show();
            }

            if(form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Activate();
        }

        void Save()
        {
            Debug.WriteLine("Save data!");
        }

        void End()
        {

        }
    }
}