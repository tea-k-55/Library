create procedure uspAuthorFields
@authorID int=null
as
select AutorID, Ime, Prezime, FORMAT(DatumRodjenja, 'dd/MM/yyyy') as 'Date of Birth'
from Autor
where AutorID=@authorID