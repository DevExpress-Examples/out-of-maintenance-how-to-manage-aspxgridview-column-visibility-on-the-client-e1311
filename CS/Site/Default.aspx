<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v14.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example</title>
    <script type="text/javascript" src="JS/ColumnVisibilityManager.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxgv:ASPxGridView ID="gvGrid" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" KeyFieldName="EmployeeID" OnCustomCallback="OnCustomCallback">
            <Columns>
                <dxgv:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dxgv:GridViewDataTextColumn>
                <dxgv:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="1" />
                <dxgv:GridViewDataTextColumn FieldName="LastName" VisibleIndex="2" />
                <dxgv:GridViewDataTextColumn FieldName="City" VisibleIndex="4" />
                <dxgv:GridViewDataTextColumn FieldName="Address" VisibleIndex="5" />
                <dxgv:GridViewDataTextColumn FieldName="HomePhone" VisibleIndex="6" />
            </Columns>
        </dxgv:ASPxGridView>
        
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [EmployeeID], [FirstName], [LastName], [City], [Address], [HomePhone] FROM [Employees]">
        </asp:AccessDataSource>
    </div>
    </form>
</body>
</html>
