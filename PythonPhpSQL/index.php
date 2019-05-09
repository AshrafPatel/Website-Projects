<?php
session_start();
if (isset($_SESSION['user'])) {
    if ($_SESSION['user'] == 'admin') {
        header('location:php/admin.php');
    }
    else  {
        header("location:php/student.php");
    }
}
?>
<!DOCTYPE html>
<html lang="en">
    <head>
        <!--  Meta  -->
        <meta charset="UTF-8" />
        <title>CPAN204 - Ashraf & Harpreet</title>

        <!--Scripts to load-->
        <link href="https://fonts.googleapis.com/css?family=Orbitron" rel="stylesheet">
        <link rel="stylesheet" href="css/loginregister.css">
    </head>
    <body>
        <div class="container">
            <form method="post">
                <h2>Register</h2>
                <div class="row">
                    <label for="firstname">First Name</label>
                </div>
                <div class="row2">
                    <input type="text" id="firstname" placeholder="First Name" name="fName"/>
                </div>
                <div class="row">
                    <label for="lastname">Last Name</label>
                </div>
                <div class="row2">
                    <input type="text" id="lastname" placeholder="Last Name" name="lName"/>
                </div>
                <div class="row">
                    <label for="email">Email</label>
                </div>
                <div class="row2">
                    <input type="text" id="email" placeholder="Email" name="eMail"/>
                </div>
                <div class="row">
                    <label for="phone">Phone Number</label>
                </div>
                <div class="row2">
                    <input type="text" id="phone" placeholder="Phone Number" name="number"/>
                </div>
                <div class="row">
                    <label for="password">Password</label>
                </div>
                <div class="row2">
                    <input type="text" id="password" placeholder="Password" name="pWord"/>
                </div>
                <button type="submit" name="register">Submit</button>
            </form>
        </div>
        <?php
        $host = "localhost";
        $user = "root";
        $password = "";
        $dbname = "project2";
        $con = mysqli_connect($host, $user, $password, $dbname) or die("Connection has failed.". mysqli_connect_error($con));

        if(isset($_POST["fName"]) && isset($_POST["lName"]) && isset($_POST["eMail"]) && isset($_POST["number"]) && isset($_POST["pWord"])) {
            if (!empty($_POST["fName"]) && !empty($_POST["lName"]) && !empty($_POST["eMail"]) && !empty($_POST["number"]) && !empty($_POST["pWord"])) {
                $eMail = mysqli_real_escape_string($con, $_POST["eMail"]);
                $query = "select * from users where Email = '$eMail'";
                $result = mysqli_query($con, $query) or die("Query has failed." . my_sqli_error($con));
                if ($result->num_rows < 1) {
                    $fName = mysqli_real_escape_string($con, $_POST["fName"]);
                    $lName = mysqli_real_escape_string($con, $_POST["lName"]);
                    $pNumber = mysqli_real_escape_string($con, $_POST["number"]);
                    $pWord = mysqli_real_escape_string($con, $_POST["pWord"]);
                    $temp = explode("@", $eMail);
                    $uniqid = $temp[0] . uniqid();
                    echo '<script>console.log('.$uniqid.')</script>';

                    //  Creating Account
                    $query = "insert into users values('$fName','$lName','$eMail','$pNumber','$pWord', '$uniqid')";
                    $result = mysqli_query($con, $query) or die("Query has failed." . my_sqli_error($con));

                    if (mysqli_affected_rows($con)) {
                        echo "User Created.";
                        $_SESSION["user"] = $eMail;
                        header("location:php/student.php");
                    } else if (empty($eMail)) {
                        echo '<script language="javascript">';
                        echo 'alert("Please enter an eMail address")';
                        echo '</script>';
                    }
                } else {
                    echo '<script language="javascript">';
                    echo 'alert("User already created please login")';
                    echo '</script>';
                }
            }
        }
        mysqli_close($con);
        ?>
        <div class="container">
            <form method="post">
                <h2>Login</h2>
                <div class="row">
                    <label for="username">Username</label>
                </div>
                <div class="row2">
                    <input type="text" id="username" placeholder="Username" name="uName"/>
                </div>
                <div class="row">
                    <label for="password2">Password</label>
                </div>
                <div class="row2">
                    <input type="text" id="password2" placeholder="Password" name="pWord2"/>
                </div>
                <button type="submit" name="login">Login</button>
            </form>
            <?php
            $host = "localhost";
            $user = "root";
            $password = "";
            $dbname = "project2";

            //  Connecting to Database
            $con = mysqli_connect($host, $user, $password, $dbname) or die("Connection has failed.". mysqli_connect_error($con));

            //  Checking if form has been filled
            if(isset($_POST["uName"]) && isset($_POST["pWord2"])) {
                if (!empty($_POST["uName"]) && !empty($_POST["pWord2"])) {
                    $use = mysqli_real_escape_string($con, $_POST["uName"]);
                    $pas = mysqli_real_escape_string($con, $_POST["pWord2"]);
                    $query = "select * from users where Email = '$use' and Password = '$pas'";
                    $query2 = "select * from users where REGID = '$use' and Password = '$pas'";
                    $result = mysqli_query($con, $query) or die("Query has failed." . my_sqli_error($con));
                    $result2 = mysqli_query($con, $query2) or die("Query has failed." . my_sqli_error($con));
                    //  Check User Login
                    if ($use == 'admin@admin.com' || $use == 'admin123') {
                        if (mysqli_num_rows($result) || mysqli_num_rows($result2)) {
                            $_SESSION["user"] = 'admin';
                            header("location:php/admin.php");
                        }
                        else {
                            echo '<script language="javascript">';
                            echo 'alert("Incorrect username or password")';
                            echo '</script>';
                        }
                    } else {
                        if (mysqli_num_rows($result) || mysqli_num_rows($result2)) {
                            $_SESSION["user"] = $use;
                            header("location:php/student.php");
                        } else {
                            echo '<script language="javascript">';
                            echo 'alert("Incorrect username or password")';
                            echo '</script>';
                        }
                    }
                } else if(empty($use)){
                    echo '<script language="javascript">';
                    echo 'alert("Please enter username or password")';
                    echo '</script>';
                }
                else if(empty($pas)){
                    echo '<script language="javascript">';
                    echo 'alert("Please enter username or password")';
                    echo '</script>';
                }
            }

            //  Closing Connection
            mysqli_close($con);
            ?>
        </div>

    </body>
</html>