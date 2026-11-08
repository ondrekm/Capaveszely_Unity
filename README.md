# Cápaveszély

Egyszerű 2D Unity játék, amely egy egyetemi játékfejlesztési beadandó keretében készült.

## A játék célja

A játékos egy cápát irányít. A cél 10 hal összegyűjtése úgy, hogy közben elkerülje a mozgó köveket.

- Egy hal elkapása: **+1 pont**
- 10 pont elérése: **győzelem**
- Kővel való ütközés: **Game Over**

## Irányítás

A cápa a billentyűzet nyílbillentyűivel irányítható:

- ↑ felfelé
- ↓ lefelé
- ← balra
- → jobbra

## Főbb funkciók

- 2D játék Unityben
- irányítható játékos
- 3 mozgó hal eltérő sebességgel
- 3 mozgó akadály eltérő sebességgel
- ütközésérzékelés
- pontszám
- győzelmi és vereségi feltétel
- újrakezdési lehetőség
- állapotfüggő cápa sprite-ok
- TextMeshPro alapú felhasználói felület

## Főbb scriptek

- `SharkController.cs` – a cápa mozgatása és sprite-váltásai
- `FishMovement.cs` – a halak mozgása és elkapása
- `StoneMovement.cs` – a kövek mozgása és az ütközések kezelése
- `GameManager.cs` – pontszám, győzelem, vereség és újrakezdés

## Technológia

- Unity
- C#
- 2D Physics
- TextMeshPro