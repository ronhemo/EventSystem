using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
public interface DbAction
{

    int Init();
    int AddNew();
    int Update();
    int Delete();

}
public static class DbQ
{
    static string dbName = "eventDb.accdb";
	/// <summary>
    /// ביצוע שאילתה הוספה עדכון או מחיקה בדטהבס
    /// </summary>
    /// <param name="QueryString">שאילתה</param>
    /// <returns>מספר 1- מציין שהפעולה נכשלה 1 מציין ביצוע מוצלח</returns>
    public static int ExecuteNonQuery(String QueryString)
    {
        
        string dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + dbName);
        string connectionString = @"Data Source='" + dbPath + "';Provider='Microsoft.ACE.OLEDB.12.0';";
        OleDbConnection con = new OleDbConnection(connectionString);

        int retVal;
        con.Open();
        OleDbCommand cmd = new OleDbCommand(QueryString, con);
        try
        {
            retVal = cmd.ExecuteNonQuery();
        }
        catch
        {
            retVal = -1;
        }
        finally
        {
            con.Close();

        }
        return retVal;
    }
    /// <summary>
    /// הבאת נתונים מהדטהביס בתוך דטהסט
    /// </summary>
    /// <param name="QueryString">שאילתה</param>
    /// <returns>דטהסט המכיל את טבלת נתונים</returns>
    public static DataSet ExecuteQuery(String QueryString)
    {
        string dbPath = HttpContext.Current.Server.MapPath("~\\App_Data\\" + dbName);
        //מחרוזת התחברות לקובץ אקסס 2003
        string connectionString = @"Data Source='" + dbPath + "';Provider='Microsoft.ACE.OLEDB.12.0';";
        //יצירת אוביקט התחברות בהתאם למחרות ההתחברות
        OleDbConnection con = new OleDbConnection(connectionString);
        //פתיחת החיבור 
        con.Open();
        //יצירת אוביקט הפקודה להרצת השאילתה עבור החיבור הנתון
        OleDbCommand cmd = new OleDbCommand(QueryString,con);
        //הפעלת הפקודה
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //יצירת דטהסט לאיחסון הנתונים
        DataSet ds = new DataSet();
        //הכנסת הנתונים,תוצאת השאילתה,לתוך הדטהסט שבזיכון
        da.Fill(ds, "tbl");
        //סגירת החיבור לדטהביס
        con.Close();

        return ds;
    }   
}