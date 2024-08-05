<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BooksCheckInCheckOut.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
    <style type="text/css">
        .Error {
            color: red;
            font-size: 14px;
            font-weight: bold;
        }
    
        .TextBox {
            margin-bottom: 5px;
        }
    
    </style>
</head>
<body>
    <form id="frmCheckout" runat="server">
        <div>
            <h1>Checkout</h1>
            <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="Error"></asp:Label>
            <br />
            <asp:Label ID="lblBookTitleCaption" runat="server" Text="Book Title: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblBookTitle" runat="server" Text="" CssClass="TextBox" Width="200px"></asp:Label>
            <br />
            <asp:Label ID="lblISBNCaption" runat="server" Text="ISBN: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblISBN" runat="server" Text="" CssClass="TextBox"  Width="100px"></asp:Label>
            <br />
            <asp:Label ID="lblPublishYearCaption" runat="server" Text="Publish Year: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblPublishYear" runat="server" Text="" CssClass="TextBox"  Width="100px"></asp:Label>
            <br />
            <asp:Label ID="lblCoverPriceCaption" runat="server" Text="Cover Price: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblCoverPrice" runat="server" Text="" CssClass="TextBox"  Width="100px"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblBorrowerName" runat="server" Text="Borrower Name: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtBorrowerName" runat="server" Width="170px" CssClass="TextBox"></asp:TextBox>&nbsp;<span class="Error">*</span>
            <br />
            <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile Number: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtMobileNumber" runat="server" Width="170px" CssClass="TextBox" MaxLength="11"></asp:TextBox>&nbsp;<span class="Error">*</span> (Allowed format: xx-xxxx xxx)
            <br />
            <asp:Label ID="lblNationalID" runat="server" Text="National ID: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtNationalID" runat="server" Width="170px" CssClass="TextBox" MaxLength="11"></asp:TextBox>&nbsp;<span class="Error">*</span>
            <br />
            <asp:Label ID="lblCheckedOutDate" runat="server" Text="Checked out Date: " Width="170px" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtCheckedOutDate" runat="server" ReadOnly="true" CssClass="TextBox" Width="170px"></asp:TextBox>
            <br />
            <asp:Label ID="lblReturnDate" runat="server" Text="Return Date:" Width="170px" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtReturnDate" runat="server" ReadOnly="true" CssClass="TextBox" Width="170px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" />
        </div>
    </form>
</body>
</html>
