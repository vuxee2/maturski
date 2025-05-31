<?php

$con = mysqli_connect("localhost","root","root","unityaccess");
if (mysqli_connect_errno())
{
    echo "1: connection failed"; // error code #1 = connection failed
    exit();
}

$jmbg = $_POST["jmbg"];

$selectquery = "SELECT tekst, predmet FROM ucenik_obaveza WHERE id_ucenik = '$jmbg'";

$result = mysqli_query($con, $selectquery);
if (!$result)
{
    echo "2: query failed"; // error code #2 = select query failed
    exit();
}

$obaveze = array();

while($row = mysqli_fetch_assoc($result))
{
    $obaveze[] = array(
        "tekst" => $row['tekst'],
        "predmet" => $row['predmet']
    );
}

echo json_encode(["items" => $obaveze]);

mysqli_close($con);
?>
