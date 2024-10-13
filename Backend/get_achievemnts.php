<?php
//i'm not sure i spelt achievemnts the right way achievemnts i dont think i know how to

require 'db_connect.php';

if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    // Retrieve user_id
    $user_id = $_GET['user_id'];

    // Fetch achievements based on user_id
    $stmt = $conn->prepare("SELECT * FROM achievements WHERE user_id = ?");
    $stmt->bind_param("i", $user_id);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        // Return achievements
        $achievements = $result->fetch_assoc();
        echo json_encode(array("status" => "success", "achievements" => $achievements));
    } else {
        echo json_encode(array("status" => "error", "message" => "No achievements found."));
    }
}
$conn->close();