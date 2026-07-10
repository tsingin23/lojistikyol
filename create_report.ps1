try {
    Write-Host "Word Uygulamasi baslatiliyor..."
    $word = New-Object -ComObject Word.Application
    $word.Visible = $false
    $doc = $word.Documents.Add()

    # Sayfa yapisi
    $doc.PageSetup.TopMargin = 72 # 1 inc = 72 pt
    $doc.PageSetup.BottomMargin = 72
    $doc.PageSetup.LeftMargin = 72
    $doc.PageSetup.RightMargin = 72

    # Renk Kodlari
    $bgrOrange = 36095
    $bgrDarkBlue = 1190412

    # Yazi tipi yardimcilari
    function Add-TitlePage($doc) {
        $p = $doc.Paragraphs.Add()
        $p.Range.Text = "`r`n`r`n`r`nFIRAT UNIVERSITESI`r`nMESLEK YUKSEKOKULU TEKNIK BILIMLER`r`nBilgisayar Teknolojileri Bolumu`r`n"
        $p.Range.Font.Name = "Arial"
        $p.Range.Font.Size = 14
        $p.Range.Font.Bold = $true
        $p.Alignment = 1 # Center
        $p.Range.InsertParagraphAfter()

        $p2 = $doc.Paragraphs.Add()
        $p2.Range.Text = "`r`n`r`n`r`nSISTEM ANALIZI VE TASARIMI`r`nDersi Proje Uygulamasi ve Dokumantasyonu`r`n"
        $p2.Range.Font.Name = "Arial"
        $p2.Range.Font.Size = 18
        $p2.Range.Font.Bold = $true
        $p2.Range.Font.Color = $bgrOrange
        $p2.Alignment = 1 # Center
        $p2.Range.InsertParagraphAfter()

        $p3 = $doc.Paragraphs.Add()
        $p3.Range.Text = "`r`n`r`nPROJE ADI:`r`nLojistikYol - Yapay Zeka Destekli Akilli Sevkiyat ve Lojistik Yonetim Platformu`r`n"
        $p3.Range.Font.Name = "Arial"
        $p3.Range.Font.Size = 14
        $p3.Range.Font.Bold = $true
        $p3.Alignment = 1 # Center
        $p3.Range.InsertParagraphAfter()

        $p4 = $doc.Paragraphs.Add()
        $p4.Range.Text = "`r`n`r`n`r`nGelistiren:`r`nTaha SINGIN (Ogrenci No: U2207.00023)`r`n`r`nProje Yurutucusu:`r`nOgr. Uyesi Merve PARLAK BAYDOGAN`r`n"
        $p4.Range.Font.Name = "Arial"
        $p4.Range.Font.Size = 12
        $p4.Range.Font.Bold = $true
        $p4.Alignment = 1 # Center
        $p4.Range.InsertParagraphAfter()

        $p5 = $doc.Paragraphs.Add()
        $p5.Range.Text = "`r`n`r`n`r`nTEMMUZ - 2026"
        $p5.Range.Font.Name = "Arial"
        $p5.Range.Font.Size = 11
        $p5.Range.Font.Bold = $true
        $p5.Alignment = 1 # Center
        
        # Sayfa sonu
        $doc.Words.Last.InsertBreak(7) # wdSectionBreakPage
    }

    function Add-Header($doc, $text) {
        $p = $doc.Paragraphs.Add()
        $p.Range.Text = $text
        $p.Range.Font.Name = "Arial"
        $p.Range.Font.Size = 14
        $p.Range.Font.Bold = $true
        $p.Range.Font.Color = $bgrDarkBlue
        $p.Format.SpaceBefore = 12
        $p.Format.SpaceAfter = 6
        $p.Alignment = 0 # Left
        $p.Range.InsertParagraphAfter()
    }

    function Add-SubHeader($doc, $text) {
        $p = $doc.Paragraphs.Add()
        $p.Range.Text = $text
        $p.Range.Font.Name = "Arial"
        $p.Range.Font.Size = 12
        $p.Range.Font.Bold = $true
        $p.Range.Font.Color = $bgrOrange
        $p.Format.SpaceBefore = 6
        $p.Format.SpaceAfter = 4
        $p.Alignment = 0 # Left
        $p.Range.InsertParagraphAfter()
    }

    function Add-BodyText($doc, $text) {
        $p = $doc.Paragraphs.Add()
        $p.Range.Text = $text
        $p.Range.Font.Name = "Arial"
        $p.Range.Font.Size = 11
        $p.Range.Font.Bold = $false
        $p.Range.Font.Color = 0 # Black
        $p.Format.SpaceAfter = 6
        $p.Alignment = 3 # Justify
        $p.Range.InsertParagraphAfter()
    }

    # Kapak Sayfasi
    Add-TitlePage $doc

    # 1. Onsoz
    Add-Header $doc "ONSOZ VE TESEKKUR"
    Add-BodyText $doc "Bu proje calismasi, Firat Universitesi Teknik Bilimler Meslek Yuksekokulu Bilgisayar Programciligi programi bunyesinde yurutulen BTB228 Sistem Analizi ve Tasarimi dersi kapsaminda gelistirilmiştir. Lojistik ve tasimacilik sektorundeki dijitallesme ihtiyaclarini adresleyen bu yazilimin tasarim, kodlama ve test asamalarinda bana yol gosteren, bilgi birikimini esirgemeyen degerli danismanim Ogr. Uyesi Merve PARLAK BAYDOGAN'a tesekkuru bir borc bilirim. Ayrica egitim hayatim boyunca her zaman yanimda olan aileme ve arkadaslarima desteklerinden oturu sukranlarimi sunarim. Bu projeyi gerceklestirme asamasinda yararlandigim her kaynagi kaynaklar kisminda bildirdigimi taahhut ederim."
    Add-BodyText $doc "Taha SINGIN"
    $doc.Words.Last.InsertBreak(7)

    # 2. Giris
    Add-Header $doc "GIRIS"
    
    Add-SubHeader $doc "Projenin Tanitilmasi"
    Add-BodyText $doc "LojistikYol, gonderici firmalar ile bagimsiz kuryeleri ve lojistik sirketlerini tek bir dijital platformda bir araya getiren yapay zeka destekli akilli bir sevkiyat ve lojistik yonetim sistemidir. Sistem, geleneksel tasimacilik sureclerindeki yuksek komisyon oranlarini, manuel evrak takibini ve guvenli odeme sorunlarini ortadan kaldirarak modern bir 'Uber Freight' modeli sunar."
    
    Add-SubHeader $doc "Projenin Amaci"
    Add-BodyText $doc "Projenin temel amaci; tasima ihalelerinde adil fiyatlandirmayi saglamak, yapay zeka tabanli sevk irsaliyesi dogrulamasiyla operasyonel hatalari azaltmak, bloke cuzdan sistemi ile hem gondericinin kargosunu hem de tasiyicinin navlun hakkini guvenceye almak ve iki yonlu puanlama modeliyle taraflar arasinda guvenilir bir is ekosistemi insa etmektir."
    
    Add-SubHeader $doc "Projenin Kapsami"
    Add-BodyText $doc "Sistem, gondericilerin kolayca ilan acabilmesini, tasiyicilarin bu ilanlara teklif veya otomatik teklif (Auto-Bid) verebilmesini, canli GPS ilerlemesini takip etmesini, yapay zeka destekli OCR irsaliye dogrulama modulunu, bloke akilli cuzdan altyapisini ve teslimat sonrasi iki yonlu kurye/musteri puanlama ekranlarini kapsamaktadir."

    Add-SubHeader $doc "Kullanilacak Teknolojiler"
    Add-BodyText $doc "o Mobil Arayuz (Frontend): Flutter & Dart (Cross-platform)`r`no Sunucu Katmani (Backend): C# .NET Core 9.0 Web API (RESTful Mimari)`r`no Veritabanı Katmani: SQLite (Tasınabilir dosya tabanli veritabanı)`r`no OCR / Yapay Zeka Servisi: Gomulu Ozel NLP / Gemini AI API (Yapay zeka tabanli irsaliye dogrulama)`r`no Harita ve Telemetri: Custom Route Truck Animator & GPS Simulation Services`r`no Veri Erisim Teknolojisi: Entity Framework Core (Code-First Migrations)"
    $doc.Words.Last.InsertBreak(7)

    # 3. Proje Plani
    Add-Header $doc "PROJE PLANI"
    
    Add-SubHeader $doc "Sistemin Kullanicilari"
    Add-BodyText $doc "1. Gonderici (Sirket/Sahis): Sevkiyati yapilacak kargosu olan, sisteme ilan yukleyen ve tasiyicilardan teklif alan kullanici roludur.`r`n2. Tasiyici / Surucu: Kendisine ait araci veya filosu bulunan, ilanlara teklif vererek sevkiyatlari tasiyan ve teslim eden kurye roludur."

    Add-SubHeader $doc "Islevsel Ihtiyaclar (Olmazsa Olmazlar)"
    Add-BodyText $doc "- Kullanici Kayit ve Rol Secimi (Gonderici / Tasiyici)`r`n- Dinamik Katsayili Fiyat Teklifi ve Canli Ihale Paneli`r`n- Auto-Bid (Kullanicinin belirledigi alt sinira kadar otomatik teklif dusurme sistemi)`r`n- Guvence Teminati ve Navlun Blokaji (Cuzdan Guvenligi)`r`n- GPS Canli Konum ve Sevkiyat Takibi`r`n- Yapay Zeka (OCR) Irsaliye Analizi ve Dogrulama`r`n- Iki Yonlu Puanlama (Kurye puanlama ve musteri puanlama)"

    Add-SubHeader $doc "Islevsel Olmayan Ihtiyaclar (Ilave Ozellikler)"
    Add-BodyText $doc "- Akilli Chatbot Asistani (Yapay zeka destekli rota ve fiyat danismanligi)`r`n- Fiyat Optimizasyon Motoru (Hava durumu ve talebe gore dinamik fiyat hesaplama)`r`n- Kolay Kurulum Altyapisi (start.bat ve veritabanı tasinabilirligi)"

    Add-SubHeader $doc "UML Sinif (Class) Yapisi ve Mimari"
    Add-BodyText $doc "Sistem nesneye yonelik programlama standartlarina gore tasarlanmis olup; User, Ad (Ilan), Bid (Teklif), Transaction (Sevkiyat Sureci), CarrierProfile (Surucu Detaylari), Notification (Bildirimler), PayoutRequest (Odeme Talepleri) ve SenderReview (Yorumlar) siniflarindan olusmaktadir. Bu siniflar arasindaki iliskiler veritabanı semasinda yabanci anahtarlarla (Foreign Key) baglanmistir."
    $doc.Words.Last.InsertBreak(7)

    # 4. Proje Gerceklestirilmesi
    Add-Header $doc "PROJE GERCEKLESTIRILMESI"
    
    Add-SubHeader $doc "Modullerin ve Tum Ekranlarin Tasarimi"
    Add-BodyText $doc "- Giris ve Kayit Ekrani: Kullanicilarin e-posta ve sifre ile guvenli giris yaptigi, Gonderici veya Tasiyici rollerini sectigi ekrandir.`r`n- Ilan Arama ve Kesfet Ekrani: Harita destekli arayuzde aktif ihalelerin listelendigi, hava durumu katsayisina gore fiyatlarin optimize edildigi ekrandir.`r`n- Ihale Detay ve Teklif Verme Paneli: Geri sayim sayacinin calistigi, manuel ve Auto-Bid tekliflerin girildigi kritik is mantigi ekranidir.`r`n- Aktif Sevkiyat Ekrani: Surucu icin GPS simulasyonu baslatma ve irsaliye fotografi yukleme butonlarini; Gonderici icin ise canli konum takibini ve OCR dogrulama metnini barindirir.`r`n- Degerlendirme ve Puanlama Ekrani: Teslimat gerceklestikten sonra iki tarafin da birbirine yildiz verip yorum yazdigi ekrandir.`r`n- Cuzdan Modulu: Bakiye yukleme, cekme ve bloke teminatlarin izlendigi finansal yonetim ekranidir."

    Add-SubHeader $doc "Veritabanı Tasarimi"
    Add-BodyText $doc "SQLite veritabanı uzerinde 8 ana tablo bulunmaktadir:`r`n1. Users: Kullanicilarin kimlik, sifre hash ve bakiye bilgileri.`r`n2. CarrierProfiles: Tasiyicilarin lisans ve rating ortalamalari.`r`n3. Ads: Ilan bilgileri, baslangic/bitis noktalari ve statusu.`r`n4. Bids: Ilanlara verilen teklifler ve otomatik teklif sinirlari.`r`n5. Transactions: Aktif sevkiyat durumlari ve cuzdan blokaj detaylari.`r`n6. Notifications: Kullanicilara gonderilen sistem bildirimleri.`r`n7. PayoutRequests: Finansal cikis talepleri.`r`n8. SenderReviews: Gondericilere yapilan degerlendirme ve puanlamalar."
    $doc.Words.Last.InsertBreak(7)

    # 5. Eksiklikler ve Teslimat
    Add-Header $doc "PROJEDE ONGORULEN EKSIKLIKLER VE TESLIM"
    Add-BodyText $doc "Proje planindaki tum islevsel moduller (Auto-bid, yapay zeka irsaliye dogrulama, canli takip ve iki yonlu puanlama) %100 basariyla tamamlanmistir. Gelecekte sisteme canli SMS bildirimleri ve gercek kredi karti entegrasyonu eklenmesi planlanmaktadir."
    Add-BodyText $doc "Kurulum ve Teslimat:`r`nSistem, kurulum gerektirmeyen SQLite veritabanı ile tasınabilir hale getirilmistir. Teslim edilen zip dosyasindaki 'start.bat' dosyasina cift tiklandiginda backend sunucusu ve Android emulator otomatik olarak ayaga kalkmaktadir."

    # 6. Sonuc
    Add-Header $doc "SONUC"
    Add-BodyText $doc "Bu proje calismasi ile modern lojistik sektorunun en buyuk ihtiyaclarindan olan guvenli odeme, seffaf fiyat teklifleri ve dijital evrak takibi problemleri akilli cozumlerle giderilmistir. Projenin gelistirilme sureci boyunca Flutter'da durum yonetimi (Provider), .NET Web API tasarimi, EF Core veritabanı gocleri (Migrations) ve yapay zeka OCR kutuphaneleriyle calisma konularinda kapsamli pratik deneyimler edinilmistir."
    
    Add-Header $doc "KAYNAKLAR"
    Add-BodyText $doc "1. Flutter Resmi Dokumantasyonu (docs.flutter.dev)`r`n2. Microsoft .NET Core API Kilavuzu (learn.microsoft.com)`r`n3. Entity Framework Core SQLite Entegrasyon Rehberi`r`n4. GitHub API ve Versiyon Kontrol Sistemi Dokumanlari"
    
    $doc.Words.Last.InsertBreak(7)

    # 7. Maliyet Kestirimi (Function Point)
    Add-Header $doc "PROJE MALIYET KESTIRIM DOKUMANI"
    Add-BodyText $doc "Bu bolumde, FPA (Function Point Analysis - Islev Noktasi Analizi) yontemi kullanilarak yazilimin maliyeti, islevsel karmasikligi ve satir sayisi tahmin hesaplamasi gerceklestirilmistir."

    # Tablo Olusturma
    $table1 = $doc.Tables.Add($doc.Paragraphs.Last.Range, 5, 4)
    $table1.Borders.Enable = 1
    
    # Headers
    $table1.Cell(1, 1).Range.Text = "Olcum Parametresi"
    $table1.Cell(1, 2).Range.Text = "Sayi"
    $table1.Cell(1, 3).Range.Text = "Agirlik Faktoru"
    $table1.Cell(1, 4).Range.Text = "Toplam"
    
    # Rows
    $table1.Cell(2, 1).Range.Text = "Kullanici Girdi Sayisi"
    $table1.Cell(2, 2).Range.Text = "5"
    $table1.Cell(2, 3).Range.Text = "3 (Dusuk)"
    $table1.Cell(2, 4).Range.Text = "15"
    
    $table1.Cell(3, 1).Range.Text = "Kullanici Cikti Sayisi"
    $table1.Cell(3, 2).Range.Text = "5"
    $table1.Cell(3, 3).Range.Text = "4 (Orta)"
    $table1.Cell(3, 4).Range.Text = "20"
    
    $table1.Cell(4, 1).Range.Text = "Veri Tabanindaki Tablo Sayisi"
    $table1.Cell(4, 2).Range.Text = "8"
    $table1.Cell(4, 3).Range.Text = "7 (Yuksek)"
    $table1.Cell(4, 4).Range.Text = "56"
    
    $table1.Cell(5, 1).Range.Text = "Arayuz Sayisi"
    $table1.Cell(5, 2).Range.Text = "9"
    $table1.Cell(5, 3).Range.Text = "5 (Orta)"
    $table1.Cell(5, 4).Range.Text = "45"

    $pSpace = $doc.Paragraphs.Add()
    $pSpace.Range.Text = "`r`nAna Islev Nokta Sayisi (AIN Degeri): 136`r`n"
    $pSpace.Range.Font.Bold = $true
    $pSpace.Range.InsertParagraphAfter()

    Add-SubHeader $doc "Teknik Karmasiklik Sorulari ve Puanlama (TKF)"
    Add-BodyText $doc "1. Uygulama, guvenilir yedekleme ve kurtarma gerektiriyor mu? (4)`r`n2. Veri iletisimi gerekiyor mu? (5)`r`n3. Dagitik islem islevleri var mi? (3)`r`n4. Performans kritik mi? (4)`r`n5. Sistem mevcut ve agir yuku olan bir isletim ortaminda mi calisacak? (2)`r`n6. Sistem, cevrim ici veri girisi gerektiriyor mu? (5)`r`n7. Cevrim ici veri girisi, birden cok ekran gerektiriyor mu? (4)`r`n8. Ana tablolar cevrim-ici olarak mi gunleniyor? (5)`r`n9. Girdiler, ciktilar ya da sorgular karmasik mi? (4)`r`n10. Icsal islemler karmasik mi? (3)`r`n11. Tasarlanacak kod, yeniden kullanilabilir mi olacak? (4)`r`n12. Kurulum ve gecis dikkate alinacak mi? (3)`r`n13. Sistem birden cok yerde yerlesik farkli kurumlar icin mi gelistiriliyor? (2)`r`n14. Tasarlanan uygulama, kolay kullanilabilir ve degistirilebilir mi? (4)"

    $tkfTotal = 52
    Add-BodyText $doc "Toplam TKF Puani: $tkfTotal"
    
    Add-BodyText $doc "Hesaplama Formulleri:`r`nIN (Islev Noktasi) = AIN x (0.65 + 0.01 x TKF) = 136 x (0.65 + 0.52) = 159.12`r`nTahmini Satir Sayisi = IN x 30 = 159.12 x 30 = 4.773 Satir Kod"

    # Kaydetme
    $desktopPath = [System.IO.Path]::Combine($env:USERPROFILE, "Desktop")
    $savePath = [System.IO.Path]::Combine($desktopPath, "LojistikYol_SAT_Raporu.docx")
    Write-Host "Dosya kaydediliyor: $savePath"
    $doc.SaveAs([ref]$savePath)
    $doc.Close()
    $word.Quit()
    
    Write-Host "Rapor basariyla olusturuldu!"
} catch {
    Write-Host "Hata olustu: $_"
    if ($null -ne $word) { $word.Quit() }
}
