<?php

    $con = mysqli_connect("localhost","root","root","unityaccess");
    if (mysqli_connect_errno())
    {
        echo "1: connection failed"; // error code #1 = connection failed
        exit();
    }

    $jmbg = $_POST["jmbg"];
    $ime = $_POST["ime"];
    $prezime = $_POST["prezime"];
    $password = $_POST["password"];

    //proveri da li postoji jmbg
    $jmbgcheckquery = "SELECT jmbg FROM ucenici WHERE jmbg = '" . $jmbg . "';";
    $jmbgcheck = mysqli_query($con, $jmbgcheckquery) or die("2: jmbg check query failed"); // error code #2

    if(mysqli_num_rows($jmbgcheck) > 0)
    {
        echo "3: jmbg already exists"; // error code #3 = jmbg vec postoji
        exit();
    }

    //encryption
    $salt = "\$5\$rounds=5000\$" . "idegas" . $username . "\$"; 
    $hash = crypt($password, $salt);

    $insertuserquery = "INSERT INTO ucenici (jmbg, ime, prezime, hash, salt, verifikacija) 
        VALUES ( '" . $jmbg ."', '" . $ime . "', '" . $prezime. "' , '" . $hash ."', '" . $salt . "', '" . 0 . "');";
    mysqli_query($con, $insertuserquery) or die("4: insert ucenici query failed"); // error code #4 - insert query faield

    echo("0");
?>