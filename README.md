Ataskaitos dokumentas: [Ataskaita_Gintaras_Beskajev.docx](https://github.com/GintarasBeskajev/Auction_Finder/files/13703934/Ataskaita_Gintaras_Beskajev.docx)

# 1.	Sprendžiamo uždavinio aprašymas
## 1.1.	Sistemos paskirtis
Projekto tikslas – leisti greitai ir patogiai sukurti aukcionus bei nusipirkti aukcionuose parduodamas prekes.
Veikimo principas – pačią kuriamą platformą sudaro dvi dalys: internetinė aplikacija, kuria naudosis žmonės norintys sukurti aukcionus ir nusipirkti aukcionuose parduodamas prekes, administratorius bei aplikacijų programavimo sąsaja.
Norėdamas nusipirkti aukcionuose parduodamas prekes bei kurti aukcionus naudotojas sistemoje turės užsiregistruoti. Užsiregistruodamas naudotojas turės nurodyti savo pavadinimą bei elektroninį paštą. Užsiregistravęs naudotojas galės sukurti aukcioną, priskirti aukcionui kategoriją ir nustatyti aukciono pabaigos laiką. Taip pat užsiregistravęs vartotojas galės statyti aukcionuose, kai pasirinks norimą statymo sumą. Pasibaigus aukcionui, jo kūrėjui bus rodomas aukcioną laimėjęs naudotojas. Administratorius galės nutraukti netinkamus aukcionus, pakeisti aukciono kategoriją.

## 1.2.	Funkciniai reikalavimai
Svečias galės:
1.	Peržiūrėti sukurtus aktyvius aukcionus.
2.	Peržiūrėti kategorijas.
3.	Užsiregistruoti prie internetinės aplikacijos.
4.	Prisijungti prie internetinės aplikacijos.
5.	
Užsiregistrravęs naudotojas galės:
1.	Atsijungti nuo internetinės aplikacijos
2.	Sukurti aukcionus.
3.	Sukurti statymus už aukcione parduodamą prekę.
4.	Peržiūrėti visus savo sukurtus aukcionus.
5.	Peržiūrėti kitų sukurtus aktyvius aukcionus.
6.	Redaguoti savo aukcionus.
7.	Naikinti savo aukcionus.
8.	Peržiūrėti savo statymus.
9.	Redaguoti savo statymus.
10.	Šalinti savo statymus.
11.	Peržiūrėti kitų sukurtus statymus ant aktyvių aukcionų.
12.	Peržiūrėti kategorijas.

Administratorius galės:
1.	Atlikti tuos pačius veiksmus kai pir užsiregistravęs naudotojas.
2.	Redaguoti visus matomus aukcionus.
3.	Šalinti visus matomus aukcionus.
4.	Kurti kategorijas.
5.	Redaguoti kategorijas.
6.	Šalinti kategorijas.

# 2.	Sistemos architektūra
Sistemos sudedamosios dalys:

•	Kliento pusė (ang. Front-End) – naudojant Angular karkasą;
•	Serverio pusė (angl. Back-End) – naudojant .NET 6. Duomenų bazė –PostgreSQL.

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/be272b4f-7421-4a04-a745-aae447a2cc4d)

pav. 1. Sistemos AuctionFinder diegimo diagrama


Github nuoroda: https://github.com/GintarasBeskajev/Auction_Finder

 
# 3.	Naudotojo sąsajos architektūra
Čia bus pateikta keletos langų wireframe ir realizacijos:

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/0631ac70-b2c4-43ea-98ba-8fa14e6a865f)

pav. 2. Prisijungimo lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/4292ef6c-7207-4f76-a3ef-a797be9e3965)
 
pav. 3. Prisijungimo lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/8967aa27-b298-4767-bc9a-3abb405a1547)
 
pav. 4. Registracijos lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/0577f675-a037-478c-81f1-3bc0c1a0e090)

pav. 5. Registracijos lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/65ede6ee-9089-459e-a7c2-5be7927e36b9)

pav. 6. Aukcionų peržiūros lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/959b541e-b670-4498-98d9-d96e7e7d7334)

pav. 7.  Aukcionų peržiūros lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/39639eea-7812-4b18-8b7a-129f71e923d7)
 
pav. 8.  Statymų peržiūros lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/338cd955-7e53-4f0c-a5d7-4f036004ffdd)

pav. 9.  Statymų peržiūros lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/61b2275d-a8ae-4b70-8b8d-569cac4238b8)

pav. 10.  Kategorijų peržiūros lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/fac1246c-4bde-419f-9908-8a86608e9839)

pav. 11.  Kategorijų peržiūros lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/b5864059-e257-4b89-8971-775fd5ec519f)

pav. 12.  Detalaus peržiūrėjimo lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/e6301e9f-d070-48ea-8d63-1a4b136a8da8)

pav. 13.  Detalaus peržiūrėjimo lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/8457980d-8134-49eb-9de5-950b94447292)

pav. 14.  Redagavimo lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/0556bd4c-2bee-4410-924c-68aad1c3bba4)

pav. 15.  Redagavimo lango realizacija

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/af4bb886-cd3c-43a4-b409-168056a3bff9)
 
pav. 16.  Kūrimo lango wireframe

![image](https://github.com/GintarasBeskajev/Auction_Finder/assets/100523608/2ef5e2fd-f163-411e-bb8e-88f0ce6cad1e)

pav. 17.  Kūrimo lango realizacija
 
# 4.	Api specifikacija

Categories:

GET Category

Paskirtis: Gauti vienos kategorijos informaciją.

Kelias iki metodo:  /api/categories/{categoryId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Ketegorija rasta
404	NotFound	Kategorija nerasta

Užklausos struktūra: - 

Atsako struktūra: 
{
	"id": "...",
	"name": "..."
}

Header dalis: -


GET Categories

Paskirtis: Gauti visų kategorijų informaciją.

Kelias iki metodo:  /api/categories

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Atsiunčiamos visos rastos kategorijos

Užklausos struktūra: - 

Atsako struktūra: 
{
	"id": "...",
	"name": "..."
}, ...

Header dalis: -


POST Category

Paskirtis: Sukurti kategoriją.

Kelias iki metodo:  /api/categories

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
201	Created	Ketegorija sukurta
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Vartotojas nėra administratorius
422	Unprocessable Entity	Kategorijos pavadinimas per trumpas

Užklausos struktūra:
{
	"Name": "..."
}


Atsako struktūra: 
{
	"id": "...",
	"name": "..."
}

Header dalis: 
Authorization: Bearer {token}


PUT Category

Paskirtis: Redaguoti kategorijos informaciją.

Kelias iki metodo:  /api/categories/{categoryId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Ketegorija sėkmingai redaguota
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Vartotojas nėra administratorius
404	Not Found	Kategorija nebuvo rasta
422	Unprocessable Entity	Kategorijos pavadinimas per trumpas

Užklausos struktūra:
{
	"Name": "..."
}


Atsako struktūra: 
{
	"id": "...",
	"name": "..."
}

Header dalis: 
Authorization: Bearer {token}


DELETE Category

Paskirtis: Ištrinti kategoriją.

Kelias iki metodo:  /api/categories/{categoryId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
204	No Content	Ketegorija sėkmingai ištrinta
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Vartotojas nėra administratorius
404	Not Found	Kategorija nebuvo rasta

Užklausos struktūra: -

Atsako struktūra:  -

Header dalis: 
Authorization: Bearer {token}

Auctions:

GET Auction

Paskirtis: Gauti vieno aukciono informaciją.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Aukcionas rastas
404	NotFound	Aukcionas arba kategorija nerasti

Užklausos struktūra: - 

Atsako struktūra: 
{
	"id": "...",
	"name": "...",
	"description": "...",
"startDate": "...",
"endDate": "...",
"category": {
		"id": "...",
		"name": "...",
	"userId": "...",
	"user": "..."
},
"userId": "..."
}

Header dalis: -


GET Auctions

Paskirtis: Gauti visų aukcionų informaciją.

Kelias iki metodo:  /api/categories/{categoryId}/auctions

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Atsiunčiami visi rasti aukcionai
404	Not Found	Kategorija nerasta

Užklausos struktūra: - 

Atsako struktūra: 
{
	"id": "...",
	"name": "...",
	"description": "...",
"startDate": "...",
"endDate": "...",
"category": {
		"id": "...",
		"name": "...",
	"userId": "...",
	"user": "..."
},
"userId": "..."
}, ...

Header dalis: -


POST Auction

Paskirtis: Sukurti aukcioną.

Kelias iki metodo:  /api/categories/{categoryId}/auctions

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
201	Created	Aukcionas sukurtas
401	Unauthorized	Vartotojas neautorizuotas
404	Not Found	Kategorija nerasta
422	Unprocessable Entity	Pavadinimas arba aprašymas per trumpi arba pradžios data vėlesnė už pabaigos datą.

Užklausos struktūra:
{
	"Name": "...",
	"Description": "...",
	"StartDate": "...",
	"EndDate": "..."
}


Atsako struktūra: 
{
	"id": "...",
	"name": "...",
	"description": "...",
"startDate": "...",
"endDate": "...",
"category": {
		"id": "...",
		"name": "...",
	"userId": "...",
	"user": "..."
},
"userId": "..."
}

Header dalis: 
Authorization: Bearer {token}


PUT Auction

Paskirtis: Redaguoti aukciono informaciją.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Aukcionas sėkmingai redaguotas
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Aukcionas nepriklauso prisijungusiam vartotojui ir vartotojas nėra administratorius
404	Not Found	Kategorija arba aukcionas nebuvo rasti
422	Unprocessable Entity	Pavadinimas arba aprašymas per trumpi arba pradžios data vėlesnė už pabaigos datą.

Užklausos struktūra:
{
	"Name": "...",
	"Description": "...",
	"EndDate": "..."
}


Atsako struktūra: 
{
	"id": "...",
	"name": "..."
}

Header dalis: 
Authorization: Bearer {token}


DELETE Auction

Paskirtis: Ištrinti aukcioną.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
204	No Content	Aukcionas sėkmingai ištrintas
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Aukcionas nepriklauso prisijungusiam vartotojui ir vartotojas nėra administratorius
404	Not Found	Kategorija arba aukcionas nebuvo rasti

Užklausos struktūra: -

Atsako struktūra: -

Header dalis: 
Authorization: Bearer {token}

Bids:

GET Bid

Paskirtis: Gauti vieno statymo informaciją.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}/bids/{bidId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Statymas rastas
404	NotFound	Aukcionas arba kategorija arba statymas nerasti

Užklausos struktūra: - 

Atsako struktūra: 
{
	"id": "...",
	"bidSize": "...",
	"comment": "...",
"creationDate": "...",
"auction": {
		"id": "...",
		"name": "...",
	"description": "...",
	"startDate": "...",
	"endDate": "...",
	"category": {
		"id": "...",
		"name": "...",
		"userId": "...",
		"user": "...",
	},
	"userId": "...",
	"user": "..."
},
"userId": "...",
"userEmail": "..."
}

Header dalis: -


GET Bids

Paskirtis: Gauti visų statymų informaciją.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}/bids

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Atsiunčiami visi rasti aukcionai
404	Not Found	Kategorija arba aukcionas nerasti

Užklausos struktūra: - 

Atsako struktūra: 
{
	"id": "...",
	"bidSize": "...",
	"comment": "...",
"creationDate": "...",
"auction": {
		"id": "...",
		"name": "...",
	"description": "...",
	"startDate": "...",
	"endDate": "...",
	"category": {
		"id": "...",
		"name": "...",
		"userId": "...",
		"user": "...",
	},
	"userId": "...",
	"user": "..."
},
"userId": "...",
"userEmail": "..."
}, ...

Header dalis: -


POST Bid

Paskirtis: Sukurti statymą.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}/bids

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
201	Created	Statymas sukurtas
401	Unauthorized	Vartotojas neautorizuotas
404	Not Found	Kategorija arba aukcionas nerasti
422	Unprocessable Entity	Komentaras yra per trumpas arba statymo suma yra per maža arba sukūrimo data yra senesenė už aukciono pabaigos datą arba ankstesnė už aukciono pradžios datą .

Užklausos struktūra:
{
	"BidSize": "...",
	"Comment": "...",
	"CreationDate": "..."
}

Atsako struktūra: 
{
	"id": "...",
	"bidSize": "...",
	"comment": "...",
"creationDate": "...",
"auction": {
		"id": "...",
		"name": "...",
	"description": "...",
	"startDate": "...",
	"endDate": "...",
	"category": {
		"id": "...",
		"name": "...",
		"userId": "...",
		"user": "...",
	},
	"userId": "...",
	"user": "..."
},
"userId": "..."
}

Header dalis: 
Authorization: Bearer {token}


PUT Bid

Paskirtis: Redaguoti statymo informaciją.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}/bids/{bidId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Statymas sėkmingai redaguotas
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Statymas nepriklauso prisijungusiam vartotojui ir vartotojas nėra administratorius
404	Not Found	Kategorija arba aukcionas arba statymas nebuvo rasti
422	Unprocessable Entity	Komentaras yra per trumpas

Užklausos struktūra:
{
	"Comment": "..."
}


Atsako struktūra: 
{
	"id": "...",
	"bidSize": "...",
	"comment": "...",
"creationDate": "...",
"auction": {
		"id": "...",
		"name": "...",
	"description": "...",
	"startDate": "...",
	"endDate": "...",
	"category": {
		"id": "...",
		"name": "...",
		"userId": "...",
		"user": "...",
	},
	"userId": "...",
	"user": "..."
},
"userId": "..."
}

Header dalis: 
Authorization: Bearer {token}


DELETE Bid

Paskirtis: Ištrinti statymą.

Kelias iki metodo:  /api/categories/{categoryId}/auctions/{auctionId}/bids/{bidId}

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
204	No Content	Statymas sėkmingai ištrintas
401	Unauthorized	Vartotojas neautorizuotas
403	Forbidden	Statymas nepriklauso prisijungusiam vartotojui ir vartotojas nėra administratorius
404	Not Found	Kategorija arba aukcionas arba statymas nebuvo rasti

Užklausos struktūra: -

Atsako struktūra: -

Header dalis: 
Authorization: Bearer {token}


Authorization:


POST Login

Paskirtis: Prisijungti.

Kelias iki metodo:  /api/login

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	Ok	Prisijungta
400	Bad request	Netinkami duomenys

Užklausos struktūra:
{
	"userName": "...",
	"password": "..."
}


Atsako struktūra: 
{
	"accessToken": "...",
	"refreshToken": "..."
}

Header dalis: -


 
POST Register

Paskirtis: Užsiregistruoti.

Kelias iki metodo:  /api/register

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
201	Created	Vartotojas užregistruotas
400	Bad request	Per trumpas arba ne visus reikalaujamus simbolius turintis slaptažodis arba per trumpas vartotojas vardas arba netinkamas elektroninis paštas

Užklausos struktūra:
{
	"userName": "...",
	"email": "...",
	"password": "..."
}


Atsako struktūra: 
{
	"id": "...",
	"userName": "...",
	"email": "..."
}

Header dalis: -


POST Refresh Access token

Paskirtis: Užsiregistruoti.

Kelias iki metodo:  /api/accessToken

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Access token atnaujintas
422	Unprocessable Entity	Neteisingas refresh token

Užklausos struktūra:
{
	"refreshToken": "..."
}


Atsako struktūra: 
{
	"accessToken": "...",
	"refreshToken": "..."
}

Header dalis: -


POST Logout

Paskirtis: Atsijungti.

Kelias iki metodo:  /api/logout

Atsako kodai:
Kodas	Reikšmė	Paaiškinimas
200	OK	Atsijungta
422	Unprocessable Entity	Netinkamas access token

Užklausos struktūra: -

Atsako struktūra: -

Header dalis: 
Authorization: Bearer {token} 

# 5.	Išvados

Sėkmingai įgyvendinau visas pateiktas užduotis. Buvo sukurtas API (backend) 3 objektams, įgyvendinta autentifikacija ir autorizacija naudojant JWT tokenus, sukurta naudotoja sąsaja ir visa tai patalpinta serveriuose. Įgyvendinęs projektą supratau kaip veikia pasirinktas Angular karkasas. Norėdamas išmokti naudotis Angular karkasu pasirinkau projektą įgyvendinti būtent su juo. Dirbdamas su juo pastebėjau, kad atskirtas typescript ir html kodas yra patogesnis naudoti ir suprasti nei jsx kodas React karkase. Taigi renkantis tarp šių dviejų karkasų vėl naudočiau Angular karkasą.








