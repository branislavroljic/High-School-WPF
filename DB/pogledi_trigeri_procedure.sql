SET GLOBAL log_bin_trust_function_creators = 1;

drop function if exists nadji_prosjek_ucenika;
delimiter $$
create function nadji_prosjek_ucenika (pJMBUcenika char(13))
returns decimal(3,2)
begin
	 declare vRazred, vSmjer int;
     declare vProsjek decimal(3,2);
     select Razred into vRazred from ucenik u where u.JMB = pJMBUcenika;
     select IdSmjera into vSmjer from ucenik u where u.JMB = pJMBUcenika;
     select round(avg(un.Ocjena),2) into vProsjek
	 from (select Ocjena from radi_provjeru as rp where rp.UCENIK_JMB = pJMBUcenika and rp.IdPredmeta
		in (select IdPredmeta from predmet_na_smjeru where IdSmjera = vSmjer and Razred = vRazred))un;

     return vProsjek;
end $$
delimiter ;

drop view if exists predmeti_detaljno;
create view predmeti_detaljno (IdPredmeta, Naziv, Skola, Smjer, Razred, Tip) as
	select p.IdPredmeta, p.Naziv, sk.Naziv, sm.Naziv as Smjer, pns.Razred, pns.Tip 
	from predmet p
	inner join predmet_na_smjeru pns on pns.IdPredmeta = p.IdPredmeta
	inner join smjer sm on sm.IdSmjera = pns.IdSmjera
	inner join skola sk on sm.SKOLA_JIB = sk.JIB;
    
    -- prosjek trazim u zavisnosti od razreda, prikazujem prosjek samo za trenutni razred 
drop view if exists ucenik_detaljno;
create view ucenik_detaljno (JMB, Ime, Prezime, Skola, JIB, Smjer, IdSmjera, Razred, Odjeljenje, ProsjekOcjena) as
select o.JMB,  o.Ime, o.Prezime, sk.Naziv, sk.JIB, s.Naziv, s.IdSmjera, u.Razred, u.Odjeljenje, nadji_prosjek_ucenika(o.JMB)
from osoba o
inner join ucenik u on o.JMB = u.JMB
-- inner join osoba r on u.JMB_RAZREDNIKA = r.JMB
 inner join smjer s on u.IdSmjera = s.IdSmjera
 inner join skola sk on sk.JIB = s.SKOLA_JIB
group by o.JMB, s.IdSmjera 
order by 7 desc;


drop trigger if exists dodavanje_ucenik_provjera;
delimiter $$
create trigger dodavanje_ucenik_provjera after insert
on radi_provjeru
for each row
begin 
	update provjera
	set BrojPrisutnihUcenika = BrojPrisutnihUcenika + 1,
    BrojNegativnihOcjena = BrojNegativnihOcjena + (new.Ocjena = 1)
    where new.Datum = Datum and new.IdPredmeta = IdPredmeta and new.IdSmjera = IdSmjera and new.Odjeljenje = Odjeljenje;
end$$;
delimiter ;
    
drop trigger if exists uklanjanje_ucenik_provjera;
delimiter $$
create trigger uklanjanje_ucenik_provjera after delete
on radi_provjeru
for each row
begin
	update provjera
    set BrojPrisutnihUcenika = BrojPrisutnihUcenika - 1,
    BrojNegativnihOcjena = BrojNegativnihOcjena - (old.Ocjena = 1)
    where old.Datum = Datum and old.IdPredmeta = IdPredmeta and old.IdSmjera = IdSmjera;
end$$
delimiter ;

drop trigger if exists izmjena_ucenik_provjera;
delimiter $$
create trigger izmjena_ucenik_provjera after update
on radi_provjeru
for each row
begin
	update provjera
    set BrojPrisutnihUcenika = BrojPrisutnihUcenika - 1,
    BrojNegativnihOcjena = BrojNegativnihOcjena - (old.Ocjena = 1)
    where old.Datum = Datum and old.IdPredmeta = IdPredmeta and old.IdSmjera = IdSmjera;
    update provjera
	set BrojPrisutnihUcenika = BrojPrisutnihUcenika + 1,
    BrojNegativnihOcjena = BrojNegativnihOcjena + (new.Ocjena = 1)
    where new.Datum = Datum and new.IdPredmeta = IdPredmeta and new.IdSmjera = IdSmjera;
end$$
delimiter ;

drop procedure if exists dodaj_profesora;
delimiter $$
create procedure dodaj_profesora(in pJMB char(13), in pIME varchar(20), in pPREZIME varchar(13),in pDATUMRODJENJA date,in pPOL enum('muski', 'zenski'),in pADRESA varchar(255),
				in pMAIL_ADRESA varchar(255),in pLozinka varchar(255), in pVERIFIKOVAN tinyint(1),in pPLATA decimal(10,0))
begin
if (select count(*) from osoba o where o.JMB = pJMB) = 0
		 then
			insert into osoba values (pJMB, pIME, pPREZIME, pDATUMRODJENJA, pPOL, pADRESA, pMAIL_ADRESA, pLozinka, 'EN', 'B');
         end if;
		insert into profesor values (pVERIFIKOVAN, pPLATA, pJMB);
end$$
delimiter ;


drop procedure if exists azuriraj_profesora;
delimiter $$
create procedure azuriraj_profesora(in pJMB char(13), in pIME varchar(20), in pPREZIME varchar(13),in pDATUMRODJENJA date,in pPOL enum('muski', 'zenski'),in pADRESA varchar(255),
				in pMAIL_ADRESA varchar(255),in pLOZINKA varchar(128),in pVERIFIKOVAN tinyint(1),in pPLATA decimal(10,0))
begin
        
        UPDATE osoba SET  `Ime` = pIme, `Prezime` = pPrezime, `DatumRodjenja` = pDatumRodjenja, `Pol` = pPol, `Adresa` = pAdresa, `mail_adresa` = pMail_adresa, `lozinka` = pLozinka WHERE (`JMB` = pJMB);
        update profesor set Verifikovan=pVerifikovan, Plata=pPlata where JMB = pJMB;
end$$
delimiter ;



drop procedure if exists dodaj_predmet_na_smjeru;
delimiter $$
create procedure dodaj_predmet_na_smjeru (in pIdPredmeta int, in pNazivPredmeta varchar(45), in pIdSmjera int, in pTip char(1), in pRazred tinyint(1),
				in pMinimalniBrojPismenihProvjera tinyint, pMinimalniBrojUsmenihProvjera tinyint)
begin
	declare vTrajanje int default 0;
    select Trajanje_Godina into vTrajanje
    from smjer
    where IdSmjera = pIdSmjera;

		if (select count(*) from predmet p where p.IdPredmeta = pIdPredmeta ) = 0
		 then
			insert into predmet values (pIdPredmeta, pNazivPredmeta);
         end if;
		insert into predmet_na_smjeru values (pIdPredmeta, pIdSmjera, pTip, pRazred, pMinimalniBrojPismenihProvjera, pMinimalniBrojUsmenihProvjera);
      
end$$
delimiter ;



drop procedure if exists azuriraj_predmet_na_smjeru;
delimiter $$
create procedure azuriraj_predmet_na_smjeru (in pIdPredmeta int, in pNazivPredmeta varchar(45), in pIdSmjera int, in pTip char(1), in pRazred tinyint(1),
				in pMinimalniBrojPismenihProvjera tinyint, pMinimalniBrojUsmenihProvjera tinyint)
begin
	declare vTrajanje int default 0;
    select Trajanje_Godina into vTrajanje 
    from smjer
    where IdSmjera = pIdSmjera;

		update predmet p set Naziv = pNazivPredmeta where p.IdPredmeta = pIdPredmeta;
		update predmet_na_smjeru set
        Razred = pRazred,
        Tip = pTip,
        MInimalniBrojPismenihProvjera = pMinimalniBrojPismenihProvjera,
        MinimalniBrojUsmenihProvjera = pMinimalniBrojUsmenihProvjera
        where IdPredmeta = pIdPredmeta and IdSmjera = pIdSmjera;
       
-- end if;
end$$
delimiter ;

drop trigger if exists brisanje_profesora;
delimiter $$
create trigger brisanje_profesora after delete
on profesor
for each row
begin
	delete from osoba o
    where o.JMB= old.JMB;
end $$
delimiter ;
