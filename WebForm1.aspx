<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
        
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblDate" runat="server">Enter Date</asp:Label>
      <asp:TextBox ID="txtDate" runat="server" />
 <asp:ImageButton ID="ImageButton1" runat="server" Height="17px"
            ImageUrl="~/image/calender.jpg" onclick="ImageButton1_Click" Width="21px" />
<asp:Calendar ID="Calendar1" runat="server"
            onselectionchanged="Calendar1_SelectionChanged" Visible="False">
        </asp:Calendar>
            <br />
             <asp:Label ID="lblEnergyType" runat="server">Select Energy Type</asp:Label>
            <asp:DropDownList ID="ddlEnergyType" runat="server">
                <asp:ListItem  Text="Gas" Value="Gas" Enabled="true"></asp:ListItem>
                <asp:ListItem  Text="Electricity" Value="Electricity"></asp:ListItem>
            </asp:DropDownList>
            <br />
             <asp:Label ID="lblPrice" runat="server">Price</asp:Label>
            <asp:TextBox ID="txtPrice" runat="server">

            </asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>

            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

        </div>

         <div style="margin-left:10px;margin-top:10px">  
     <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CellPadding="4"  
        ForeColor="#333333" GridLines="None">  
        <AlternatingRowStyle BackColor="White" />  
        <Columns>  
            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Date" DataField="Date" />  
            <asp:BoundField HeaderStyle-Width="120px" HeaderText="Energy Type" DataField="EnergyType" />  
            <asp:BoundField HeaderStyle-Width="120px" HeaderText=" Price" DataField="Price" />  
             
        </Columns>  
        <EditRowStyle BackColor="#2461BF" />  
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
        <RowStyle BackColor="#EFF3FB" />  
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
        <SortedAscendingCellStyle BackColor="#F5F7FB" />  
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
        <SortedDescendingCellStyle BackColor="#E9EBEF" />  
        <SortedDescendingHeaderStyle BackColor="#4870BE" />  
    </asp:GridView>  
    </div>  
    </form>
</body>
</html>
