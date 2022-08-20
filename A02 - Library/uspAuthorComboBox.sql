create procedure uspAuthorComboBox
as
select AutorID as ID, Ime+' '+Prezime as FullName
from Autor
order by Ime