using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
  //第一次載入時執行
  protected void Page_Init(object sender, EventArgs e)
  {

  }

  //每次載入時執行
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  //Create
  protected void ButtonCreate_Click(object sender, EventArgs e)
  {
    //SQL新增語法
    string insertSQL = "Insert into dbo.Table (A,B,C) values (@A,@B,@C)";

    try
    {
      using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Server"].ConnectionString))
      {
        //開啟資料庫
        Connection.Open();

        using (SqlCommand command = new SqlCommand(insertSQL, Connection))
        {
          //避免隱碼攻擊，定義資料類型與內容
          command.Parameters.Add("@A", SqlDbType.NVarChar, 200).Value = "A";
          command.Parameters.Add("@B", SqlDbType.NVarChar, 200).Value = "B";
          command.Parameters.Add("@C", SqlDbType.NVarChar, 200).Value = "C";
          //執行SQL語法
          command.ExecuteNonQuery();
        }
      }
    }
    catch (Exception ex)
    {
      //例外處理
    }
  }

  //Read
  protected void ButtonRead_Click(object sender, EventArgs e)
  {

    //SQL搜尋語法
    string selectSQL = "Select * From dbo.Table";

    try
    {
      using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Server"].ConnectionString))
      {
        //執行SQL語法，SqlDataAdapter會自動開啟資料庫
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectSQL, Connection))
        {
          //將資料流取出
          DataSet dataSet = new DataSet();
          dataAdapter.Fill(dataSet);
          //將資料帶入DataTable
          using (DataTable selectDataTable = dataSet.Tables[0])
          {
            //以迴圈將所有資料回傳
            foreach (int TableRow in selectDataTable.Rows)
            {
              Response.Write(TableRow + "<br>");
            }
          }
        }
      }
    }
    catch (Exception ex)
    {
      //例外處理
    }
  }

  //Update
  protected void ButtonUpdate_Click(object sender, EventArgs e)
  {

    //SQL更新語法
    string updateSQL = "Update dbo.Table set B=@B,C=@C Where A=@A";

    try
    {
      using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Server"].ConnectionString))
      {
        //開啟資料庫
        Connection.Open();

        using (SqlCommand command = new SqlCommand(updateSQL, Connection))
        {
          //避免隱碼攻擊，定義資料類型與內容
          command.Parameters.Add("@A", SqlDbType.NVarChar, 200).Value = "A";
          command.Parameters.Add("@B", SqlDbType.NVarChar, 200).Value = "BB";
          command.Parameters.Add("@C", SqlDbType.NVarChar, 200).Value = "CC";
          //執行SQL語法
          command.ExecuteNonQuery();
        }
      }
    }
    catch (Exception ex)
    {
      //例外處理
    }
  }

  //Delete
  protected void ButtonDelete_Click(object sender, EventArgs e)
  {

    //SQL刪除語法
    string deleteSQL = "Delete From dbo.Table Where B=@B";

    try
    {
      using (System.Data.SqlClient.SqlConnection Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Server"].ConnectionString))
      {
        //開啟資料庫
        Connection.Open();

        using (SqlCommand command = new SqlCommand(deleteSQL, Connection))
        {
          //避免隱碼攻擊，定義資料類型與內容
          command.Parameters.Add("@B", SqlDbType.NVarChar, 200).Value = "BB";
          //執行SQL語法
          command.ExecuteNonQuery();
        }
      }
    }
    catch (Exception ex)
    {
      //例外處理
    }
  }
}