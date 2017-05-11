<?php
$login = $_POST['login'];
$password = $_POST['password'];

if ($login == "admin" && $password == "admin")
	echo "Authorized";

else
	echo "Fail";
?>
