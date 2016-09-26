<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <title>Основы работы с регулярными выражениями</title>
    <link href="../../css/reset.css" rel="stylesheet"/>
    <link href="../../css/style.css" rel="stylesheet"/>
    <style>
        .text_red_bold{
            color: Blue;
            font-weight: bold;
        }
    </style>

</head>
<body>
<div id="header">
    <div style="float:left">
        <a href="../../index.php">web-технологии</a>
    </div>
    <div style="float:left;color:white">
        <h1>Основы PHP</h1>
    </div>
</div>
<div id="content">
    <div class="job">
        <div class="jobTitle">
            <p>Регулярное выражение, проверяющее, является ли строка корректным e-mail адресом.</p>
        </div>
        <div class="jobContent">
            <?php
            $array = array("vasya-pupkin@mail.com", "vasya_pupkin@mail.com", "vasya.pupkin@mail.com", "v.v.pupkin@firma.mail.com",
                "v.v.pupkin@firma-mail.com", "v.v.pupkin12@firma_mail.com", "v.v.pupkin-director@firma.mail.com",
                "-vasya--pupkin@mail.com", "vasya_pupkin@mail..com", "vasya.-pupkin@mail.com", "v.v.pup kin@firma.mail.com", "v.v.pup#kin@firma-mail.com_");
            for ($i = 0; $i < count($array); $i++) {
                if (filter_var($array[$i], FILTER_VALIDATE_EMAIL)) {
                    echo $array[$i];
                    echo '<br />';
                }
            }
            ?>
        </div>
    </div>
    <div class="job">
        <div class="jobTitle">
            <p>Регулярное выражение, удаляющее из текста HTML-комментарии</p>
        </div>
        <div class="jobContent">
            <?php
            $html = '';
            echo preg_replace('|<!--(?!<!)[^\[>].*?-->|im', "", $html);
            ?>
        </div>
    </div>
    <div class="job">
        <div class="jobTitle">
            <p>Регулярное выражение, очищающее текст от HTML-тегов.</p>
        </div>
        <div class="jobContent">
            <?php
            $html = '<h1>Текст для проверки</h1>';
            echo preg_replace('/<[^>]*>/', "", $html);
            ?>
        </div>
    </div>


    <div class="job">
        <div class="jobTitle">
            <p>Регулярное выражение, выделяющее красным жирным шрифтом все слова с длиной в 5...</p>
        </div>
        <div class="jobContent">
            <?php
                $regExp = "/(^[a-z]{3,4}$)/";
                $str = "HELLO i fg AD like ice CREAM dfg asd DFG dfD and french FRIES and cola.";
                $output = "";
                $parts = explode(' ', $str);
                foreach($parts as $part) {
                    if (preg_match_all($regExp, $part, $array)) {
                        $output = $output . "<span style=\"color: blue; font-weight: bold;\">" . $part . "</span>" . ' ';
                    } else {
                        $output = $output . $part . ' ';
                    }
                }

                //$text = 'HELLO i fg AD like ice CREAM dfg asd DFG dfD and french FRIES and cola.';
                //$text = preg_replace('|(\W[a-z]{2,3}\W)|m', '<span class="text_red_bold">${1}</span>', $text);
            //$text = preg_replace('|([A-Z]{5})|m', '<span class="text_red_bold">${1}</span>', $text);

            echo $output;
            ?>
        </div>
    </div>

    <div class="job">
        <div class="jobTitle">
            <p>Cкрипт, представляющий HTML-документ в виде дерева элементов (дерево хранить в массиве).</p>
        </div>
        <div class="jobContent">
            <?php
            $html = '';
            $elements = array('<h1>Заголовок h1</h1>', '<h2>Заголовок h2</h2>', '<h3>Заголовок h3</h3>', '<p>абзац p</p>', '<a href="#" onClick="alert(\'ссылка\'); return false")">ссылка</a>');
            for ($i = 0; $i < count($elements); $i++) {
                $html .= $elements[$i].'<br />';
            }
            echo $html;
            ?>
        </div>
    </div>

</div>

</body>
</html>
