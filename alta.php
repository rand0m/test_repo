<?php
session_start();
?>

<?php
include("config.php");
?>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Sistema para alta de licencias</title>
        <link href="estilo.css" type="text/css" rel="stylesheet">
    </head>
    <body>
        <center>
            <div id="AreaTotal">
                <div id="Banner"><a href="index.php"><img src='img/banner.png' border="0"></a></div>
                <div id="menu">
                    <table border="1" cellspacing="0" cellpadding="1" align="left">
                        <tbody>
                            <tr>
                                <td class="FondoMenuCelda" width="182px" height="18px" ><a href="alta.php">Altas</a></td>
                                <td class="FondoMenuCelda" width="182px" height="18px">Modifaciones</td>
                                <td class="FondoMenuCelda" width="182px" height="18px">Reportes</td>
                                <td class="FondoMenuCelda" width="182px" height="18px">Asesores</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="contenido">

                     <form name="f_alta" method='POST' action="insertar.php">
                       <strong>Empresa</strong><br />
                            <select name='empresa'>
                                <option>Angel xxx </option>
                                <option>Industrias Random</option>
                            </select>
                        <br>

                            <strong>licencia</strong><br />
                            <select name='licencia'>
                                <option>---Selecciona---</option>
                                <option>local</option>
                                <option>Modulos</option>
                                <option>Movimientos</option>
                                <option>Usuario</option>
                                <option>Movimientos anuales</option>
                                <option>red</option>
                            </select>
                        
                        <br>

                        <p><strong>Asesor</strong><br />
                            <select name='asesores' >
                                <option>---Selecciona---</option> -->
                                <?

                                $list=mysql_query("SELECT CONCAT(nombre,' ', apellido) As Minombre FROM asesor");
                                while($row_list=mysql_fetch_assoc($list)){
                                    ?>
                                <option value="<? echo $row_list['Minombre']; ?>" <? if($row_list['Minombre']==$select) ?>><? echo $row_list['Minombre']; ?></option>
                                <?
                                // End while loop.
                            }
                            ?>
                            </select>
                        </p>
                        <br>
                        <center><input name='submit' type="submit" value='enviar'></center>
                    </form>
                </div>


            </div>
        </center>
    </body>
</html>
