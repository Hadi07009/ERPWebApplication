using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPWebApplication.AppClass.Model;

namespace ERPWebApplication.AppClass.CommonClass
{
    public class AutoTableData
    {
        private int _tableID;

        public int TableID
        {
            get { return _tableID; }
            set { _tableID = value; }
        }
        DataTable dtAutoData = null;

        public AutoTableData(TwoColumnTables objTwoColumnTables)
        {
            TableID = objTwoColumnTables.TableID;
            dtAutoData = new DataTable();
            dtAutoData.Columns.Add(new DataColumn("FieldOfID", typeof(String)));
            dtAutoData.Columns.Add(new DataColumn("FieldOfName", typeof(String)));
        }

        public DataTable ControlTableID()
        {
            try
            {
                DataTable dtTargetData = new DataTable();
                if (TableID == 8)
                {
                    dtTargetData = GenderSetup();

                }
                else if (TableID == 9)
                {
                    dtTargetData = MaritalStatusSetup();
                }
                else if (TableID == 10)
                {
                    dtTargetData = ReligionSetup();
                }
                else if (TableID == 11)
                {
                    dtTargetData = BloodGroupSetup();
                }
                else if (TableID == 12)
                {
                    dtTargetData = BankAccountTypeSetup();
                }
                else if (TableID == 13)
                {
                    dtTargetData = DataStatusSetup();
                }
                else if (TableID == 14)
                {
                    dtTargetData = DataUsedSetup();
                }
                else if (TableID == 15)
                {
                    dtTargetData = ContactCategorySetup();
                }
                else if (TableID == 16)
                {
                    dtTargetData = BankListSetup();
                }
                else if (TableID == 17)
                {
                    dtTargetData = CardTypeSetup();
                }
                else if (TableID == 18)
                {
                    dtTargetData = TransactionMediaSetup();
                }
                else if (TableID == 19)
                {
                    dtTargetData = MaterialTransactionStatusSetup();
                }
                else if (TableID == 20)
                {
                    dtTargetData = BusinessNatureSetup();
                }
                else if (TableID == 21)
                {
                    dtTargetData = OwnershipSetup();
                }
                else if (TableID == 23)
                {
                    dtTargetData = DistrictSetup();
                }

                return dtTargetData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable DistrictSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100231"; dr[1] = "DHAKA"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100232"; dr[1] = "FARIDPUR"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable GenderSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100301"; dr[1] = "Male"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100302"; dr[1] = "Female"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable MaritalStatusSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100401"; dr[1] = "Married"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100402"; dr[1] = "Single"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100403"; dr[1] = "Widowed"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100404"; dr[1] = "Divorced"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100405"; dr[1] = "Separated"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception)
            {

                throw;
            }

        }
        private DataTable ReligionSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100501"; dr[1] = "Islam"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100502"; dr[1] = "Christianity"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100503"; dr[1] = "Hinduism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100504"; dr[1] = "Buddhism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100505"; dr[1] = "Sikhism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100506"; dr[1] = "Judaism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100507"; dr[1] = "Bahaism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100508"; dr[1] = "Confucianism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100509"; dr[1] = "Jainism"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100510"; dr[1] = "Shintoism"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable BloodGroupSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100601"; dr[1] = "A RhD positive (A+)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100602"; dr[1] = "A RhD negative (A-)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100603"; dr[1] = "B RhD positive (B+)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100604"; dr[1] = "B RhD negative (B-)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100605"; dr[1] = "O RhD positive (O+)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100606"; dr[1] = "O RhD negative (O-)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100607"; dr[1] = "AB RhD positive (AB+)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100608"; dr[1] = "AB RhD negative (AB-)"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception)
            {

                throw;
            }

        }
        private DataTable BankAccountTypeSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100701"; dr[1] = "Savings Account"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100702"; dr[1] = "Current Account "; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100703"; dr[1] = "Short Term Deposit Account"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100704"; dr[1] = "Fixed Depsit Receipt Account"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100705"; dr[1] = "Loans & Advance Account"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable DataStatusSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100901"; dr[1] = "Cancelled"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100902"; dr[1] = "Posted"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100903"; dr[1] = "Suspended"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100904"; dr[1] = "Female"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable DataUsedSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "101001"; dr[1] = "Active"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101002"; dr[1] = "Inactive"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable ContactCategorySetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "101101"; dr[1] = "Client"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101102"; dr[1] = "Supplier"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101103"; dr[1] = "Agent"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101104"; dr[1] = "Dealer"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101105"; dr[1] = "Distributor"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101106"; dr[1] = "Employee"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101107"; dr[1] = "Shipper"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101108"; dr[1] = "Labor"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101109"; dr[1] = "Worker"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable BankListSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100801"; dr[1] = "Agrani Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100802"; dr[1] = "BASIC Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100803"; dr[1] = "Janata Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100804"; dr[1] = "Rupali Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100805"; dr[1] = "Sonali Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100806"; dr[1] = "Bangladesh Development Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100807"; dr[1] = "Bangladesh Krishi Bank"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100808"; dr[1] = "Rajshahi Krishi Unnayan Bank (RAKUB)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100809"; dr[1] = "Shimanto bank"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100810"; dr[1] = "Palli Sanchay Bank"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100811"; dr[1] = "Private Commercial Banks[edit]"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100812"; dr[1] = "Conventional Commercial Banks"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100813"; dr[1] = "AB Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100814"; dr[1] = "Bangladesh Commerce Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100815"; dr[1] = "Bank Asia Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100816"; dr[1] = "BRAC Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100817"; dr[1] = "City Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100818"; dr[1] = "Dhaka Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100819"; dr[1] = "Dutch-Bangla Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100820"; dr[1] = "Eastern Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100821"; dr[1] = "IFIC Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100822"; dr[1] = "Jamuna Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100823"; dr[1] = "Meghna Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100824"; dr[1] = "Mercantile Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100825"; dr[1] = "Midland Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100826"; dr[1] = "Modhumoti Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100827"; dr[1] = "Mutual Trust Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100828"; dr[1] = "National Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100829"; dr[1] = "National Credit & Commerce Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100830"; dr[1] = "NRB Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100831"; dr[1] = "NRB Commercial Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100832"; dr[1] = "NRB Global Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100833"; dr[1] = "One Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100834"; dr[1] = "Premier Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100835"; dr[1] = "Prime Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100836"; dr[1] = "Pubali Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100837"; dr[1] = "South Bangla Agriculture & Commerce Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100838"; dr[1] = "Southeast Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100839"; dr[1] = "Standard Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100840"; dr[1] = "The Farmers Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100841"; dr[1] = "Trust Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100842"; dr[1] = "United Commercial Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100843"; dr[1] = "Uttara Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100844"; dr[1] = "Islamic Shariah based Commercial Banks"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100845"; dr[1] = "Al-Arafah Islami Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100846"; dr[1] = "EXIM Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100847"; dr[1] = "First Security Islami Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100848"; dr[1] = "ICB Islamic Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100849"; dr[1] = "Islami Bank Bangladesh Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100850"; dr[1] = "Shahjalal Islami Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100851"; dr[1] = "Social Islami Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100852"; dr[1] = "Union Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100853"; dr[1] = "Foreign Commercial Banks[edit]"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100854"; dr[1] = "Bank Al-Falah Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100855"; dr[1] = "Citibank N.A"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100856"; dr[1] = "Commercial Bank of Ceylon PLC"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100857"; dr[1] = "Habib Bank Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100858"; dr[1] = "National Bank of Pakistan"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100859"; dr[1] = "Standard Chartered Bank"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100860"; dr[1] = "State Bank of India"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100861"; dr[1] = "Hong Kong and Shanghai Banking Corporation Limited"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100862"; dr[1] = "Woori Bank"; dtAutoData.Rows.Add(dr);

                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable CardTypeSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "101201"; dr[1] = "VISA Debit Card"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101202"; dr[1] = "Master Debit Card"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101203"; dr[1] = "VISA Credit Card"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101204"; dr[1] = "Master Credit Card"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101205"; dr[1] = "JCB Credit Card"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101206"; dr[1] = "Bank Debit Card"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable TransactionMediaSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "101301"; dr[1] = "Cash"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101302"; dr[1] = "Cheque"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101303"; dr[1] = "Credit Card"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101304"; dr[1] = "Bank Deposit"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101305"; dr[1] = "Bank transfer"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101306"; dr[1] = "bKash"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101307"; dr[1] = "Q- cash"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101308"; dr[1] = "Rocket"; dtAutoData.Rows.Add(dr);

                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable MaterialTransactionStatusSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "101401"; dr[1] = "Sold"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101402"; dr[1] = "Rented"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101403"; dr[1] = "Un deliverd"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101404"; dr[1] = "Full Delivered"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101405"; dr[1] = "Partial Delivered"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "101406"; dr[1] = "Order Cancelled"; dtAutoData.Rows.Add(dr);

                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
        private DataTable BusinessNatureSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100101"; dr[1] = "Aerospace"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100102"; dr[1] = "Automotive"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100103"; dr[1] = "Banking"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100104"; dr[1] = "Buying House"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100105"; dr[1] = "Cement"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100106"; dr[1] = "Ceramics Sector"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100107"; dr[1] = "Chemical and petroleum"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100108"; dr[1] = "Construction"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100109"; dr[1] = "Consumer products"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100110"; dr[1] = "Cyber Cafe"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100111"; dr[1] = "Data Entry"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100112"; dr[1] = "Defense"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100113"; dr[1] = "Donor Agency"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100114"; dr[1] = "Education"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100115"; dr[1] = "Electronics"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100116"; dr[1] = "Energy and utilities"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100117"; dr[1] = "Engineering"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100118"; dr[1] = "Financial Institutions"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100119"; dr[1] = "Food & Allied"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100120"; dr[1] = "Garments Industry"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100121"; dr[1] = "Government"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100122"; dr[1] = "Healthcare"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100123"; dr[1] = "Hotel"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100124"; dr[1] = "Insurance"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100125"; dr[1] = "ISP"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100126"; dr[1] = "IT Enabled Service"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100127"; dr[1] = "IT Sector"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100128"; dr[1] = "Jute"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100129"; dr[1] = "Leasing"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100130"; dr[1] = "Life Sciences"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100131"; dr[1] = "Media and Entertainment"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100132"; dr[1] = "Mineral Resources"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100133"; dr[1] = "Miscellaneous"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100134"; dr[1] = "Newspaper"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100135"; dr[1] = "NGO"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100136"; dr[1] = "Online Seller"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100137"; dr[1] = "Paper & Printing"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100138"; dr[1] = "Pharmaceuticals & Chemicals"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100139"; dr[1] = "Radio Station"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100140"; dr[1] = "Real Estate & Housing"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100141"; dr[1] = "Retail"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100142"; dr[1] = "Software Development"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100143"; dr[1] = "Tannery Industries"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100144"; dr[1] = "Telecommunication"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100145"; dr[1] = "Television Channel"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100146"; dr[1] = "Textile"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100147"; dr[1] = "Travel & Leisure"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }
        }

        private DataTable OwnershipSetup()
        {
            try
            {
                DataRow dr;
                dr = dtAutoData.NewRow(); dr[0] = "100201"; dr[1] = "Sole Proprietorship"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100202"; dr[1] = "General Partnership"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100203"; dr[1] = "Limited Partnership"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100204"; dr[1] = "Private Limited Company"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100205"; dr[1] = "Public Limited Company"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100206"; dr[1] = "Corporation"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100207"; dr[1] = "Nonprofit Corporation"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100208"; dr[1] = "Trust"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100209"; dr[1] = "Joint Venture"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100210"; dr[1] = "Association"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100211"; dr[1] = "Society"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100212"; dr[1] = "Limited Liability Company (LLC)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100213"; dr[1] = "Limited Liability Partnership (LLP)"; dtAutoData.Rows.Add(dr);
                dr = dtAutoData.NewRow(); dr[0] = "100214"; dr[1] = "Limited Liability Limited Partnership (LLLP)"; dtAutoData.Rows.Add(dr);
                return dtAutoData;

            }
            catch (Exception msgException)
            {

                throw msgException;
            }

        }
    }
}