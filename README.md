# iikoTest
ТЗ:
Написать web приложение на asp net 8
 - В приложении должно быть настроено подключение к базе данных (postgre/litedb на выбор). При этом строка подключения к базе должна быть получена из конфигурационного файла
 - В приложении реализовать получение / удаление / обновление / данных в бд на основе объекта с тремя полями: ClientId (long), Username (string), SystemId (Guid) где ClientId - ключ
 - Логика этого контроллера должна быть реализована в отдельном классе и внедрена в контроллер через внедрение зависимостей
 - Дополнительно реализовать один post метод, который в теле запроса будет принимать массив объектов (не менее 10). Этот метод должен сравнить существующие в бд данные на предмет дубликатов (только по ключу), и добавить только уникальные объекты. В теле ответа должны прийти все недобавленные объекты. При этом добавление и сравнение каждого объекта в этом методе должно выполняться асинхронно

Интерфейс веб-приложения сделан на Swagger.

Нюансы:
1) SystemId колонка автоматически генерирует новый Guid при добавлении новой сущности;
2) При изменении существующей сущности если не ввести SystemId в запросе, то он изменится на стандартный Guid.Epty (default value);
3) Насчёт асинхронного добавления каждого элемента изначально мы получаем всю коллекцию уже существующих записей так как при расширении базы до большого количества записей сравнивать по отдельности каждого клиента будет трудоёмко.
