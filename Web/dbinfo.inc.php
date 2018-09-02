<?php
	function db_connect()
	{
		$db_user   = "root";
		$db_pass   = "123321";
		$db_dbname = "TIDGen";

		$db_serverName     = "127.0.0.1"; // IP
		$conn = mysqli_connect($db_serverName, $db_user, $db_pass, $db_dbname);

		if(! $conn)
		{
			//echo "Connection could not be established.\n";
			die( print_r( mysqli_error(), true));
			exit();
		}

		return $conn;
	}
	
	function db_exec($conn, $tsql)
	{
		$stmt  = mysqli_query($conn, $tsql);
		if(! $stmt)
		{
			echo "exec failed.\n";
			die( print_r( mysqli_error(), true));
		}

		$member = mysqli_fetch_array($stmt);
		return $member;
	}

	$conn = db_connect();
	
	$typeArray = array("Application", "Game", "Tool", "Concept");
?>