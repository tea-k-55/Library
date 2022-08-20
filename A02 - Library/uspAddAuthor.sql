create procedure uspAddAuthor
@authorID int = null,
@fname nvarchar(50) = null,
@lname nvarchar(50) = null,
@dob datetime = null
as
insert into Autor(AutorID, Ime, Prezime, DatumRodjenja)
values (@authorID, @fname, @lname, @dob)