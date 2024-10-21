<?php
// Include the database connection at the start of all the php files or it will give me stories that touch
require_once 'db_connect.php'; //require_once? not sure still giving me a warningg but tutorial used require alone

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $f_name = $_POST['f_name'];
    $l_name = $_POST['l_name'];
    $user_name = $_POST['user_name'];
    $email = filter_var ($_POST['email'], FILTER_SANITIZE_EMAIL);
    $password = $_POST['password'];
    $DOB = $_POST['DOB'];// sql injection using post method obvi


    if (empty($f_name) || empty($l_name) || empty($user_name) || empty($email) || empty($password) || empty($DOB)) {
        echo json_encode(array("status" => "error", "message" => "All fields are required."));
        exit;
    }

    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        echo json_encode(array("status" => "error", "message" => "Invalid email format."));
        exit;
    }

    if (!preg_match("/^\d{4}-\d{2}-\d{2}$/", $DOB)) {
        echo json_encode(array("status" => "error", "message" => "Invalid date format. Use YYYY-MM-DD."));
        exit;
    }

    // logic to check if username or email already exists
    $check_user = $conn->prepare("SELECT * FROM user_info WHERE email = ? OR user_name = ?");
    $check_user->bind_param("ss", $email, $user_name);
    $check_user->execute();
    $result = $check_user->get_result();

    if ($result->num_rows > 0) {
       
        echo json_encode(array("status" => "error", "message" => "User already exists. Try logging in"));
    } else {
        if(strlen($password)< 8){
            echo json_encode(array("staus" => "error", "message" => "Make Your password longer and more complex"));
            exit;
        }
        $hashed_password = password_hash($password, PASSWORD_DEFAULT);


        $stmt = $conn->prepare("INSERT INTO user_info (f_name,  l_name, user_name, email, password, DOB) VALUES (?, ?, ?, ?, ?, ?, ?)");
        $stmt->bind_param("ssssss" /*seven S's for the seven strings*/, $f_name, $l_name, $user_name, $email, $hashed_password, $DOB);

        if ($stmt->execute()) {
            echo json_encode(array("status" => "success", "message" => "User registered successfully."));
        } else {
            error_log("Registration error:" .$stmt->error);
            echo json_encode(array("status" => "error", "message" => "Error registering user."));
        }
    }
}
$conn->close();
