using MySql.Data.MySqlClient;  // Ensure MySql.Data is installed
using System;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string connectionString = "Server=localhost;Database=cyberly_database;Uid=root;Pwd=your_password;"; // Modify with your credentials


    // Method to insert a user into the existing table
    public void InsertUser(string fName, string mName, string lName, string userName, string email, string password, string dob, int score)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO user_info 
                                (f_name, m_name, l_name, user_name, dob, email, u_password, score)
                                VALUES (@f_name, @m_name, @l_name, @user_name, @dob, @email, @u_password, @score);";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Using parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@f_name", fName);
                cmd.Parameters.AddWithValue("@m_name", mName);
                cmd.Parameters.AddWithValue("@l_name", lName);
                cmd.Parameters.AddWithValue("@user_name", userName);
                cmd.Parameters.AddWithValue("@dob", dob);  // Format: yyyy-MM-dd
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@u_password", password);  // In practice, hash passwords before storing
                cmd.Parameters.AddWithValue("@score", score);

                cmd.ExecuteNonQuery();
                Debug.Log("User inserted successfully.");
            }
            catch (Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
    }
}
