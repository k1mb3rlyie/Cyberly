<?php
// Include the database connection at the start of all the php files or it will give me stories that touch
require 'db_connect.php'; //require_once? not sure still giving me a warningg but tutorial used require alone

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $f_name = $_POST['f_name'];
    $m_name = $_POST['m_name'];
    $l_name = $_POST['l_name'];
    $user_name = $_POST['user_name'];
    $email = $_POST['email'];
    $password = $_POST['password'];
    $DOB = $_POST['DOB'];// sql injection using post methid obvi

    // logic to check if username or email already exists
    $check_user = $conn->prepare("SELECT * FROM user_info WHERE email = ? OR user_name = ?");
    $check_user->bind_param("ss", $email, $user_name);
    $check_user->execute();
    $result = $check_user->get_result();

    if ($result->num_rows > 0) {
       
        echo json_encode(array("status" => "error", "message" => "User already exists."));//if email exiists 
    } else {
      
        $hashed_password = password_hash($password, PASSWORD_DEFAULT);


        $stmt = $conn->prepare("INSERT INTO user_info (f_name, m_name, l_name, user_name, email, password, DOB) VALUES (?, ?, ?, ?, ?, ?, ?)");
        $stmt->bind_param("sssssss" /*seven S's for the seven strings*/, $f_name, $m_name, $l_name, $user_name, $email, $hashed_password, $DOB);

        if ($stmt->execute()) {
            echo json_encode(array("status" => "success", "message" => "User registered successfully."));
        } else {
            echo json_encode(array("status" => "error", "message" => "Error registering user."));
        }
    }
}
$conn->close();
