using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Item
        {
            public string ItemName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }

            // Constructor
            public Item(string itemName, double price, int quantity)
            {
                ItemName = itemName;
                Price = price;
                Quantity = quantity;
            }

            // Virtual method to calculate total amount
            public virtual double CalculateTotalAmount()
            {
                return Price * Quantity;
            }
        }

        public class DiscountedItem : Item
        {
            public double Discount { get; set; }

            // Constructor with base class constructor invocation
            public DiscountedItem(string itemName, double price, int quantity, double discount)
                : base(itemName, price, quantity)
            {
                Discount = discount;
            }

            // Overriding the base class method to apply discount
            public override double CalculateTotalAmount()
            {
                double discountAmount = Price * (Discount * 0.01);
                double discountedPrice = Price - discountAmount;
                return discountedPrice * Quantity;
            }
        }



        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve input values from TextBoxes
                string itemName = txtItemName.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);
                double discount = Convert.ToDouble(txtDiscount.Text);
                double payment = Convert.ToDouble(txtPayment.Text);

                // Create an instance of DiscountedItem
                DiscountedItem item = new DiscountedItem(itemName, price, quantity, discount);

                // Calculate the total amount and change
                double totalAmount = item.CalculateTotalAmount();
                double change = payment - totalAmount;

                // Display the results
                lblTotalAmount.Text = $"Total Amount: {totalAmount:C}";
                lblChange.Text = $"Change: {change:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
                 

