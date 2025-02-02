<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPGolf._Default" EnableSessionState="True" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Current Golfer</h1>
        <p>
            <asp:TextBox ID="txtboxGolfer" runat="server" ReadOnly="True" ViewStateMode="Enabled">Mike</asp:TextBox>           
        </p>
        <p>
            <asp:TextBox ID="txtboxCourse" runat="server" ReadOnly="True" ViewStateMode="Enabled">Kawana Hotel</asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Adjustments</h2>
            <p>
                Hiatus Players or closed/hiatus courses...
            </p>
            <p>
                <asp:Button ID="btnNextGolfer" runat="server" Text="Next Golfer (Hiatus)" OnClick="btnNextGolfer_Click" />
                <asp:Button ID="btnNextCourse" runat="server" Text="Next Course" OnClick="btnNextCourse_Click" />
                <asp:Button ID="btnPriorGolfer" runat="server" Text="Prior Golfer" OnClick="btnPriorGolfer_Click" />
                <asp:Button ID="btnPriorCourse" runat="server" Text="Prior Course" OnClick="btnPriorCourse_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                Stuff about NuGet was here...
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                Azure or other hosters was here.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
