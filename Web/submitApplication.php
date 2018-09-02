<?php

$appname = htmlspecialchars($_POST["appName"]);
$appid = htmlspecialchars($_POST["appID"]);
$website = htmlspecialchars($_POST["website"]);
$hbtype = htmlspecialchars($_POST["hbtype"]);
$version = htmlspecialchars($_POST["version"]);


require_once('dbinfo.inc.php');
/*
echo ($appid);
echo ($appname);
echo ($website);
echo ($hbtype);
echo ($version);*/



$select = mysqli_query($conn, "SELECT `AppID` FROM `applications` WHERE `AppID` = '".$appid."'") or exit(mysqli_error($conn));
if(mysqli_num_rows($select)) {
    exit('Application ID in use');
}
$sql = "INSERT INTO `applications` (`AppID`, `AppName`, `AppType`, `AppVersion`, `Website`)VALUES ('".$appid."', '".$appname."', '".$hbtype."', '".$version."', '".$website."')";
if($conn->query($sql) === TRUE)
	echo "Application Submitted Successfully";
else
	echo "Error: " . $conn->error;

?>