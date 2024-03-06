<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectDb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>User List</h2>
             <form ID="form1" action="/" method="post">
                 <div class="row">
                    From date: <asp:TextBox ID="fromDateSearch" runat="server" ></asp:TextBox>
                    To date: <asp:TextBox ID="toDateSearch" runat="server" ></asp:TextBox>
                     <asp:Button ID="SerchBtn" runat="server" Text="Search" OnClick="SerchBtn_Click" />
                     
                     <asp:GridView runat="server" ID="usersGrView" AutoGenerateColumns="false" CellPadding="4" 
                         AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <EditRowStyle BackColor="#999999" />
                     <FooterStyle BackColor="#5d7b9d" Font-Bold="true" ForeColor="White" />
                     <HeaderStyle BackColor="#5d7b9d" Font-Bold="true" ForeColor="White" HorizontalAlign="Center" />
                     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="#f7f6f3" ForeColor="#333333" Height="50" Width="75" />
                     <SelectedRowStyle BackColor="#f7f6f3" Font-Bold="true" ForeColor="#333333" />
                         <Columns>
                              <asp:BoundField DataField="Id" HeaderText="User Id" />
                              <asp:BoundField DataField="firstName" HeaderText="First Name" />
                              <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                              <asp:BoundField DataField="userEmail" HeaderText="Email" />
                         </Columns>
                     </asp:GridView>
                 </div>
                 <div class="col-md-4">
                     <asp:Button ID="InitializationDbBtn" runat="server" Text="Initialization DB" OnClick="InitializationDbBtn_Click" />
                 </div>
             </form>
        </div>

        <div id="chart_conteiner" class="col-md-4">
            <h2>Google Chart</h2>
            
        </div>
    </div>

</asp:Content>
