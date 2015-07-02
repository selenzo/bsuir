<?php


    $fmain = file_get_contents('templates/main.tpl'); //считывем шаблоны
	$fmainmenu = file_get_contents('templates/main_menu.tpl'); 
  	$fmain = str_replace('{MAIN_MENU}',$fmainmenu,$fmain);//заменяем {MAIN_MENU} на содержимое шаблона main_menu.tpl
	
    
	$text = file_get_contents('templates/text.tpl');//считывем тест
	$fmain = str_replace('{text}',$text,$fmain);// производим замену плайсхолдера {text} на текст с шаблона 
	
    
    // замена плейсхолдеров 
	$fmain = str_replace('{TODAY_D}',date("d"),$fmain);
	$fmain = str_replace('{TODAY_M}',date("m"),$fmain);
	$fmain = str_replace('{TODAY_Y}',date("y"),$fmain);
	$fmain = str_replace('{NOW_H}',date("H"),$fmain);
	$fmain = str_replace('{NOW_M}',date("i"),$fmain);
	$fmain = str_replace('{NOW_S}',date("s"),$fmain);
	
    // считывание новостей
	$fnews = file_get_contents('templates/news.tpl');	
	
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
	
	//читаем конфиг
	$mcfg = file('site.cfg');
	$cfg0 = str_word_count($mcfg[0],1);

	$fmain = str_replace('{main_color}',$cfg0[2],$fmain);
	
	echo($fmain);
	
?>