<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcPagination.ascx.cs" Inherits="Bootstrap.Pagination.UserControls.UcPagination" %>
<div style="text-align: center">
    <ul class="pagination">
        <% if (pagination.IsFirstGroup)
           { %>
            <li class="disabled"><span>«</span></li>
        <% }
           else
           { %>
            <li><a href="<%= url %>page=<%= pagination.PagesPerGroup %>&group=<%= pagination.Group - 1 %>">«</a></li>
        <% }
           for (var i = 0; i < pagination.CurrentPageCount; i++)
           {
               if (pagination.IsCurrentPage(i))
               { %>
                <li class="active"><span><%= pagination.GetPageIndex(i) %></span></li>
            <% }
               else
               { %>
                <li><a href="<%= url %>page=<%= i + 1 %>&group=<%= pagination.Group %>"><%= pagination.GetPageIndex(i) %></a></li>
        <% }
           }
           if (pagination.IsLastGroup)
           { %>
            <li class="disabled"><span>»</span></li>
        <% }
           else
           { %>
            <li><a href="<%= url %>page=1&group=<%= pagination.Group + 1 %>">»</a></li>
        <% } %>
    </ul>
</div>