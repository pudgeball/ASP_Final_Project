<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewBuild.aspx.cs" Inherits="NewBuild" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
        .row
        {
            padding: 10px;
            background-color: #2A2A2A;
        }
        
        .odd
        {
            background-color: #3A3A3A;
        }
        
        .abilityRowEven
        {
           background-color: #2A2A2A;
        }
        
        .center
        {
            text-align: center;
        }
        
        #pageContent_Items
        {
            padding: 20px 10px;
        }
        
        .itemSelect
        {
            width: 300px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" Runat="Server">
    <div>
        <h1>Create New Build</h1>
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Build Name: " Width="100px"></asp:Label>
            <asp:TextBox ID="txtBuildName" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorBuildName" runat="server" 
                ControlToValidate="txtBuildName" ErrorMessage="Build Name Required" 
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="row odd">
            <asp:Label ID="Label28" runat="server" Text="Username: " Width="100px"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorUsername" runat="server" 
                ControlToValidate="txtUsername" ErrorMessage="Username Required" 
                ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="row">
            <asp:Label ID="Label2" runat="server" Text="Character: " Width="100px"></asp:Label>
            <asp:DropDownList ID="dropCharacter" runat="server" 
            AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <table class="style1" bgcolor="#0A0A0A">
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Level"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label10" runat="server" Text="1"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label11" runat="server" Text="2"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label12" runat="server" Text="3"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label13" runat="server" Text="4"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label14" runat="server" Text="5"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label15" runat="server" Text="6"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label16" runat="server" Text="7"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label17" runat="server" Text="8"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label18" runat="server" Text="9"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label19" runat="server" Text="10"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label20" runat="server" Text="11"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label21" runat="server" Text="12"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label22" runat="server" Text="13"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label23" runat="server" Text="14"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label24" runat="server" Text="15"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label25" runat="server" Text="16"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label26" runat="server" Text="17"></asp:Label>
                </td>
                <td class="center">
                    <asp:Label ID="Label9" runat="server" Text="18"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="abilityRowEven">
                    <asp:Label ID="lblAbility1" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="18" align="center" class="abilityRowEven">
                    <asp:Label ID="Label27" runat="server" Text="Passive"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAbility2" runat="server" Text="Label"></asp:Label>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel1" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel2" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel3" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel4" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel5" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel6" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel7" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel8" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel9" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel10" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel11" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel12" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel13" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel14" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel15" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel16" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel17" runat="server">
                    </asp:RadioButtonList>
                </td>
                <td rowspan="4">
                    <asp:RadioButtonList ID="radioListLevel18" runat="server">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="abilityRowEven">
                    <asp:Label ID="lblAbility3" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAbility4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="abilityRowEven">
                    <asp:Label ID="lblAbility5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>

        <div id="pageContent_Items" class="center odd">
            <asp:ListBox ID="listAllItems" runat="server" AutoPostBack="True" 
                onselectedindexchanged="listAllItems_SelectedIndexChanged" 
                CssClass="itemSelect"></asp:ListBox>
            <asp:Button ID="cmdAdd" runat="server" Text="&gt;&gt;" onclick="cmdAdd_Click" 
                Enabled="False" />
            <asp:Button ID="cmdRemove" runat="server" Text="&lt;&lt;" 
                onclick="cmdRemove_Click" Enabled="False" />
            <asp:ListBox ID="listBuildItems" runat="server" AutoPostBack="True" 
                onselectedindexchanged="listBuildItems_SelectedIndexChanged" 
                CssClass="itemSelect"></asp:ListBox>
        </div>
        <div class="center">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="cmdCreate" runat="server" Text="Create Build" 
                onclick="cmdCreate_Click" />
        </div>
    </div>
</asp:Content>

