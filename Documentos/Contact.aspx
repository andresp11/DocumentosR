<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Documentos.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Contacto<br /></h1>
        <header>
            <table class="auto-style1">
                <tr>
                    <td>
            <h3> <span class="auto-style3">Danos la oportunidad de servirte, para cualquier duda o comentario, <br /><br />favor de enviar un correo electrónico a:<br /><br />
                        <a href="mailto:andres.ponce.de.leon.huerta@gmail.com">andres.ponce.de.leon.huerta@gmail.com</a></span> <span class="auto-style3"> <br /><br />
                        Atentamente</span><br /><br /><br />
                        Andrés Ponce de León Huerta</h3>
                    </td>
                </tr>
            </table>
        </header>
    </hgroup>

    <section class="contact">
        <header>
            <table class="auto-style1">
            </table>
        </header>
    </section>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            font-weight: normal;
        }
    </style>
</asp:Content>
