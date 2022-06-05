using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    interface IVendingMachine
    {
        public void DisplayMachineBalance();
        public void ShowProducts();
        public void RefillMachine();
        public void SelectProduct();
        public void DisplaySaleRecords();
        public void CancelTransaction();
        public void ChangeLanguage();
    }
}
