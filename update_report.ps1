try {
    Write-Host "Paths and files are being resolved..."
    $desktopPath = [System.IO.Path]::Combine($env:USERPROFILE, "Desktop")
    $btbFolder = Get-ChildItem -Path $desktopPath -Directory | Where-Object { $_.Name -like "*BTB228*" } | Select-Object -First 1
    
    if ($null -eq $btbFolder) {
        Write-Host "Error: BTB228 folder not found on Desktop"
        exit
    }
    
    $templateDoc = Get-ChildItem -Path $btbFolder.FullName -File -Filter "*SAT-Rapor*.docx" | Select-Object -First 1
    
    if ($null -eq $templateDoc) {
        Write-Host "Error: SAT-Rapor template document not found"
        exit
    }
    
    $outputPath = [System.IO.Path]::Combine($desktopPath, "LojistikYol_SAT_Raporu.docx")
    
    Write-Host "Copying template to output path: $outputPath"
    Copy-Item -Path $templateDoc.FullName -Destination $outputPath -Force
    
    Write-Host "Launching Microsoft Word..."
    $word = New-Object -ComObject Word.Application
    $word.Visible = $false
    
    $doc = $word.Documents.Open($outputPath)
    
    # 1. Text Replacement Helper
    function Replace-Text($doc, $findText, $replaceText) {
        $find = $doc.Content.Find
        $find.ClearFormatting()
        $find.Replacement.ClearFormatting()
        $null = $find.Execute($findText, $true, $false, $false, $false, $false, $true, 1, $false, $replaceText, 2)
    }
    
    function Insert-AfterText($doc, $findText, $insertText) {
        $range = $doc.Content
        $range.Find.ClearFormatting()
        # MatchWholeWord = $false to allow ASCII substring search
        $found = $range.Find.Execute($findText, $true, $false, $false, $false, $false, $true, 1, $false)
        if ($found) {
            try {
                $pRange = $range.Paragraphs.Item(1).Range
                $pRange.Collapse(0) # wdCollapseEnd = 0 (Collapses to end of paragraph range)
                $pRange.InsertAfter("`r`n" + $insertText)
                Write-Host "Success: Content inserted after '$findText'"
            } catch {
                try {
                    $range.InsertParagraphAfter()
                    $range.InsertAfter($insertText)
                    Write-Host "Success (Fallback): Content inserted after '$findText'"
                } catch {
                    Write-Host "Warning: Failed to insert content after '$findText' - $_"
                }
            }
        } else {
            Write-Host "Warning: Heading containing '$findText' not found"
        }
    }

    Write-Host "Performing placeholder replacements on Cover Page..."
    Replace-Text $doc "Proje Adi" "LojistikYol - Yapay Zeka Destekli Akilli Sevkiyat ve Lojistik Yonetim Platformu"
    Replace-Text $doc "Okul no-Ad soyad" "U2207.00023 - Taha SINGIN"
    Replace-Text $doc "Ad-soyad" "Taha SINGIN"
    
    # Add project content under headings using ASCII substrings
    Write-Host "Inserting project contents..."
    
    Insert-AfterText $doc "Projenin Tan" "LojistikYol, gonderici firmalar ile bagimsiz kuryeleri ve lojistik sirketlerini tek bir dijital platformda bir araya getiren yapay zeka destekli akilli bir sevkiyat ve lojistik yonetim sistemidir. Geleneksel lojistikteki yuksek komisyon oranlarini, kagit evrak karmasasini ve guvensiz odeme kosullarini ortadan kaldirarark modern bir 'Uber Freight' modeli sunar."
    
    Insert-AfterText $doc "Projenin Am" "Tasima ihalelerinde adil katsayili fiyatlandirmayi saglamak, bloke cuzdan teminatiyla finansal guvenligi tesis etmek, yapay zeka destekli sevk irsaliyesi kontrolu ile teslimat onay sureclerini otomatilestirmek ve iki yonlu puanlama ile taraflar arasinda guvenilirligi dogrulamaktir."
    
    Insert-AfterText $doc "Projenin Kap" "Ilan ve ihale olusturma paneli, Auto-Bid (otomatik teklif dusurme), canli GPS konum simulasyonu, yapay zeka OCR irsaliye dogrulama modulu, bloke cuzdan altyapisi ve teslimat sonrasinda calisan iki yonlu kurye/musteri yorumlama sistemidir."
    
    Insert-AfterText $doc "Teknolojiler" "Mobil Arayuz icin Flutter (Dart), Sunucu ve API katmani icin C# .NET Core 9.0 Web API, veri tabanı katmani icin SQLite, veri erisimi icin Entity Framework Core ve irsaliye dogrulama icin Gemini AI / NLP irsaliye okuma servisi kullanilmistir."
    
    Insert-AfterText $doc "Sistemin" "1. Gonderici (Sirket/Sahis): Sevkiyati yapilacak kargosu olan, sisteme ilan yukleyen ve tasiyicilardan teklif alan kurye musterisi.`r`n2. Tasiyici / Surucu: Kendisine ait araci veya filosu bulunan, ilanlara teklif vererek sevkiyatlari tasiyan ve teslim eden kurye."
    
    Insert-AfterText $doc "Olmazsa Olmazlar" "- Kullanici Kayit ve Rol Secimi (Gonderici / Tasiyici)`r`- Canli Ihale Paneli ve Dinamik Katsayili Teklif Verme`r`- Auto-Bid (Kullanicinin belirledigi alt sinira kadar otomatik teklif dusurme)`r`- Bloke Teminat ve Navlun Odeme Guvenligi (Akilli Cuzdan)`r`- GPS Canli Konum ve Sevkiyat Takibi`r`- Yapay Zeka (OCR) Irsaliye Analizi ve Dogrulama`r`- Iki Yonlu Puanlama (Musteri ve Kurye yorumlamalari)"
    
    Insert-AfterText $doc "Olmayan" "- Akilli Chatbot Asistani (Rota ve fiyat danismanligi)`r`- Fiyat Optimizasyon Motoru (Hava durumu ve talebe gore dinamik fiyat)`r`- Kolay Kurulum Altyapisi (start.bat ve veritabanı tasinabilirligi)"
    
    Insert-AfterText $doc "Class her projede" "Projemiz nesneye yonelik programlama standartlarina gore tasarlanmis olup; User, Ad (Ilan), Bid (Teklif), Transaction (Sevkiyat Sureci), CarrierProfile (Surucu Detaylari), Notification (Bildirimler), PayoutRequest (Odeme Talepleri) ve SenderReview (Yorumlar) siniflarindan olusmaktadir. Siniflar arasindaki iliskiler veritabanı semasinda yabanci anahtarlarla (Foreign Key) kurulmustur."
    
    Insert-AfterText $doc "Her form resim" "Sistemin kullanici arayuzu; Giris ve Kayit Ekrani, Ilan Arama ve Kesfet Ekrani, Ihale Detay ve Teklif Verme Paneli, Aktif Sevkiyat Ekrani, Degerlendirme ve Puanlama Ekrani ve Cuzdan Yonetim ekranlarindan olusmaktadir. Tasarimlar modern estetik standartlarina gore hazirlanmistir."
    
    Insert-AfterText $doc "Veritaban" "SQLite veritabanı uzerinde 8 ana tablo bulunmaktadir: Users, CarrierProfiles, Ads, Bids, Transactions, Notifications, PayoutRequests, ve SenderReviews. Veritabanı Entity Framework Core Code-First yaklasimiyla yonetilmektedir."
    
    Insert-AfterText $doc "Raporlar" "Sistem ciktisi olarak; yapay zeka OCR irsaliye dogrulama raporu, finansal cuzdan hareketleri raporu ve kullanici degerlendirme istatistikleri sunulmaktadir."
    
    Insert-AfterText $doc "eksik kalan" "Proje planindaki tum islevsel moduller (Auto-bid, yapay zeka irsaliye dogrulama, canli takip ve iki yonlu puanlama) %100 basariyla tamamlanmistir."
    
    Insert-AfterText $doc "zenginle" "Gelecekte sisteme canli SMS bildirimleri ve gercek kredi karti entegrasyonu (Iyzico / Stripe) eklenmesi planlanmaktadir."
    
    Insert-AfterText $doc "setup" "Sistem, kurulum gerektirmeyen SQLite veritabanı ile tasınabilir hale getirilmistir. Zip dosyasindaki 'start.bat' dosyasina cift tiklandiginda backend sunucusu ve Android emulator otomatik olarak ayaga kalkmaktadir."
    
    Insert-AfterText $doc "tercih edilme" "LojistikYol, modern lojistik sektorunun en buyuk ihtiyaclarindan olan guvenli odeme, seffaf fiyat teklifleri ve dijital evrak takibi problemlerini akilli cozumlerle gideren yuksek kullanilabilirlige sahip bir platformdur."
    
    Insert-AfterText $doc "katk" "Bu proje surecinde; Flutter'da durum yonetimi (Provider), .NET Web API tasarimi, EF Core veritabanı gocleri (Migrations) ve yapay zeka OCR kutuphaneleriyle calisma konularinda kapsamli pratik deneyimler edinilmistir."

    Write-Host "Updating Function Point Analysis Table inside the document..."
    # 3. Update Function Point Table dynamically
    foreach ($table in $doc.Tables) {
        try {
            $cellText = $table.Cell(1, 1).Range.Text
            if ($cellText -like "*Olcum*" -or $cellText -like "*Ölçüm*") {
                Write-Host "Found Function Point table, updating values..."
                
                # Update Sayı and Toplam columns
                $table.Cell(2, 2).Range.Text = "5"
                $table.Cell(2, 4).Range.Text = "15"
                
                $table.Cell(3, 2).Range.Text = "5"
                $table.Cell(3, 4).Range.Text = "20"
                
                $table.Cell(4, 2).Range.Text = "8"
                $table.Cell(4, 4).Range.Text = "56"
                
                $table.Cell(5, 2).Range.Text = "9"
                $table.Cell(5, 4).Range.Text = "45"
            }
        } catch {
            # Skip tables that don't match index bounds
        }
    }
    
    # 4. Save and close document
    Write-Host "Saving modified document..."
    $doc.Save()
    $doc.Close()
    $word.Quit()
    
    Write-Host "Report completed successfully!"
} catch {
    Write-Host "Error occurred: $_"
    if ($null -ne $word) { $word.Quit() }
}
