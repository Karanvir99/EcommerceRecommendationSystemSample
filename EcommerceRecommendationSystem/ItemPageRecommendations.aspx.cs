using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceRecommendationSystem
{
    public partial class ItemDetailsPage : System.Web.UI.Page
    {
        //PagedDataSource pg = null;   
        static int currentposition = 0;
        static int currentposition1 = 0;
        static int totalrows = 0;
        static double ItemPrice;
        static int itemID;
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                string urlItemID = Request.QueryString["id"];

                if (urlItemID== null)
                {
                    urlItemID = Session["ItemQS"].ToString();
                }

                //Retrieve item details
                SQLConnectionClass selectData = new SQLConnectionClass();
                selectData.retrieveData("SELECT * FROM [dbo].[ItemView] where [Item ID] = '" + urlItemID + "'");
                byte[] bytes = (byte[])selectData.SQLTable.Rows[0][6];
                string strBase64 = Convert.ToBase64String(bytes);
                imgItemImage.ImageUrl = "data:image/png;base64," + strBase64;
                lblItemNumber.Text = "Shoppverse item number: " + selectData.SQLTable.Rows[0][1].ToString();
                lblItemTitle.Text = selectData.SQLTable.Rows[0][2].ToString();
               
                txtItemDetails.Text = selectData.SQLTable.Rows[0][3].ToString();
                lblPrice.Text = "£" + selectData.SQLTable.Rows[0][4].ToString();
                itemID = Convert.ToInt32(selectData.SQLTable.Rows[0][0]);
                ItemPrice = Convert.ToDouble(selectData.SQLTable.Rows[0][4]);

                //Retrieve item reviews
                SQLConnectionClass selectData1 = new SQLConnectionClass();
                selectData1.retrieveData("SELECT * FROM [dbo].[CustomerItemFeedbackView] where [ItemID] = '" + urlItemID + "'");
                dlCustomerReviews.DataSource = selectData1.SQLTable;
                dlCustomerReviews.DataBind();

                //Item average rating
                SQLConnectionClass selectData2 = new SQLConnectionClass();
                selectData2.retrieveData("SELECT ROUND(AVG(CAST(rating as FLOAT)),1) FROM [dbo].[CustomerItemFeedbackView] where [ItemID] = '" + urlItemID + "'");
                lblRating.Text = selectData2.SQLTable.Rows[0][0].ToString() + "/5";           

                //Item size
                SQLConnectionClass selectData3 = new SQLConnectionClass();
                selectData3.retrieveData("SELECT  Size FROM [dbo].[ItemSpecification] where [ItemID] = " + urlItemID + " group by Size ");
                ddlSize.DataSource = selectData3.SQLTable;
                ddlSize.DataValueField = "Size";
                ddlSize.DataTextField = "Size";
                ddlSize.DataBind();

                //Item colour
                SQLConnectionClass selectData4 = new SQLConnectionClass();
                selectData4.retrieveData("SELECT Colour FROM [dbo].[ItemSpecification] where [ItemID] = " + urlItemID + " group by Colour ");
                ddlColour.DataSource = selectData4.SQLTable;
                ddlColour.DataValueField = "Colour";
                ddlColour.DataTextField = "Colour";
                ddlColour.DataBind();

                //Disable size cmb if no size available
                if (ddlSize.Items.Count == 0)
                {
                    ddlSize.Enabled = false;
                    ddlSize.Attributes.Add("style", "background-color: #E1E1E1");
                    lblSize.Text = "No size";
                }

                //Disable colour cmb if no colour available
                if (ddlColour.Items.Count == 0)
                {
                    ddlColour.Enabled = false;
                    ddlColour.Attributes.Add("style", "background-color: #E1E1E1");
                    lblColour.Text = "No colour";
                }

                //Save viewed item for datalist
                if (Session["UserID"] != null)
                {

                    SQLConnectionClass deleteitem = new SQLConnectionClass();
                    deleteitem.retrieveData("delete from ViewedItems where ItemID=" + urlItemID + " and CustomerID=" + Session["UserID"] + "");


                    SQLConnectionClass saveViewData = new SQLConnectionClass();
                    saveViewData.CommandExec("INSERT INTO [dbo].[ViewedItems] ([ItemID], [CustomerID], [CreateDate]) VALUES(" + urlItemID + "," + Session["UserID"] + ",'" + DateTime.Now.ToString("MM/dd/yyyy") + "')");

                    if (selectData1.SQLTable.Rows.Count != 0)
                    {
                        UserBasedCFRecommendations();
                    }
                }
                else
                {
                    btnUserBasedPrevious.Visible = false;
                    btnUserBasedNext.Visible = false;
                }

                SimilarRecommendations();
            }
        }

        //Get user based recommendations
        private void UserBasedCFRecommendations()
        {
            CollaborativeFilteringRecommendation RecommendedCust = new CollaborativeFilteringRecommendation();

            SQLConnectionClass RecommendedItemList = new SQLConnectionClass();
            RecommendedItemList.retrieveData("SELECT   dbo.CustomerItemFeedback.ItemID, dbo.ItemList.ItemName, dbo.ItemList.ItemImage, dbo.ItemList.ItemPrice"
           + " FROM dbo.CustomerItemFeedback INNER JOIN"
                        + " dbo.ItemList ON dbo.CustomerItemFeedback.ItemID = dbo.ItemList.ItemID"
                        + " WHERE(dbo.CustomerItemFeedback.CustomerID = "+ RecommendedCust.GetRecommendedCustomer() + ") AND(dbo.CustomerItemFeedback.ItemID NOT IN"
                      + " (SELECT ItemID  FROM  dbo.CustomerItemFeedback AS CustomerItemFeedback_1 WHERE(CustomerID = " + Session["UserID"] + ")))");
            dlRecommenderList.DataSource = RecommendedItemList.SQLTable;
            dlRecommenderList.DataBind();

            DataTable dt = RecommendedItemList.SQLTable;
            totalrows = RecommendedItemList.SQLTable.Rows.Count;

            //Datalist navigation
            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = dt.DefaultView;
            pg.AllowPaging = true;
            pg.CurrentPageIndex = currentposition;
            pg.PageSize = 5;
            btnUserBasedPrevious.Enabled = !pg.IsFirstPage;
            btnUserBasedNext.Enabled = !pg.IsLastPage;
            dlRecommenderList.DataSource = pg;
            dlRecommenderList.DataBind();
        }

        //Get similar recommendations
        private void SimilarRecommendations()
        {
            SQLConnectionClass itemLen = new SQLConnectionClass();
            itemLen.retrieveData("select len(itemname) from ItemList where itemid= " + itemID + "");
            int ItemLconengh = Convert.ToInt32(itemLen.SQLTable.Rows[0][0]);

            SQLConnectionClass RecommendedItemList = new SQLConnectionClass();
            RecommendedItemList.retrieveData("execute itemrecommendation '" + itemID + "','"+ ItemLconengh  + "'");
            dlSimilarRecommendedList.DataSource = RecommendedItemList.SQLTable;
            dlSimilarRecommendedList.DataBind();

            DataTable dt = RecommendedItemList.SQLTable;
            totalrows = RecommendedItemList.SQLTable.Rows.Count;

            //Datalist navigation
            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = dt.DefaultView;
            pg.AllowPaging = true;
            pg.CurrentPageIndex = currentposition1;
            pg.PageSize = 5;
            btnSimilarPrev.Enabled = !pg.IsFirstPage;
            btnSimilarNext.Enabled = !pg.IsLastPage;
            dlSimilarRecommendedList.DataSource = pg;
            dlSimilarRecommendedList.DataBind();
        }

        //User based recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnUserBasedPrevious_Click(object sender, EventArgs e)
        {
            currentposition = currentposition - 1;
            UserBasedCFRecommendations();
        }

        protected void btnUserBasedNext_Click(object sender, EventArgs e)
        {
            currentposition = currentposition + 1;
            UserBasedCFRecommendations();
        }
        //-----------------------------------------------------------------------------//

        //Similar recommendation navigation
        //-----------------------------------------------------------------------------//
        protected void btnSimilarPrev_Click(object sender, EventArgs e)
        {
            currentposition1 = currentposition1 - 1;
            SimilarRecommendations();
        }

        protected void btnSimilarNext_Click(object sender, EventArgs e)
        {
            currentposition1 = currentposition1 + 1;
            SimilarRecommendations();
        }
        //-----------------------------------------------------------------------------//

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session["Value"] = "itemDetails";
                Session["ItemQS"] = Request.QueryString["id"];
                Response.Redirect("~/LoginPage.aspx");           
            }

            //Save added item to basket to DB
            SQLConnectionClass saveData = new SQLConnectionClass();
            saveData.CommandExec("INSERT INTO [dbo].[CustomerBasket] ([ItemID], [Price], [Quantity], [TotalAmount], [CustomerID]) VALUES (" + itemID + "," + ItemPrice + "," + txtQuantity.Text + "," + ItemPrice*Convert.ToInt32(txtQuantity.Text) + "," + Session["UserID"] + ")"); 
        }

        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session["Value"] = "itemDetails";
                Session["ItemQS"] = Request.QueryString["id"];
                Response.Redirect("~/LoginPage.aspx");
            }

            //Save added item and redirect directly to payement 
            SQLConnectionClass saveData = new SQLConnectionClass();
            saveData.CommandExec("INSERT INTO [dbo].[CustomerBasket] ([ItemID], [Price], [Quantity], [TotalAmount], [CustomerID]) VALUES (" + itemID + "," + ItemPrice + "," + txtQuantity.Text + "," + ItemPrice * Convert.ToInt32(txtQuantity.Text) + "," + Session["UserID"] + ")");
            Response.Redirect("~/PaymentPage.aspx");
        }

        protected void dlCustomerReviews_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //Get customer review scores for average item rating
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label ReviewCount = (Label)e.Item.FindControl("lblReviewCount");
                int count = ((dlCustomerReviews.DataSource) as DataTable).Rows.Count;
                ReviewCount.Text = count + " customer reviews";
            }
        }
    }         
}