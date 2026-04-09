# Schach_Gutmann_2026
A simple version of a chess program written in C#. It is easy to understand and use, with a clear structure and basic functions. The game includes simple chess rules, user input, and clean code. It is ideal for beginners who want to learn programming while building a basic chess game step by step.

als erstes alle klassen anlegen also eine klasse für spielfeld für jede figur eine klasse wo einmal figur welche farbe schwarz oder weiß und wie sie schlagen dürfen und wie sie fahren dürfen, tostring, klassse zum setzten der figuren, win funktion
anfangen mit allen klassen ohne inhalt
dann tostring mit spielfeld 8x8
dann weiter mit ersten figur anfangen mit könig dann da ncoh genau beschrieben was ich alles dafür vrauche und weiter erst später also erst mla das



############################################################################################################



# Schach_Gutmann_2026

A simple version of a chess program written in C#. It is easy to understand and use, with a clear structure and basic functions. The game includes simple chess rules, user input, and clean code. It is ideal for beginners who want to learn programming while building a basic chess game step by step.

---

## Projekt-Anforderungen & Ablauf

Ziel ist die Erstellung einer **.NET-Core-Solution**, die aus mehreren Projekten besteht. Dazu gehören eine Fachlogik für Schach, passende Unit-Tests und eine Konsolenanwendung.

**Wichtig:** Nach jedem Schritt ist ein **Git-Commit** durchzuführen und die Änderungen zu **pushen**. Es dürfen keine Schritte übersprungen werden.

---

### 1. Solution-Struktur erstellen (Kommandozeile)
Erstelle eine neue .NET-Core-Solution über die Kommandozeile. Die Solution soll folgende Projekte enthalten:
* Eine **Class Library** für die Fachlogik (Schach-Logik)
* Ein **xUnit-Testprojekt** für Unit-Tests
* Ein **Konsolenprojekt** als Startanwendung

Alle Projekte sind korrekt zur Solution hinzuzufügen. Das Konsolenprojekt und das Testprojekt müssen eine Referenz auf die Class Library besitzen.

---

### 2. Klassen-Skelett anlegen
In der Class Library sind die grundlegenden Klassen zu erstellen.
* **Schritt 1:** Erstelle eine leere Klasse `Spielfeld` und Unit-Tests, die die Instanziierbarkeit prüfen.
* **Schritt 2:** Erstelle eine Basisklasse `Figur` sowie leere Klassen für jede Schachfigur: `Koenig`, `Dame`, `Turm`, `Laeufer`, `Springer`, `Bauer`.
* **Eigenschaften:** Jede Figur muss eine Farbe (Schwarz/Weiß) besitzen.

---

### 3. Erste Funktionalität: Visualisierung
Implementiere die Darstellung des Spielfelds.
* **Aufgabe:** Implementiere eine `ToString`-Methode in der Klasse `Spielfeld`.
* **Format:** Das Spielfeld soll als 8x8 Gitter in der Konsole ausgegeben werden (z.B. mit `.` für leere Felder).
* **Test:** Überprüfe, ob die `ToString`-Methode die korrekte Anzahl an Feldern zurückgibt.

---

### 4. Spielfeld-Logik (Setzen & Lesen)
Erweitere die `Spielfeld`-Klasse um Methoden zum Verwalten der Figuren:
* **SetFigur(int x, int y, Figur figur):**
    * Setzt eine Figur auf die Position (x, y).
    * Rückgabe `true`, wenn erfolgreich; `false`, wenn die Position außerhalb liegt.
* **GetFigur(int x, int y):**
    * Gibt die Figur an der Position zurück oder `null`, wenn das Feld leer ist.

---

### 5. Die erste Figur: König
Implementiere die Logik für den König als ersten Meilenstein.
* **Bewegung:** Der König darf sich nur ein Feld in jede Richtung bewegen.
* **Schlagen:** Implementiere die Prüfung, ob eine gegnerische Figur geschlagen werden kann.
* **ToString:** Der König soll als `K` (weiß) oder `k` (schwarz) ausgegeben werden.
* **Tests:** Erstelle Unit-Tests für alle validen und invaliden Bewegungen des Königs.

---

### 6. Spielzustand & Win-Funktion
Erstelle eine Methode `Win` (oder `IsCheckmate`), die den Zustand des Spiels prüft.
* Die Methode gibt `true` zurück, wenn eine Gewinnsituation (Schachmatt) vorliegt.
* Dieser Schritt ist mit mehreren Unit-Tests (verschiedene Matt-Szenarien) abzusichern.

---

### 7. Hauptprogramm
Im Konsolenprojekt soll ein Programm erstellt werden, das:
1. Das Spielfeld initialisiert und die Figuren aufstellt.
2. Fortlaufend Koordinaten abfragt (Eingabe Start- und Zielposition).
3. Abwechselnd Weiß und Schwarz ziehen lässt.
4. Nach jedem Zug das aktuelle Spielfeld neu zeichnet.
5. Das Spiel beendet, wenn eine Gewinnsituation vorliegt.
