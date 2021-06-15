<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="ItemPageRecommendations.aspx.cs" Inherits="EcommerceRecommendationSystem.ItemDetailsPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 175px;
        }
        .auto-style10 {
            width: 500px;
        }
        .auto-style11 {
            height: 220px;
            width: 500px;
        }
        .auto-style12 {
            width: 175px;
            height: 100px;
        }
        .auto-style13 {
            width: 350px;
            height: 100px;
        }
        .auto-style14 {
            height: 100px;
        }     
        .auto-style19 {
            text-align: left;
        }
        .auto-style24 {
            height: 82px;
            width: 950px;
        }
        .auto-style25 {
            height: 454px;
        }
        .auto-style26 {
            width: 100%;
            height: 255px;
        }
        .auto-style28 {
            text-align: right;
        }
        .auto-style29 {
            width: 904px;
            text-align: left;
        }
        .auto-style39 {
            height: 82px;
            text-align: left;
            width: 350px;
        }
        .auto-style42 {
            height: 82px;
            width: 175px;
        }
        .auto-style45 {
            width: 350px;
            height: 100px;
        }
        .auto-style46 {
            height: 100px;
            width: 950px;
        }
        .auto-style47 {
            height: 100px;
            width: 175px;
        }
        .auto-style30 {
            width: 300px;
        }
        .auto-style33 {
            width: 74px;
        }
        .auto-style34 {
            width: 75px;
        }
        .auto-style37 {
            width: 99px;
            height: 50px;
        }
        .auto-style38 {
            height: 50px;
            width: 100px;
        }
        .auto-style50 {
            height: 45px;
            width: 580px;
        }
        .auto-style52 {
            width: 432px;
            text-align: left;
        }
        .auto-style53 {
            width: 175px;
        }
        .auto-style54 {
            width: 350px;
        }
        .auto-style55 {
            width: 950px;
        }
        .auto-style56 {
            width: 350px;
            text-align: center;
        }
        .auto-style57 {
            width: 580px;
            text-align: left;
        }
        .auto-style59 {
            width: 38px;
        }
        .auto-style62 {
            text-align: right;
            height: 80px;
        }
        .auto-style63 {
            width: 904px;
            text-align: left;
            height: 80px;
        }
        .auto-style64 {
            text-align: left;
            height: 80px;
        }
        .auto-style65 {
            width: 915px;
            text-align: left;
        }
        .auto-style66 {
            width: 250px;
            text-align: left;
        }
        .auto-style67 {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <link href="MainTheme.css" rel="stylesheet" type="text/css" />
    <table class="auto-style1">
        <tr>
            <td class="auto-style53">
            </td>
            <td class="auto-style54">
                &nbsp;</td>
            <td class="auto-style55">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style47"></td>
            <td class="auto-style45">
                </td>
            <td class="auto-style46"></td>
        </tr>
        <tr>
            <td class="auto-style53">
                &nbsp;</td>
            <td class="auto-style56">
                <asp:Image ID="imgItemImage" runat="server" CssClass="ItemDetailsFrame" />
            </td>
            <td class="auto-style55">
                <table class="auto-style65">
                    <tr>
                        <td class="auto-style57">
                            <asp:Label ID="lblItemTitle" runat="server" Font-Names="Verdana" Font-Size="15pt" Text="ItemTitle"></asp:Label>
                        </td>
                        <td class="auto-style67">
                            &nbsp;</td>
                        <td class="auto-style10">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style57">
                            <asp:Label ID="lblRating" runat="server" CssClass="CustomerFeedbackRating" Font-Names="Verdana" Text="Rating"></asp:Label>
                        </td>
                        <td class="auto-style66" rowspan="6">
                            &nbsp;</td>
                        <td class="auto-style52" rowspan="6">
                            <asp:Panel ID="pnlItemSpec" runat="server" CssClass="ItemSpecPanel">
                                <table class="auto-style30">
                                    <tr>
                                        <td class="auto-style33">
                                            &nbsp;</td>
                                        <td class="auto-style33">
                                            <asp:Label ID="lblSize" runat="server" Font-Names="Verdana" Text="Size"></asp:Label>
                                        </td>
                                        <td class="auto-style34">
                                            <asp:DropDownList ID="ddlSize" runat="server" CssClass="SmallDropDownList">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style34">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style33">
                                            &nbsp;</td>
                                        <td class="auto-style33">
                                            <asp:Label ID="lblColour" runat="server" Font-Names="Verdana" Text="Colour:"></asp:Label>
                                        </td>
                                        <td class="auto-style34">
                                            <asp:DropDownList ID="ddlColour" runat="server" CssClass="SmallDropDownList">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style34">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style33">
                                            &nbsp;</td>
                                        <td class="auto-style33">
                                            <asp:Label ID="lblQuantity" runat="server" Font-Names="Verdana" Text="Quantity:"></asp:Label>
                                        </td>
                                        <td class="auto-style34">
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="SmallTextBox">1</asp:TextBox>
                                        </td>
                                        <td class="auto-style34">&nbsp;</td>
                                    </tr>
                                </table>
                                <table class="auto-style30">
                                    <tr>
                                        <td class="auto-style37">&nbsp;</td>
                                        <td class="auto-style37"></td>
                                        <td class="auto-style38"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style37">&nbsp;</td>
                                        <td class="auto-style37">
                                            <asp:Button ID="btnAddToBasket" runat="server" CssClass="PurchaseButton" OnClick="btnAddToBasket_Click" Text="Add to Basket" />
                                        </td>
                                        <td class="auto-style38">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style37">&nbsp;</td>
                                        <td class="auto-style37">
                                            <asp:Button ID="btnBuyNow" runat="server" CssClass="PurchaseButton" Text="Buy Now" OnClick="btnBuyNow_Click" />
                                        </td>
                                        <td class="auto-style38">&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style57"><asp:Image runat="server" ImageUrl="~/Images/line2.jpg" Height="4px" Width="500px" ID="Image4"></asp:Image>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style57">
                            <asp:Label ID="lblPrice" runat="server" Font-Names="Verdana" Text="Price" ForeColor="#CC0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style57">
                            <asp:Label ID="Label3" runat="server" Font-Names="Verdana" Text="Stock"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style57">
                            <asp:Label ID="lblItemDescription" runat="server" Font-Names="Verdana" Text="Item Description"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style50">
                            <asp:TextBox ID="txtItemDetails" runat="server" TextMode="MultiLine" CssClass="ItemDescription" ReadOnly="true"></asp:TextBox>
                            <br />
                <asp:Label ID="lblItemNumber" runat="server" Font-Names="Verdana" Text="Shoppverse item number"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style42"></td>
            <td class="auto-style39">
                &nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style25" colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table class="auto-style26">
                            <tr>
                                <td class="auto-style28">
                                    &nbsp;</td>
                                <td class="auto-style29">
                                    &nbsp;</td>
                                <td class="auto-style19">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style28">
                                    <asp:Button ID="btnUserBasedPrevious" runat="server" CssClass="PreviousButton" OnClick="btnUserBasedPrevious_Click" Text="&lt;" />
                                </td>
                                <td class="auto-style29">
                                    <asp:DataList ID="dlRecommenderList" runat="server" CssClass="RecommenderList" CellPadding="10" Height="160px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="910px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="User Based Recommended Items"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Item" runat="server" CssClass="RecommenderItemName" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# Eval("ItemName", "{0}") %>' ></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Price" runat="server" CssClass="RecommenderItemPrice" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# "£" + Eval("ItemPrice") %>' ></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                <td class="auto-style19">
                                    <asp:Button ID="btnUserBasedNext" runat="server" CssClass="NextButton" OnClick="btnUserBasedNext_Click" Text="&gt;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">&nbsp;</td>
                                <td class="auto-style29">&nbsp;</td>
                                <td class="auto-style19">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style28">
                                    <asp:Button ID="btnSimilarPrev" runat="server" CssClass="PreviousButton" OnClick="btnSimilarPrev_Click" Text="&lt;" />
                                </td>
                                <td class="auto-style29">
                                    <asp:DataList ID="dlSimilarRecommendedList" runat="server" CellPadding="10" CssClass="RecommenderList" Height="160px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="910px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader0" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Top Rated Similar Recommended Items"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image5" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Item0" runat="server" CssClass="RecommenderItemName" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# Eval("ItemName", "{0}") %>'></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Price0" runat="server" CssClass="RecommenderItemPrice" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# "£" + Eval("ItemPrice") %>'></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                <td class="auto-style19">
                                    <asp:Button ID="btnSimilarNext" runat="server" CssClass="NextButton" OnClick="btnSimilarNext_Click" Text="&gt;" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table class="auto-style26">
                            <tr>
                                <td class="auto-style62">
                                    </td>
                                <td class="auto-style63">
                                    </td>
                                <td class="auto-style64">
                                    </td>
                            </tr>
                            <tr>
                                <td class="auto-style28">
                                    &nbsp;</td>
                                <td class="auto-style29">
                                    <asp:DataList ID="dlCustomerReviews" runat="server" CssClass="CustomerReviewList" CellPadding="10" Height="160px" Width="910px" OnItemDataBound="dlCustomerReviews_ItemDataBound">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblCustomerReviews" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Customer Reviews"></asp:Label>
                                            <br />
                                            <br />
                                            <br />
                                            <asp:Label ID="lblReviewCount" runat="server" Text="ReviewCount" Font-Bold="True" Font-Names="Verdana"></asp:Label>
                                            <br />
                                            <br />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style59">
                                                        <asp:Image ID="imgUserProfileIcon" runat="server" ImageUrl="~/Images/UserProfileIcon.png" Width="35px" Height="35px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCustomerName" runat="server" CssClass="CustomerFeedbackName" Text='<%# Eval("CustomerName") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style59">
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="lblItemRating" runat="server" CssClass="CustomerFeedbackRating" Text='<%# Eval("Rating") + "/5" %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style59">
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="lblReviewDate" runat="server" CssClass="CustomerFeedbackDate" Text='<%# Eval("CreateDate") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style59">
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Label ID="lblFeedbackDescription" runat="server" CssClass="CustomerFeedbackDescription" Text='<%# Eval("Comments") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                <td class="auto-style19">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style53">&nbsp;</td>
            <td class="auto-style54">&nbsp;</td>
            <td class="auto-style55">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
