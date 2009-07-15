<%@ Page Language="C#" Inherits="WebSystem.Altas" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
	<title>Altas</title>
</head>
<body>
	<form id="form1" runat="server">
	    <p>
        <h3><font face="Verdana"><strong><u>Insercion de un campo en una base de datos
        (asp.NET/C#)</u></strong></font></h3> 
    </p>
    <p>
        <font face="Verdana"></font>
    </p>
    <p>
        <font face="Verdana">CLAVE:</font> 
        <asp:TextBox id="CLAVE" runat="server"></asp:TextBox>
        <font face="Verdana">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; NOMBRE</font> 
        <asp:TextBox id="NOMBRE" runat="server"></asp:TextBox>
        <font face="Verdana">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; EDAD:</font> 
        <asp:TextBox id="EDAD" runat="server"></asp:TextBox>
        <font face="Verdana"></font>
    </p>
    <p align="center">
        <asp:Button id="Button1" onclick="INSERTAR" runat="server" text="insertar"></asp:Button>
    </p>
    <p>
        <asp:DataGrid id="TABLAGRID" EnableViewState="false" HeaderStyle-BackColor="green" Font-Size="8pt" Font-Name="Verdana" CellSpacing="0" CellPadding="3" ShowFooter="false" BorderColor="black" BackColor="Transparent" Width="400" RUNAT="SERVER">
            <HeaderStyle backcolor="green"></HeaderStyle>
        </asp:DataGrid>
    </p>
    <p><a href="Default.aspx">Regresar</a></p>
	</form>
</body>
</html>