using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Class3.Models
{
    public class ItemGateway
    {
        public string Save(Item anItem)
        {
            string connString = WebConfigurationManager.ConnectionStrings["ProductDatabase"].ConnectionString;
            SqlConnection aConnection = new SqlConnection(connString);
            string commandStr = "INSERT INTO table_item VALUES ('" + anItem.Code + "','" + anItem.Name + "','" + anItem.UnitPrice + "')";
            SqlCommand aSqlCommand = new SqlCommand(commandStr, aConnection);
            aConnection.Open();
            aSqlCommand.ExecuteNonQuery();
            aConnection.Close();
            return "saved";
        }

        public List<Item> GetTheList()
        {
            string connString = WebConfigurationManager.ConnectionStrings["ProductDatabase"].ConnectionString;
            SqlConnection aConnection = new SqlConnection(connString);
            string commandStr = "SELECT * FROM table_item";
            SqlCommand aSqlCommand = new SqlCommand(commandStr, aConnection);
            aConnection.Open();
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            List<Item> aList=new List<Item>();

            while (aDataReader.Read())
            {
                Item item=new Item();
                item.Code = aDataReader["code"].ToString();
                item.Name = aDataReader["name"].ToString();
                item.UnitPrice = aDataReader["unit_price"].ToString();
                aList.Add(item);
            }
            aDataReader.Close();
            aConnection.Close();
            return aList;
        }

        
    }
}