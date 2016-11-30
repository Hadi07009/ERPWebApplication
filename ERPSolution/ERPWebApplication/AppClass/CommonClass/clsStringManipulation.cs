using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Linq;


public class clsStringManipulation
{
    public clsStringManipulation() { }

    public string CreatingCommaSeparatedlist(string inputString1, string inputString2, string inputString3,
                                             string inputString4, string inputString5, string inputString6)
    {
        try
        {
            string commaSeparatedlist = null;
            string lastIndexValue = null;
            IList<string> stringList = new List<string>();
            if (inputString1 != null)
            {
                stringList.Add(inputString1);

            }

            if (inputString2 != null)
            {
                stringList.Add(inputString2);

            }

            if (inputString3 != null)
            {
                stringList.Add(inputString3);

            }

            if (inputString4 != null)
            {
                stringList.Add(inputString4);

            }

            if (inputString5 != null)
            {
                stringList.Add(inputString5);

            }

            if (inputString6 != null)
            {
                stringList.Add(inputString6);

            }

            int countIndex = stringList.Count;
            if (countIndex == 0)
            {
                return commaSeparatedlist;

            }

            if (countIndex == 1)
            {
                return commaSeparatedlist = string.Join(",", stringList);

            }

            if (countIndex == 2)
            {
                return commaSeparatedlist = string.Join(" and ", stringList);

            }

            if (countIndex > 2)
            {
                lastIndexValue = stringList[countIndex - 1].ToString();
                stringList.Remove(stringList.Last());
                commaSeparatedlist = string.Join(",", stringList);
                commaSeparatedlist = commaSeparatedlist + " and " + lastIndexValue;
            }

            return commaSeparatedlist;

        }
        catch (Exception msgException)
        {

            throw msgException;
        }
    }

    public string CommaSeparatedlistFromGridView(GridView gridViewID, string columnIndexs)
    {
        try
        {
            string commaSeparatedlist = null;
            string lastIndexValue = null;
            IList<string> stringList = new List<string>();
            foreach (GridViewRow rowNo in gridViewID.Rows)
            {
                String cellText = null;
                int cellIndex = 0;

                foreach (TableCell cell in rowNo.Cells)
                {
                    bool checkIndex = false;
                    string[] arryColumnIndex = columnIndexs.Split(',');
                    foreach (string selectedColumnIndex in arryColumnIndex)
                    {
                        if (cellIndex == Convert.ToInt32(selectedColumnIndex))
                        {
                            checkIndex = true;

                        }
                    }

                    if (checkIndex == false)
                    {
                        cellIndex++;
                        continue;

                    }

                    if (cell.Text == "&nbsp;")
                    {
                        cellIndex++;
                        continue;
                    }

                    if (cellIndex == (rowNo.Cells.Count - 1))
                    {
                        cellText += " @";

                    }
                    cellText += cell.Text + " ";
                    cellIndex++;

                }
                stringList.Add(cellText);
            }

            int countIndex = stringList.Count;
            if (countIndex == 0)
            {
                return commaSeparatedlist;

            }

            if (countIndex == 1)
            {
                return commaSeparatedlist = string.Join(",", stringList);

            }

            if (countIndex == 2)
            {
                return commaSeparatedlist = string.Join(" and ", stringList);

            }

            if (countIndex > 2)
            {
                lastIndexValue = stringList[countIndex - 1].ToString();
                stringList.Remove(stringList.Last());
                commaSeparatedlist = string.Join(",", stringList);
                commaSeparatedlist = commaSeparatedlist + " and " + lastIndexValue;
            }

            return commaSeparatedlist;

        }
        catch (Exception msgException)
        {

            throw msgException;
        }

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
    public static String SplitTheID(String str,char strSymbol)
    {
        char[] separator = new char[] { strSymbol };

        string rStr = str.Split(separator)[0].ToString();      

        return rStr;

    }

    public static String SplitTheName(String str, char strSymbol)
    {
        char[] separator = new char[] { strSymbol };

        string rStr = str.Split(separator)[1].ToString();

        return rStr;

    }

    public static string HtmlEncode(string text)
    {
        char[] chars = System.Web.HttpUtility.HtmlEncode(text).ToCharArray();
        StringBuilder result = new StringBuilder(text.Length + (int)(text.Length * 0.1));

        foreach (char c in chars)
        {
            int value = Convert.ToInt32(c);
            if (value > 127)
                result.AppendFormat("&#{0};", value);
            else
                result.Append(c);
        }

        return result.ToString();
    }

    public string SplitTheName(string name, int flag)
    {
        int stringlength;
        string ReturnName = string.Empty;
        string MiddleName = string.Empty;
        string FilterName = string.Empty;
        string ExtractTitle = string.Empty;
        string ExtractTitleFilterName = string.Empty;
        FilterName = clsStringManipulation.RemoveSpace(name);
        string[] ar1 = (FilterName.ToString().Replace(".", ". ")).Split(' ');
        
        string[] titles = { "Mr.", "Mrs.", "Mr", "Mrs", "Miss.", "Miss", "Ms", "Ms.", "Dr.", "Dr", "Eng.", "Eng", "Engr.", "Engr" };
        
        for (int i = 0; i < titles.Length; i++)
        {
            for (int j = 0; j < ar1.Length; j++)
            {
                if (clsStringManipulation.ConvertProperCase(ar1[j].ToString()) == clsStringManipulation.ConvertProperCase(titles[i].ToString()))
                {
                    ExtractTitle = ar1[j].ToString();

                }
            }
        }

        ReturnName = ExtractTitle;


        if (ReturnName != string.Empty)
        {
            ExtractTitleFilterName = clsStringManipulation.RemoveSpace(FilterName.Replace(ReturnName, string.Empty));
        }
        else
        {
            ExtractTitleFilterName = FilterName;
        }


        ExtractTitleFilterName = clsStringManipulation.RemoveSpace(ExtractTitleFilterName);
        string[] ar = ExtractTitleFilterName.ToString().Split(' ');
        stringlength = ar.Length;

        if (flag == 0)
        {
            ReturnName = ExtractTitle;
        }
        else if ((ar.Length >= 2) && (flag == 1))
        {
            ReturnName = ar[0].ToString();
        }

        else if ((ar.Length <= 2) && (flag == 2))
        {
            ReturnName = string.Empty;
        }
        else if ((ar.Length > 2) && (flag == 2))
        {
            for (int i = 1; i < (ar.Length - 1); i++)
            {
                MiddleName += ar[i].ToString() + " " + string.Empty;
            }
            ReturnName = MiddleName;
        }

        else if ((ar.Length >= 2) && (flag == 3))
        {
            ReturnName = ar[(stringlength - 1)].ToString();
        }
        else if ((ar.Length < 2) && (flag == 3))
        {
            ReturnName = string.Empty;
        }
        return ReturnName;

    }

    public string FullName(string title, string firstname, string middlename, string lastname)
    {
        string ReturnName = string.Empty;

        ReturnName = clsStringManipulation.RemoveSpace(title + " " + firstname + " " + middlename + " " + lastname);

        return ReturnName;
    }

    public static string RemoveSpace(string inputString)
    {
        string[] ips;
        string retStr = "";
        try
        {
            ips = inputString.Trim().Split(' ');
            for (int i = 0; i < ips.Length; i++)
            {
                if (ips[i] != "")
                {
                    retStr = retStr + " " + ips[i];
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return retStr.Trim();
    }

    public static string ConvertProperCase(string inputString)
    {
        string[] ips;
        string retStr = "";
        try
        {
            ips = inputString.Trim().Split(' ');
            string ps = "";
            for (int i = 0; i < ips.Length; i++)
            {
                if (ips[i].ToUpper() != ips[i])
                {
                    ps = ips[i];
                    for (int j = 0; j < ps.Length; j++)
                    {
                        if (j == 0)
                        {
                            retStr = retStr + Convert.ToString(ps[j]).ToUpper();
                        }
                        else
                        {
                            retStr = retStr + ps[j];
                        }
                    }

                    retStr = retStr + " ";
                }
                else
                    if (ips[i] == "")
                        retStr = retStr + " ";
                    else
                        retStr = retStr + ips[i] + " ";

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

        return retStr.Trim();
    }

    public static string addZeroInString(string str, int len, bool left)
    {
        for (int i = str.Length; i < len; i++)
        {
            if (left)
                str = "0" + str;
            else
                str = str + "0";
        }
        return str;
    }

    public static string InvalidCharecterHandler(string PassStr)
    {
        PassStr = PassStr.Replace("'", "''");
        return PassStr;
    }

    public static string InvalidCharecterAssign(string PassStr)
    {
        PassStr = PassStr.Replace("&#39;", "'");
        PassStr = PassStr.Replace("&amp;#", "'");
        PassStr = PassStr.Replace("&nbsp;", "");

        return PassStr;
    }

    public static string InvalidCharecterRemove(string PassStr)
    {
        PassStr = PassStr.Replace("'", "");
        return PassStr;
    }
}
