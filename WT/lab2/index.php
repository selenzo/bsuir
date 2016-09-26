<?php 

$A = 381064;
$B = "sting";
$C = 0.5;
$D = false;
$E = array ("abc", "def", "ghi");

$a = 555;
$b = "ZZZ";
echo ($a + $b);
echo "\n";
echo $a.$b;


$sotrudniki = array(
	'0' => array ('name' => 'Ivanov','phone' => '111-22-33','email' => 'ivanov@domain.com', 't-shirt' => array(
'color' => 'red') 
	),
	'1' => array('name' => 'Petrov','phone' => '112-24-36','email' => 'petrov@domain.com'),
	'2' => array('name' => 'Sidorov','phone' => '113-25-37','email' => 'sidorov@domain.com')
);
echo $sotrudniki[0];
 
foreach($sotrudniki as $Skey => $Svalue) {
	echo "\n".$Skey.") ";
foreach ($Svalue as $key => $value) 
	echo $value." ";
foreach ($value as $skey => $svalue) 
	echo $svalue." ";
}

$MyArray = array (1, 2, "A", 3.764, 34, "B", 12 );
echo "First array: ";
foreach($MyArray as $value ){
	echo "\n".$value;}
echo "\n";
	
$i = 0;
foreach($MyArray as $value ){
	if ((gettype($value) <> "integer") and (gettype($value) <> "double")) {
           unset($MyArray[$i]);
           }
	$i++;
	} 

echo "\n"."Second array: ";
foreach($MyArray as $value ){
	echo "\n".$value;}

$n=0;
$red = 0x00;
$green = 0x00;
$blue = 0x00;
echo '<table style="width: 500px; color: chocolate">';
for ($i = 1; $i <= 1000; $i++){
	$red++; 
        $green++; 
  	$blue++;
	if ($red == 256) {
            $red = 0;
            $green = 0;
            $blue = 0;
            }
	if ($red < 16) echo '<tr bgcolor = "#'."0".dechex($red)."0".dechex($green)."0".dechex($blue).'">';
	else echo '<tr bgcolor = "#'.dechex($red).dechex($green).dechex($blue).'">';
	for ($td = 1; $td <=3; $td++){
		echo '<td>';
		if ($td == 1){
			echo $n;
			$n++;
			}
		echo "</td>";
		}
	echo "</tr>";
	}
echo '</table>';

?>