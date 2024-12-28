<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PasswordGenerator._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="Mark Otto, Jacob Thornton, and Bootstrap contributors" />
    <meta name="generator" content="Hugo 0.84.0" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <title>TechRacine Password Hasher</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .bd-placeholder-img { font-size: 1.125rem; text-anchor: middle; -webkit-user-select: none; -moz-user-select: none; user-select: none; }
        @media (min-width: 768px) { .bd-placeholder-img-lg { font-size: 3.5rem; } }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-8 mx-auto p-3 py-md-5">
            <header class="d-flex align-items-center pb-3 mb-5 border-bottom">
                <a href="/" class="d-flex align-items-center text-dark text-decoration-none">
                    <img src="images/logo.png" width="40" height="32" class="me-2" />
                    <span class="fs-4">Password Hasher</span>
                </a>
            </header>

            <main>
                <p class="fs-5 col-md-12">This page allows you to securely hash your password using advanced encryption algorithms...</p>
                
                <div class="col-6 mb-3">
                    <label for="txtPassword" class="form-label">Password </label>
                    <input type="password" runat="server" class="form-control" id="txtPassword" />
                </div>

                <div class="col-6 mb-3">
                    <label for="txtSalt" class="form-label">Salt </label>
                    <input type="text" runat="server" class="form-control" id="txtSalt" />
                </div>

                <div class="col-5">
                    <asp:Button CssClass="w-100 btn btn-primary btn-lg" ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Generate Hash" />
                </div>

                <div class="col-12">
                    <label for="resultHash" class="form-label">Hashed Password </label>
                    <input type="text" runat="server" class="form-control" id="txtResultHash" />
                    <span title="Copy hashed password" onclick="return copyValue()" style="cursor:pointer;">
                        <svg aria-hidden="true" focusable="false" class="octicon octicon-copy" viewBox="0 0 16 16" width="16" height="16" fill="currentColor" style="display: inline-block; user-select: none; vertical-align: text-bottom; overflow: visible;">
                            <path d="M0 6.75C0 5.784.784 5 1.75 5h1.5a.75.75 0 0 1 0 1.5h-1.5a.25.25 0 0 0-.25.25v7.5c0 .138.112.25.25.25h7.5a.25.25 0 0 0 .25-.25v-1.5a.75.75 0 0 1 1.5 0v1.5A1.75 1.75 0 0 1 9.25 16h-7.5A1.75 1.75 0 0 1 0 14.25Z"></path>
                            <path d="M5 1.75C5 .784 5.784 0 6.75 0h7.5C15.216 0 16 .784 16 1.75v7.5A1.75 1.75 0 0 1 14.25 11h-7.5A1.75 1.75 0 0 1 5 9.25Zm1.75-.25a.25.25 0 0 0-.25.25v7.5c0 .138.112.25.25.25h7.5a.25.25 0 0 0 .25-.25v-7.5a.25.25 0 0 0-.25-.25Z"></path>
                        </svg> Copy
                    </span>
                </div>

                <p class="fs-5 col-md-12">Verify the generated hash is correct. Hashing the password again and compare against the above generated hash value.</p>
                
                <div class="col-12">
                    <div class="col-5">
                        <asp:Button CssClass="w-100 btn btn-primary btn-lg" runat="server" ID="btnVerify" Text="Verify Hash" OnClick="btnVerify_Click" />                    
                     <div class="col-6 p-3">
                        <label for="res" class="form-label">Verify</label>
                        <input type="text" runat="server" class="form-control" id="res" />
                     </div>
                </div>
                </div>
            </main>

            <footer class="pt-5 my-5 text-muted border-top">
                Created by the TechRacine team &middot; &copy; 2024
            </footer>
        </div>
    </form>
    <script>
        function copyValue() {
            var hashText = document.getElementById('<%= txtResultHash.ClientID %>'); 
            hashText.select(); 
            document.execCommand('copy');
            alert('Hashed password copied to clipboard!'); 
        }
    </script>
</body>
</html>
