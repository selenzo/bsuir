-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Окт 29 2013 г., 23:50
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `news`
--

-- --------------------------------------------------------

--
-- Структура таблицы `news`
--

CREATE TABLE IF NOT EXISTS `news` (
  `id` int(11) NOT NULL,
  `datatime` datetime NOT NULL,
  `title_news` text NOT NULL,
  `news_text` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;

--
-- Дамп данных таблицы `news`
--

INSERT INTO `news` (`id`, `datatime`, `title_news`, `news_text`) VALUES
(1, '2013-10-22 04:16:22', 'Новая статья 1', 'текст новой статьи'),
(2, '2013-10-10 00:00:00', 'Новая статья 2', 'Описание новой статьи 2'),
(3, '2013-10-18 02:05:08', 'Новая новость 3', 'Описание новой новости 3'),
(4, '2013-10-17 16:38:28', 'Новая статья 4', 'Описание новой статьи 4');

-- --------------------------------------------------------

--
-- Структура таблицы `pages`
--

CREATE TABLE IF NOT EXISTS `pages` (
  `ID` int(11) NOT NULL,
  `INFO_TEXT` text NOT NULL,
  `MENU_TEXT` text NOT NULL,
  `PAGETEXT` text
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;

--
-- Дамп данных таблицы `pages`
--

INSERT INTO `pages` (`ID`, `INFO_TEXT`, `MENU_TEXT`, `PAGETEXT`) VALUES
(1, 'Автомобили', 'Автомобили', 'Автомобили'),
(2, 'Телефоны', 'Телефоны', 'Телефоны'),
(3, 'Наушники', 'Наушники', 'Наушники'),
(4, 'Зарядки', 'Зарядки', 'Зарядки'),
(5, 'BMW', 'BMW', 'BMW'),
(6, 'AUDI', 'AUDI', 'AUDI'),
(7, 'HTC', 'HTC', 'HTC'),
(8, 'Samsung', 'Samsung', 'Samsung'),
(9, 'Короткая', 'Короткая', 'Короткая'),
(10, 'Длинная', 'Длинная', 'Длинная');

-- --------------------------------------------------------

--
-- Структура таблицы `rss`
--

CREATE TABLE IF NOT EXISTS `rss` (
  `Title` text NOT NULL,
  `Link` text NOT NULL,
  `Description` text NOT NULL,
  `comments` text NOT NULL,
  `pubDate` date NOT NULL,
  `guid` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=cp1251;

--
-- Дамп данных таблицы `rss`
--

INSERT INTO `rss` (`Title`, `Link`, `Description`, `comments`, `pubDate`, `guid`) VALUES
('Заглавие новости 1', 'http://www.somesite.com/news/newsid4792/', 'Краткое содержание новости 1', 'http://www.somesite.com/news/newsid4792/', '2013-10-11', 'http://www.somesite.com/news/newsid4792/'),
('Заглавие новости 2', 'http://www.somesite.com/news/newsid4792/', 'Краткое содержание новости 2', 'http://www.somesite.com/news/newsid4792/', '2013-10-19', 'http://www.somesite.com/news/newsid4792/'),
('Заглавие новости  3', 'http://www.somesite.com/news/newsid4792/', 'Краткое содержание новости', 'http://www.somesite.com/news/newsid4792/', '2013-10-16', 'http://www.somesite.com/news/newsid4792/'),
('Заглавие новости  4', 'http://www.somesite.com/news/newsid4792/', 'Краткое содержание новости 4', 'http://www.somesite.com/news/newsid4792/', '2013-10-17', 'http://www.somesite.com/news/newsid4792/');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
