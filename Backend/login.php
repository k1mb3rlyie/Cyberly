<?php

require_once 'db_connect.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $login_identifier = $_POST['login_identifier']; // using cause i want user to be able to use either email or username
    $password = $_POST['password'];     // Retrieve email and password from POST request the proper method

    // Query the user by email or username
    $stmt = $conn->prepare("SELECT * FROM user_info WHERE email = ? OR user_name = ?");
    $stmt->bind_param("ss", $login_identifier, $login_identifier);
    $stmt->execute();
    $result = $stmt->get_result();


    if ($result->num_rows === 1) {

        $user = $result->fetch_assoc();
        

        if (password_verify($password, $user['password'])) {
            // Success: Return user data (without password!!)
            unset($user['password']);  // Don't include the password in the response!! lol, it has to work well
            echo json_encode(array("status" => "success", "user" => $user));
        } else {
            echo json_encode(array("status" => "error", "message" => "Incorrect password."));
        }
    } else {
        echo json_encode(array("status" => "error", "message" => "User not found.")); //
    }

}
$conn->close();