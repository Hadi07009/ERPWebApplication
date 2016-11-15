using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWebApplication.Model
{
    public class ClsRequisitionDetail
    {

        public ClsRequisitionDetail()
        { 
        
        }

       
        private string itemRequisitionNo;
        private int inventoryItemID;
        private string requiredItemName;
        private decimal requestedQuantity;
        private decimal finalQuantity;
        private decimal possibleRate;
        private decimal finalRate;
        private int unitID;

       
      
        private string countryOfOrigin;
        private string specification;
        private string brand;
     

        
        public string ItemRequisitionNo
        {
            get { return itemRequisitionNo; }
            set { itemRequisitionNo = value; }

        }
        public int InventoryItemID
        {
            get { return inventoryItemID; }
            set { inventoryItemID = value; }
        }


        public string RequiredItemName
        {
            get { return requiredItemName; }
            set { requiredItemName = value; }
        }

        public decimal RequestedQuantity
        {
            get { return requestedQuantity; }
            set { requestedQuantity = value; }
        }

        public decimal FinalQuantity
        {
            get { return finalQuantity; }
            set { finalQuantity = value; }
        }

        public decimal PossibleRate
        {
            get { return possibleRate; }
            set { possibleRate = value; }
        }

        public decimal FinalRate
        {
            get { return finalRate; }
            set { finalRate = value; }
        }


        public int UnitID
        {
            get { return unitID; }
            set { unitID = value; }
        }


        public string CountryOfOrigin
        {
            get { return countryOfOrigin; }
            set { countryOfOrigin = value; }
        }

        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }


    }
}