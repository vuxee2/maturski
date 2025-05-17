<?php

    $con = mysqli_connect("localhost","root","root","unityaccess");
    if (mysqli_connect_errno())
    {
        echo "1: connection failed"; // error code #1 = connection failed
        exit();
    }
    
    $ime = $_POST["ime"];
    $prezime = $_POST["prezime"];
    $predmet = $_POST["predmet"];
    $password = $_POST["password"];
    $mail = $_POST["mail"];

    //encryption
    $salt = "\$5\$rounds=5000\$" . "idegas" . $mail . "\$"; 
    $hash = crypt($password, $salt);

    $insertuserquery = "INSERT INTO profesori (ime, prezime, predmet, mail, hash, salt, verifikacija) 
        VALUES ( '" . $ime ."', '" . $prezime . "', '" . $predmet. "' , '" . $mail. "' , '" . $hash ."', '" . $salt . "', '" . 0 . "');";
    mysqli_query($con, $insertuserquery) or die("4: insert profesori query failed"); // error code #4 - insert query faield

    echo("0");
?>