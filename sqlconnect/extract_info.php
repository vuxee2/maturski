<?php
    $con = mysqli_connect("localhost","root","root","unityaccess");
    if (mysqli_connect_errno())
    {
        echo "1: connection failed"; // error code #1 = connection failed
        exit();
    }

    $jmbg = $_POST["jmbg"];

    //proveri da li postoji jmbg
    $jmbgcheckquery = "SELECT jmbg, ocene FROM ucenici WHERE jmbg = '" . $jmbg . "';";
    $jmbgcheck = mysqli_query($con, $jmbgcheckquery) or die("2: jmbg check query failed"); // error code #2

    if(mysqli_num_rows($jmbgcheck) != 1)
    {
        echo "8: No matching jmbg"; // error code #8 = ne postoji jmbg
        exit();
    }

    // uzmi ocene
    $row = mysqli_fetch_assoc($jmbgcheck);
    $ocene = $row["ocene"];
    echo "Ocene: " . $ocene;

?>