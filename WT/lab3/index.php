<?php
	$fmain = file_get_contents('templates/main.tpl');
	
	$fmainmenu = file_get_contents('templates/main_menu.tpl'); 
  	$fmain = str_replace('{MAIN_MENU}',$fmainmenu,$fmain);
    
	$text = file_get_contents('templates/text.tpl');
	$fmain = str_replace('{text}',$text,$fmain);
    
    
	$fmain = str_replace('{TODAY_D}',date("d"),$fmain);
	$fmain = str_replace('{TODAY_M}',date("m"),$fmain);
	$fmain = str_replace('{TODAY_Y}',date("y"),$fmain);
	$fmain = str_replace('{NOW_H}',date("H"),$fmain);
	$fmain = str_replace('{NOW_M}',date("i"),$fmain);
	$fmain = str_replace('{NOW_S}',date("s"),$fmain);

	$fnews = file_get_contents('templates/news.tpl');

    $flogo = file_get_contents('templates/logo.tpl');
  	$fmain = str_replace('{LOGO}',$flogo,$fmain);

$fnews_str = file_get_contents('templates/news_str.tpl');
	$array_news = file('news.inf');	
	
	$str_all = "";	
	for($i = 0; $i < count($array_news); $i++)
	{
		if ($i%2 == 0) 
		{
			$str1 = $fnews_str;
			$str1 = str_replace('{news_date}',$array_news[$i],$str1);
		}
		else 
		{
			$str1 = str_replace('{news_text}',$array_news[$i],$str1);
			$str_all .=$str1;
		}		
	}	
	$fnews = str_replace('{news_str}',$str_all,$fnews);	
	$fmain = str_replace('{news}',$fnews,$fmain);
	
	
$mcfg = file('site.cfg');
$cfg0 = str_word_count($mcfg[0], 1);

$cfg1 = str_word_count($mcfg[1], 1);

$fmain = str_replace('{main_color}', $cfg0[2], $fmain);

$fmain = str_replace('{copyright_color}', $cfg1[2], $fmain);
	
	echo($fmain);
	
?>
