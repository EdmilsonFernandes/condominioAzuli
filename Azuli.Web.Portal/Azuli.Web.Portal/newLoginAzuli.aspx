<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newLoginAzuli.aspx.cs" Inherits="Azuli.Web.Portal.newLoginAzuli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" class="form-signin" runat="server">
     <div class="wrapper">
      <h2 class="form-signin-heading">Entre com seu bloco e apartamento</h2>

      <input type="text" class="form-control" name="username" placeholder="Email Address" required="" autofocus="" />
      <input type="password" class="form-control" name="password" placeholder="Password" required=""/>      
      <label class="checkbox">
      </label>
      <button class="btn btn-lg btn-primary btn-block" type="submit">Login</button>   
  </div>
    </form>
</body>
</html>
