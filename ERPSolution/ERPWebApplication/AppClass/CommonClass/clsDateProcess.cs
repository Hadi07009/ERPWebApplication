using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


public class clsDateProcess
{

    public clsDateProcess() { }

    public static int NoOfDaysOfMonth(DateTime inputDate)
    {
        try
        {
            int month = inputDate.Month;
            int year = inputDate.Year;
            if (1 == month || 3 == month || 5 == month || 7 == month || 8 == month || 10 == month || 12 == month)
            {
                return 31;
            }
            else if (2 == month)
            {
                if (0 == (year % 400))
                    return 29;
                else if (0 == (year % 100))
                    return 28;
                else if (0 == (year % 4))
                    return 29;
                else
                    return 28;
            }
            else
                return 30;
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
            return 0;
        }
    }

    public static int FirstDayOfMonth(DateTime inputDate)
    {
        return 1;
    }

    public static DateTime FirstDateOfMonth(DateTime inputDate)
    {
        DateTime dt = Convert.ToDateTime("1/" + inputDate.Month + "/" + inputDate.Year);
        return dt;
    }

    public static string FirstDayOfMonthName(DateTime inputDate)
    {
        try
        {
            DateTime pd;
            pd = Convert.ToDateTime("1/" + inputDate.Month + "/" + inputDate.Year);
            return pd.DayOfWeek.ToString();
        }
        catch (Exception ex)
        {

            System.Windows.Forms.MessageBox.Show(ex.Message);
            return "";
        }
    }

    public static int LastDayOfMonth(DateTime inputDate)
    {
        try
        {
            int month = inputDate.Month;
            int year = inputDate.Year;
            if (1 == month || 3 == month || 5 == month || 7 == month || 8 == month || 10 == month || 12 == month)
            {
                return 31;
            }
            else if (2 == month)
            {
                if (0 == (year % 400))
                    return 29;
                else if (0 == (year % 100))
                    return 28;
                else if (0 == (year % 4))
                    return 29;
                else
                    return 28;
            }
            else
                return 30;
        }
        catch (Exception ex)
        {

            System.Windows.Forms.MessageBox.Show(ex.Message);
            return 0;
        }
    }

    public static DateTime LastDateOfMonth(DateTime inputDate)
    {
        try
        {
            int month = inputDate.Month;
            int year = inputDate.Year;
            if (1 == month || 3 == month || 5 == month || 7 == month || 8 == month || 10 == month || 12 == month)
            {
                return Convert.ToDateTime("31/" + inputDate.Month + "/" + inputDate.Year);
            }
            else if (2 == month)
            {
                if (0 == (year % 400))
                    return Convert.ToDateTime("29/" + inputDate.Month + "/" + inputDate.Year);
                else if (0 == (year % 100))
                    return Convert.ToDateTime("28/" + inputDate.Month + "/" + inputDate.Year);
                else if (0 == (year % 4))
                    return Convert.ToDateTime("29/" + inputDate.Month + "/" + inputDate.Year);
                else
                    return Convert.ToDateTime("28/" + inputDate.Month + "/" + inputDate.Year);
            }
            else
                return Convert.ToDateTime("30/" + inputDate.Month + "/" + inputDate.Year);
        }
        catch (Exception ex)
        {

            System.Windows.Forms.MessageBox.Show(ex.Message);
            return System.DateTime.Now.Date; ;
        }
    }

    public static string LastDayOfMonthName(DateTime inputDate)
    {
        try
        {
            DateTime pd;
            pd = Convert.ToDateTime(LastDayOfMonth(inputDate) + "/" + inputDate.Month + "/" + inputDate.Year);
            return pd.DayOfWeek.ToString();
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
            return "";
        }
    }

    public static int CurrentMonthNo
    {
        get { return System.DateTime.Now.Month; }
    }

    public static string CurrentMonthName
    {
        get { return MonthName(System.DateTime.Now.Month); }
    }

    public static string MonthName(int month)
    {
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        return months[month].ToString();
    }

    public static DateTime GetServerDate(string ConnectionString)
    {
        DateTime dd = System.DateTime.Now;
        try
        {
            DataTable dt = clsDataManipulation.GetData(ConnectionString, "select Getdate() as rd");
            if (dt.Rows.Count > 0)
            {
                dd = Convert.ToDateTime(dt.Rows[0]["rd"].ToString());
            }

        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "");
        }
        return dd;
    }

    public static string AccountingPeriodbydate(DateTime dt)
    {
        string acp = "";

        try
        {
            acp = string.Format("{0:0000}", dt.Year) + "/" + string.Format("{0:00}", dt.Month);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
        return acp;

    }
    public static string AccountingPeriodbydate(DateTime dt, bool a)
    {
        string acp = "";

        try
        {
            acp = string.Format("{0:0000}", dt.Year) + "" + string.Format("{0:00}", dt.Month);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
        return acp;

    }

    public static int GetTotalMinutes(DateTime dtst, DateTime dtend)
    {
        int totalMinutes = 0;
        DateTime dt1 = Convert.ToDateTime(dtst);
        DateTime dt2 = Convert.ToDateTime(dtend);
        TimeSpan ts = dt2 - dt1;
        totalMinutes = Convert.ToInt32(ts.TotalMinutes.ToString());
        return totalMinutes;
    }

    public static string TimeDuration(int duration)
    {
        int hr = duration / 60;
        int min = duration % 60 > 0 ? duration % 60 : 0;
        string dur = string.Format("{0:00}", hr).ToString() + ":" + string.Format("{0:00}", min).ToString();
        return dur;
    }

    public static string[] GetFinancialPeriod(string startLeaveDate)
    {
        int monthNo = Convert.ToDateTime(startLeaveDate).Month;
        DateTime leaveDate = Convert.ToDateTime(startLeaveDate);
        string fromDate = null;
        string toDate = null;
        if (monthNo < 7)
        {
            fromDate = ("01/07/" + (leaveDate.Year - 1)).ToString();
            toDate = ("30/06/" + leaveDate.Year).ToString();
        }
        else
        {
            fromDate = ("01/07/" + leaveDate.Year).ToString();
            toDate = ("30/06/" + (leaveDate.Year + 1)).ToString();
        }
        string[] periodValue = new string[] { fromDate, toDate };
        return periodValue;
    }

    public static bool CheckDate(string dtt)
    {
        try
        {
            DateTime dtr = Convert.ToDateTime(dtt);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public static string DateToNumber(DateTime dtDate)
    {

        return string.Format("{0:00}", dtDate.Month) + "" + string.Format("{0:00}", dtDate.Year.ToString().Substring(2, 2)) + "-";
    }



}

