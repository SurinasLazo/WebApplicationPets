Egy ASP.NET webalkalmazás, amely pontosan követi az MVC modellt és amely egy kisállat
nyilvántartó rendszert valósít meg. A webalkalmazás Entity Framework Core-t használ az SQLite
adatbázissal való kommunikációhoz, code-first megközelítéssel. Az alkalmazás a következő modellekkel
dolgozik:
1. Kategória: Új kisállat kategóriát tudunk hozzáadni a következő tulajdonságokkal:
• azonosító
• kategória neve
• rövid leírás
2. Kisállat: Egy új kisállatot tudunk regisztrálni a következő tulajdonságokkal:
• azonosító
• név
• nem
• életkor
• súly
• fotó elérési útvonala (URL)
• kategória azonosító (helyette a kategória neve jelenjen meg a View-ban)
Az alkalmazás biztosítja a CRUD műveleteket a modellekhez. Kisállat hozzáadásakor alapvető input
validációt végez el (pl. ne lehessen üresen hagyni input mezőt, ne lehessen negatív értéket átadni, vagy
nem képfájl kiterjesztésű állományra hivatkozni). Ez a fotó kerüljön megjelenítésre a kisállat Index és
a Details nézetben is. A kategória Details nézetében jelenjenek meg a kategóriába tartozó kisállatok,
amelyre kattintva a kisállat Details nézetére navigál át az alkalmazás.
Végezetül módosítás az alkalmazás kinézetén CSS segítségével.
