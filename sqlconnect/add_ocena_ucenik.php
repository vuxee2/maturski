<?php
$con = mysqli_connect("localhost", "root", "root", "unityaccess");
if (mysqli_connect_errno()) {
    echo "1: connection failed";
    exit();
}

$jmbg = $_POST["jmbg"];
$predmet = $_POST["predmet"];
$ocena = $_POST["ocena"];

// Escape
$jmbg = mysqli_real_escape_string($con, $jmbg);
$predmet = mysqli_real_escape_string($con, $predmet);
$ocena = mysqli_real_escape_string($con, $ocena);

// Dohvati trenutne ocene
$query = "SELECT ocene FROM ucenici WHERE jmbg = '$jmbg'";
$result = mysqli_query($con, $query) or die("2: query failed");

if(mysqli_num_rows($result) != 1)
{
    echo "3: no such student";
    exit();
}

$row = mysqli_fetch_assoc($result);
$ocene = $row["ocene"];

// Dodaj novu ocenu na kraj stringa
$ocene .= $predmet . $ocena;

// Upisi nazad
$updateQuery = "UPDATE ucenici SET ocene = '$ocene' WHERE jmbg = '$jmbg'";
if (mysqli_query($con, $updateQuery)) {
    echo "0";
} else {
    echo "4: update failed";
}
?>
