using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Gallery3WinForm
{
    public partial class frmWork : Form
    {
        protected clsAllWork _Work;
        public delegate void LoadWorkFormDelegate(clsAllWork prWork);
        public static void DispatchWorkForm(clsAllWork prWork)
        {
            Dictionary<char, Delegate> WorksForm = new Dictionary<char, Delegate>
            {
                {'P', new LoadWorkFormDelegate(frmPainting.Run) },
                {'H', new LoadWorkFormDelegate(frmPhotograph.Run) },
                {'S', new LoadWorkFormDelegate(frmSculpture.Run) }
            };
            WorksForm[prWork.WorkType].DynamicInvoke(prWork);
        }

        public frmWork()
        {
            InitializeComponent();
        }

        public void SetDetails(clsAllWork prWork)
        {
            _Work = prWork;
            updateForm();
            ShowDialog();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                if (txtName.Enabled)
                    MessageBox.Show(await ServiceClient.InsertWorkAsync(_Work));
                else
                    MessageBox.Show(await ServiceClient.UpdateWorkAsync(_Work));

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtName.Text = _Work.Name;
            txtCreation.Text = _Work.Date.ToShortDateString();
            txtValue.Text = _Work.Value.ToString();
            txtName.Enabled = string.IsNullOrEmpty(_Work.Name); //Prevent the user from being able to change artworks names which are primary keys in Work DB table
        }

        protected virtual void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtCreation.Text);
            _Work.Value = decimal.Parse(txtValue.Text);
        }

    }
}