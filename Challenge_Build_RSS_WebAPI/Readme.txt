Her er en række bemærkninger og kommentarer til Assignment A og B.

Assignment A, A1 og A2 er for så vidt løst, men der udestår mange spørgsmål. 
Løsningen er bygget i Visual Studio 2019 16.11.5 som et ASP.NET Core Web API i C#. 
Projektet kan bygge uden fejl og kører lokalt. Det kørende projekt kan forbruges via nedenstående ressourcer. 

Assignment B er ikke løst konkret i kode, men der er en række overvejelser til videre diskussion.


                                   ----------oooooooooooooooooooooooooooooooooooooooooo----------

                                                       Assignment A, A1 og A2


 Bemærkninger og/eller spørgsmål som kræver nærmere afklaring

 1) Projektet mangler måske at blive fordøjet yderligere, idet man ikke kan kalde en Url med en parameter som er en Url medmindre den er UrlEnkodet. Er det mon en maskine som skal konsumere denne WebAPI?
 2) Lidt underligt at jeg ikke kan se nogle authors i feed'et. Er den mon overhovedet udfyldt af RSS-leverandøren?
 3) Lidt underligt at jeg ikke kan nogle ImageUrl i feed'et. Er den mon overhovedet udfyldt af RSS-leverandøren?
 4) Lidt underligt at jeg ikke kan se nogle description for kanalen. Er den mon overhovedet udfyldt af RSS-leverandøren?
 5) Skal der laves ekstra check for om RSS-Uri'en er gyldig? Men det vil gøre hver forspørgsel tungere. Dels at pakke den ind i TryCatch og dels at Resolve den
 6) Hvor meget skal der mon trækkes hjem af nyheder? Skal vi sætte en grænse for det, eller tror vi bare på alle leverandørerne af RSS-feeds at vi ikke kommer til at trække en kæmpe stak Entries hjem?
 7) Hvad skal der ske hvis feed'et er ugyldigt? Bare en 404 NotFound som jeg har gjort det her?
 8) Når jeg skal tælle hvor mange forskellige forfattere der har været indenfor 24 timer, hvordan sikre jeg så at jeg HAR 24 timers feed? De sammentælles rullende, dvs. antallet vil variere over dagen efterhånden som der kommer flere forfattere til. Er det det som kunden ønsker!?
 9) Resultat data sættes til 5 nyheder, indtil vi får at vide hvor meget at vi skal give retur
 10) Bør der laves et Test projekt?

Dokumentation til forbruger:
https://localhost:44332/swagger/index.html

Link til forbrug:

Curl:
curl -X GET "https://localhost:44332/api/RSSfeed?feed=http%3A%2F%2Ffeeds.tv2.dk%2Fnyheder%2Frss" -H  "accept: */*"

Request URL:
https://localhost:44332/api/RSSfeed?feed=http%3A%2F%2Ffeeds.tv2.dk%2Fnyheder%2Frss



                                   ----------oooooooooooooooooooooooooooooooooooooooooo----------


                                          Assignment B - Implement Your Own Linked List


Det er ikke lykkedes mig at lave en hjemmelavet Linked List.

Her er nogle overvejelser til videre diskussion:

1) Det er en liste af knuder som ligger skulder ved skulder
2) Hver knude har et payload samt mindst en pegepind som peger enten fremad og/eller bagud på dvs. til næste og/eller forrige knude
3) I praksis ligger knuderne måske rekursivt inde i hinanden. Man kunne dog også argumentere for at de ligger skulder ved skulder som siblinger pga. pegepindene og det at knuderne er ens. Så der er en kommunikativ og kognitiv udfordring her.
4) Der skal være en metode til at sætte det igang. Muligvis fornuftigt at lægge denne i liste konstruktoren, så forbrugeren ikke skal tænke over initialiserings-metoder og start-knude

5) Der skal være en metode som tilføjer (Add) en ny knude til listen og vedligeholder pegepindene 
5.1) Ideelt skal der kunne indsættes på vilkårlige indeks pladser i knude listen

6) Der skal være en visnings metode som viser listen
7) Der skal være at tælle (Count) metode/egenskab for antal knuder. 
8) Der skal være en metode (Remove) som fjerner knuder og vedligeholder pegepindene efterfølgende
8.1) Ideelt skal der kunne fjernes på vilkårlige indeks pladser i knude listen

9) Hvis det var rigtig sejt ville løsningen implementerer iteratoren så man kunne lave en foreach over listen

Denne opgave er noget som skal re-faktoreres mange gange. 
Der er flere edge-cases på denne problemstilling og det vil kræve en del iterationer at få dem alle håndteret så det er lækkert at forbruge.
