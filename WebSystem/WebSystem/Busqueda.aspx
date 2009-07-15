<%@ Page Language="C#" Inherits="WebSystem.Busqueda" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
	<title>Busqueda</title>
</head>
<body>
	<form id="form1" runat="server">
		<p align="left">
			<h3>
				<font face="Verdana">
					<strong>
						<u>Busqueda en una base de datos (asp.Net/C#)</u>
					</strong>
				</font>
			</h3> 
       </p>
        <p align="left">
            <br />
            <strong>clave a buscar: </strong>
            <asp:textbox id="CLAVE" runat="server"></asp:textbox>
        </p>
        <p align="left">
            <asp:button id="Button1" onclick="BUSCAR" runat="server" text="buscar"></asp:button>
        </p>
        <p align="left">
            <br />
        </p>
        <p align="left">
            <asp:datagrid id="TABLAGRID" runat="server" EnableViewState="false" HeaderStyleColor="green" Font-Size="8pt" Font-Name="Verdana" cellSpacing="3" ShowFooter="false" BorderColor="black" BackColor="DarkSeaGreen" width="400"></asp:datagrid>
        </p>
        <p><a href="Default.aspx">Regresar</a></p>
	</form>
</body>
</html>