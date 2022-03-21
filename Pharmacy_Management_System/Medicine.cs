using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System
{
    public class Medicine
    {
        private int id;
        private string name;
        private string manufacturer;
        private int quantity;
        private int price;
        static int balance = 100000;

        public Medicine(int id, string name, string manufacturer, int quantity, int price)
        {
            this.id = id;
            this.name = name;
            this.manufacturer = manufacturer;
            this.quantity = quantity;
            this.price = price;
        }
        public void decrease(int quantity)
        {
            this.quantity -= quantity;
        }
        public void increase(int quantity)
        {
            this.quantity += quantity;
        }
        public int getQuantity()
        { return this.quantity; }
        public int getPrice()
        { return this.price; }
        public int getID()
        { return this.id; }
        public string getName()
        {
            return this.name;
        }
        public string getInfo()
        {
            string info = name + "\t" + id.ToString() + "\t" + quantity.ToString() + "\t" + price.ToString();
            return info;
        }
        public void decrease_amount(int amount)
        {
            balance -= amount;
        }
        public void increase_amount(int amount)
        {
            balance += amount;
        }
        public static int getBalance()
        {
            return balance;
        }
    }
}
