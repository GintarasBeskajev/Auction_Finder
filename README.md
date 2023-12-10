# 1.	Sprendžiamo uždavinio aprašymas

## 1.1. Sistemos paskirtis

Projekto tikslas – leisti greitai ir patogiai sukurti aukcionus bei nusipirkti aukcionuose parduodamas prekes.

Veikimo principas – pačią kuriamą platformą sudaro dvi dalys: internetinė aplikacija, kuria naudosis žmonės norintys sukurti aukcionus ir nusipirkti aukcionuose parduodamas prekes, administratorius bei aplikacijų programavimo sąsaja.

Norėdamas nusipirkti aukcionuose parduodamas prekes bei kurti aukcionus naudotojas sistemoje turės užsiregistruoti. Užsiregistruodamas naudotojas turės nurodyti savo pavadinimą bei telefoną arba elektroninį paštą. Užsiregistravęs naudotojas galės sukurti aukcioną, priskirti aukcionui kategoriją ir nustatyti aukciono pabaigos laiką. Taip pat užsiregistravęs vartotojas galės statyti aukcionuose, kai pasirinks norimą statymo sumą. Pasibaigus aukcionui, jo kūrėjui bus rodomas aukcioną laimėjęs naudotojas. Administratorius galės nutraukti netinkamus aukcionus, pakeisti aukciono kategoriją.

## 1.2. Funkciniai reikalavimai

Svečias galės:

1.	Peržiūrėti pagrindinį puslapį bei sukurtus aukcionus ir kategorijas;

2.	Užsiregistruoti prie internetinės aplikacijos;

3.	Prisijunti prie internetinės aplikacijos.


Užsiregistravęs naudotojas galės:

1.	Atsijungti nuo internetinės aplikacijos;

2.	Susikurti aukcioną:

3.1.	Nustatyti aukciono kategoriją;

3.2.	Nustatyti pradinę aukciono kainą;

3.3.	Nustatyti minimalaus statymo sumą;

3.4.	Nustatyti aukciono pabaigos laiką;

4.	Statyti aukcionuose

5.	Peržiūrėti savo sukurtus aktyvius aukcionus;

6.	Peržiūrėti savo sukurtus pasibaigusius aukcionus;

7.	Peržiūrėti kitų sukurtus aktyvius aukcionus;
   
8.	Redaguoti savo aukcionus.

9. Naikinti savo aukcionus.
    
10. Peržiūrėti kategorijas.
    
11. Peržiūrėti savo statymus.

12. Naikinti savo statymus.

13. Redaguoti savo statymus.
 
Administratorius galės:

1.	Panaikinti netinkamus aukcionus;

2.	Peržiūrėti visus aukcionus;

3.	Šalinti naudotojus;

4.	Kurti kategorijas;
   
5.	Redaguoti kategorijas;
   
6.	Šalinti kategorijas;

7.	Atlikti tuos pačius veiksmus kaip ir užsiregistravęs naudotojas.


# 2.	Sistemos architektūra

Sistemos sudedamosios dalys:

•	Kliento pusė (ang. Front-End) – naudojant Angular karkasą;

•	Serverio pusė (angl. Back-End) – naudojant .NET 7. Duomenų bazė – PostgreSQL.

2.1 pav. Sistemos diegimo diagrama
![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/8925cabd-8643-4797-bd77-8b94c14c88c4)








