<?php
    $con = mysqli_connect("localhost","root","root","unityaccess");
    if (mysqli_connect_errno())
    {
        echo "1: connection failed"; // error code #1 = connection failed
        exit();
    }

    $jmbg = $_POST["jmbg"];
    $password = $_POST["password"];

    $jmbgcheckquery = "SELECT jmbg, salt, hash, verifikacija FROM ucenici WHERE jmbg = '" . $jmbg . "';";
    $jmbgcheck = mysqli_query($con, $jmbgcheckquery) or die("2: jmbg check query failed"); // error code #2

    if(mysqli_num_rows($jmbgcheck) != 1)
    {
        echo "5: Either no user with name or more than one"; // error code #5 = nema tacno jedan takav jmbg
        exit();
    }
    
    // get existinginfo info from query
    $existinginfo = mysqli_fetch_assoc($jmbgcheck);
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["hash"];
    $verifikacija = $existinginfo["verifikacija"];

    if($verifikacija == 0)
    {
        echo "6: Unverified account"; // error code #6 = nije verifikovan nalog
        exit();
    }

    $loginhash = crypt($password, $salt);
    if($hash != $loginhash)
    {
        echo "7: Incorrect password"; // error code #7 = pogresna sifra
        exit();
    }
    echo "0\t";



?>