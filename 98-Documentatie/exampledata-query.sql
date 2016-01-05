select 

	--productnaam
	REPLACE(p.prod_naam,',','\,')

	--leveranciernaam
	+ ',' + l.lev_naam + ','

	--leverancierid
	+ ',' + CAST(p.prod_lev_id as varchar(20)) + ','

	--prijs
	--+ ',' + '€ ' + CAST(p.prod_prijs as varchar(20)) + ','

	--aantal
	+ ',' + '5,'

	--totaalprijs
	--+ ',' + '€ ' + CAST(5 * p.prod_prijs as varchar(20)) + ','

from Product p 
inner join leverancier l on p.prod_lev_id = l.lev_id