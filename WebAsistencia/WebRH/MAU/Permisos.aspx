<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="MAU_Permisos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH - Permisos de usuario</title>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta name="keywords" content="jquery,ui,easy,easyui,web">
	<meta name="description" content="easyui help you build your web page easily!">
	<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/default/easyui.css">
	<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/themes/icon.css">
	<link rel="stylesheet" type="text/css" href="http://www.jeasyui.com/easyui/demo/demo.css">
	<script type="text/javascript" src="http://code.jquery.com/jquery-1.6.1.min.js"></script><style type="text/css"></style>
	<script type="text/javascript" src="http://www.jeasyui.com/easyui/jquery.easyui.min.js"></script>

  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul id="tt"></ul>
    </div>
    </form>
</body>  
<script type="text/javascript">
    $(document).ready(function () {
        $('#tt').tree({
            data: [{
                text: 'Item1',
                state: 'closed',
                children: [{
                    text: 'Item11'
                }, {
                    text: 'Item12'
                }]
            }, {
                text: 'Item2'
            }]
        });
    });
     </script>
</html>
