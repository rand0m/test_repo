<?php
session_start();
?>

<?php
mysql_connect('localhost','root','wicked13') or die(mysql_error());
mysql_select_db('licencias1') or die(mysql_error());
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
            <div id="areatotal">
                <div id="Banner"><a href="index.php"><img src='img/banner-licencias.png' border="0"></a></div>
                <div id="menu">
                    <table border="1" cellspacing="0" cellpadding="1" align="left">
                        <tbody>
                            <tr>
                                <td class="FondoMenuCelda" width="182px" height="18px" ><a href="alta.php">Altas</a></td>
                                <td class="FondoMenuCelda" width="182px" height="18px"><a href="modificar.php">Modifaciones</a></td>
                                <td class="FondoMenuCelda" width="182px" height="18px"><a href="reporte.php">Reportes</a></td>
                                <td class="FondoMenuCelda" width="182px" height="18px">Asesores</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div id="contenido">

                    <?php

                    $empresa = $_REQUEST['empresa'];
                    $licencia = $_REQUEST['licencia'];
                    $asesor = $_REQUEST['asesor'];
                    $comentario = $_REQUEST['comentarios'];


                    $insert=mysql_query("INSERT INTO registro(emp_codigo, lic_codigo, asr_codigo, comentario) VALUES('$empresa', '$licencia','$asesor', '$comentario')") or die (mysql_error());
                    echo "La insercion de datos a sido exitosa!" ;

                    
                    //Cerramos conexion a la base de datos
                    mysql_close();
                    ?>
                    <html>

                    <form name='regresa' action='alta.php'>
                       <br />
                       <input name='regresar' value='regresar' type='submit'>
                    </form>
                </div>
            </div>

        </center>

    </body>
</html>