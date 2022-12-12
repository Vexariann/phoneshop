using Microsoft.Extensions.DependencyInjection;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.WinForms
{
    public partial class PhoneOverview : Form
    {
        readonly IPhoneService _service;
        //readonly IRepository<Brand> _repository;
        List<Phone> _phoneList = new();
        public PhoneOverview(IPhoneService service)
        {
            _service = service;
            InitializeComponent();

            GetNewPhoneList();
        }

        public void GetNewPhoneList()
        {
            _phoneList = _service.GetAllPhones();
            DrawList(_phoneList);
        }

        private void PhoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // prevents crashing when clicking empty area in Listbox
            if (PhoneList.SelectedIndex >= 0)
            {
                Phone selectedPhone = PhoneList.SelectedItem as Phone;
                lblBrand.Text = selectedPhone.Brand.BrandName;
                //lblBrand.Text = _repository.Get(selectedPhone.ID).ToString();
                lblType.Text = selectedPhone.Type;
                lblPrice.Text = "€ " + selectedPhone.Price.ToString();
                lblStock.Text = selectedPhone.Stock.ToString();
                lblDescription.Text = selectedPhone.Description;
            }
        }

        private async void SearchBox_TextChanged(object sender, EventArgs e)
        {
            List<Phone> phonesToDisplay = searchBox.Text.Length > 3 ? await _service.SearchPhone(searchBox.Text) : _phoneList;
            DrawList(phonesToDisplay);
        }

        public void DrawList(List<Phone> listToDraw)
        {
            PhoneList.DisplayMember = "FullName";
            PhoneList.DataSource = listToDraw;

            if (PhoneList.Items.Count > 0)
            {
                PhoneList.SelectedIndex = 0;
            }
            else
            {
                lblBrand.Text = "";
                lblType.Text = "";
                lblPrice.Text = "";
                lblStock.Text = "";
                lblDescription.Text = "";
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddPhone addPhone = Services.ServiceProvider.GetRequiredService<AddPhone>();
            if (addPhone.ShowDialog() == DialogResult.OK)
            {
                GetNewPhoneList();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Phone selectedPhone = PhoneList.SelectedItem as Phone;
            DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedPhone.Brand} - {selectedPhone.Type}?",
                "Delete Phone", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _service.DeletePhone(selectedPhone);
                GetNewPhoneList();
            }
        }
    }
}