<!DOCTYPE html>
<html lang="en">
<head>
    <!--  Meta  -->
    <meta charset="UTF-8" />
    <title>CPAN204 - Ashraf & Harpreet</title>

    <!--Scripts to load-->
    <link href="https://fonts.googleapis.com/css?family=Orbitron" rel="stylesheet">
    <link rel="stylesheet" href="../css/admin.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.9/css/all.css" integrity="sha384-5SOiIsAziJl6AWe0HWRKTXlfcSHKmYV4RBF18PPJ173Kzn7jzMyFuTtk8JA7QQG1" crossorigin="anonymous">
</head>
<body>
<div class="logout" >
    <button name="logout"><a href="logout.php">Logout</a></button>
</div>

<div class="container">
    <h1>Table of Students</h1>
    <table border=1 id="adminTable">
        <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Phone Number</th>
            <th>Password</th>
            <th>RegID</th>
            <th>Group ID</th>
        </tr>
        <?php
        $host = "localhost";
        $user = "root";
        $password = "";
        $dbname = "project2";

        //  Connecting to Database
        $con = mysqli_connect($host, $user, $password, $dbname) or die("Connection has failed.". mysqli_connect_error($con));
        $query = "select * from users";
        $result = mysqli_query($con, $query) or die("Query has failed." . my_sqli_error($con));
        if(mysqli_num_rows($result)) {
            while ($row = mysqli_fetch_row($result)) {
                echo "<tr>
                        <td>$row[0]</td>
                        <td>$row[1]</td>
                        <td>$row[2]</td>
                        <td>$row[3]</td>
                        <td>$row[4]</td>
                        <td>$row[5]</td>
                        <td>$row[6]</td>
                    </tr>";
            }
        }
        ?>
    </table>
</div>


<div class="container">
    <form method="post" id="editStudents">
        <h2>Admin Form</h2>
        <div class="row">
            <label>RegID</label>
            <input type="text" name="regId" placeholder="Necessary must fill in">
        </div>
        <div class="row">
            <label>First Name</label>
            <input type="text" name="fName">
        </div>
        <div class="row">
            <label>Last Name</label>
            <input type="text" name="lName">
        </div>
        <div class="row">
            <label>Email</label>
            <input type="text" name="eMail">
        </div>
        <div class="row">
            <label>Phone Number</label>
            <input type="text" name="number" >
        </div>
        <div class="row">
            <label>Password</label>
            <input type="text" name="pWord" >
        </div>

        <div class="btn">
            <button name="aButton" class="formButtons">Add</button>
            <button name="eButton" class="formButtons">Edit</button>
            <button name="dButton" class="formButtons">Delete</button>
        </div>
    </form>
    <?php
    if (isset($_POST['aButton'])) {
        $host = "localhost";
        $user = "root";
        $password = "";
        $dbname = "project2";
        $con = mysqli_connect($host, $user, $password, $dbname) or die("Connection has failed.". mysqli_connect_error($con));

        if(isset($_POST["fName"]) && isset($_POST["lName"]) && isset($_POST["eMail"]) && isset($_POST["number"]) && isset($_POST["pWord"]) && isset($_POST['regId'])) {
            if (!empty($_POST["fName"]) && !empty($_POST["lName"]) && !empty($_POST["eMail"]) && !empty($_POST["number"]) && !empty($_POST["pWord"]) && !empty($_POST['regId'])) {
                $fName = mysqli_real_escape_string($con, $_POST["fName"]);
                $lName = mysqli_real_escape_string($con, $_POST["lName"]);
                $eMail = mysqli_real_escape_string($con, $_POST["eMail"]);
                $pNumber = mysqli_real_escape_string($con, $_POST["number"]);
                $pWord = mysqli_real_escape_string($con, $_POST["pWord"]);
                $regID = mysqli_real_escape_string($con, $_POST["regId"]);

                //  Creating Account
                $query = "insert into users values('$fName','$lName','$eMail','$pNumber','$pWord', '$regID')";
                $result = mysqli_query($con, $query) or die('<script language="javascript">alert("Could not add user")</script>');

                if (mysqli_affected_rows($con)) {
                    echo '<script language="javascript">';
                    echo 'alert("User Created")';
                    echo '</script>';
                } else {
                    echo '<script language="javascript">';
                    echo 'alert("Error regID needs to unique")';
                    echo '</script>';
                }
            }
        }
        mysqli_close($con);
    } elseif (isset($_POST['eButton'])) {
        if (isset($_POST['regId']) && !empty($_POST['regId'])) {
            if(isset($_POST["fName"]) || isset($_POST["lName"]) || isset($_POST["eMail"]) || isset($_POST["number"]) || isset($_POST["pWord"])) {
                if (!empty($_POST["fName"]) || !empty($_POST["lName"]) || !empty($_POST["eMail"]) || !empty($_POST["number"]) || !empty($_POST["pWord"])) {
                    $host = "localhost";
                    $user = "root";
                    $password = "";
                    $dbname = "project2";
                    $con = mysqli_connect($host, $user, $password, $dbname) or die('<script language="javascript">alert("Connection Failed")</script>'. mysqli_connect_error($con));
                    $queryStarter = 'UPDATE users SET';
                    if (isset($_POST['fName']) && !empty($_POST['fName'])) {
                        $fName = mysqli_real_escape_string($con, $_POST["fName"]);
                        $queryStarter .= " First_Name = '$fName',";
                    }
                    if (isset($_POST['lName']) && !empty($_POST['lName'])) {
                        $lName = mysqli_real_escape_string($con, $_POST["lName"]);
                        $queryStarter .= " Last_Name = '$lName',";
                    }
                    if (isset($_POST['eMail']) && !empty($_POST['eMail'])) {
                        $eMail = mysqli_real_escape_string($con, $_POST["eMail"]);
                        $queryStarter .= " Email = '$eMail',";
                    }
                    if (isset($_POST['number']) && !empty($_POST['number'])) {
                        $number = mysqli_real_escape_string($con, $_POST["number"]);
                        $queryStarter .= " Phone_Number = '$number',";
                    }
                    if (isset($_POST['pWord']) && !empty($_POST['pWord'])) {
                        $pWord = mysqli_real_escape_string($con, $_POST["pWord"]);
                        $queryStarter .= " Password = '$pWord',";
                    }
                    $lastIndex = strripos($queryStarter, ",");
                    $finalQuery = substr_replace($queryStarter, '', $lastIndex, $lastIndex); //Get rid of last comma
                    $regID = $_POST['regId'];
                    $finalQuery .= " WHERE RegID = '$regID'";
                    echo '<script type="text/javascript">alert("'.$finalQuery.'")</script>';
                    $result = mysqli_query($con, $finalQuery) or die('<script language="javascript">alert("Could not edit user information")</script>');
                    if(mysqli_affected_rows($con)){
                        echo '<script language="javascript">alert("User updated")</script>';
                    }
                }
            }
        }
        mysqli_close($con);
    } elseif (isset($_POST['dButton'])) {
        if (isset($_POST['regId']) && !empty($_POST['regId'])) {
            $host = "localhost";
            $user = "root";
            $password = "";
            $dbname = "project2";
            $con = mysqli_connect($host, $user, $password, $dbname) or die('<script language="javascript">alert("Connection Failed")</script>'. mysqli_connect_error($con));
            $regID = $_POST['regId'];
            $query = "DELETE FROM users WHERE RegID = '$regID'";
            $result = mysqli_query($con, $query) or die('<script language="javascript">alert("Could not edit user information")</script>');
            if(mysqli_affected_rows($con)){
                echo '<script language="javascript">alert("User deleted")</script>';
            }
        }
        mysqli_close($con);
    }
    ?>
</div>
<div class="container">
    <h2>Group Generator</h2>
    <form method="post" action="../py/students.py" class="generateForm">
        <div class="row" style="width: 100%">
            <label>Please enter how many people you would like in your group</label>
            <input type="text" name="grp">
        </div>
        <button name="bGenerate">Generate With Python</button>
    </form>
    <form method="post" class="generateForm">
        <div class="row" style="width: 100%">
            <label>Please enter how many people you would like in your group</label>
            <input type="text" name="grp">
        </div>
        <button name="bPGenerate">Generate With PHP</button>
    </form>
    <?php
    if (isset($_POST['bGenerate']))
    {
        echo '<script language="javascript">alert("Groups generated")</script>';
    }
    if (isset($_POST['bPGenerate']))
    {
        echo '<script language="javascript">alert("Groups generated")</script>';
        $host = "localhost";
        $user = "root";
        $password = "";
        $dbname = "project2";
        $con = mysqli_connect($host, $user, $password, $dbname) or die('<script language="javascript">alert("Connection Failed")</script>'. mysqli_connect_error($con));
        $query = "select * from users WHERE NOT (FIRST_NAME = 'admin')";
        $result = mysqli_query($con, $query) or die("Query has failed." . mysqli_error($con));
        $rows = array();
        echo "<table>";
        if(mysqli_num_rows($result)) {
            while ($row = mysqli_fetch_row($result)) {
                $rows[] = $row;
            }
        }
        shuffle($rows);
        $numberGen = $_POST['grp'];
        $remainderStudents = 0;
                if ((count($rows) % $numberGen) != 0) {
                    $remainderStudents = count($rows) % $numberGen;
                }

                $groupCounter = 1;  # Which group student delegated to
                $remainderCounter = 0;  # Remainder counter
                foreach ($rows as $r) {
                    if (($remainderStudents != 0) && ($remainderCounter != $remainderStudents)) {
                        $queryStarter = "UPDATE users SET GROUP_ID = 'not verified waiting for more people' WHERE REGID = '$r[5]'";
                        $remainderCounter += 1;
                        $result = mysqli_query($con, $queryStarter) or die("Query has failed." . mysqli_error($con));
                        continue;
                    }
                    $queryStarter = "UPDATE users SET GROUP_ID = '$groupCounter' WHERE REGID = '$r[5]'";
                    if ($groupCounter == $numberGen) {
                        $groupCounter = 0;
                    }
                    $groupCounter += 1;
                    $result = mysqli_query($con, $queryStarter) or die("Query has failed." . mysqli_error($con));
                }
                echo '<table border=1 id="adminTable2">
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Email</th>
                            <th>Phone Number</th>
                            <th>Password</th>
                            <th>RegID</th>
                            <th>Group_ID</th>
                        </tr>';
                foreach ($rows as $r) {
                    echo "<tr>
                        <td>$r[0]</td>
                        <td>$r[1]</td>
                        <td>$r[2]</td>
                        <td>$r[3]</td>
                        <td>$r[4]</td>
                        <td>$r[5]</td>
                        <td>$r[6]</td>
                    </tr>";
                }
                echo "</table>";
                }

    ?>
</div>

</body>
</html>