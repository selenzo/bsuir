<?php

ini_set('default_charset','utf-8');
mysql_set_charset('utf8');
header("Content-Type: application/rss+xml; charset=utf-8");
$html = '<?xml version="1.0" encoding="windows-1251" ?>
 <rss version="2.0">
  <channel>
  <title>Название ленты новостей</title>
  <link>http://www.somesite.com/rss/</link>
  <description>Описание ленты новостей</description>
  <lastBuildDate>Sun, 18 Jan 2009 16:49:01 +0200</lastBuildDate>
';

$lnk = mysql_connect("localhost", "root", "mysql") or die("Could not connect" . mysql_error());
mysql_select_db("news") or die (mysql_error());
mysql_select_db("news", $lnk);
mysql_set_charset('utf8');
$result = mysql_query("SELECT * FROM rss");
while ($row = mysql_fetch_array($result, MYSQL_NUM)) {
    $html .= ' <item>
  <title>'.$row[0].'</title>
  <link>'.$row[1].'</link>
  <description>'.$row[2].'</description>
  <comments>http:'.$row[3].'</comments>
  <pubDate>'.$row[4].'</pubDate>
  <guid>'.$row[5].'</guid>
  </item>';
}
$html .= '</channel>
  </rss>
';
echo $html;

?>
