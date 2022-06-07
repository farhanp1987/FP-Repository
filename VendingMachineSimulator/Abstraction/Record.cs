using System;

namespace VendingMachine.Abstraction
{
    public abstract class Record
    {
        protected readonly int recordID;
        protected readonly DateTime recordDate;
        protected readonly string recordMessage;

        public Record(int recordID, DateTime recordDate, string recordMessage)
        {
            this.recordID = recordID;
            this.recordDate = recordDate;
            this.recordMessage = recordMessage;
        }

        public int RecordID
        {
            get
            {
                return this.recordID;
            }
        }

        public DateTime RecordDate
        {
            get
            {
                return this.recordDate;
            }
        }

        public string RecordMessage
        {
            get
            {
                return this.recordMessage;
            }
        }
    }

    public sealed class SaleRecord : Record
    {
        private static int totalSaleRecords = 1;

        private readonly Item saleItem;
        private readonly double amountPaid;

        public SaleRecord(DateTime recordDate, string recordMessage, Item saleItem, double amountPaid) :
            base(totalSaleRecords++, recordDate, recordMessage)
        {
            this.saleItem = saleItem;
            this.amountPaid = amountPaid;
        }

        public Item SaleItem
        {
            get
            {
                return this.saleItem;
            }
        }

        public double AmountPaid
        {
            get
            {
                return this.amountPaid;
            }
        }

        public override string ToString()
        {
            return string.Format("[Sale Record] ID: {0}, Date: {1}, Item Sold: {2}, Sold Amount: {3}E",
                this.recordID, this.recordDate.ToString("dd/MM/yyyy HH:mm:ss"), this.saleItem.ItemName, this.saleItem.ItemPrice);
        }
    }
}
