<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcPager.ascx.cs" Inherits="Bootstrap.Pagination.UserControls.UcPager" %>
<ul class="pager">
    <% if (pager.IsFirstPage)
       { %>
        <li class="disabled"><span>← 上一页</span></li>
    <% }
       else
       { %>
        <li><a href="<%= url %>page=<%= pager.Page - 1 %>">← 上一页</a></li>
    <% }
       if (pager.IsLastPage)
       { %>
        <li class="disabled"><span>下一页 →</span></li>
    <% }
       else
       { %>
        <li><a href="<%= url %>page=<%= pager.Page + 1 %>">下一页 →</a></li>
    <% } %>
</ul>