<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="AddSalesman" runat="server" Text="Add Salesman" />
        <asp:Button ID="DeleteSalesman" runat="server" Text="Delete Salesman" />
        <asp:Button ID="UpdateSalesman" runat="server" Text="Update Salesman" />

        <h3> Salesman </h3>
        <asp:GridView ID="GridViewSales" runat="server">
        </asp:GridView>
        <h3> Orders </h3>
        <asp:GridView ID="GridViewOrders" runat="server">
        </asp:GridView>
        <h3> Items </h3>
        <asp:GridView ID="GridViewItems" runat="server">
        </asp:GridView>

        <asp:Button ID="Button1" runat="server" Text="Display All Items of Orders" />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
