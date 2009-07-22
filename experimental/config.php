<?php
//Conexiones para la base de datos
$host = "localhost";
$user = "root";
$pass = "wicked13";


mysql_connect($host, $user, $pass) or die (mysql_error());
mysql_select_db("daq") or die(mysql_error());
?>
