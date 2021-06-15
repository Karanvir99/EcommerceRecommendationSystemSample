<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="HomePageRecommendations.aspx.cs" Inherits="EcommerceRecommendationSystem.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style15 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<asp:Timer runat="server" ID="ctlTimer" Interval="3000" OnTick="OnTimerIntervalElapse" />--%>
    <link href="MainTheme.css" rel="stylesheet" type="text/css" />
    <table class="auto-style1">
        <tr>
            <td>
                                    <asp:Button ID="btnRecentViewedPrev" runat="server" CssClass="PreviousButton" OnClick="btnRecentViewedPrev_Click" Text="&lt;" />
                                </td>
            <td>
                                    <asp:DataList ID="dlRecentViewedRecommendations" runat="server" CssClass="HomeRecommenderList2" CellPadding="10" Height="330px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Items You've Recently Viewed"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' PostBackUrl='<%# Eval("[ItemID]", "~/ItemDetailsPage.aspx?id={0}") %>' />
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
            <td>
                                    <asp:Button ID="btnRecentViewedNext" runat="server" CssClass="NextButton" OnClick="btnRecentViewedNext_Click" Text="&gt;" />
                                </td>
        </tr>
        <tr>
            <td>
                                    <asp:Button ID="btnViewedBasedPrevious" runat="server" CssClass="PreviousButton" OnClick="btnViewedBasedPrevious_Click" Text="&lt;" />
                                </td>
            <td>
                                    <asp:DataList ID="dlViewedBasedRecommendations" runat="server" CssClass="HomeRecommenderList2" CellPadding="10" Height="330px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Viewed Based Recommended Items"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' PostBackUrl='<%# Eval("[ItemID]", "~/ItemDetailsPage.aspx?id={0}") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Item" runat="server" Width="200" CssClass="RecommenderItemName" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# Eval("ItemName", "{0}") %>' ></asp:HyperLink>
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
            <td>
                                    <asp:Button ID="btnViewedBasedlNext" runat="server" CssClass="NextButton" OnClick="btnViewedBasedlNext_Click" Text="&gt;" />
                                </td>
        </tr>
        <tr>
            <td>
                                    <asp:Button ID="btnUserBasedPrevious" runat="server" CssClass="PreviousButton" OnClick="btnUserBasedPrevious_Click" Text="&lt;" />
                                </td>
            <td>
                                    <asp:DataList ID="dlUserBasedRecommendations" runat="server" CellPadding="10" Height="330px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="User Based Recommended Items"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' PostBackUrl='<%# Eval("[ItemID]", "~/ItemDetailsPage.aspx?id={0}") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Item" runat="server" Width="200" CssClass="RecommenderItemName" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# Eval("ItemName", "{0}") %>' ></asp:HyperLink>
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
            <td>
                                    <asp:Button ID="btnUserBasedNext" runat="server" CssClass="NextButton" OnClick="btnUserBasedNext_Click" Text="&gt;" />
                                </td>
        </tr>
        <tr>
            <td>
                                    <asp:Button ID="btnTopSellPrevious" runat="server" CssClass="PreviousButton" OnClick="btnTopSellPrevious_Click" Text="&lt;" />
                                </td>
            <td>
                                    <asp:UpdatePanel ID="pnlTopSellingRecommendations" runat="server">
                                        <%--<Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ctlTimer" eventname="Tick"/>
                                        </Triggers>--%>
                                        <ContentTemplate>
                                            <asp:DataList ID="dlTopSellingRecommendations" runat="server" CellPadding="10" CssClass="HomeRecommenderList" Height="330px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="100%">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Top Selling Recommended Items"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' PostBackUrl='<%# Eval("[ItemID]", "~/ItemDetailsPage.aspx?id={0}") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:HyperLink ID="Item" runat="server" Width="200" CssClass="RecommenderItemName" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# Eval("ItemName", "{0}") %>'></asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:HyperLink ID="Price" runat="server" CssClass="RecommenderItemPrice" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# "£" + Eval("ItemPrice") %>'></asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
            </td>
            <td>
                                    <asp:Button ID="btnTopSellNext" runat="server" CssClass="NextButton" OnClick="btnTopSellNext_Click" Text="&gt;" />
                                </td>
        </tr>
        <tr>
            <td>
                                    <asp:Button ID="btnPopularPrev" runat="server" CssClass="PreviousButton" OnClick="btnPopularPrev_Click" Text="&lt;" />
                                </td>
            <td>
                                    <asp:DataList ID="dlPopularRecommendations" runat="server" CssClass="HomeRecommenderList2" CellPadding="10" Height="330px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Popular Recommended Items"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' PostBackUrl='<%# Eval("[ItemID]", "~/ItemDetailsPage.aspx?id={0}") %>' />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HyperLink ID="Item" runat="server" Width="200" CssClass="RecommenderItemName" NavigateUrl='<%# Eval("ItemID", "~/ItemDetailsPage.aspx?id={0}") %>' Text='<%# Eval("ItemName", "{0}") %>' ></asp:HyperLink>
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
            <td>
                                    <asp:Button ID="btnPopularNext" runat="server" CssClass="NextButton" OnClick="btnPopularNext_Click" Text="&gt;" />
                                </td>
        </tr>
        <tr>
            <td>
                                    <asp:Button ID="btnAreaBasedPrev" runat="server" CssClass="PreviousButton" OnClick="btnAreaBasedPrev_Click" Text="&lt;" />
                                </td>
            <td>
                                    <asp:DataList ID="dlAreaRecommendations" runat="server" CssClass="HomeRecommenderList2" CellPadding="10" Height="330px" HorizontalAlign="Left" RepeatDirection="Horizontal" Width="100%">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRecommenderHeader" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Large" Text="Area Based Recommended Items"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="Image" runat="server" CssClass="RecommenderItemImage" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ItemImage")) %>' PostBackUrl='<%# Eval("[ItemID]", "~/ItemDetailsPage.aspx?id={0}") %>' />
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
            <td>
                                    <asp:Button ID="btnAreaBasedNext" runat="server" CssClass="NextButton" OnClick="btnAreaBasedNext_Click" Text="&gt;" />
                                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
