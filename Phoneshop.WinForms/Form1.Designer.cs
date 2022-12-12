namespace Phoneshop.WinForms
{
    partial class PhoneOverview
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.BrandText = new System.Windows.Forms.Label();
            this.TypeText = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.Label();
            this.PriceText = new System.Windows.Forms.Label();
            this.StockText = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.PhoneList = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.PlaceholderText = "Search";
            this.searchBox.Size = new System.Drawing.Size(318, 27);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(791, 395);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(94, 29);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(336, 121);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(549, 268);
            this.lblDescription.TabIndex = 3;
            // 
            // BrandText
            // 
            this.BrandText.AutoSize = true;
            this.BrandText.Location = new System.Drawing.Point(336, 21);
            this.BrandText.Name = "BrandText";
            this.BrandText.Size = new System.Drawing.Size(51, 20);
            this.BrandText.TabIndex = 4;
            this.BrandText.Text = "Brand:";
            // 
            // TypeText
            // 
            this.TypeText.AutoSize = true;
            this.TypeText.Location = new System.Drawing.Point(336, 60);
            this.TypeText.Name = "TypeText";
            this.TypeText.Size = new System.Drawing.Size(43, 20);
            this.TypeText.TabIndex = 5;
            this.TypeText.Text = "Type:";
            // 
            // DescriptionText
            // 
            this.DescriptionText.AutoSize = true;
            this.DescriptionText.Location = new System.Drawing.Point(336, 101);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(88, 20);
            this.DescriptionText.TabIndex = 6;
            this.DescriptionText.Text = "Description:";
            // 
            // PriceText
            // 
            this.PriceText.AutoSize = true;
            this.PriceText.Location = new System.Drawing.Point(693, 23);
            this.PriceText.Name = "PriceText";
            this.PriceText.Size = new System.Drawing.Size(44, 20);
            this.PriceText.TabIndex = 7;
            this.PriceText.Text = "Price:";
            // 
            // StockText
            // 
            this.StockText.AutoSize = true;
            this.StockText.Location = new System.Drawing.Point(693, 62);
            this.StockText.Name = "StockText";
            this.StockText.Size = new System.Drawing.Size(48, 20);
            this.StockText.TabIndex = 8;
            this.StockText.Text = "Stock:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrand.Location = new System.Drawing.Point(385, 21);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(53, 22);
            this.lblBrand.TabIndex = 9;
            this.lblBrand.Text = "Empty";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblType.Location = new System.Drawing.Point(385, 60);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 22);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Empty";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrice.Location = new System.Drawing.Point(747, 21);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(53, 22);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "Empty";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStock.Location = new System.Drawing.Point(747, 60);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(53, 22);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "Empty";
            // 
            // PhoneList
            // 
            this.PhoneList.FormattingEnabled = true;
            this.PhoneList.ItemHeight = 20;
            this.PhoneList.Location = new System.Drawing.Point(12, 45);
            this.PhoneList.Name = "PhoneList";
            this.PhoneList.Size = new System.Drawing.Size(318, 344);
            this.PhoneList.TabIndex = 13;
            this.PhoneList.SelectedIndexChanged += new System.EventHandler(this.PhoneList_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 395);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(30, 29);
            this.AddButton.TabIndex = 14;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(48, 395);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(30, 29);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "-";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PhoneOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 434);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.PhoneList);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.StockText);
            this.Controls.Add(this.PriceText);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.TypeText);
            this.Controls.Add(this.BrandText);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PhoneOverview";
            this.Text = "Phoneshop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox searchBox;
        private Button ExitButton;
        private Label lblDescription;
        private Label BrandText;
        private Label TypeText;
        private Label DescriptionText;
        private Label PriceText;
        private Label StockText;
        private Label lblBrand;
        private Label lblType;
        private Label lblPrice;
        private Label lblStock;
        private ListBox PhoneList;
        private Button AddButton;
        private Button DeleteButton;
    }
}