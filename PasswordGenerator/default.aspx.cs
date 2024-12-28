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

                string newHash = HashPasswordWithPBKDF2(password, saltValue);
                if (ViewState["GeneratedHash"] == null)
                {
                    res.Value = "Error: No hash generated to verify.";
                    return;
                }

                string storedHash = (string)ViewState["GeneratedHash"];
                if (newHash == storedHash)
                {
                    res.Value = "Hash matches!";
                }
                else
                {
                    res.Value = "Hash does not match.";
                }
            }
            catch (Exception ex)
            {
                res.Value = "Error: " + ex.Message;
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