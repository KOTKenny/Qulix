# Settings of the project

В папке BackUpDB находится резервная копия базы данных, устанавливаем на свой SQL Server (использовал 2012 год)<br>

Запускаем решение.<br>

В Web.config настраиваем connectionString, меняем на свой.<br>
Можно также добавить свой connectionString, а в классе DAL/Repositories/DataManager поменять его название (свойство ConnectionString)<br>

Настройка завершена, можно запускать проект.

# Working

Всё должно быть интуитивно понятно.<br>

Главная страница:<br>
  * Статистика, полученная на основе Базы Данных<br>

Страница "Компании":<br>
  * Таблица с отображением всех компаний<br>
  * Фильтр<br>
  * Сортировка<br>
  * Кнопка "Создание компании"<br>

Страница "Работники":<br>
  * Таблица с отображением всех работников<br>
  * Фильтр<br>
  * Сортировка<br>
  * Кнопка "Создание работника"

# BLL, DAL, Presentation levels (From 08.03.2021)

Проект был поделен на 3 уровня:<br>
  * Data Access Level
  * Buisness Logic Level
  * Presentation Level

# Developer

KOTKenny

[VK](https://vk.com/kotkenny)

Время написания: 19 часов
