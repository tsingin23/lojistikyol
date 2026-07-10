# LOJÄ°STÄ°KYOL - AkÄ±llÄ± DÃ¶nÃ¼ÅŸ Ã–nerisi, Chatbot ve Payout KampanyalarÄ± Entegrasyonu

Bu gÃ¼ncellemede kullanÄ±cÄ±larÄ±n lojistik sÃ¼reÃ§lerini optimize etmek amacÄ±yla **GeliÅŸmiÅŸ Filtreli DÃ¶nÃ¼ÅŸ Ã–neri AlgoritmasÄ±**, **AkÄ±llÄ± Chatbot DesteÄŸi**, **TaÅŸÄ±yÄ±cÄ± HoÅŸ Geldin & Periyodik Bonus Sistemleri**, **Harita Ãœzerinde GPS Koordinat DetaylarÄ±** ve **Yenilenen Ã–zel Logo** entegrasyonu tamamlanmÄ±ÅŸtÄ±r.

---

## ğŸš€ Eklenen ve Yenilenen Ã–zellikler

### 1. DÃ¶nÃ¼ÅŸ YÃ¼kÃ¼ Tavsiyeleri ("BoÅŸ DÃ¶nme" Filtreleme AlgoritmasÄ±)
*   **Algoritma MantÄ±ÄŸÄ±:** SeÃ§ilen ilanÄ±n varÄ±ÅŸ yerini (`EndLocation`) kendi Ã§Ä±kÄ±ÅŸ noktasÄ± (`StartLocation`), ilanÄ±n Ã§Ä±kÄ±ÅŸ yerini ise kendi varÄ±ÅŸ noktasÄ± olarak belirleyen tÃ¼m aktif ilanlarÄ± arar.
*   **Kriterlere GÃ¶re AkÄ±llÄ± Filtreleme:**
    *   **Ä°ller ArasÄ± UyuÅŸma:** Sadece Ã§Ä±kÄ±ÅŸ/varÄ±ÅŸ yerleri birbirini tamamlayan ters yÃ¶nlÃ¼ (backhaul) rotalar taranÄ±r.
    *   **Seviye KontrolÃ¼:** TaÅŸÄ±yÄ±cÄ±nÄ±n mevcut seviyesinin yetmediÄŸi (Ã¶rn. Level 3 yetkisi gerektiren) kargolar filtrelenerek elenir.
*   **ArayÃ¼z Entegrasyonu:** Ä°lan detay ekranÄ±nÄ±n altÄ±nda **"DÃ¶nÃ¼ÅŸ YÃ¼kÃ¼ Ã–nerileri (DÃ¶nÃ¼ÅŸte BoÅŸ Gitmeyin!)"** paneli yerleÅŸtirildi. TaÅŸÄ±yÄ±cÄ±lar Ã¶nerilen ilana tÄ±klayarak anÄ±nda detayÄ±na gidebilir ve teklif verebilirler.

### 2. AkÄ±llÄ± Chatbot AsistanÄ± ("LojistikYol AsistanÄ±")
*   **Arka Plan API Entegrasyonu:** `POST api/chatbot` uÃ§ noktasÄ± yazÄ±ldÄ±. Havuz iÅŸlemleri, seviye kriterleri, yakÄ±t fiyatlarÄ±, taban fiyat formÃ¼lÃ¼ ve bonuslara dair anahtar kelimeleri analiz ederek zengin yanÄ±tlar Ã¼retir.
*   **ArayÃ¼z Entegrasyonu:** UygulamanÄ±n saÄŸ alt kÃ¶ÅŸesine ÅŸÄ±k bir floating forum butonu yerleÅŸtirildi. Butona tÄ±klandÄ±ÄŸÄ±nda alttan aÃ§Ä±lan (bottom sheet) konuÅŸma penceresinde:
    *   Mesaj geÃ§miÅŸi baloncuklarÄ±,
    *   HÄ±zlÄ± soru sorma Ã§ipleri (chips) ("ğŸ”’ GÃ¼venli Havuz?", "ğŸ“ˆ Seviye YÃ¼kseltme?", vb.) yer alÄ±r.

### 3. TaÅŸÄ±yÄ±cÄ± Bonus & Payout Kampanya AltyapÄ±sÄ±
*   **HoÅŸ Geldin Bonusu:** Yeni kayÄ±t olan taÅŸÄ±yÄ±cÄ±lara 1 hafta boyunca geÃ§erli **%0 platform komisyonu** ve **+%10 ek navlun kazancÄ±** (payout) hakkÄ± tanÄ±mlanÄ±r.
*   **HaftalÄ±k GÃ¶rev Bonusu:** 3 taÅŸÄ±ma yapan taÅŸÄ±yÄ±cÄ±lara +5.000 TL ek cÃ¼zdan Ã¶dÃ¼lÃ¼ tanÄ±mlayan periyodik gÃ¶revler eklendi.
*   **Profil GÃ¶sterimi:** Profil sekmesinde taÅŸÄ±yÄ±cÄ±ya Ã¶zel degrade kaplamalÄ± **Aktif Payout BonuslarÄ±** paneli ve bitiÅŸ sÃ¼resi sayaÃ§larÄ± yerleÅŸtirildi.
*   **Ã–deme DaÄŸÄ±tÄ±mÄ±:** Teslimat onaylandÄ±ÄŸÄ±nda arka planda `CompleteTransaction` API'si taÅŸÄ±yÄ±cÄ±nÄ±n bonus durumunu denetler; aktif hoÅŸ geldin bonusu varsa navlunun %10'u kadar tutarÄ± cÃ¼zdanÄ±na hediye bakiye olarak yansÄ±tÄ±r.

### 4. CanlÄ± Rota HaritasÄ±nda GPS KoordinatlarÄ±
*   Ä°lan detaylarÄ±ndaki Custom Paint harita gÃ¶rselinde ÅŸehir isimlerinin altÄ±na enlem ve boylam dereceleri (Ã¶rn. Ä°stanbul iÃ§in `41.00Â°N, 28.97Â°E`, Ankara iÃ§in `39.93Â°N, 32.85Â°E`) yerleÅŸtirildi.

### 5. Ã–zel Logo Entegrasyonu
*   Yapay zeka ile tasarlanan modern ve minimalist `logo.jpg` gÃ¶rseli, uygulamanÄ±n giriÅŸ (Login) ekranÄ± baÅŸlÄ±ÄŸÄ±na ve profil sayfasÄ±nÄ±n app bar kÄ±smÄ±ndaki daire avatar alanÄ±na yerleÅŸtirildi.

---

## ğŸ› ï¸ Teknik AltyapÄ± ve Test
*   **SQL Database Update:** `AddBonusFieldsAndSeeding` gÃ¶Ã§Ã¼yle veritabanÄ±na bonus sÃ¼tunlarÄ± eklenmiÅŸ ve dÃ¶nÃ¼ÅŸ rotalarÄ± eÅŸleÅŸecek ÅŸekilde 8 adet yeni aktif ilan seed edilmiÅŸtir.
*   **Flutter Recompile:** BaÅŸarÄ±yla derlenmiÅŸ ve tarayÄ±cÄ±da yansÄ±tÄ±lmÄ±ÅŸtÄ±r.
