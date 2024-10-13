<?php

require 'db_connect.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $email = $_POST['email'];
    $password = $_POST['password'];     // Retrieve email and password from POST request the proper method

    // Query the user by email
    $stmt = $conn->prepare("SELECT * FROM user_info WHERE email = ?");
    $stmt->bind_param("s", $email);
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