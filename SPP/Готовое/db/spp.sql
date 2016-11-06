-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Окт 21 2015 г., 12:14
-- Версия сервера: 5.6.26
-- Версия PHP: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `spp`
--

-- --------------------------------------------------------

--
-- Структура таблицы `customers`
--

CREATE TABLE IF NOT EXISTS `customers` (
  `id` int(11) NOT NULL,
  `name` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `email` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `mobile` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `customers`
--

INSERT INTO `customers` (`id`, `name`, `email`, `mobile`) VALUES
(1, 'Ivan', 'ivan@meil.ru', '20203272'),
(15, '123', '3453453', '23423423123');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL,
  `Username` text NOT NULL,
  `Password` varchar(64) NOT NULL,
  `AuthKey` varchar(64) NOT NULL,
  `AccessToken` varchar(64) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`Id`, `Username`, `Password`, `AuthKey`, `AccessToken`) VALUES
(5, 'admin', '$2gCXDSrN2DHo', '$2a$%13$gZerJHCccxqlxsgh9YD7jbcpxmmEAg==', '$2a$%13$RZYuW5hzynSoT5JtG/SPQb0SLUkEJQ==');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `customers`
--
ALTER TABLE `customers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
