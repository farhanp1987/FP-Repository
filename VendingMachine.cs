using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VendingMachine
{
    public class VendingMachine : IVendingMachine
    {
        #region Local Variables
        public static CultureInfo CurrentCulture { get; set; }
        public static VendingMachine instance;
        private readonly Dictionary<Item, int> machineItems;
        private readonly List<SaleRecord> saleRecords;
        public double machineBank;
        #endregion

        #region Resource Variables
        public string invalidInput = string.Empty;
        public string enterLanguageTxt = string.Empty;
        public string languageChangedTxt = string.Empty;
        public string languageName = string.Empty;
        #endregion

        public VendingMachine()
        {
            this.machineItems = new Dictionary<Item, int>();
            this.saleRecords = new List<SaleRecord>();
            this.machineBank = 0;
        }

        public double MachineBank
        {
            get
            {
                return this.machineBank;
            }
            set
            {
                this.machineBank = value;
            }
        }

        public Dictionary<Item, int> MachineItems
        {
            get
            {
                return this.machineItems;
            }
        }

        public List<SaleRecord> SaleRecords
        {
            get
            {
                return this.saleRecords;
            }
        }

        public void DisplayMachineBalance()
        {
            PrintMessage(string.Format("Machine has {0}E remaining.", machineBank), ConsoleColor.Green);
        }

        public void ShowProducts()
        {
            if (machineItems.Count == 0)
            {
                PrintMessage("[ERROR] Vending machine does not have any items in stock. Please refill the machine first.", ConsoleColor.Red);
                return;
            }
            foreach (Item item in machineItems.Keys)
            {
                if (machineItems[item] > 0)
                {
                    PrintMessage(string.Format("{0}. {1} {2}E - {3} Items Left", item.ItemID, item.ItemName, item.ItemPrice, machineItems[item]), ConsoleColor.White);
                }
                else
                {
                    PrintMessage(string.Format("{0}. {1} {2}E - SOLD OUT", item.ItemID, item.ItemName, item.ItemPrice), ConsoleColor.White);
                }
            }
        }

        public void RefillMachine()
        {
            RefillItems();
            PrintMessage("Machine has been refilled successfully.", ConsoleColor.Green);
        }

        public void SelectProduct()
        {
            Item requestedItem = null;
            string userInputString = string.Empty;
            int userInputInt;
            double userInputDouble;

            if (machineItems.Count == 0)
            {
                PrintMessage("[ERROR] This vending machine does not have any items in stock. Please refill the machine first.", ConsoleColor.Red);
                return;
            }

            PrintMessage("Available Machine Items:", ConsoleColor.Cyan);
            foreach (Item item in machineItems.Keys)
            {
                if (machineItems[item] > 0)
                {
                    PrintMessage(string.Format("{0}. {1} {2}E - {3} Items Left", item.ItemID, item.ItemName, item.ItemPrice, machineItems[item]), ConsoleColor.White);
                }
                else
                {
                    PrintMessage(string.Format("{0}. {1} {2}E - SOLD OUT", item.ItemID, item.ItemName, item.ItemPrice), ConsoleColor.White);
                }                
            }
            PrintMessage("Enter the Item (Item ID) you would like to purchase from the above displayed Items.", ConsoleColor.Cyan);
            Console.WriteLine("Note: Type 'BACK' in order to return to the previous menu.\n");

            userInputString = Console.ReadLine();

            if (userInputString == "BACK" || userInputString == "back")
                return;

            if (!int.TryParse(userInputString, out userInputInt))
            {
                PrintMessage("[ERROR] Invalid input.", ConsoleColor.Red);
                SelectProduct();
                return;
            }

            foreach (Item item in machineItems.Keys)
            {
                if (item.ItemID == userInputInt)
                {
                    requestedItem = item;
                    break;
                }
            }

            if (requestedItem == null)
            {
                PrintMessage("\n[ERROR] Invalid input.", ConsoleColor.Red);
                SelectProduct();
                return;
            }

            if (GetItemStock(requestedItem) == 0)
            {
                PrintMessage("[ERROR] Item is out of stock.", ConsoleColor.Red);
                SelectProduct();
                return;
            }

            PrintMessage(string.Format("ID: {0}, Name: {1}, Price: {2}E", requestedItem.ItemID, requestedItem.ItemName, requestedItem.ItemPrice), ConsoleColor.White);
            PrintMessage("How much money are you paying? Please note the machine accepts amount only in Euros.", ConsoleColor.Cyan);
            Console.WriteLine("Note: Type 'BACK' in order to return to the previous menu.\n");

            userInputString = Console.ReadLine();

            if (userInputString == "BACK" || userInputString == "back")
                return;

            if (!Double.TryParse(userInputString, out userInputDouble))
            {
                PrintMessage("[ERROR] Invalid input.", ConsoleColor.Red);
                SelectProduct();
                return;
            }
            if (userInputDouble < 0.5 || userInputDouble > 2)
            {
                PrintMessage("[ERROR] Invalid amount. Please enter the amount between 0.5E and 2E.", ConsoleColor.Red);
                SelectProduct();
                return;
            }
            if (userInputDouble < requestedItem.ItemPrice)
            {
                PrintMessage("[ERROR] The amount you enterred is insufficient for the item you have selected for purchase.", ConsoleColor.Red);
                SelectProduct();
                return;
            }

            DispenseItem(requestedItem, userInputDouble);

            string recordMessage = string.Format("[Vending Machine]: Item has been dispensed successfully! (Paid: {0}E, Change Returned: {1}E).",
                    userInputDouble, (userInputDouble - requestedItem.ItemPrice));

            SaleRecord saleRecord = new SaleRecord(DateTime.Now, recordMessage, requestedItem, userInputDouble);
            AddSaleRecord(saleRecord);
            PrintMessage(recordMessage, ConsoleColor.Green);
        }

        public void DisplaySaleRecords()
        {
            List<SaleRecord> saleRecords = GetLastSaleRecords(10);

            if (saleRecords == null || saleRecords.Count == 0)
            {
                PrintMessage("There are currently no sale records to display.", ConsoleColor.Red);
                return;
            }

            foreach (SaleRecord saleRecord in saleRecords)
                PrintMessage(saleRecord.ToString(), ConsoleColor.DarkYellow);
        }

        public void CancelTransaction()
        {
            Environment.Exit(0);
        }

        public void ChangeLanguage()
        {
            string userInputString = string.Empty;
            CultureInfo culture;

            SetUserMessagesByLanguage();

            PrintMessage(enterLanguageTxt, ConsoleColor.Cyan);
            userInputString = Console.ReadLine();

            if (userInputString != "EN" && userInputString != "en" && userInputString != "DE" && userInputString != "de" && userInputString != "FR" && userInputString != "fr")
            {
                PrintMessage(invalidInput, ConsoleColor.Red);
                return;
            }

            switch (userInputString)
            {
                case "DE" or "de":
                    culture = CultureInfo.CreateSpecificCulture("de-DE");
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                    break;
                case "FR" or "fr":
                    culture = CultureInfo.CreateSpecificCulture("fr-FR");
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                    break;
                default:
                    culture = CultureInfo.CreateSpecificCulture("en-US");
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;
                    break;
            }
            SetUserMessagesByLanguage();
            PrintMessage(string.Format("{0} {1}", languageChangedTxt, languageName), ConsoleColor.Green);
        }

        public void DispenseItem(Item item, double amountPaid)
        {
            machineBank = machineBank + (amountPaid - item.ItemPrice);
            machineItems[item]--;
            PrintMessage("Item has been dispensed successfully!", ConsoleColor.Green);
            ReturnChange(machineBank);
            PrintMessage("THANK YOU! Have a good day.", ConsoleColor.Green);
        }

        public void ReturnChange(double remainingAmount)
        {
            if (remainingAmount > 0)
            {
                machineBank = machineBank - remainingAmount;
                PrintMessage(string.Format("Please take your change: {0}E", remainingAmount), ConsoleColor.Green);
            }
        }

        public int GetItemStock(Item item)
        {
            int count;
            if (!machineItems.TryGetValue(item, out count)) return -1;

            return count;
        }

        public int GetTotalMachineItems()
        {
            return machineItems.Values.Sum();
        }

        public void RefillItems()
        {
            machineItems.Clear();
            this.machineItems.Add(ItemFactory.GetItem("Cola"), 15);
            this.machineItems.Add(ItemFactory.GetItem("Chips"), 10);
            this.machineItems.Add(ItemFactory.GetItem("Candy"), 2);
        }
        
        public void AddSaleRecord(SaleRecord saleRecord)
        {
            this.saleRecords.Add(saleRecord);
            PrintMessage("Sale Record Added successfully!", ConsoleColor.Green);
        }

        public List<SaleRecord> GetLastSaleRecords(int num)
        {
            return saleRecords.Take(num).ToList();
        }

        public void PrintMessage(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text + "\n");
            Console.ResetColor();
        }

        public override string ToString()
        {
            return string.Format("Unique Items: {0}, Total Items: {1}, Total Sales: {2}, Machine Total Amount: {3}E",
                machineItems.Count, GetTotalMachineItems(), saleRecords.Count, machineBank);
        }

        public void SetUserMessagesByLanguage()
        {
            string cultureName = CultureInfo.CurrentUICulture.Name;

            if (cultureName == "de-DE")
            {
                enterLanguageTxt = Properties.Messages_DE.EnterLanguageText;
                languageChangedTxt = Properties.Messages_DE.LanguageChangedText;
                invalidInput = Properties.Messages_DE.InvalidInput;
                languageName = Properties.Messages_DE.LanguageName;
            }
            else if (cultureName == "fr-FR")
            {
                enterLanguageTxt = Properties.Messages_FR.EnterLanguageText;
                languageChangedTxt = Properties.Messages_FR.LanguageChangedText;
                invalidInput = Properties.Messages_FR.InvalidInput;
                languageName = Properties.Messages_FR.LanguageName;
            }
            else
            {
                enterLanguageTxt = Properties.Messages.EnterLanguageText;
                languageChangedTxt = Properties.Messages.LanguageChangedText;
                invalidInput = Properties.Messages.InvalidInput;
                languageName = Properties.Messages.LanguageName;
            }
        }

    }
}
