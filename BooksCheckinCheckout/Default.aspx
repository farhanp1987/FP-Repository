<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksCheckInCheckOut.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library System Home Page</title>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style type="text/css">
        .Error {
            color: red;
            font-size: 14px;
            font-weight: bold;
        }

        .GridHeader, .GridData {
            margin: 5px;
            padding: 5px;
        }
    
        .odd-row {
            background-color: #cfd1cf;
        }
    
        .even-row {
            background-color: white;
        }
    </style>
</head>
<body>
<form id="frmHome" runat="server">
    <div>
        <h1>Library System</h1>
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="Error"></asp:Label>
        <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False" RowStyle-CssClass="odd-row" AlternatingRowStyle-CssClass="even-row" Width="70%">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Book Title" HeaderStyle-Width="200px" ItemStyle-Width="200px" HeaderStyle-CssClass="GridHeader" ItemStyle-CssClass="GridData" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" HeaderStyle-Width="100px" ItemStyle-Width="100px" HeaderStyle-CssClass="GridHeader" ItemStyle-CssClass="GridData" />
                <asp:BoundField DataField="PublishYear" HeaderText="Publish Year" HeaderStyle-CssClass="GridHeader" ItemStyle-CssClass="GridData" HeaderStyle-Width="120px" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="CoverPrice" HeaderText="Cover Price" DataFormatString="{0:C}" HeaderStyle-CssClass="GridHeader" ItemStyle-CssClass="GridData" HeaderStyle-Width="120px" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="210px" ItemStyle-Width="210px" HeaderStyle-CssClass="GridHeader" ItemStyle-CssClass="GridData" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:Button ID="btnCheckOut" runat="server" Text="Check-out" CommandName="CheckOut" CommandArgument='<%# Eval("BookId") %>' Enabled='<%# !Convert.ToBoolean(Eval("IsCheckedOut")) %>' OnClick="btnCheckOut_Click" />
                        <asp:Button ID="btnCheckIn" runat="server" Text="Check-in" CommandName="CheckIn" CommandArgument='<%# Eval("BookId") %>' Enabled='<%# Convert.ToBoolean(Eval("IsCheckedOut")) %>' OnClick="btnCheckIn_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</form>
</body>
</html>
