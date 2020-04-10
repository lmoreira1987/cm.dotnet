<?php
//var_dump($_REQUEST);
if(isset($_REQUEST['echostr'])){
    saveFile('test-echostr-request-'.date('Y-m-d H:i:s').'.txt',json_encode($_REQUEST));
    echo $_REQUEST['echostr'];
    die();
}

$result = file_get_contents('php://input');

$xml = simplexml_load_string($result);

saveFile('test-request-'.date('Y-m-d H:i:s').'.txt',json_encode($_REQUEST));
saveFile('test-result-'.date('Y-m-d H:i:s').'.txt',$result);
die('buh');

function saveFile($name,$value) {
    $fp = fopen($name, 'w');
    fwrite($fp, $value);
    fclose($fp);
}