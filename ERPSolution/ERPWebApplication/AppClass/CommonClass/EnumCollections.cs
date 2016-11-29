using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace MyFrameWork
//{
    public class EnumCollections 
    {
        public EnumCollections()   {}
    }

    //        ' For Database Types (SQL Server or Oracle)
    //' -----------------------------------------
    //' Place in	:	DataBaseConcls
    //' call by	:	clsDataBaseCon


    public enum eDBServerType
    {
        e1SQLServer = 1,
        e2OracleServer,
        e3MySQLServer
    }


    //' For Account Types (Child or Parent)
    //' -----------------------------------------
    //' Place in	:	COAcls
    //' call by	:	clsCOA

    public enum eParentOrChild
    {

        e0ChildAccount = 0,
        e1ParentAccount
    }

    public enum eAccountType
    {
        e0IndirectAccount = 0,
        e1DirectAccount
    }

    public enum eTransactionType
    {
        eUndefined              = 0,
        ePurchaseTrans          = 1,
        eLCPurchase             = 2,
        eSalesTrans             = 3,
        eReciptTrans            = 4,
        ePaymentTrans           = 5,
        ////'=====================
        //' Cheque Related
        //'====================
        eChequeDeposit          = 6,
        eChequeCleared          = 7,
        eChequeBounced          = 8,
        //'====================
        //' Account Related
        //'====================
        eAccountTransfer        = 9,
        //'====================
        //' Godown Related
        //'====================
        eStockMovment           = 10,

        eSalesOrder             = 11,
        ePurchaseOrder          = 12,
        eOrderDelivery          = 13,
        eSalesReturn            = 14,
        ePurchaseReturn         = 15,
        eBillSubmission         = 17,
        eBillRecipt             = 18,
        eCashWithdrawal         = 19,
        eCashDeposit            = 20,
        eCreditCardRecipt       = 21,
        eCreditCardPayment      = 22,
        eReceivedOrderCancel    = 23,
        ePurchaseOrderCancel    = 24,
        etStopPayment           = 25,
        eItemIssued             = 26,
        eIOU                    = 27,
        eOpeningBalance         = 100,
        eExpense                = 101,
        eSalaryPayment          = 102,
        eAdjustment             = 103,
        eInvestment             = 104,
        eJournal                = 105,
    }


    //' For Posting status of vouchers
    //' -----------------------------------------
    //' Place in	:	COAcls
    //' call by	:	clsCOA

    public enum eVoucherPostStatus
    {

        ePostedVoucher,
        eUnpostedVoucher
    }

    //' For Types of vouchers
    //' -----------------------------------------
    //' Place in	:	COAcls
    //' call by	:	clsCOA


    public enum eVoucherTypes
    {
        e0Credit = 0,
        e1Debit
    }

    //' For Check Status
    //' -----------------------------------------
    //' Place in	:	Bankcls
    //' call by	:	clsBank


    public enum eChequeStatus
    {
        //' This Enum is to get the value of Cheque Status Type.
        //' It is used in SelectDBType Parameter

        e1Bounced = 1,
        e2Received,
        e3Issued,
        e4Deposited,
        e5Cleared,
        e6DepositedAgain,
        e7CashAgainstChequeRefund,
        e8OnlyChequeRefund,
        e9StopPayment,
        e10NewChequeReceived,
    }



    //' For Item Barcode Type (System or Product Barcode)
    //' -----------------------------------------
    //' Place in	:	Productscls
    //' call by	:	clsProducts


    public enum eItemBarCodeTypeInt
    {

        SystemBarcode_01 = 1,
        ProductBarcode_02
    }


    public enum eMatTransType
    {
        eUndeliverd = 1,
        eFullDelivery,
        ePartialDelivery,
        eOrderCancelled
    }


    public enum eItemDeliveryStatus
    {

        eToBeDelivered = 0,
        eItemCancelled
    }

    public enum eItemType
    {

        eBarcodeItem = 1,
        eScaleItem
    }



    //' For Item Offers to Customer 
    //' -----------------------------------------
    //' Place in	:	CustomerBenefitscls
    //' call by	:	clsCustomerBenefits

    public enum eOfferTypes
    {
        eODiscount01 = 1,
        eOCoupon02 = 2,
        eOLottery03 = 3
    }

    //' For LC report type
    //' -----------------------------------------
    //' Place in	:	LCDetailscls
    //' call by	:	clsLCDetails

    public enum eLCReportType
    {
        eLCReportDetails = 0,
        eLCReportSummary,
        eLCReportDetailsQNT,
        eLCReportSummaryQNT
    }

    //' For Software product type
    //' -----------------------------------------
    //' Place in	:	SoftwareMangementcls
    //' call by	:	clsSoftwareMangement


    public enum eSoftType
    {

        eAllSoft,
        eAccountingSoft,
        eInventorySoft,
        eLCSoft,
        eRealEstateSoft,
        eArchitecheralSoft,
        eTailorShopSoft,
        eHospitalSoft,
        eExport
    }


    public enum eAccessType
    {

        e0Disable = 0,
        e1Enable
    }

    public enum eDataType
    {
        eString,
        eInteger,
        eLong,
        eDouble,
        eSingle,
        eDate
    }


    //' For Project use or Not
    //' -----------------------------------------
    //' Place in	:	Projectscls
    //' call by	:	clsProjects


    public enum eProjectType
    {
        eNoProject,
        eMultiProject
    }


    //' For Report Module
    //' -----------------------------------------
    //' Place in	:	Reportcls
    //' call by	:	clsReport


    public enum eCalculateWhat
    {
        eAdvanceReceipt = 1,
        eReceivables = 2,
        eAdvancePaid = 3,
        ePayables = 4,
        eOthers = 5
    }


    //' For Calculation
    //' -----------------------------------------
    //' Place in	:	Calculationcls
    //' call by	:	clsCalculation

    public enum pTypeOfRound
    {
        Actual = 0,
        UpperRound,
        LowerRound
    }


    //' For Persons Type
    //' -----------------------------------------
    //' Place in	:	Contactcls
    //' call by	:	clsContact


    public enum eTypeOfPersons
    {
        eClient_1 = 1,
        eSupplier_2,
        eAgent_3,
        eDealer_4,
        eDistributor_5,
        eEmployee_6,
        eShipper_7,
        eLabor_8,
        eBank_9,
        eCreditCard_10,
        eOthers_11
    }


    //' For DateProperty
    //' -----------------------------------------
    //' Place in	:	Reportcls
    //' call by	:	clsReport

    public enum eDatePropertyType
    {
        eDay = 1,
        eWeek,
        eMonth,
        eQuaterM,
        eYear
    }

    public enum eDataUsedProperty
    {
        All,
        OnlyActive,
        OnlyInActive
    }

public enum eNamePartition
{
    Title,
    FirstName,
    MiddleName,
    LastName,
}
//}
