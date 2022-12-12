using Microsoft.Extensions.Logging;
using Phoneshop.Business.Extensions;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Models;

namespace Phoneshop.WinForms
{
    public partial class AddPhone : Form
    {
        readonly IPhoneService _phoneService;
        readonly ILogger<AddPhone> _logger;
        public AddPhone(IPhoneService phoneService, ILogger<AddPhone> logger)
        {
            _logger = logger;
            _phoneService = phoneService;
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            List<string> inputFields = new()
            {
                BrandTextBox.Text,
                TypeTextBox.Text,
                DescriptionTextBox.Text,
                PriceTextBox.Text,
                StockTextBox.Text
            };
            if (inputFields.IsValid(out string message))
            {
                Brand brandToAdd = new()
                {
                    BrandName = BrandTextBox.Text
                };
                Phone phoneToAdd = new()
                {
                    Brand = brandToAdd,
                    Type = TypeTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Stock = int.Parse(StockTextBox.Text)
                };
                try
                {
                    _phoneService.AddPhone(phoneToAdd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Phone already exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }
                MessageBox.Show("Phone added succesfully.");
                _logger.LogInformation($"The phone: {phoneToAdd.Brand.BrandName} - {phoneToAdd.Type} has been added to the database");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                _logger.LogInformation($"Invalid input: {message}");
                MessageBox.Show(message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
