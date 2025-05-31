<?php
$con = mysqli_connect("localhost", "root", "root", "unityaccess");
if (mysqli_connect_errno()) {
    echo "1: connection failed"; // connection failed
    exit();
}

$jmbg = $_POST["jmbg"];
$tekst = $_POST["tekst"];
$predmet = $_POST["predmet"];

if (!$jmbg || !$tekst || !$predmet) {
    echo "3: missing fields"; // missing input
    exit();
}

// Izbegni SQL Injection jednostavnom zaštitom (idealno koristi prepared statements)
$jmbg = mysqli_real_escape_string($con, $jmbg);
$tekst = mysqli_real_escape_string($con, $tekst);
$predmet = mysqli_real_escape_string($con, $predmet);

$insertQuery = "INSERT INTO ucenik_obaveza (id_ucenik, tekst, predmet) VALUES ('$jmbg', '$tekst', '$predmet')";

if (mysqli_query($con, $insertQuery)) {
    echo "0: success"; // success
} else {
    echo "2: insert query failed";
}

mysqli_close($con);
?>
