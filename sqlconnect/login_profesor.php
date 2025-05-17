<?php
    $con = mysqli_connect("localhost", "root", "root", "unityaccess");
    if (mysqli_connect_errno()) {
        echo "1: connection failed"; // error code #1 = connection failed
        exit();
    }

    $mail = $_POST["mail"];
    $password = $_POST["password"];

    $mailcheckquery = "SELECT id_profesor, mail, salt, hash, verifikacija, kod_predmeta FROM profesori WHERE mail = '" . $mail . "';";
    $mailcheck = mysqli_query($con, $mailcheckquery) or die("2: mail check query failed"); // error code #2

    if (mysqli_num_rows($mailcheck) != 1) {
        echo "5: Either no user with name or more than one"; // error code #5
        exit();
    }

    // get existing info from query
    $existinginfo = mysqli_fetch_assoc($mailcheck);
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["hash"];
    $verifikacija = $existinginfo["verifikacija"];
    $id_profesor = $existinginfo["id_profesor"];
    $kod_predmeta = $existinginfo["kod_predmeta"];

    if ($verifikacija == 0) {
        echo "6: Unverified account"; // error code #6
        exit();
    }

    $loginhash = crypt($password, $salt);
    if ($hash != $loginhash) {
        echo "7: Incorrect password"; // error code #7
        exit();
    }

    // ako je sve okej — saljemo podatke
    echo "0\t" . $id_profesor . "\t" . $kod_predmeta;

?>
