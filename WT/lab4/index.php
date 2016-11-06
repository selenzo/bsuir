<?php


$fmain = file_get_contents('templates/main.tpl');
$fmainmenu = getContains();
$header = file_get_contents('templates/header.tpl');
$fmain = str_replace('{HEADER}', $header, $fmain);
$fmain = str_replace('{HEADER_TITLE}', "Основы разработки сайтов", $fmain);
$fmain = str_replace('{MAIN_MENU}', $fmainmenu, $fmain);


$text = file_get_contents('templates/text.tpl');
$fmain = str_replace('{text}', $text, $fmain);


$fmain = str_replace('{TODAY_D}', date("d"), $fmain);
$fmain = str_replace('{TODAY_M}', date("m"), $fmain);
$fmain = str_replace('{TODAY_M}', date("m"), $fmain);
$fmain = str_replace('{TODAY_Y}', date("y"), $fmain);
$fmain = str_replace('{NOW_H}', date("H"), $fmain);
$fmain = str_replace('{NOW_M}', date("i"), $fmain);
$fmain = str_replace('{NOW_S}', date("s"), $fmain);


$fnews = file_get_contents('templates/news.tpl');
$N = 3;
$str_all = get_db_news($N);


$fnews = str_replace('{news_str}', $str_all, $fnews);
$fmain = str_replace('{news}', $fnews, $fmain);


$mcfg = file('site.cfg');
$cfg0 = str_word_count($mcfg[0], 1);

$cfg1 = str_word_count($mcfg[1], 1);

$fmain = str_replace('{main_color}', $cfg0[2], $fmain);

$fmain = str_replace('{copyright_color}', $cfg1[2], $fmain);
echo($fmain);


function get_db_news($num)
{
    $fnews_str = file_get_contents('templates/news_str.tpl');

    $lnk = mysql_connect("localhost", "root", "") or die("Could not connect" . mysql_error());

    mysql_select_db("news") or die (mysql_error());
    mysql_select_db("news", $lnk);
    mysql_set_charset('utf8');
    $result = mysql_query("SELECT * FROM news ORDER BY datatime DESC");
    $str_all = "";
    $i = 0;
while ($row = mysql_fetch_array($result, MYSQL_NUM)) {
        if ($i == $num) {
            $i = 0;
            break;
        }
        $str1 = $fnews_str;
        $str1 = str_replace('{news_date}', $row[1], $str1);
        $str1 = str_replace('{news_text}', $row[2], $str1);
        $str_all .= $str1;
        $i++;
    }
    return $str_all;
}

function getItemMenu($id)
{
    $lnk = mysql_connect("localhost", "root", "") or die("Could not connect" . mysql_error());
    mysql_select_db("news") or die (mysql_error());
    mysql_select_db("news", $lnk);
mysql_set_charset('utf8');
$result = mysql_query("SELECT * FROM pages WHERE ID = $id");
    while ($row = mysql_fetch_array($result, MYSQL_NUM)) {
        return $row[2];
    }
}

function getContains()
{

    return '<ul id="my-menu">
<li><a href="#0">Главная</a></li>
<li><a #0="">'. getItemMenu(4).'</a>
<ul>
<li><a href="#0">'. getItemMenu(7).'</a></li>
<li><a href="#0">'. getItemMenu(8).'</a></li>
<li><a href="#0">'. getItemMenu(9).'</a></li>
</ul>
</li>
<li><a #0="">'. getItemMenu(5).'</a>
</li>
</li>
</ul>';
//
//return '<ul class="mainmenu" id="my-menu">'.
//    '<li class="menuOpen" >'. getItemMenu(1).''.
//     '<ul class="mainmenuin1">'.
//      '<li><a href="/catalog/tyres/">'.getItemMenu(4).''.
//       '<ul class="mainmenuin2">'.
//        '<li><a href="/track/">'.getItemMenu(7).'</a></li>'.
//        '<li><a href="/car/">'.getItemMenu(8).'</a>'.
//'<ul class="mainmenuin2">'.
//        '<li><a href="/car/">'.getItemMenu(10).'</a>'.
//'</ul></li>'.
//        '<li><a href="/farm/">'.getItemMenu(9).'</a></li>'.
//       '</ul>'.
//      '</li>'.
//      '<li><a href="/catalog/akb/">'.getItemMenu(5).'</li>'.
//      '<li><a href="/catalog/parts/">'.getItemMenu(6).'</li>'.
//     '</ul>'.
//    '</li>'.
//   '<li><a href="/news/">'.getItemMenu(2).'</a></li>'.
//   '<li><a href="/contacts/">'. getItemMenu(3).'</a></li>'.
//  '</ul>';
}

?>

