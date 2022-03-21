using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Management_System;

namespace Pharmacy_Management_system_Task05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Medicine> medicine_list = new List<Medicine>();

        private void AddMedicineOnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Medicine_ID.Text);
            int quantity = Convert.ToInt32(Medicine_Quantity.Text);
            int price = Convert.ToInt32(Medicine_Price.Text);
            string name = Medicine_Name.Text;
            string manufacturer = Medicine_Manufacturer.Text;

            Medicine dummy_medicine = new Medicine(id, name, manufacturer, quantity, price);

            medicine_list.Add(dummy_medicine);

            dummy_medicine.decrease_amount(price * quantity);

            MessageBox.Show("Medicine has been added successfully");
                
            
        }

        private void Show_Stock_On_Click(object sender, EventArgs e)
        {
            Inventory_Info.Items.Clear();
            Inventory_Info.Items.Add("Name" + "\t" + "ID" + "\t" + "Quantity" + "\t" + "Price" + "\n");

            int stock_id = Convert.ToInt32(Inventory_Input.Text);

            foreach (Medicine dummy in medicine_list)
            {
                if (stock_id == dummy.getID())
                {
                    Inventory_Info.Items.Add(dummy.getInfo());
                }
            }
        }

        private void Sell_Medicine_On_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Sale_ID_Input.Text);
            int quantity = Convert.ToInt32(Sale_Quantity_Input.Text);

            foreach (Medicine dummy in medicine_list)
            {
                if (id == dummy.getID())
                {
                    if (quantity > dummy.getQuantity())
                    {
                        MessageBox.Show("Not enough medicine in stock");
                    }
                    else
                    {
                        dummy.decrease(quantity);
                        dummy.increase_amount(quantity * dummy.getPrice());
                        MessageBox.Show("Successfully sold " + quantity.ToString() + " amount of " + dummy.getName());
                    }
                }
            }
        }

        private void Show_Balance_On_Click(object sender, EventArgs e)
        {
            Balance_Output.Text = "$ " + Convert.ToString(Medicine.getBalance());
        }
    }
}
