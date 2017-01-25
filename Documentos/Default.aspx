<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Documentos._Default" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Bienvenidos a Documentos (aplicación WEB)</h2>
    <ol class="round">
        
            <table class="auto-style2">
                <tr>
                    <td colspan="2">
            1.- Es una oficina de documentos, una biblioteca, un museo o una custodia de datos, con capacidad de administrar el contenido agregando, catalogando, revisando, agrupando, autorizando y distribuyendo información digitalizada.
                        </td>

                </tr>
                <tr>
                    <td colspan="2">2.- Permite el resguardo de múltiples versiones durante el desarrollo de un documento</td>
                </tr>
                <tr>
                    <td colspan="2">3.- Fácil acceso a los datos corporativos, información disponible permanentemente en cualquier lugar donde se encuentre.</td>
                </tr>
                <tr>
                    <td>4.- Evita adjuntar archivos digitales, disminuye la saturación de los correos electrónicos.</td>
                    <td rowspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>5.- Resguardo de la información digitalizada y respaldo automático de las bases de datos.</td>
                </tr>
                <tr>
                    <td>6.- Aprovecha al máximo la seguridad de internet.</td>
                    <td rowspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>7.- Diseñado a la medida para usuarios no especializados en informática.</td>
                </tr>
                <tr>
                    <td colspan="2">8.- Registro detallado de la administración de la biblioteca en una bitácora.</td>
                </tr>
                <tr>
                    <td colspan="2">9.- Máxima seguridad, después de implementar la aplicación WEB, el cliente conserva las contraseñas y claves de acceso de su sitio.</td>
                </tr>
                <tr>
                    <td colspan="2">10.- Adecuaciones a la aplicación por un costo simbólico.</td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBase" runat="server" Text="Label" CssClass="auto-style3" style="font-weight: 700"></asp:Label>
                    &nbsp;<asp:Label ID="lblDocs" runat="server" Text="Label" CssClass="auto-style3" style="font-weight: 700"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
    </ol>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            font-size: medium;
        }
        .auto-style3 {
            font-size: large;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
</asp:Content>

