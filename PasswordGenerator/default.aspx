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
    <link rel="canonical" href="https://getbootstrap.com/docs/5.0/examples/starter-template/" />
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
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
    <p class="fs-5 col-md-12">This page allows you to securely hash your password using advanced encryption algorithms. Simply enter your password, and the tool will generate a hashed version, ensuring your sensitive data remains protected. Ideal for securely storing passwords without exposing the original text.</p>
    <div class="col-12 mb-3">
        <label for="txtPassword" class="form-label">Password </label>
        <input type="password" runat="server" class="form-control" id="txtPassword" />
    </div>
    
    <div class="col-3">
    <asp:Button CssClass="w-100 btn btn-primary btn-lg" runat="server" OnClick="btnGenerate_Click" Text="Generate Hash" ></asp:Button>
    </div>

    <div class="col-12">
    <label for="resultHash" class="form-label">Hashed Password </label>
    <input type="text" runat="server" class="form-control" id="txtResultHash" />
    </div>
  </main>
  <footer class="pt-5 my-5 text-muted border-top">
    Created by the TechRacine team &middot; &copy; 2024
  </footer>
</div>
    </form>
    <script src="js/bootstrap.bundle.min.js"></script>
</body>
</html>
