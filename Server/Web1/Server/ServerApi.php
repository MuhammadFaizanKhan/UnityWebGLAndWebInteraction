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

$objectName         =   $_POST['objName'];
$objectPosition     =   $_POST['Objposition'];

$RecordAddDateTime  =   date('Y-m-d H:i:s');

//Add Employee attendance Record.l
$sql = "INSERT INTO  object_clicked
            (objectName, Objposition, dateTime)
VALUES      (:objName, :Objposition, :addDateTime)";

$statement = $connPDO->prepare($sql);

$params = array (

':objName'                  =>    $objectName,
':Objposition'              =>    $objectPosition,
':addDateTime'              =>    $RecordAddDateTime,

);

echo $statement->execute($params);
?>