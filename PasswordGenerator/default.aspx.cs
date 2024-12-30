using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
namespace PasswordGenerator
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No changes needed for Page_Load
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txtPassword.Value;
                string salt = txtSalt.Value;

                // Check if the salt has at least 8 characters
                if (salt.Length < 8)
                {
                    txtResultHash.Value = "Error: Salt must have at least 8 characters.";
                    return;
                }

                byte[] saltValue = Encoding.UTF8.GetBytes(salt);
                string hashedPassword = HashPasswordWithPBKDF2(password, saltValue);

                ViewState["GeneratedHash"] = hashedPassword;
                txtResultHash.Value = hashedPassword;
            }
            catch (Exception ex)
            {
                txtResultHash.Value = "Error: " + ex.Message;
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txtPassword.Value;
                string salt = txtSalt.Value;
                byte[] saltValue = Encoding.UTF8.GetBytes(salt);

                // Generate a new hash based on user input
                string newHash = HashPasswordWithPBKDF2(password, saltValue);

                // Check if a hash has been previously generated
                if (ViewState["GeneratedHash"] == null)
                {
                    resultVal.InnerText = "Error: No hash generated to verify.";
                    resultVal.Attributes["class"] = "form-label text-white bg-warning p-2 rounded"; // Yellow background for error
                    return;
                }

                // Retrieve the previously generated hash
                string storedHash = (string)ViewState["GeneratedHash"];

                // Compare the new hash with the stored hash
                if (newHash == storedHash)
                {
                    resultVal.InnerText = "Hash matches!";
                    resultVal.Attributes["class"] = "form-label text-white bg-success p-2 rounded"; // Green background
                }
                else
                {
                    resultVal.InnerText = "Hash does not match.";
                    resultVal.Attributes["class"] = "form-label text-white bg-danger p-2 rounded"; // Red background
                }
            }
            catch (Exception ex)
            {
                resultVal.InnerText = "Error: " + ex.Message;
                resultVal.Attributes["class"] = "form-label text-white bg-danger p-2 rounded"; // Red background for errors
            }
        }

        private string HashPasswordWithPBKDF2(string password, byte[] salt)
        {
            try
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000)) 
                {
                    byte[] hash = pbkdf2.GetBytes(64);  
                    return Convert.ToBase64String(hash); 
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error generating hash: " + ex.Message);
            }
        }
    }
}
