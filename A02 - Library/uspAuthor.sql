create procedure uspAuthor
as
select AutorID as Sifra, Ime, Prezime, FORMAT(DatumRodjenja, 'dd/MM/yyyy') as 'Date of Birth', Adresa
from Autor