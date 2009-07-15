<%@ Page Language="C#" Inherits="WebSystem.Bajas" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
	<title>Bajas</title>
</head>
<form id="form1"runat="server">
<body>
    <p>
        <h3><u><font face="Verdana">Bajas en base de datos (asp.NET/C#)</font></u></h3>
    </p>
    <p>
        clave a borrar:
        <asp:textbox id="CLAVE" runat="server"></asp:textbox>
        <br />
        <asp:button id="Button1" onclick="BORRAR" runat="server" text="borrar"></asp:button>
        <br />
        <asp:datagrid id="TABLAGRID" runat="server" enableviewstate="false" cellpadding="3" showfooter="false" BorderColor="black" BackColor="green" width="400" headerstyle-backcolor="blue" font-size="8pt" font-name="verdana" cellspacing="0"></asp:datagrid>
    </p>
    <p><a href="Default.aspx">Regresar</a></p>
</body>
</form>
</html>