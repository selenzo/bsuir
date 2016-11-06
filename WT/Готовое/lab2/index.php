<?php
error_reporting( E_ERROR );

echo "Операционная система ".php_uname("s")."<br><br>".PHP_OS;

echo "1.Объявить переменные следующих типов: целочисленную, строковую, дробную, логическую, массив. <br><br>";
$A = 381064;
$B = "sting";
$C = 0.5;
$D = false;
$E = array ("abc", "def", "ghi");
echo "целочисленная: A = ".$A."<br>";
echo "строка: B = ".$B."<br>";
echo "дробная: C = ".$C."<br>";
echo "логическая: D = ".$D."<br>";
echo "массив: E = <br>";
foreach($E as $key => $value ){
	echo "[".$key."] = ".$value."<br>";}
echo "<br>";

// .$E."<br><br>";

echo '2.	Объявить переменные $a=555 и $b="ZZZ" и сложить их: а) как числа, б) как строки. Результат сложения не помещать в новую переменную, а сразу выводить на экран.<br><br>';
$a = 555;
$b = "ZZZ";
echo "a + b = ".($a + $b)."<br>";
echo "a.b = ".$a.$b."<br><br>";
$a = (string)$a;
echo $a;
echo "3.Объявить двухмерный массив, первый уровень которого пронумерован, начиная с нуля, а второй уровень содержит элементы name, phone, email, в которых хранятся соответствующие данные вышеназванных сотрудников. <br>";

$sotrudniki = array(
	'0' => array ('name' => 'Ivanov','phone' => '111-22-33','email' => 'ivanov@domain.com', "3uroven" => array("3uroven" =>"test")),
	'1' => array('name' => 'Petrov','phone' => '112-24-36','email' => 'petrov@domain.com'),
	'2' => array('name' => 'Sidorov','phone' => '113-25-37','email' => 'sidorov@domain.com')
);

foreach($sotrudniki as $Skey => $Svalue) {
	echo "<br>[".$Skey."]=><br> ";
	foreach ($Svalue as $key2 => $value) {
		echo "[".$key2."] = ".$value."<br> ";

		foreach ($value as $key3 => $s2value)
		echo "[".$key3."] = ".$s2value."<br> ";
}


}
echo "<br>";

echo '4.	Дан массив, содержащий элементы: 1, 2, "A", 3.764, 34, "B", 12. Объявить этот массив, проанализировать его содержимое и удалить из него все элементы, не являющиеся целыми или дробными числами. <br>';

$MyArray = array (1, 2, "A", 3.764, 34, "B", 12 );

echo "<br>Массив: <br>";
foreach($MyArray as $key => $value ){
	echo "[".$key."] = ".$value."<br>";}
echo "<br>";

$i = 0;
foreach($MyArray as $value ){
	if ((gettype($value) <> "integer") and (gettype($value) <> "double")) {
           unset($MyArray[$i]);
           }
	$i++;
	}

echo "После удаления: <br>";
foreach($MyArray as $key => $value ){
	echo "[".$key."] = ".$value."<br>";}

echo "<br><br>";

echo '5.	Сгенерировать HTML-таблицу, состоящую из трёх колонок и 1000 строк. В первой колонке разместить номера строк таблицы. <br>';


echo "<br>";
$n=0;
$red = 0x00;
$green = 0x00;
$blue = 0x00;
echo '<table style="width: 300px; color: chocolate">';
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

phpinfo();

?>
