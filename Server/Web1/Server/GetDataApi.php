<?php

/*

$localhost = "127.0.0.1";
$root = "root";
$rootpass = "p@k!st@n";
$rootpass = "";
$dbName = "objectInteractionWeb1";
$con = mysql_connect($localhost,$root,$rootpass);
$db = mysql_select_db("objectInteractionWeb1", $con);
#region PDOConnection
$connPDO = new PDO("mysql:host=$localhost;dbname=$dbName",$root,$rootpass);

*/

include 'Connect.php';

$sql            = "Select * from object_clicked order by  dateTime DESC";
$queryExecuted  = $connPDO->query($sql);
$array          = $queryExecuted->fetchAll(PDO::FETCH_ASSOC);
$json           = json_encode($array);

echo $json;

?>