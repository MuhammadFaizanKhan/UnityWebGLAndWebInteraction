<?php
$localhost = "127.0.0.1";
$root = "root";
$rootpass = "p@k!st@n";
$rootpass = "";
$dbName = "objectInteractionWeb1";
$con = mysql_connect($localhost,$root,$rootpass);
$db = mysql_select_db("objectInteractionWeb1", $con);
#region PDOConnection
$connPDO = new PDO("mysql:host=$localhost;dbname=$dbName",$root,$rootpass);

date_default_timezone_set("Asia/Karachi");

?>