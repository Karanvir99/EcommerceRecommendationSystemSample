using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace EcommerceRecommendationSystem
{
    public class CollaborativeFilteringRecommendation
    {
        //For returning average rating simillarity between all customers of the website
        public double AVGMethod(double parameter1, double parameter2)
        {
            Double AVGReturn;

            SQLConnectionClass CurrentCustRateAVG = new SQLConnectionClass();
            CurrentCustRateAVG.retrieveData("select * from TempMatrixTable where CustomerID="+ parameter1  + "");
            double CurCustomer = 0;
            int avgCount = 0;
            double CurCustomerAVG = 0;
            foreach (DataRow allDataRow in CurrentCustRateAVG.SQLTable.Rows)
            {
                string CurCustRate = allDataRow["Rating"].ToString();
                if (CurCustRate != "")
                {
                    SQLConnectionClass CustRateAVG = new SQLConnectionClass();
                    CustRateAVG.retrieveData("select * from TempMatrixTable where CustomerID=" + parameter2 + " and ItemID=" + allDataRow["ItemID"] + "");

                    string CompCustRate = CustRateAVG.SQLTable.Rows[0][1].ToString();

                    if (CompCustRate != "")
                    {
                        CurCustomer = CurCustomer + Convert.ToDouble(allDataRow["Rating"]);
                        avgCount = avgCount + 1;

                    }
                }
            }
            CurCustomerAVG = CurCustomer / avgCount;
            AVGReturn = CurCustomerAVG;

            return AVGReturn;
        }

        //Gathering customer data
        public double GetRecommendedCustomer()
        {
            int i = 0;          

            Guid gid = Guid.NewGuid();

            SQLConnectionClass selectCustomer = new SQLConnectionClass();
            selectCustomer.retrieveData("select CustomerID from [CustomerItemFeedback] group by CustomerID");

            foreach (DataRow CustDataRow in selectCustomer.SQLTable.Rows)
            {

                SQLConnectionClass selectData = new SQLConnectionClass();
                selectData.retrieveData("select Rating,ItemID from [CustomerItemFeedback]  where   CustomerID= " + CustDataRow["CustomerID"] + " group by ItemID, Rating order by ItemID");

                foreach (DataRow allDataRow in selectData.SQLTable.Rows)
                {

                    SQLConnectionClass saveData = new SQLConnectionClass();
                    saveData.CommandExec("INSERT INTO [dbo].[TempMatrixTable]([GID],[Rating],[CustomerID] ,[ItemID])VALUES ('" + gid + "'," + allDataRow["Rating"] + ", " + CustDataRow["CustomerID"] + ",'" + allDataRow["ItemID"] + "' )");
                }

                SQLConnectionClass selectData1 = new SQLConnectionClass();
                selectData1.retrieveData("select ItemID from [CustomerItemFeedback]  where CustomerID<>" + CustDataRow["CustomerID"] + " group by ItemID"
                   + " EXCEPT"
                    + " select ItemID from[CustomerItemFeedback]  where CustomerID = " + CustDataRow["CustomerID"] + " group by ItemID order by ItemID");

                foreach (DataRow allDataRow1 in selectData1.SQLTable.Rows)
                {

                    SQLConnectionClass saveData = new SQLConnectionClass();
                    saveData.CommandExec("INSERT INTO [dbo].[TempMatrixTable]([GID],[CustomerID] ,[ItemID])VALUES ('" + gid + "', " + CustDataRow["CustomerID"] + ",'" + allDataRow1["ItemID"] + "' )");
                }
            }
            // Now I Got All customers data 
          
            // Start Calculation
            SQLConnectionClass AllCus = new SQLConnectionClass();
            AllCus.retrieveData("select CustomerID from TempMatrixTable   where  Gid='" + gid + "' and CustomerID!=" + HttpContext.Current.Session["UserID"] + "  group by CustomerID");

            double equation4 = 0;
            double equation6 = 0;
            double equation8 = 0;
            double MainEquation = 0;
            double CustID;

            var CFRecommender = new List<double>();

            var myArray = CFRecommender.ToArray();
           
            foreach (DataRow itemDataRow1 in AllCus.SQLTable.Rows)
            {
                double custAvg = AVGMethod(Convert.ToDouble(HttpContext.Current.Session["UserID"]), Convert.ToDouble(itemDataRow1["CustomerID"]));
                double AnotherCusAvg = AVGMethod( Convert.ToDouble(itemDataRow1["CustomerID"]), Convert.ToDouble(HttpContext.Current.Session["UserID"]));

                SQLConnectionClass CurrentCust = new SQLConnectionClass();
                CurrentCust.retrieveData("select * from TempMatrixTable where CustomerID=" + HttpContext.Current.Session["UserID"] + " and  Gid='" + gid + "'");             

                foreach (DataRow itemDataRow2 in CurrentCust.SQLTable.Rows)
                {
                    string rate = itemDataRow2["Rating"].ToString();

                    if (rate != "")
                    {                  
                        double equation1 = Convert.ToDouble(itemDataRow2["Rating"]) - custAvg;

                        SQLConnectionClass AnotherCus = new SQLConnectionClass();
                        AnotherCus.retrieveData("select Rating from TempMatrixTable where CustomerID=" + itemDataRow1["CustomerID"] + " and  ItemID =" + itemDataRow2["ItemID"] + " and  Gid='" + gid + "'");

                        string cutsrate = AnotherCus.SQLTable.Rows[0][0].ToString();

                        if (cutsrate != "")
                        {
                            double equation2 = Convert.ToDouble(AnotherCus.SQLTable.Rows[0][0].ToString()) - AnotherCusAvg;

                            double equation3 = equation1 * equation2;
                            equation4 = equation4 + equation3;

                            double equation5 = Math.Pow(equation1, 2);
                            equation6 = equation6 + equation5;

                            double equation7 = Math.Pow(equation2, 2);
                            equation8 = equation8 + equation7;
                        }
                    }
                }
                //Getting the rating similarity range for all customers of the system excluding the logged in customer
                MainEquation = equation4 /( Math.Sqrt(equation6) * Math.Sqrt(equation8));
                CustID = Convert.ToDouble(itemDataRow1["CustomerID"]);

                CFRecommender.Add(CustID);
                myArray = CFRecommender.ToArray();
                CFRecommender.Add(MainEquation);
                myArray = CFRecommender.ToArray();

                equation4 = 0;
                equation6 = 0;
                equation8 = 0;
            }

            double MaxValue = -1;
            double k = 0;
            double recommendedCustomer = 0;
            double m = 0;

            foreach (var CFiltering in myArray)
            {
                if (i % 2 == 0)
                {
                    if (myArray[i + 1] > MaxValue)
                    {
                        MaxValue = myArray[i + 1];
                        recommendedCustomer = myArray[i];
                    }
                    else
                    {
                        k = myArray[i + 1];
                        m = myArray[i];
                    }
                }

                i = i + 1;

            }
            //Delete data from matrix table to avoid overbundance of data and return the customer ID with the highest similarity ranged compared to the logged in customer
            SQLConnectionClass DeleteData = new SQLConnectionClass();
            DeleteData.CommandExec("Delete from [TempMatrixTable] where Gid='" + gid + "'");

            return recommendedCustomer;
        }
    }
}