<?php
//Borramos cualquier sesion 
//del cliente
session_unset();
?>

<?php include('config.php');?>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link href="estilo.css" type="text/css" rel="stylesheet">
        <title>Sistemas</title>
    </head>
    <body>

        <?php include('menu.php'); ?>



        <div id="areatotal" class="font">

            <!-- inicia codigo de random -->
            <div id="areasecundaria">

                <?php
                $DAQ = $_POST["DAQ"];
                // If not empty, prompt for Edit DAQ:
                $master = mysql_query("SELECT Nombre_DAQ FROM Dispositivos WHERE Nombre_DAQ = 'DAQ1'");
                // Store the record of the "example" table into $row
                $existe = mysql_fetch_array($master);

                // If DAQ1 is already en DB, edit fields
                ?>

                <?php
                if (($existe['Nombre_DAQ']) == 'DAQ1')
                {
                    echo "Este dispositivo Maestro  <br>";
                    echo "ya se encuentra registrado en Base de Datos";
                    echo "<br />";
                    ?>
                <br>
                <center>
                    <form action="index.php" method="post">
                        <input type="submit" name="regresar" value="Regresar">
                    </form>
                </center>
            </div>
        </div>
        <?php
    }

    else if (!isset($_POST['submit']))

    { // If page is not submitted to itself echo the form
        ?>
        <html>
            <head>
                <title>Configuracion de Dispositivo Maestro</title>
            </head>
            <body>
                <form method="POST" action="<?php echo $PHP_SELF; ?>">
                    <p>
                        <b>Introduce la URL o IP del DAQ Maestro para enviar datos (ej.: <i>http://192.168.1.15 o http://daq.no-ip.org</i>)</b>:<br>
                    </p>
                    <p>
                        <input type="text" name="DAQ" value="" />
                        <input type="submit" value="submit" name="submit"><br />
                    </p>
                </form>
            </body>
        </html>
        <?php
    }
    else
    {
        // If empty, insert a row of information into the table "Dispositivos"
        mysql_query("INSERT INTO Dispositivos(Nombre_DAQ, IP_URL, Fecha, Master, Status)
    VALUES('DAQ1', '$DAQ', '$Fecha', 1, 1)") or die (mysql_error());

        echo "El DAQ: ".$DAQ."<br />";
        echo "Ha sido configurado. <br />";
        echo "<a href='index.php'>Regresar</a>";
    }
    // close connection
    mysql_close();
    ?>
     <br>
                <center>
                    <form action="index.php" method="post">
                        <input type="submit" name="regresar" value="Regresar">
                    </form>
                </center>

</body>
</html>
