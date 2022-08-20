create procedure uspAnalytics
@authorID int=null,
@period int=null
as
select year(nc.DatumUzimanja) as 'Year' , count(nc.KnjigaID) as 'Number'
from Na_Citanju nc
left join Napisali np
on nc.KnjigaID = np.KnjigaID
where np.AutorID = @authorID and(YEAR(GETDATE()) - @period < year(nc.DatumUzimanja))
group by year(nc.DatumUzimanja)                            
order by 'Year'
