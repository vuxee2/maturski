<?php
$con = mysqli_connect("localhost","root","root","unityaccess");
if (mysqli_connect_errno())
{
    echo "1: connection failed";
    exit();
}

$id_profesor = $_POST["id_profesor"];

$query = "SELECT razred, odeljenje FROM profesor_odeljenje WHERE id_profesor = '$id_profesor'";
$result = mysqli_query($con, $query) or die("2: query failed");

if (mysqli_num_rows($result) == 0)
{
    echo "8";
    exit();
}

while ($row = mysqli_fetch_assoc($result)) {
    echo $row["razred"] . "|" . $row["odeljenje"] . "\n";
}
?>