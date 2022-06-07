using System;

namespace VendingMachine.Abstraction
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
