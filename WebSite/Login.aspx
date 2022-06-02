<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSite.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .login{  

        width: 382px;  
        overflow: hidden;  
        margin: auto;  
        padding: 80px; 
        background: #b2c5d9;  
        border-radius: 15px ;  
          
        } 
        html, body, h1, h2, h3, h4, h5 {
            font-family: "Raleway", sans-serif
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
    
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body class="w3-light-grey">
    <!-- Top container -->
    <div class="w3-bar w3-top w3-black w3-large" style="z-index: 4">
        <button class="w3-bar-item w3-button w3-hide-large w3-hover-none w3-hover-text-light-grey" onclick="w3_open();"><i class="fa fa-bars"></i>Menu</button>
        <span class="w3-bar-item w3-right"><img src="Images/Logo.png" class="w3-circle w3-margin-right" style="width: 46px"></span>
    </div>
    <br />
    <br />
    <br />
    <br />
    <center>
        <div class="login">
            <h1>Login</h1>
            <form id="form" runat="server">
                <asp:textbox id="textBoxEmail" runat="server" placeholder="email"></asp:textbox>
                <br />
                <asp:textbox id="textBoxPass" runat="server" type="password" placeholder="password"></asp:textbox>
                <br />
                <asp:button runat="server" CssClass="btn btn-primary" text="Login" OnClick="User_Login" />
                <br />
                <asp:label id="ErrorMsg" runat="server" text=""></asp:label>
            </form>
        </div>
    </center>

</body>
</html>
