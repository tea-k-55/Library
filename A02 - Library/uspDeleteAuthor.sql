create procedure uspDeleteAuthor
@authorID int=null
as
delete from Autor
where AutorID=@authorID