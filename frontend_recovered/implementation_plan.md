# LojistikYol KullanÄ±cÄ± Filtreleme ve Zengin Ä°Ã§erik PlanÄ±

Bu plan, uygulamada **Ä°l ve Yetenek BazlÄ± TaÅŸÄ±yÄ±cÄ± Filtreleme**, **Zengin Ä°hale Teklif Verileri** ve TÃ¼rkÃ§e karakterli yollarÄ±n emÃ¼latÃ¶r derlemesini Ã§Ã¶kertmesini Ã¶nlemek amacÄ±yla **C:\Users\Public\lojistikyol\frontend** Ã¼zerinden emÃ¼latÃ¶r derlemesini Ã§alÄ±ÅŸtÄ±rma adÄ±mlarÄ±nÄ± iÃ§erir.

---

## User Review Required

> [!IMPORTANT]
> **Gradle / ZipArchive Derleme HatasÄ± Ã‡Ã¶zÃ¼mÃ¼:** KullanÄ±cÄ± klasÃ¶r adÄ±nÄ±zdaki `Ä°` harfi nedeniyle Android Gradle derlemesi hata vermektedir. Bu hatayÄ± aÅŸmak iÃ§in tÃ¼m Flutter frontend projesini `C:\Users\Public\lojistikyol\frontend` konumuna kopyalayacaÄŸÄ±z ve emÃ¼latÃ¶r derlemesini bu "temiz" yoldan Ã§alÄ±ÅŸtÄ±racaÄŸÄ±z. BÃ¶ylece emÃ¼latÃ¶rÃ¼nÃ¼zde uygulama sorunsuz aÃ§Ä±lacaktÄ±r.

---

## Proposed Changes

### C# Backend Projesi (backend)

#### [MODIFY] [User.cs](file:///C:/Users/Public/lojistikyol/backend/Models/User.cs)
*   KullanÄ±cÄ±larÄ±n kayÄ±tlÄ± olduÄŸu ÅŸehri belirtmek iÃ§in `City` (string) alanÄ±nÄ±n eklenmesi.

#### [MODIFY] [AppDbContext.cs](file:///C:/Users/Public/lojistikyol/backend/Data/AppDbContext.cs)
*   Seed kullanÄ±cÄ±lara (Ahmet: Ä°stanbul, Mehmet: Ä°stanbul, Ali: Ankara, Veli: Ä°zmir) ÅŸehir bilgilerinin tanÄ±mlanmasÄ±.
*   Seed `Bids` (Teklifler) listesinin doldurulmasÄ± (Mehmet, Ali ve Veli tarafÄ±ndan ilanlara verilmiÅŸ 7 adet aktif teklif verisi).

---

### Flutter Mobil UygulamasÄ± (frontend)

#### [MODIFY] [explore_screen.dart](file:///C:/Users/Taha%20S%C4%B0NG%C4%B0N/.gemini/antigravity/scratch/lojistikyol/frontend/lib/screens/explore_screen.dart)
*   Ãœst kÄ±sma **"YÃ¼k Ä°lanlarÄ±"** ve **"TaÅŸÄ±yÄ±cÄ± Rehberi"** geÃ§iÅŸ segmentinin eklenmesi.
*   **TaÅŸÄ±yÄ±cÄ± Rehberi GÃ¶rÃ¼nÃ¼mÃ¼:**
    *   **Ä°l Filtresi:** Ä°stanbul, Ankara, Ä°zmir, Bursa ÅŸehirlerine gÃ¶re taÅŸÄ±yÄ±cÄ±larÄ± sÃ¼zme.
    *   **Seviye Filtresi:** Level 1, 2, 3 lisans derecelerine gÃ¶re sÃ¼zme.
    *   **Puan/Rating Filtresi:** YÄ±ldÄ±z puanÄ±na gÃ¶re taÅŸÄ±yÄ±cÄ±larÄ± sÄ±ralama/sÃ¼zme.
    *   Filtrelenen taÅŸÄ±yÄ±cÄ± kartlarÄ±nda ehliyet tipi, cÃ¼zdan onay durumu ve puan bilgilerinin sergilenmesi.

---

## Verification Plan

### Automated Tests
*   `dotnet build` kontrolÃ¼.
*   Yeni konuma taÅŸÄ±nan Flutter projesinin (`C:\Users\Public\lojistikyol\frontend`) emÃ¼latÃ¶r Ã¼zerinde `flutter run -d emulator-5554` ile baÅŸlatÄ±lmasÄ±.

### Manual Verification
1.  **Teklif DoluluÄŸu:** GiriÅŸ yapÄ±ldÄ±ÄŸÄ±nda ilan detaylarÄ±nda veya "Tekliflerim" menÃ¼sÃ¼nde seed edilen tekliflerin gÃ¶rÃ¼ntÃ¼lendiÄŸi doÄŸrulanÄ±r.
2.  **TaÅŸÄ±yÄ±cÄ± Arama & Filtreleme:** KeÅŸfet sekmesinde "TaÅŸÄ±yÄ±cÄ± Rehberi" seÃ§ilerek illere ve ehliyet/seviye kriterlerine gÃ¶re arama yapÄ±labildiÄŸi doÄŸrulanÄ±r.
