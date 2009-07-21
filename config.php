<?php
$host = 'localhost';
$user_db = 'root';
$pass_db = 'wicked13';
$db = 'licencias';
$tbl_name = 'usuarios';

    //Hacemos la conexion a base de datos
    mysql_connect($host, $user_db, $pass_db) or die(mysql_error());

    //Seleccionamos la base de datos
    mysql_select_db($db) or die(mysql_error());
?>
