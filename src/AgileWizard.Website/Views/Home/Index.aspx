﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: HomeString.IndexTitle %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:8px;">
        <img src="../../Content/Images/home_pic.png" alt="" align=middle />
    </div>
    <h2>
        <%: HomeString.Welecome %></h2>
    <div><% Html.RenderAction("ResourceList", "Resource"); %></div>
</asp:Content>
