SQL Запросы:
1. SELECT * FROM Managers WHERE Phone NOT NULL;
2. SELECT * FROM Sells WHERE Date = "20.06.2021"; 
3. SELECT AVG sum FROM Sells INNER JOIN Products WHERE Products.ID = Sells.ID_Prod AND Products.Name = "Фанера";
4. SELECT Fio, SUM(sum) AS Sum FROM Manager;
   LEFT JOIN Sells ON Manager.ID = Sells.ID_Manag
   LEFT JOIN Product ON Product.ID = Sells.ID_Prod
   WHERE Product.Name = "ОСБ";
5. SELECT Fio, Name FROM Managers
   INNER JOIN Sells ON Managers.ID = Sells.ID_Manag
   INNER JOIN Product ON Product.ID = Sells.ID_Prod
   WHERE Sells.Date = "22.08.2021";
6. SELECT * FROM Product WHERE Name LIKE "%Фанера%" AND Cost >= 1750;
7. SELECT COUNT(ID_Prod) AS Cnt, * FROM Sells 
   WHERE Date IN LIKE("%.01.%","%.02.%","%.03.%","%.04.%","%.05.%","%.06.%","%.07.%","%.08.%","%.09.%","%.10.%","%.11.%","%.12.%")
   GROUP BY ID_Prod AND Date
   ORDER BY Date ASC;
8. SELECT ID, Name, Cost, Volume, COUNT(*) AS Cnt FROM Product
   GROUP BY ID, Name, Cost, Volume
   HAVING COUNT(*) > 1;
   
