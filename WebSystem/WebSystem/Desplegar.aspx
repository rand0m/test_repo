<%@ Page Language="C#" Inherits="WebSystem.Desplegar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
	<title>Desplegar</title>
</head>
<body>
	<form id="form1" runat="server">
	<p><h3><strong><font face="Verdana">Despliegue de una Base de Datos (asp.NET/C#)</font></strong></h3></p>
	<p align=center>&nbsp;</p>
	<p align=center>
	<asp:DataGrid id=TABLAGRID OnSelectedIndexChanged="TABLAGRID_SelectedIndexChanged" Width="400" BackColor="Gray" BorderColor="Blue" ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" EnableViewState="False" RUNAT="SERVER">
	<HeaderStyle BackColor="#70cb50">
	</HeaderStyle>
	</asp:DataGrid></p>
	<p><a href="Default.aspx">Regresar</a></p>
	</form>
</body>
</html>