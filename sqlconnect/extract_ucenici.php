<?php
$con = mysqli_connect("localhost", "root", "root", "unityaccess");
if (mysqli_connect_errno()) {
    echo "1: connection failed";
    exit();
}

$razred = $_POST["razred"];
$odeljenje = $_POST["odeljenje"];

$razred = mysqli_real_escape_string($con, $razred);
$odeljenje = mysqli_real_escape_string($con, $odeljenje);

$query = "SELECT jmbg, ime, prezime, razred, odeljenje FROM ucenici WHERE razred = '$razred' AND odeljenje = '$odeljenje'";
$result = mysqli_query($con, $query) or die("2: query failed");

$response = "";

while ($row = mysqli_fetch_assoc($result)) {
    // Format: jmbg|ime|prezime|razred|odeljenje\n
    $response .= $row["jmbg"] . "|" . $row["ime"] . "|" . $row["prezime"] . "|" . $row["razred"] . "|" . $row["odeljenje"] . "\n";
}

echo $response;
?>
