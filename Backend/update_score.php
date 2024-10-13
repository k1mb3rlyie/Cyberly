<?php
//php logic to save the users score, i will probably add one that takes the frequency of a score and stores it
require 'db_connect.php';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // retrieve input values SQL
    $user_id = $_POST['user_id'];
    $high_score = $_POST['high_score'];
    $XP_calculation = $_POST['XP_calculation'];
    $check_in = date('Y-m-d'); // current date to be counted everyday the user log unto the app a Doulingo-esque approach


    $stmt = $conn->prepare("UPDATE user_score SET high_score = ?, XP_calculation = ?, check_in = ? WHERE user_id = ?");
    $stmt->bind_param("iisi", $high_score, $XP_calculation, $check_in, $user_id);

    if ($stmt->execute()) {
        echo json_encode(array("status" => "success", "message" => "User score updated."));
    } else {
        echo json_encode(array("status" => "error", "message" => "Error updating user score."));
    }
}
$conn->close();