<?php
    session_start();
    ?>
<!DOCTYPE html>
<html lang="en">
    <head>

        <!--  Meta  -->
        <meta charset="UTF-8" />
        <title>CPAN204 - Ashraf & Harpreet</title>

        <!--Scripts to load-->
        <link href="https://fonts.googleapis.com/css?family=Orbitron" rel="stylesheet">
        <link rel="stylesheet" href="../css/student.css">
    </head>
    <body>
    <div class="logout" >
        <button name="logout"><a href="logout.php">Logout</a></button>
    </div>
        <div class="container">
            <?php
            #echo '<script type="text/javascript">alert("'.$_SESSION['user'].'")</script>';
            if (isset($_SESSION['user'])) {$name = $_SESSION['user'];};
            if (stripos($name, "@")) {
                $greetingName = explode("@", $name);
                echo "<h1>Hello $greetingName[0] </h1>";
            }
            else {
                echo "<h1>Hello " . $name . "</h1>";
            }
            ?>
            <h2>Table of Students</h2>
            <table class="tables">
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                </tr>
                <?php
                $host = "localhost";
            $user = "root";
            $password = "";
            $dbname = "project2";

            //  Connecting to Database
            $con = mysqli_connect($host, $user, $password, $dbname) or die("Connection has failed." . mysqli_connect_error($con));
            $query = "select First_name, Last_Name from users";
            $result = mysqli_query($con, $query) or die("Query has failed." . my_sqli_error($con));
            if (mysqli_num_rows($result)) {
                while ($row = mysqli_fetch_row($result)) {
                    echo "<tr>
                        <td>$row[0]</td>
                        <td>$row[1]</td>
                    </tr>";
                }
            }

                ?>
            </table>
        </div>
        <div class="container">
            <h2>Update Information</h2>
            <form method="post">
                <div class="row">Password:</div><div class="row2"><input type="text" name="pass"></div>
                <div class="row">Phone Number:</div><div class="row2"><input type="text" name="phone"></div>
                <div class="row">Email Name:</div><div class="row2"><input type="text" name="email"></div>
                <input type="submit" value="Update User" name="upass">
            </form>
            <?php
            if (isset($_POST["pass"]) || isset($_POST["phone"]) || isset($_POST["email"])) {
                if (!empty($_POST["pass"]) || !empty($_POST["phone"]) || !empty($_POST["email"])) {
                    $host = "localhost";
                    $user = "root";
                    $password = "";
                    $dbname = "project2";
                    $con = mysqli_connect($host, $user, $password, $dbname) or die('<script language="javascript">alert("Connection Failed")</script>'. mysqli_connect_error($con));
                    $queryStarter = 'UPDATE users SET';
                    if (isset($_POST['pass']) && !empty($_POST['pass'])) {
                        $pWord = mysqli_real_escape_string($con, $_POST["pass"]);
                        $queryStarter .= " Password = '$pWord',";
                    }
                    if (isset($_POST['phone']) && !empty($_POST['phone'])) {
                        $pNumber = mysqli_real_escape_string($con, $_POST["phone"]);
                        $queryStarter .= " Phone_Number = '$pNumber',";
                    }
                    if (isset($_POST['email']) && !empty($_POST['email'])) {
                        $eMail = mysqli_real_escape_string($con, $_POST["email"]);
                        $queryStarter .= " Email = '$eMail',";
                    }
                    $lastIndex = strripos($queryStarter, ",");
                    $finalQuery = substr_replace($queryStarter, '', $lastIndex, $lastIndex); //Get rid of last comma
                    $finalQuery .= " WHERE RegID = '$name' OR (Email = '$name')";
                    $result = mysqli_query($con, $finalQuery) or die('<script language="javascript">alert("Could not edit user information")</script>');
                    if(mysqli_affected_rows($con)){
                        echo '<script language="javascript">alert("User updated")</script>';
                    }
                }
            }
            ?>
        </div>

        <div class="container">
            <h2> Groups!</h2>
            <form action="../py/viewgroups.py" method="get">
                <input type="hidden" name="getUname" value="<?php echo $name;?>"/>
                <button name="getGroup">Display Groups using Python</button>
            </form>
            <form method="POST">
                <button name="getPHPGroup">Display Groups using PHP</button>
            </form>
        </div>
        <?php
        if (isset($_POST['getGroup'])) {
            #echo '<script type="text/javascript">alert("'.$name.'")</script>';
        }
        if (isset($_POST['getPHPGroup'])) {
            echo '<script type="text/javascript">alert("' . $name . '")</script>';
            $host = "localhost";
            $user = "root";
            $password = "";
            $dbname = "project2";
            $con = mysqli_connect($host, $user, $password, $dbname) or die('<script language="javascript">alert("Connection Failed")</script>' . mysqli_connect_error($con));
            $query = "select First_name, Last_Name, EMAIL, PHONE_NUMBER from users 
                      where GROUP_ID IN (
                      SELECT GROUP_ID from users where REGID = '$name' OR EMAIL = '$name'
                      )";
            $result = mysqli_query($con, $query) or die("Query has failed." . mysqli_error($con));
            print("<div class='container'>");
            print("<h1>Your Group</h1>");
            print("<table border=1>");
            print("<tr>");
            print("<th>First Name</th>");
            print("<th>Last Name</th>");
            print("<th>Email</th>");
            print("<th>Phone Number</th>");
            print("</tr>");
            if (mysqli_num_rows($result)) {
                while ($row = mysqli_fetch_row($result)) {
                    echo "<tr>
                            <td>$row[0]</td>
                            <td>$row[1]</td>
                            <td>$row[2]</td>
                            <td>$row[3]</td>
                          </tr>";
                }
            }
            print("</table>");
            print("</div>");
        }
        ?>

    </body>
</html>