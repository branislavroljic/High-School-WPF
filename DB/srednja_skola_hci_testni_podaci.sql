insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('0512983100067', 'Popović', 'Slavko', '2005-12-05', 'muski', 'Koševo 3, 71000, Sarajevo, BiH', 'slavko.popovic@mail.com', 'student123'); 
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('0607989100027', 'Stojanović', 'Danijel', '2005-07-06', 'muski', 'Vase Pelagića 11a, 78000, BanjaLuka, BiH','danijel.stojanovic@mail.com', 'student123');
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1002952100005', 'Mitrović', 'Nikola', '2006-02-10',  'muski', 'Nikole Tesle 72, 72600, Mrkonjic Grad, BiH', 'mitrovic.nikola@mail.com', 'student123');
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1006949100067', 'Soldat', 'Stanko', '2005-06-10', 'muski', 'Veljka Mlađenovića bb, 78000, Banja Luka, BiH', 'stanko.soldat@mail.com', 'student123');
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1010988101124', 'Babić', 'Dejan', '2003-10-10', 'muski', 'Koševo 3, 71000, Sarajevo, BiH', 'dejan.babic@mail.com', 'student123');
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1206986101234', 'Mirković', 'Marko', '2003-06-12', 'muski', 'Vase Pelagića 11a, 78000, BanjaLuka, BiH',  'marko.mirkovic@mail.com', 'student123');
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1210987100018', 'Janković', 'Petar', '1987-10-12', 'muski', 'Nikole Tesle 72, 72600, Mrkonjic Grad, BiH','petar.jankovic@mail.com', 'prof123');   -- profesor
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol,Adresa, mail_adresa, lozinka) values ('1210987100778', 'Janković', 'Milan', '1987-10-12', 'muski', 'Nikole Tesle 72, 72600, Mrkonjic Grad, BiH','milan.jankovic@mail.com', 'prof123');   -- profesor 
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1312981163309', 'Filipović', 'Mirko', '1981-12-13', 'muski', 'Koševo 3, 71000, Sarajevo, BiH', 'mirko.filipovic@mail.com', 'prof123'); 	-- profesor
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1312981163312', 'Filipović', 'Dejan', '1981-10-13', 'muski', 'Koševo 3, 71000, Sarajevo, BiH', 'dejan.filipovic@mail.com', 'prof123'); 	-- profesor


-- ADMIN
insert into osoba (JMB, Prezime, Ime, DatumRodjenja, Pol, Adresa, mail_adresa, lozinka) values ('1111111111111', 'Adminovic', 'Admin', '1981-10-13', 'muski', 'Vase Pelagića 11a, 78000, BanjaLuka, BiH', 'admin', 'admin');
insert into admin (JMB)  values ('1111111111111');


insert into profesor (JMB, Plata,  Verifikovan) values ('1210987100018',  1000.00, 1);
insert into profesor (JMB, Plata, Verifikovan) values ('1210987100778',  700.00, 1);
insert into profesor (JMB, Plata,  Verifikovan) values ('1312981163309',  1000.00,  1);
insert into profesor (JMB, Plata, Verifikovan) values ('1312981163312',  1200.00,  1);

insert into skola (JIB, Naziv, mail_adresa, Vrsta, Adresa, Telefon)  values ('123456', 'Gimnazija Mrkonjic Grad', 'mggimn@mail.com', 'Gimnazija', 'Nikole Tesle 72, 72600, Mrkonjic Grad, BiH', '050212307');

insert into predmet (IdPredmeta, Naziv) values (1111, 'Matematika');
insert into predmet (IdPredmeta, Naziv) values (3111, 'Matematika' );
insert into predmet (IdPredmeta, Naziv) values (1222, 'Srpski' );
insert into predmet (IdPredmeta, Naziv) values (3222, 'Srpski');
insert into predmet (IdPredmeta, Naziv ) values (3333, 'Fizka' );
insert into predmet (IdPredmeta, Naziv ) values (1555, 'Informatika' );
insert into predmet (IdPredmeta, Naziv ) values (1444, 'Muzicko' );

insert into smjer (IdSmjera, Trajanje_Godina, Naziv, SKOLA_JIB, Zvanje) values (1, 4, 'Opsti' , 123456, 'Gimnazijalac');
insert into smjer (IdSmjera, Trajanje_Godina, Naziv, SKOLA_JIB, Zvanje) values (2, 3, 'Jezicki' , 123456, 'Jezicar');
insert into smjer (IdSmjera, Trajanje_Godina, Naziv, SKOLA_JIB, Zvanje) values (3, 4, 'Informaticki' , 123456, 'Informaticar');

insert into predmet_na_smjeru (IdPredmeta, IdSmjera, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera) values (1111, 1, 'O', 1, 4, 2); 
insert into predmet_na_smjeru (IdPredmeta, IdSmjera, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera) values (3111, 1, 'O', 3, 4, 2);
insert into predmet_na_smjeru (IdPredmeta, IdSmjera, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera) values (1222, 1, 'O', 1, 4, 2);
insert into predmet_na_smjeru (IdPredmeta, IdSmjera, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera) values (3222, 1, 'O', 3, 4, 2);
insert into predmet_na_smjeru (IdPredmeta, IdSmjera, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera) values (1444, 1, 'I', 1, 1, 1);
insert into predmet_na_smjeru (IdPredmeta, IdSmjera, Tip, Razred, MinimalniBrojPismenihProvjera, MinimalniBrojUsmenihProvjera) values (3333, 1, 'I', 3, 2, 2);


insert into ucenik (JMB,Razred,Odjeljenje, BrojMaticneKnjige, JMB_RAZREDNIKA,  Obnova, IdSmjera) values ('0512983100067', 1, 2, 444, '1210987100018',  0, 1);
insert into ucenik (JMB,Razred,Odjeljenje, BrojMaticneKnjige, JMB_RAZREDNIKA, Obnova, IdSmjera) values ('0607989100027', 1, 2, 555, '1210987100018',  0, 1);	
insert into ucenik (JMB,Razred,Odjeljenje, BrojMaticneKnjige, JMB_RAZREDNIKA,  Obnova, IdSmjera) values ('1002952100005', 1, 2, 666, '1210987100018',  1, 1);	
insert into ucenik (JMB,Razred,Odjeljenje, BrojMaticneKnjige, JMB_RAZREDNIKA,  Obnova, IdSmjera) values ('1006949100067', 1, 2, 777, '1312981163312',  0, 1);
insert into ucenik (JMB,Razred,Odjeljenje, BrojMaticneKnjige, JMB_RAZREDNIKA, Obnova, IdSmjera) values ('1010988101124', 3, 2, 888, '1312981163312',  0, 1);
insert into ucenik (JMB,Razred,Odjeljenje, BrojMaticneKnjige, JMB_RAZREDNIKA,  Obnova, IdSmjera) values ('1206986101234', 3, 2, 999, '1312981163312',  0, 1);


insert into ima_nastavu (ucenik_jmb, IdPredmeta, IdSmjera) values ('1002952100005',  1111, 1);
insert into ima_nastavu (ucenik_jmb, IdPredmeta, IdSmjera) values ('0607989100027',  1111, 1);
insert into ima_nastavu (ucenik_jmb,  IdPredmeta, IdSmjera) values ('0512983100067',  1111, 1);
insert into ima_nastavu (ucenik_jmb,  IdPredmeta, IdSmjera) values ('1006949100067',  1111, 1);
insert into ima_nastavu (ucenik_jmb,  IdPredmeta, IdSmjera) values ('1010988101124',  3111, 1);
insert into ima_nastavu (ucenik_jmb, IdPredmeta, IdSmjera) values ('1206986101234',  3111, 1);
insert into ima_nastavu (ucenik_jmb,  IdPredmeta, IdSmjera) values ('1206986101234',  3222, 1);

insert into predaje(IdPredmeta, IdSmjera, PROFESOR_JMB, BrojSedmicnihCasova) values ('1111', '1' ,'1210987100018', 3);
insert into predaje(IdPredmeta, IdSmjera, PROFESOR_JMB, BrojSedmicnihCasova) values ('1222', '1' ,'1210987100018', 1);
insert into predaje(IdPredmeta, IdSmjera, PROFESOR_JMB, BrojSedmicnihCasova) values ('1444', '1' ,'1210987100018', 1);
