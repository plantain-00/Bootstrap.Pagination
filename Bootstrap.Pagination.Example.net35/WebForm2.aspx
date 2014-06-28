<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Bootstrap.Pagination.Example.net35.WebForm2" %>

<%@ Register src="UserControls/UcPager.ascx" tagname="UcPager" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
    </head>
    <body>
        <ul>
            <% for (var i = 0; i < data.Length; i++)
               { %>
                <li><%= data[i] %></li>
            <% } %>
        </ul>
        <uc1:UcPager ID="UcPager1" runat="server" />
        <script src="Scripts/jquery-1.9.0.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
    </body>
</html>