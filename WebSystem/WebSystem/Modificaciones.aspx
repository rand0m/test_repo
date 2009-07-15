<%@ Page Language="C#" Inherits="WebSystem.Modificaciones" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head><title>Modificaciones</title></head>
<body style="FONT: 10pt verdana">
    <form id="form1" runat="server">
        <h3><font face="Verdana"><u>EDICION O ACTUALIZACION DE REGISTROS</u></font> (asp.NET/C#)
        </h3>
        <span id="Message" runat="server"> 
        <p>
            <ASP:DataGrid id="TABLAGRID" runat="server" Width="400" BackColor="#ccccff" BorderColor="black" ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" OnCancelCommand="DataGrid_Cancel" OnEditCommand="DataGrid_Edit" OnUpdateCommand="DataGrid_Update" DataKeyField="clave">
                <Columns>
                    <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" ItemStyle-Wrap="false" />
                </Columns>
            </ASP:DataGrid>
        </p>
        </span>
        <p><a href="Default.aspx">Regresar</a></p>
    </form>
</body>
</html>