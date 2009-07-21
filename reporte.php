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
        <title>Sistema para registro de licencias</title>
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
                    echo "Selecciona la empresa";
                    ?>
                    <form id="reporte" name="reporte" method="POST" action="<? echo $_SERVER['PHP_SELF']; ?> ">
                        <select name='select'>
                            <option>---Selecciona---</option>
                            <?
                            $select = $_POST['select'];
                            $list=mysql_query("SELECT * FROM empresa order by emp_codigo");
                            while($row_list=mysql_fetch_assoc($list)){
                                ?>
                            <option value="<? echo $row_list['emp_codigo']; ?>" <? if($row_list['emp_codigo']==$select) ?>><? echo $row_list['emp_descripcion']; ?></option>
                            <?
                            // End while loop.
                        }

                        ?>
                        </select>

                        <p><input type='submit' value="Procesar"></p>
                    </form>

                    <hr>
                    <p>
                        <?
                        if(isset($select)&&$select !=""){

                            // Traemos informacion de la base de datos
                            $row=mysql_fetch_assoc($result);
                            ?>
                    Registros para: <strong><? echo $row['emp_descripcion']; ?></strong></p>
                    <p><?php
                        $result=mysql_query("SELECT registro.reg_hora as hora, empresa.emp_descripcion as Empresa,CONCAT(asesor.asr_nombre, ' ', asesor.asr_apellido) AS nombre, empresa.emp_descripcion AS empresa, tipolicencia.tla_nombre As Licencia,
                                                                                     registro.comentario FROM registro INNER JOIN empresa ON registro.emp_codigo = empresa.emp_codigo INNER JOIN asesor ON registro.asr_codigo = asesor.asr_codigo
                                                                                     INNER JOIN tipolicencia ON registro.lic_codigo = tipolicencia.tla_codigo WHERE empresa.emp_codigo ='$select'");


                        ?>

                        <?php
                        $linea = $myrow = mysql_fetch_array($result);
                        if ($linea) {

                            echo "<table border=1>\n";

                            echo "<tr>
                                                                            <th>Empresa</th>
                                                                            <th>Asesor</th>
                                                                            <th>Comentarios</th>
                                                                            <th>Hora</th>
                                                                            </tr>\n";

                            do {

                                printf("<tr><td><strong>%s</strong></td><td>%s</td><td>%s</td><td>%s</tr>\n", $myrow["Empresa"], $myrow["nombre"], $myrow["comentario"], $myrow["hora"]);

                            } while ($myrow = mysql_fetch_array($result));

                            echo "</table>\n";

                        }
                        else {

                            echo "No hay registros para esta empresa!";

                        }
                    
                        ?>

                        <?
                        // End if statement.
                    }
                    else {
                        echo "No hay registros";
                    }
                    // Close database connection.
                    mysql_close();
                    ?>
                    </p>

                </div>
            </div>
        </center>
    </body>
</html>
