using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
// Implemented By Sneka
public partial class _Default : System.Web.UI.Page
{
    string connectionString = "Server=localhost;Database=LoginDB;Uid=root;Pwd=sneka0122;";

    // This function handles login functionality
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string hashedPassword = HashPassword(password);

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            // Query to check if username and password hash match
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                lblMessage.Text = "Login successful!";
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }

    // This function handles sign-up functionality
    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string hashedPassword = HashPassword(password);

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            // Query to insert the new user
            string query = "INSERT INTO Users (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

            try
            {
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Sign Up successful!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }

    // This function hashes the password using SHA256
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
