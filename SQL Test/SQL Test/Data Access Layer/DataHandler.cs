using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace SQL_Test
{
    //  Empty method stubs in order to hide the inner workings of the database.
    
    
    class DataHandler
    {
        string link = null;

        public void testConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(link);
                conn.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string getProductID(string code)
        {
            string output = null;
            return output;
        }

        public List<Class2> getIncidents(string code)
        {
            List<Class2> arrOut = new List<Class2>();
            return arrOut;
        }

        public string getStockDesc(string code)
        {
            string output = null;
            return output;
        }

        public string getStockName(string code)
        {
            string output = null;
            return output;
        }

        public Class7 GetProductClass(string code)
        {
            Class7 output = null;
            return output;
        }

        public Class3 GetDescription(string code)
        {
            Class3 output = null;
            return output;
        }

        public Class5 GetMethodDetails(string code)
        {
            Class5 output = null;
            return output;
        }

        public string getQtyPer(string code)
        {
            string output = "";
            return output;
        }

        public List<Class4> getScrapRate(string code)
        {
            List<Class4> output = new List<Class4>();
            return output;
        }

        public List<Class1> getComponents(string code)
        {
            List<Class1> output = new List<Class1>();
            return output;
        }
    }
}
