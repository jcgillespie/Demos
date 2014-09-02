<%@ Page Title="Echo" Language="C#" 
    Inherits="System.Web.Mvc.ViewPage<TeamWebAccess.Areas.Custom.Models.IndexViewModel>" 
    MasterPageFile="~/_views/Shared/Masters/HubPage.Master" %>
<asp:Content runat="server" ID="Hub" ContentPlaceHolderID="HubContent">
    <p>This is an echo page. It echos back whatever you passed in. You passed in: </p>
    <blockquote><%: Model.Echo %></blockquote>
    <p>Server Time (UTC): <%: DateTime.UtcNow.ToString("G") %></p>
    <p>Local Time: <%: DateTime.Now.ToString("G") %></p>
</asp:Content>