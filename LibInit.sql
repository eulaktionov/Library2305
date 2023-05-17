use BookLib2305

delete from Authors;
delete from Books;
delete from AuthorBook;
delete from Readers;
delete from Records;

insert Authors (FirstName, LastName) values 
(N'Name1', N'Author1'),	--9
(N'Name2', N'Author2'),	--10
(N'Name3', N'Author3'),	--11
(N'Name4', N'Author4');	--12

insert Books (Name) values 
(N'Book1'),	--15
(N'Book2'),	--16
(N'Book3'),	--17
(N'Book4'),	--18
(N'Book5'),	--19
(N'Book6'),	--20
(N'Book7');	--21

insert Readers (FirstName, LastName) values 
(N'Name1', N'Reader1'),	--11
(N'Name2', N'Reader2'),	--12
(N'Name3', N'Reader3'),	--13
(N'Name4', N'Reader4'),	--14
(N'Name5', N'Reader5');	--15

insert AuthorBook (AuthorsId, BooksId) values 
(9, 15),	--1
(10, 16),	--2
(9, 17),	--3
(11, 17),	--4
(12, 15),	--5
(12, 19),	--6
(12, 20),	--7
(9, 20),	--8
(10, 21);	--9

insert Records (BookId, ReaderId, ReceiveDate, ReturnDate) values 
(15, 11, '20200601', '20200610'),	--1
(16, 11, '20200601', '20200610'),	--2
(17, 12, '20200601', null),			--3
(18, 12, '20200601', null),			--4
(20, 11, '20200610', '20200620'),	--5
(21, 11, '20200610', '20200620'),	--6
(15, 13, '20200701', '20200710'),	--7
(19, 13, '20200701', null),			--8
(15, 12, '20200701', null);			--9