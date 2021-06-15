using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceRecommendationSystem
{
    public partial class HomePage : System.Web.UI.Page
    {
        static int currentposition = 0;
        static int currentposition1 = 0;
        static int currentposition2 = 0;
        static int currentposition3 = 0;
        static int currentposition4 = 0;
        static int currentposition5 = 0;
        static int totalrows = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // View list of recommendations
            if (Session["UserID"] != null)
            {
                RecentViewedRecommendations();

                ViewedBasedRecommendations();

                UserBasedCFRecommendations();

                DemographicRecommendations();
            }
            else
            {
                btnRecentViewedPrev.Visible = false;
                btnRecentViewedNext.Visible = false;

                btnViewedBasedPrevious.Visible = false;
                btnViewedBasedlNext.Visible = false;

                btnUserBasedPrevious.Visible = false;
                btnUserBasedNext.Visible = false;

                btnAreaBasedPrev.Visible = false;
                btnAreaBasedNext.Visible = false;
            }

            TopSellingRecommendations();

            PopularRecommendations();
        }

        private void RecentViewedRecommendations()
        {
            SQLConnectionClass selectData1 = new SQLConnectionClass();
            selectData1.retrieveData("select top 20 * from ViewedtemView where customerid= " + Session["UserID"] + "  order by createdate desc");
            dlRecentViewedRecommendations.DataSource = selectData1.SQLTable;
            dlRecentViewedRecommendations.DataBind();

            DataTable dt = selectData1.SQLTable;
            totalrows = selectData1.SQLTable.Rows.Count;

            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = dt.DefaultView;
            pg.AllowPaging = true;
            pg.CurrentPageIndex = currentposition;
            pg.PageSize = 10;
            btnRecentViewedPrev.Enabled = !pg.IsFirstPage;
            btnRecentViewedNext.Enabled = !pg.IsLastPage;
            dlRecentViewedRecommendations.DataSource = pg;
            dlRecentViewedRecommendations.DataBind();
        }

        private void ViewedBasedRecommendations()
        {
            //From book pg 453 second recommendation
            SQLConnectionClass selectData2 = new SQLConnectionClass();
            selectData2.retrieveData("select ItemID, ItemName, ItemImage, ItemPrice from ItemList"
            + " where ItemID in (select top 10 od1.ItemID From SalesDetails od1 JOIN SalesDetails od2 ON od1.SalesID = od2.SalesID join ViewedItems sp on od2.ItemID = sp.ItemID"
            + " where sp.CustomerID =  " + Session["UserID"] + "  and od1.ItemID not in (select ItemID from ViewedItems where customerid =  " + Session["UserID"] + ")  group by od1.ItemID"
            + " Order by COUNT(od1.ItemID) DESC) ");
            dlViewedBasedRecommendations.DataSource = selectData2.SQLTable;
            dlViewedBasedRecommendations.DataBind();

            DataTable dt = selectData2.SQLTable;
            totalrows = selectData2.SQLTable.Rows.Count;

            PagedDataSource pg1 = new PagedDataSource();
            pg1.DataSource = dt.DefaultView;
            pg1.AllowPaging = true;
            pg1.CurrentPageIndex = currentposition1;
            pg1.PageSize = 5;
            btnViewedBasedPrevious.Enabled = !pg1.IsFirstPage;
            btnViewedBasedlNext.Enabled = !pg1.IsLastPage;
            dlViewedBasedRecommendations.DataSource = pg1;
            dlViewedBasedRecommendations.DataBind();
        }

        private void UserBasedCFRecommendations()
        {
            SQLConnectionClass SelectFeedback = new SQLConnectionClass();
            SelectFeedback.retrieveData("select * from CustomerItemFeedback where CustomerID= '" + Session["UserID"] + "'");

            if (SelectFeedback.SQLTable.Rows.Count != 0)
            {
                CollaborativeFilteringRecommendation RecommendedCust = new CollaborativeFilteringRecommendation();
                SQLConnectionClass RecommendedItemList = new SQLConnectionClass();
                RecommendedItemList.retrieveData("SELECT   dbo.CustomerItemFeedback.ItemID, dbo.ItemList.ItemName, dbo.ItemList.ItemImage, dbo.ItemList.ItemPrice"
               + " FROM dbo.CustomerItemFeedback INNER JOIN"
                            + " dbo.ItemList ON dbo.CustomerItemFeedback.ItemID = dbo.ItemList.ItemID"
                            + " WHERE(dbo.CustomerItemFeedback.CustomerID = " + RecommendedCust.GetRecommendedCustomer() + ") AND(dbo.CustomerItemFeedback.ItemID NOT IN"
                          + " (SELECT ItemID  FROM  dbo.CustomerItemFeedback AS CustomerItemFeedback_1 WHERE(CustomerID = " + Session["UserID"] + ")))");
                dlUserBasedRecommendations.DataSource = RecommendedItemList.SQLTable;
                dlUserBasedRecommendations.DataBind();

                DataTable dt = RecommendedItemList.SQLTable;
                totalrows = RecommendedItemList.SQLTable.Rows.Count;

                PagedDataSource pg5 = new PagedDataSource();
                pg5.DataSource = dt.DefaultView;
                pg5.AllowPaging = true;
                pg5.CurrentPageIndex = currentposition5;
                pg5.PageSize = 5;
                btnUserBasedPrevious.Enabled = !pg5.IsFirstPage;
                btnUserBasedNext.Enabled = !pg5.IsLastPage;
                dlUserBasedRecommendations.DataSource = pg5;
                dlUserBasedRecommendations.DataBind();
            }
        }

        private void TopSellingRecommendations()
        {
            SQLConnectionClass selectData4 = new SQLConnectionClass();
            selectData4.retrieveData("SELECT TOP(10) COUNT(dbo.SalesView.ItemID) AS ItemCount, dbo.SalesView.ItemID, dbo.ItemList.ItemName, dbo.ItemList.ItemPrice, dbo.ItemList.ItemImage"
            + " FROM            dbo.SalesView INNER JOIN dbo.ItemList ON dbo.SalesView.ItemID = dbo.ItemList.ItemID"
            + " GROUP BY dbo.SalesView.ItemID, dbo.ItemList.ItemName, dbo.ItemList.ItemPrice, dbo.ItemList.ItemImage ORDER BY ItemCount DESC");
            dlTopSellingRecommendations.DataSource = selectData4.SQLTable;
            dlTopSellingRecommendations.DataBind();

            DataTable dt = selectData4.SQLTable;
            totalrows = selectData4.SQLTable.Rows.Count;

            PagedDataSource pg2 = new PagedDataSource();
            pg2.DataSource = dt.DefaultView;
            pg2.AllowPaging = true;
            pg2.CurrentPageIndex = currentposition2;
            pg2.PageSize = 5;
            btnTopSellPrevious.Enabled = !pg2.IsFirstPage;
            btnTopSellNext.Enabled = !pg2.IsLastPage;
            dlTopSellingRecommendations.DataSource = pg2;
            dlTopSellingRecommendations.DataBind();
        }

        private void PopularRecommendations()
        {
            SQLConnectionClass selectData5 = new SQLConnectionClass();
            selectData5.retrieveData("SELECT TOP(10) COUNT(dbo.SalesView.ItemID) AS ItemCount, dbo.SalesView.ItemID, dbo.ItemList.ItemName, dbo.ItemList.ItemPrice, dbo.ItemList.ItemImage, dbo.SalesView.CreateDate"
            + " FROM            dbo.SalesView INNER JOIN"
            + " dbo.ItemList ON dbo.SalesView.ItemID = dbo.ItemList.ItemID"
             + " GROUP BY dbo.SalesView.ItemID, dbo.ItemList.ItemName, dbo.ItemList.ItemPrice, dbo.ItemList.ItemImage, dbo.SalesView.CreateDate"
             + " HAVING(dbo.SalesView.CreateDate BETWEEN CONVERT(DATETIME, '2020-02-11 00:00:00', 102) AND CONVERT(DATETIME, '2020-02-12 00:00:00', 102)) ORDER BY ItemCount DESC");
            // Between specified date range to avoid overabundance of data in the database

            dlPopularRecommendations.DataSource = selectData5.SQLTable;
            dlPopularRecommendations.DataBind();

            DataTable dt = selectData5.SQLTable;
            totalrows = selectData5.SQLTable.Rows.Count;

            PagedDataSource pg3 = new PagedDataSource();
            pg3.DataSource = dt.DefaultView;
            pg3.AllowPaging = true;
            pg3.CurrentPageIndex = currentposition3;
            pg3.PageSize = 5;
            btnPopularPrev.Enabled = !pg3.IsFirstPage;
            btnPopularNext.Enabled = !pg3.IsLastPage;
            dlPopularRecommendations.DataSource = pg3;
            dlPopularRecommendations.DataBind();
        }

        private void DemographicRecommendations()
        {
            SQLConnectionClass selectPostcode = new SQLConnectionClass();
            selectPostcode.retrieveData("select left(PostCode, 2) from CustomerDetails where CustomerID =  " + Session["UserID"] + "");

            SQLConnectionClass selectData6 = new SQLConnectionClass();
            selectData6.retrieveData("SELECT   TOP(20) dbo.ItemList.ItemID, dbo.ItemList.ItemImage, dbo.ItemList.ItemName, dbo.ItemList.ItemPrice"
            + " FROM dbo.SalesView INNER JOIN dbo.CustomerDetails ON dbo.SalesView.CustomerID = dbo.CustomerDetails.CustomerID INNER JOIN "
            + " dbo.ItemList ON dbo.SalesView.ItemID = dbo.ItemList.ItemID WHERE(dbo.CustomerDetails.PostCode LIKE N'%" + selectPostcode.SQLTable.Rows[0][0].ToString() + "%') AND(dbo.CustomerDetails.CustomerID <> " + Session["UserID"] + ") "
           + " ORDER BY dbo.SalesView.CreateDate DESC");
            dlAreaRecommendations.DataSource = selectData6.SQLTable;
            dlAreaRecommendations.DataBind();

            DataTable dt = selectData6.SQLTable;
            totalrows = selectData6.SQLTable.Rows.Count;

            PagedDataSource pg4 = new PagedDataSource();
            pg4.DataSource = dt.DefaultView;
            pg4.AllowPaging = true;
            pg4.CurrentPageIndex = currentposition4;
            pg4.PageSize = 10;
            btnPopularPrev.Enabled = !pg4.IsFirstPage;
            btnPopularNext.Enabled = !pg4.IsLastPage;
            dlAreaRecommendations.DataSource = pg4;
            dlAreaRecommendations.DataBind();
        }

        //Recently viewed recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnRecentViewedPrev_Click(object sender, EventArgs e)
        {
            currentposition = currentposition - 1;
            RecentViewedRecommendations();
        }

        protected void btnRecentViewedNext_Click(object sender, EventArgs e)
        {
            currentposition = currentposition + 1;
            RecentViewedRecommendations();
        }
        //-----------------------------------------------------------------------------//

        //Viewed based recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnViewedBasedPrevious_Click(object sender, EventArgs e)
        {
            currentposition1 = currentposition1 - 1;
            ViewedBasedRecommendations();
        }

        protected void btnViewedBasedlNext_Click(object sender, EventArgs e)
        {
            currentposition1 = currentposition1 + 1;
            ViewedBasedRecommendations();
        }
        //-----------------------------------------------------------------------------//

        //Top selling recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnTopSellPrevious_Click(object sender, EventArgs e)
        {
            currentposition2 = currentposition2 - 1;
            TopSellingRecommendations();
        }

        protected void btnTopSellNext_Click(object sender, EventArgs e)
        {
            currentposition2 = currentposition2 + 1;
            TopSellingRecommendations();
        }
        //-----------------------------------------------------------------------------//

        //Popular recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnPopularPrev_Click(object sender, EventArgs e)
        {
            currentposition3 = currentposition3 - 1;
            PopularRecommendations();
        }

        protected void btnPopularNext_Click(object sender, EventArgs e)
        {
            currentposition3 = currentposition3 + 1;
            PopularRecommendations();
        }
        //-----------------------------------------------------------------------------//

        //Area recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnAreaBasedPrev_Click(object sender, EventArgs e)
        {
            currentposition4 = currentposition4 - 1;
            DemographicRecommendations();
        }

        protected void btnAreaBasedNext_Click(object sender, EventArgs e)
        {
            currentposition4 = currentposition4 + 1;
            DemographicRecommendations();
        }
        //-----------------------------------------------------------------------------//

        //User based recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnUserBasedPrevious_Click(object sender, EventArgs e)
        {
            currentposition5 = currentposition5 - 1;
            UserBasedCFRecommendations();
        }

        protected void btnUserBasedNext_Click(object sender, EventArgs e)
        {
            currentposition5 = currentposition5 + 1;
            UserBasedCFRecommendations();
        }
        //-----------------------------------------------------------------------------//

        protected void OnTimerIntervalElapse(object sender, EventArgs e)
        {
            //currentposition = currentposition + 1;
        }
    }
}