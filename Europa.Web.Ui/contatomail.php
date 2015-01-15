<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv=refresh content=4;URL=http://www.autopecaseuropa.com.br/contato.html /><link rel="shortcut icon" type="image/x-icon" href="img/icone.ico">
<title>Autopeças Europa</title>
<link href="css/estrutura.css" rel="stylesheet" type="text/css" />
<link href="css/classe.css" rel="stylesheet" type="text/css" />


</head>

<body>








<?php

 ini_set('default_charset','UTF-8');
 

?>

<div id="php">

<div id="phptexto">

<?php 


if (eregi('tempsite.ws$|locaweb.com.br$|hospedagemdesites.ws$|websiteseguro.com$', $_SERVER[HTTP_HOST])) {
        $emailsender='contato@autopecaseuropa.com.br';
} else {
        $emailsender = "webmaster@" . $_SERVER[HTTP_HOST];
}
if(PATH_SEPARATOR == ";") $quebra_linha = "\r\n";
else $quebra_linha = "\n";



$nome = $_POST['nome'];
$ddd = $_POST['ddd'];
$telefone = $_POST['telefone'];
$email = $_POST['email'];
$mensagem = $_POST['mensagem'];
$formcontent = "Formulário de Contato";
$recipient = "contato@autopecaseuropa.com.br";
$subject = "$mensagem";


$mensagemHTML = '<p><b><i>'.$subject.'</i></b></p>
<P></P>
<P>'.$nome.' </P>
<P>('.$ddd.')'.$telefone.' </P>

<hr>';


$headers = "MIME-Version: 1.1" .$quebra_linha;
$headers .= "Content-type: text/html; charset=utf-8" .$quebra_linha;

$headers .= "From: " . $email.$quebra_linha;


if(!mail($recipient, $formcontent, $mensagemHTML, $headers ,"-r".$emailsender)){ 
    $headers .= "Return-Path: " . $emailsender . $quebra_linha; 
    mail($recipient, $formcontent, $mensagemHTML, $headers );
}
print "<font face='Times New Roman, Times, serif' color='#999999' size='+3'>Mensagem enviada com sucesso!<br><br></font>"
?>

</div>
</div>



</body>
</html>
