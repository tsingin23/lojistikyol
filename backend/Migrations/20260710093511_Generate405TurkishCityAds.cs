using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Generate405TurkishCityAds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "CargoImageUrl", "CargoValue", "Description", "DistanceKm", "EndLocation", "FloorPrice", "FuelConsumptionRate", "RequiredLevel", "SenderId", "StartLocation", "Status", "Title", "VerificationCode" },
                values: new object[,]
                {
                    { 1000, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 271000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 219.0, "Samsun", 1910m, 13.0, 1, 1, "Adana", "Active", "Adana - Samsun Oto Yedek Parça Nakliyesi", "LY-5616" },
                    { 1001, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 263000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 299.0, "Tunceli", 2677m, 16.0, 1, 1, "Adana", "Active", "Adana - Tunceli İnşaat Malzemeleri Götürme", "LY-5657" },
                    { 1002, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 93000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 590.0, "Yozgat", 5313m, 20.0, 1, 1, "Adana", "Active", "Adana - Yozgat Karton Kutu Ambalajları", "LY-5859" },
                    { 1003, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 353000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 225.0, "Sivas", 3823m, 33.0, 2, 1, "Adana", "Active", "Adana - Sivas Paletli Gıda Kolileri", "LY-3773" },
                    { 1004, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 407000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 103.0, "Zonguldak", 1855m, 23.0, 3, 1, "Adana", "Active", "Adana - Zonguldak İnşaat Malzemeleri Götürme", "LY-1237" },
                    { 1005, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 140000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 632.0, "Uşak", 3674m, 12.0, 3, 1, "Adıyaman", "Active", "Adıyaman - Uşak Oto Yedek Parça Nakliyesi", "LY-2292" },
                    { 1006, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 222000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 538.0, "Muş", 3089m, 11.0, 3, 1, "Adıyaman", "Active", "Adıyaman - Muş Plastik Hammadde Sevkiyatı", "LY-1119" },
                    { 1007, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 54000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 158.0, "Edirne", 2324m, 28.0, 2, 1, "Adıyaman", "Active", "Adıyaman - Edirne Tekstil Ürünleri Sevkiyatı", "LY-4952" },
                    { 1008, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 26000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 107.0, "Kocaeli", 1853m, 31.0, 1, 1, "Adıyaman", "Active", "Adıyaman - Kocaeli Tekstil Ürünleri Sevkiyatı", "LY-1310" },
                    { 1009, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 316000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 492.0, "Iğdır", 4555m, 19.0, 1, 1, "Adıyaman", "Active", "Adıyaman - Iğdır İnşaat Malzemeleri Götürme", "LY-4932" },
                    { 1010, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 456000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 440.0, "Malatya", 3948m, 17.0, 2, 1, "Afyonkarahisar", "Active", "Afyonkarahisar - Malatya Karton Kutu Ambalajları", "LY-8935" },
                    { 1011, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 69000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 704.0, "Gaziantep", 4511m, 14.0, 2, 1, "Afyonkarahisar", "Active", "Afyonkarahisar - Gaziantep İnşaat Malzemeleri Götürme", "LY-2336" },
                    { 1012, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 494000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 602.0, "Çankırı", 6532m, 23.0, 3, 1, "Afyonkarahisar", "Active", "Afyonkarahisar - Çankırı Plastik Hammadde Sevkiyatı", "LY-3605" },
                    { 1013, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 186000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 653.0, "Düzce", 3298m, 10.0, 3, 1, "Afyonkarahisar", "Active", "Afyonkarahisar - Düzce Tekstil Ürünleri Sevkiyatı", "LY-3388" },
                    { 1014, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 65000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 603.0, "Çankırı", 5389m, 20.0, 3, 1, "Afyonkarahisar", "Active", "Afyonkarahisar - Çankırı Paletli Gıda Kolileri", "LY-3891" },
                    { 1015, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 40000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 801.0, "Trabzon", 3744m, 10.0, 3, 1, "Ağrı", "Active", "Ağrı - Trabzon Tarım Gübresi ve Tohum", "LY-9335" },
                    { 1016, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 320000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 563.0, "Elazığ", 6675m, 26.0, 1, 1, "Ağrı", "Active", "Ağrı - Elazığ Oto Yedek Parça Nakliyesi", "LY-1266" },
                    { 1017, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 85000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 939.0, "Iğdır", 11853m, 30.0, 3, 1, "Ağrı", "Active", "Ağrı - Iğdır Paletli Gıda Kolileri", "LY-6039" },
                    { 1018, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 208000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 203.0, "Sivas", 2738m, 25.0, 3, 1, "Ağrı", "Active", "Ağrı - Sivas Mobilya ve Ev Eşyası Taşıma", "LY-9674" },
                    { 1019, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 81000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 905.0, "Malatya", 11803m, 31.0, 1, 1, "Ağrı", "Active", "Ağrı - Malatya Tekstil Ürünleri Sevkiyatı", "LY-9462" },
                    { 1020, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 80000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 602.0, "Mersin", 5396m, 20.0, 3, 1, "Amasya", "Active", "Amasya - Mersin Makine Teçhizat Parçaları", "LY-2553" },
                    { 1021, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 415000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 623.0, "Malatya", 9388m, 34.0, 3, 1, "Amasya", "Active", "Amasya - Malatya Oto Yedek Parça Nakliyesi", "LY-5730" },
                    { 1022, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 111000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 854.0, "Diyarbakır", 9834m, 27.0, 1, 1, "Amasya", "Active", "Amasya - Diyarbakır Oto Yedek Parça Nakliyesi", "LY-6760" },
                    { 1023, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 394000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 784.0, "İzmir", 10929m, 32.0, 3, 1, "Amasya", "Active", "Amasya - İzmir Makine Teçhizat Parçaları", "LY-9016" },
                    { 1024, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 325000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 599.0, "Bitlis", 4419m, 15.0, 2, 1, "Amasya", "Active", "Amasya - Bitlis Karton Kutu Ambalajları", "LY-8254" },
                    { 1025, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 274000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 712.0, "Kütahya", 5046m, 15.0, 3, 1, "Ankara", "Active", "Ankara - Kütahya Beyaz Eşya Dağıtımı", "LY-9412" },
                    { 1026, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 102000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 282.0, "Amasya", 2632m, 18.0, 1, 1, "Ankara", "Active", "Ankara - Amasya Oto Yedek Parça Nakliyesi", "LY-5230" },
                    { 1027, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 500000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 748.0, "Kastamonu", 9078m, 27.0, 2, 1, "Ankara", "Active", "Ankara - Kastamonu Tarım Gübresi ve Tohum", "LY-2651" },
                    { 1028, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 479000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 620.0, "Muş", 5939m, 20.0, 1, 1, "Ankara", "Active", "Ankara - Muş Mobilya ve Ev Eşyası Taşıma", "LY-3811" },
                    { 1029, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 163000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 857.0, "Batman", 4091m, 10.0, 2, 1, "Ankara", "Active", "Ankara - Batman Tekstil Ürünleri Sevkiyatı", "LY-4698" },
                    { 1030, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 472000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 936.0, "Sakarya", 7337m, 17.0, 3, 1, "Antalya", "Active", "Antalya - Sakarya Tekstil Ürünleri Sevkiyatı", "LY-6915" },
                    { 1031, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 185000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 543.0, "Siirt", 4812m, 19.0, 1, 1, "Antalya", "Active", "Antalya - Siirt Plastik Hammadde Sevkiyatı", "LY-6449" },
                    { 1032, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 425000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 184.0, "Sakarya", 1882m, 13.0, 1, 1, "Antalya", "Active", "Antalya - Sakarya Makine Teçhizat Parçaları", "LY-1005" },
                    { 1033, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 329000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 232.0, "Gümüşhane", 2128m, 14.0, 1, 1, "Antalya", "Active", "Antalya - Gümüşhane Makine Teçhizat Parçaları", "LY-6902" },
                    { 1034, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 191000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 654.0, "Ordu", 9062m, 32.0, 2, 1, "Antalya", "Active", "Antalya - Ordu Mobilya ve Ev Eşyası Taşıma", "LY-2758" },
                    { 1035, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 217000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 556.0, "Manisa", 6722m, 27.0, 2, 1, "Artvin", "Active", "Artvin - Manisa Makine Teçhizat Parçaları", "LY-3030" },
                    { 1036, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 172000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 791.0, "Malatya", 9531m, 28.0, 2, 1, "Artvin", "Active", "Artvin - Malatya Karton Kutu Ambalajları", "LY-9908" },
                    { 1037, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 222000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 135.0, "Karaman", 1802m, 20.0, 1, 1, "Artvin", "Active", "Artvin - Karaman Beyaz Eşya Dağıtımı", "LY-1016" },
                    { 1038, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 363000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 362.0, "Kayseri", 4049m, 22.0, 2, 1, "Artvin", "Active", "Artvin - Kayseri Tekstil Ürünleri Sevkiyatı", "LY-8172" },
                    { 1039, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 120000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 898.0, "Bartın", 8882m, 23.0, 3, 1, "Artvin", "Active", "Artvin - Bartın Tarım Gübresi ve Tohum", "LY-6758" },
                    { 1040, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 72000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 375.0, "Kocaeli", 2222m, 11.0, 3, 1, "Aydın", "Active", "Aydın - Kocaeli Plastik Hammadde Sevkiyatı", "LY-6121" },
                    { 1041, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 72000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 214.0, "Hatay", 2198m, 19.0, 1, 1, "Aydın", "Active", "Aydın - Hatay Plastik Hammadde Sevkiyatı", "LY-3118" },
                    { 1042, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 307000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 801.0, "Zonguldak", 7215m, 20.0, 1, 1, "Aydın", "Active", "Aydın - Zonguldak Karton Kutu Ambalajları", "LY-5899" },
                    { 1043, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 275000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 653.0, "Adana", 3909m, 12.0, 3, 1, "Aydın", "Active", "Aydın - Adana Beyaz Eşya Dağıtımı", "LY-9111" },
                    { 1044, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 433000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 399.0, "Şırnak", 4125m, 20.0, 3, 1, "Aydın", "Active", "Aydın - Şırnak Tarım Gübresi ve Tohum", "LY-8300" },
                    { 1045, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 427000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 778.0, "Artvin", 11508m, 34.0, 1, 1, "Balıkesir", "Active", "Balıkesir - Artvin Karton Kutu Ambalajları", "LY-8256" },
                    { 1046, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 150000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 870.0, "Kars", 5870m, 15.0, 3, 1, "Balıkesir", "Active", "Balıkesir - Kars İnşaat Malzemeleri Götürme", "LY-9265" },
                    { 1047, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 428000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 819.0, "Amasya", 7152m, 19.0, 2, 1, "Balıkesir", "Active", "Balıkesir - Amasya Paletli Gıda Kolileri", "LY-2187" },
                    { 1048, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 286000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 923.0, "Konya", 4478m, 10.0, 2, 1, "Balıkesir", "Active", "Balıkesir - Konya İnşaat Malzemeleri Götürme", "LY-2792" },
                    { 1049, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 291000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 494.0, "Bitlis", 4545m, 19.0, 3, 1, "Balıkesir", "Active", "Balıkesir - Bitlis Karton Kutu Ambalajları", "LY-9950" },
                    { 1050, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 156000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 551.0, "Niğde", 3080m, 11.0, 3, 1, "Bilecik", "Active", "Bilecik - Niğde Makine Teçhizat Parçaları", "LY-9679" },
                    { 1051, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 439000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 446.0, "Denizli", 6469m, 31.0, 1, 1, "Bilecik", "Active", "Bilecik - Denizli Tarım Gübresi ve Tohum", "LY-8541" },
                    { 1052, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 87000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 312.0, "Şırnak", 4581m, 32.0, 2, 1, "Bilecik", "Active", "Bilecik - Şırnak Plastik Hammadde Sevkiyatı", "LY-7887" },
                    { 1053, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 87000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 340.0, "Samsun", 3171m, 19.0, 1, 1, "Bilecik", "Active", "Bilecik - Samsun Paletli Gıda Kolileri", "LY-5616" },
                    { 1054, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 321000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 682.0, "Kayseri", 4640m, 14.0, 3, 1, "Bilecik", "Active", "Bilecik - Kayseri İnşaat Malzemeleri Götürme", "LY-9640" },
                    { 1055, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 286000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 338.0, "Erzincan", 3490m, 20.0, 1, 1, "Bingöl", "Active", "Bingöl - Erzincan Paletli Gıda Kolileri", "LY-4475" },
                    { 1056, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 226000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 506.0, "Muş", 7405m, 33.0, 3, 1, "Bingöl", "Active", "Bingöl - Muş Paletli Gıda Kolileri", "LY-2836" },
                    { 1057, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 366000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 184.0, "Yalova", 2117m, 17.0, 2, 1, "Bingöl", "Active", "Bingöl - Yalova Beyaz Eşya Dağıtımı", "LY-9869" },
                    { 1058, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 272000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 323.0, "Niğde", 3614m, 22.0, 1, 1, "Bingöl", "Active", "Bingöl - Niğde Plastik Hammadde Sevkiyatı", "LY-2573" },
                    { 1059, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 128000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 205.0, "Ağrı", 1776m, 14.0, 1, 1, "Bingöl", "Active", "Bingöl - Ağrı Karton Kutu Ambalajları", "LY-9017" },
                    { 1060, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 40000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 132.0, "Kars", 2230m, 32.0, 1, 1, "Bitlis", "Active", "Bitlis - Kars Beyaz Eşya Dağıtımı", "LY-8797" },
                    { 1061, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 437000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 579.0, "Ağrı", 8580m, 33.0, 1, 1, "Bitlis", "Active", "Bitlis - Ağrı Paletli Gıda Kolileri", "LY-3672" },
                    { 1062, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 139000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 166.0, "Edirne", 1502m, 13.0, 1, 1, "Bitlis", "Active", "Bitlis - Edirne Plastik Hammadde Sevkiyatı", "LY-4858" },
                    { 1063, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 292000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 714.0, "Konya", 10217m, 33.0, 2, 1, "Bitlis", "Active", "Bitlis - Konya Mobilya ve Ev Eşyası Taşıma", "LY-1321" },
                    { 1064, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 454000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 598.0, "Erzincan", 3824m, 12.0, 3, 1, "Bitlis", "Active", "Bitlis - Erzincan Mobilya ve Ev Eşyası Taşıma", "LY-3083" },
                    { 1065, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 43000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 250.0, "Muğla", 1643m, 11.0, 1, 1, "Bolu", "Active", "Bolu - Muğla Makine Teçhizat Parçaları", "LY-1860" },
                    { 1066, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 122000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 263.0, "Batman", 3988m, 32.0, 2, 1, "Bolu", "Active", "Bolu - Batman Karton Kutu Ambalajları", "LY-2461" },
                    { 1067, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 219000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 504.0, "Osmaniye", 3743m, 15.0, 2, 1, "Bolu", "Active", "Bolu - Osmaniye Tekstil Ürünleri Sevkiyatı", "LY-7281" },
                    { 1068, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 352000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 410.0, "Adıyaman", 3312m, 15.0, 2, 1, "Bolu", "Active", "Bolu - Adıyaman Makine Teçhizat Parçaları", "LY-1410" },
                    { 1069, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 485000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 492.0, "Afyonkarahisar", 5315m, 22.0, 3, 1, "Bolu", "Active", "Bolu - Afyonkarahisar Oto Yedek Parça Nakliyesi", "LY-6600" },
                    { 1070, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 204000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 167.0, "Ankara", 1639m, 14.0, 2, 1, "Burdur", "Active", "Burdur - Ankara Plastik Hammadde Sevkiyatı", "LY-8415" },
                    { 1071, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 23000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 240.0, "Mersin", 3499m, 31.0, 3, 1, "Burdur", "Active", "Burdur - Mersin Beyaz Eşya Dağıtımı", "LY-6296" },
                    { 1072, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 481000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 264.0, "Muğla", 4043m, 29.0, 1, 1, "Burdur", "Active", "Burdur - Muğla İnşaat Malzemeleri Götürme", "LY-5120" },
                    { 1073, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 475000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 106.0, "Sakarya", 1950m, 23.0, 3, 1, "Burdur", "Active", "Burdur - Sakarya Karton Kutu Ambalajları", "LY-2026" },
                    { 1074, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 277000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 637.0, "Malatya", 9440m, 34.0, 2, 1, "Burdur", "Active", "Burdur - Malatya Plastik Hammadde Sevkiyatı", "LY-6701" },
                    { 1075, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 477000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 122.0, "Kars", 2197m, 25.0, 3, 1, "Bursa", "Active", "Bursa - Kars İnşaat Malzemeleri Götürme", "LY-1791" },
                    { 1076, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 405000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 187.0, "Aydın", 3373m, 33.0, 3, 1, "Bursa", "Active", "Bursa - Aydın Makine Teçhizat Parçaları", "LY-6967" },
                    { 1077, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 56000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 488.0, "Denizli", 4655m, 21.0, 3, 1, "Bursa", "Active", "Bursa - Denizli Karton Kutu Ambalajları", "LY-7019" },
                    { 1078, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 77000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 144.0, "Uşak", 2363m, 31.0, 3, 1, "Bursa", "Active", "Bursa - Uşak Beyaz Eşya Dağıtımı", "LY-1331" },
                    { 1079, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 86000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 697.0, "Aydın", 5047m, 16.0, 2, 1, "Bursa", "Active", "Bursa - Aydın Plastik Hammadde Sevkiyatı", "LY-1881" },
                    { 1080, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 499000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 725.0, "Sivas", 9119m, 28.0, 2, 1, "Çanakkale", "Active", "Çanakkale - Sivas Karton Kutu Ambalajları", "LY-9334" },
                    { 1081, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 421000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 405.0, "Kastamonu", 3351m, 15.0, 1, 1, "Çanakkale", "Active", "Çanakkale - Kastamonu Tekstil Ürünleri Sevkiyatı", "LY-7765" },
                    { 1082, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 194000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 933.0, "Nevşehir", 7412m, 18.0, 1, 1, "Çanakkale", "Active", "Çanakkale - Nevşehir Tarım Gübresi ve Tohum", "LY-8914" },
                    { 1083, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 391000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 188.0, "Mardin", 1718m, 11.0, 3, 1, "Çanakkale", "Active", "Çanakkale - Mardin Karton Kutu Ambalajları", "LY-2833" },
                    { 1084, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 73000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 764.0, "Çorum", 7602m, 23.0, 1, 1, "Çanakkale", "Active", "Çanakkale - Çorum Tarım Gübresi ve Tohum", "LY-1316" },
                    { 1085, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 365000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 669.0, "Elazığ", 4611m, 14.0, 2, 1, "Çankırı", "Active", "Çankırı - Elazığ Plastik Hammadde Sevkiyatı", "LY-2057" },
                    { 1086, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 247000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 460.0, "Gümüşhane", 6635m, 32.0, 2, 1, "Çankırı", "Active", "Çankırı - Gümüşhane Karton Kutu Ambalajları", "LY-8393" },
                    { 1087, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 62000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 604.0, "Siirt", 6119m, 23.0, 3, 1, "Çankırı", "Active", "Çankırı - Siirt Paletli Gıda Kolileri", "LY-9724" },
                    { 1088, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 499000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 669.0, "Kocaeli", 6619m, 21.0, 1, 1, "Çankırı", "Active", "Çankırı - Kocaeli Paletli Gıda Kolileri", "LY-6433" },
                    { 1089, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 94000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 427.0, "İstanbul", 3839m, 19.0, 1, 1, "Çankırı", "Active", "Çankırı - İstanbul Beyaz Eşya Dağıtımı", "LY-8669" },
                    { 1090, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 193000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 363.0, "Isparta", 5194m, 31.0, 1, 1, "Çorum", "Active", "Çorum - Isparta Tekstil Ürünleri Sevkiyatı", "LY-4175" },
                    { 1091, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 499000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 258.0, "Sivas", 4198m, 31.0, 2, 1, "Çorum", "Active", "Çorum - Sivas Plastik Hammadde Sevkiyatı", "LY-2851" },
                    { 1092, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 334000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 400.0, "Diyarbakır", 2914m, 13.0, 1, 1, "Çorum", "Active", "Çorum - Diyarbakır Tekstil Ürünleri Sevkiyatı", "LY-8448" },
                    { 1093, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 459000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 548.0, "Tunceli", 6001m, 23.0, 1, 1, "Çorum", "Active", "Çorum - Tunceli Makine Teçhizat Parçaları", "LY-8205" },
                    { 1094, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 212000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 215.0, "Siirt", 2862m, 25.0, 3, 1, "Çorum", "Active", "Çorum - Siirt Makine Teçhizat Parçaları", "LY-6429" },
                    { 1095, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 347000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 454.0, "Kastamonu", 6658m, 32.0, 1, 1, "Denizli", "Active", "Denizli - Kastamonu Tarım Gübresi ve Tohum", "LY-8132" },
                    { 1096, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 395000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 720.0, "Hakkari", 4639m, 13.0, 3, 1, "Denizli", "Active", "Denizli - Hakkari Oto Yedek Parça Nakliyesi", "LY-5254" },
                    { 1097, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 435000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 774.0, "Manisa", 4960m, 13.0, 2, 1, "Denizli", "Active", "Denizli - Manisa Karton Kutu Ambalajları", "LY-4657" },
                    { 1098, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 127000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 824.0, "Bayburt", 8867m, 25.0, 2, 1, "Denizli", "Active", "Denizli - Bayburt Beyaz Eşya Dağıtımı", "LY-1086" },
                    { 1099, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 342000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 164.0, "Muğla", 2285m, 22.0, 3, 1, "Denizli", "Active", "Denizli - Muğla Oto Yedek Parça Nakliyesi", "LY-3620" },
                    { 1100, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 192000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 867.0, "Konya", 6241m, 16.0, 3, 1, "Diyarbakır", "Active", "Diyarbakır - Konya Oto Yedek Parça Nakliyesi", "LY-6005" },
                    { 1101, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 76000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 599.0, "Elazığ", 3212m, 11.0, 2, 1, "Diyarbakır", "Active", "Diyarbakır - Elazığ Plastik Hammadde Sevkiyatı", "LY-3702" },
                    { 1102, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 303000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 216.0, "Bartın", 2013m, 14.0, 1, 1, "Diyarbakır", "Active", "Diyarbakır - Bartın Tarım Gübresi ve Tohum", "LY-1220" },
                    { 1103, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 449000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 851.0, "Hakkari", 4353m, 10.0, 2, 1, "Diyarbakır", "Active", "Diyarbakır - Hakkari Tekstil Ürünleri Sevkiyatı", "LY-5726" },
                    { 1104, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 160000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 514.0, "Aksaray", 2922m, 11.0, 1, 1, "Diyarbakır", "Active", "Diyarbakır - Aksaray Makine Teçhizat Parçaları", "LY-4334" },
                    { 1105, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 407000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 496.0, "Giresun", 5073m, 21.0, 3, 1, "Edirne", "Active", "Edirne - Giresun Mobilya ve Ev Eşyası Taşıma", "LY-6102" },
                    { 1106, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 184000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 882.0, "Batman", 10915m, 29.0, 2, 1, "Edirne", "Active", "Edirne - Batman Karton Kutu Ambalajları", "LY-7637" },
                    { 1107, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 29000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 423.0, "Uşak", 3067m, 15.0, 2, 1, "Edirne", "Active", "Edirne - Uşak Paletli Gıda Kolileri", "LY-9580" },
                    { 1108, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 116000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 626.0, "Batman", 3120m, 10.0, 3, 1, "Edirne", "Active", "Edirne - Batman Karton Kutu Ambalajları", "LY-5441" },
                    { 1109, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 289000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 572.0, "Kilis", 3077m, 10.0, 2, 1, "Edirne", "Active", "Edirne - Kilis Tarım Gübresi ve Tohum", "LY-8024" },
                    { 1110, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 160000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 518.0, "Tokat", 7705m, 34.0, 2, 1, "Elazığ", "Active", "Elazığ - Tokat İnşaat Malzemeleri Götürme", "LY-9701" },
                    { 1111, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 169000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 370.0, "Çankırı", 2149m, 10.0, 2, 1, "Elazığ", "Active", "Elazığ - Çankırı Makine Teçhizat Parçaları", "LY-4876" },
                    { 1112, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 20000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 679.0, "Bingöl", 3779m, 12.0, 3, 1, "Elazığ", "Active", "Elazığ - Bingöl Tekstil Ürünleri Sevkiyatı", "LY-9388" },
                    { 1113, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 205000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 288.0, "Samsun", 4161m, 30.0, 1, 1, "Elazığ", "Active", "Elazığ - Samsun Plastik Hammadde Sevkiyatı", "LY-4757" },
                    { 1114, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 320000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 599.0, "Karaman", 4414m, 15.0, 3, 1, "Elazığ", "Active", "Elazığ - Karaman Tarım Gübresi ve Tohum", "LY-3250" },
                    { 1115, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 55000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 657.0, "Manisa", 9227m, 33.0, 3, 1, "Erzincan", "Active", "Erzincan - Manisa Paletli Gıda Kolileri", "LY-7804" },
                    { 1116, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 465000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 726.0, "Kütahya", 8515m, 26.0, 1, 1, "Erzincan", "Active", "Erzincan - Kütahya Mobilya ve Ev Eşyası Taşıma", "LY-6808" },
                    { 1117, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 181000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 808.0, "Bursa", 5529m, 15.0, 3, 1, "Erzincan", "Active", "Erzincan - Bursa Oto Yedek Parça Nakliyesi", "LY-8194" },
                    { 1118, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 118000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 540.0, "Tekirdağ", 7098m, 30.0, 1, 1, "Erzincan", "Active", "Erzincan - Tekirdağ Plastik Hammadde Sevkiyatı", "LY-6955" },
                    { 1119, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 331000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 606.0, "Elazığ", 5194m, 18.0, 2, 1, "Erzincan", "Active", "Erzincan - Elazığ İnşaat Malzemeleri Götürme", "LY-9916" },
                    { 1120, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 387000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 889.0, "Bayburt", 9066m, 23.0, 2, 1, "Erzurum", "Active", "Erzurum - Bayburt Oto Yedek Parça Nakliyesi", "LY-6272" },
                    { 1121, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 342000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 279.0, "Osmaniye", 4413m, 32.0, 2, 1, "Erzurum", "Active", "Erzurum - Osmaniye Paletli Gıda Kolileri", "LY-2330" },
                    { 1122, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 51000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 536.0, "Eskişehir", 8055m, 35.0, 2, 1, "Erzurum", "Active", "Erzurum - Eskişehir Paletli Gıda Kolileri", "LY-1447" },
                    { 1123, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 386000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 369.0, "Manisa", 5462m, 31.0, 3, 1, "Erzurum", "Active", "Erzurum - Manisa Beyaz Eşya Dağıtımı", "LY-8837" },
                    { 1124, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 56000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 184.0, "Karabük", 2322m, 24.0, 2, 1, "Erzurum", "Active", "Erzurum - Karabük Oto Yedek Parça Nakliyesi", "LY-5053" },
                    { 1125, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 182000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 940.0, "Nevşehir", 6322m, 15.0, 2, 1, "Eskişehir", "Active", "Eskişehir - Nevşehir Paletli Gıda Kolileri", "LY-7032" },
                    { 1126, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 297000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 833.0, "Bayburt", 4795m, 12.0, 2, 1, "Eskişehir", "Active", "Eskişehir - Bayburt Paletli Gıda Kolileri", "LY-1381" },
                    { 1127, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 76000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 482.0, "Bingöl", 2697m, 11.0, 3, 1, "Eskişehir", "Active", "Eskişehir - Bingöl Oto Yedek Parça Nakliyesi", "LY-2704" },
                    { 1128, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 398000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 307.0, "Trabzon", 4828m, 32.0, 1, 1, "Eskişehir", "Active", "Eskişehir - Trabzon Makine Teçhizat Parçaları", "LY-3868" },
                    { 1129, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 359000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 274.0, "Çorum", 4585m, 34.0, 2, 1, "Eskişehir", "Active", "Eskişehir - Çorum Paletli Gıda Kolileri", "LY-7982" },
                    { 1130, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 194000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 424.0, "Diyarbakır", 4934m, 25.0, 2, 1, "Gaziantep", "Active", "Gaziantep - Diyarbakır Beyaz Eşya Dağıtımı", "LY-7646" },
                    { 1131, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 485000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 518.0, "Gümüşhane", 3057m, 10.0, 2, 1, "Gaziantep", "Active", "Gaziantep - Gümüşhane Paletli Gıda Kolileri", "LY-5673" },
                    { 1132, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 75000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 151.0, "Erzincan", 2206m, 27.0, 3, 1, "Gaziantep", "Active", "Gaziantep - Erzincan Paletli Gıda Kolileri", "LY-5241" },
                    { 1133, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 465000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 471.0, "Bitlis", 7371m, 34.0, 3, 1, "Gaziantep", "Active", "Gaziantep - Bitlis Oto Yedek Parça Nakliyesi", "LY-7470" },
                    { 1134, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 155000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 431.0, "Malatya", 6172m, 32.0, 3, 1, "Gaziantep", "Active", "Gaziantep - Malatya Mobilya ve Ev Eşyası Taşıma", "LY-4762" },
                    { 1135, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 389000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 319.0, "Amasya", 4845m, 31.0, 3, 1, "Giresun", "Active", "Giresun - Amasya Makine Teçhizat Parçaları", "LY-1851" },
                    { 1136, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 228000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 217.0, "Gaziantep", 2898m, 25.0, 1, 1, "Giresun", "Active", "Giresun - Gaziantep Makine Teçhizat Parçaları", "LY-9582" },
                    { 1137, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 405000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 463.0, "Ağrı", 6276m, 29.0, 3, 1, "Giresun", "Active", "Giresun - Ağrı Plastik Hammadde Sevkiyatı", "LY-5115" },
                    { 1138, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 132000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 109.0, "Kahramanmaraş", 1460m, 19.0, 1, 1, "Giresun", "Active", "Giresun - Kahramanmaraş İnşaat Malzemeleri Götürme", "LY-1703" },
                    { 1139, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 495000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 426.0, "Düzce", 5766m, 28.0, 1, 1, "Giresun", "Active", "Giresun - Düzce Plastik Hammadde Sevkiyatı", "LY-9094" },
                    { 1140, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 480000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 182.0, "Çorum", 1999m, 14.0, 2, 1, "Gümüşhane", "Active", "Gümüşhane - Çorum Karton Kutu Ambalajları", "LY-9370" },
                    { 1141, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 111000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 313.0, "Ankara", 3491m, 23.0, 2, 1, "Gümüşhane", "Active", "Gümüşhane - Ankara Oto Yedek Parça Nakliyesi", "LY-2316" },
                    { 1142, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 111000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 182.0, "Giresun", 3159m, 35.0, 1, 1, "Gümüşhane", "Active", "Gümüşhane - Giresun Paletli Gıda Kolileri", "LY-7821" },
                    { 1143, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 80000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 144.0, "Muğla", 1444m, 15.0, 1, 1, "Gümüşhane", "Active", "Gümüşhane - Muğla Tarım Gübresi ve Tohum", "LY-2263" },
                    { 1144, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 333000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 612.0, "Kilis", 6219m, 22.0, 1, 1, "Gümüşhane", "Active", "Gümüşhane - Kilis Oto Yedek Parça Nakliyesi", "LY-3524" },
                    { 1145, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 239000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 788.0, "Sinop", 11771m, 35.0, 1, 1, "Hakkari", "Active", "Hakkari - Sinop Tekstil Ürünleri Sevkiyatı", "LY-2390" },
                    { 1146, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 23000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 134.0, "Muğla", 1059m, 10.0, 1, 1, "Hakkari", "Active", "Hakkari - Muğla Karton Kutu Ambalajları", "LY-6044" },
                    { 1147, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 346000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 899.0, "Uşak", 13072m, 34.0, 1, 1, "Hakkari", "Active", "Hakkari - Uşak Oto Yedek Parça Nakliyesi", "LY-8834" },
                    { 1148, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 395000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 682.0, "Muş", 3623m, 10.0, 3, 1, "Hakkari", "Active", "Hakkari - Muş Tarım Gübresi ve Tohum", "LY-9991" },
                    { 1149, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 84000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 206.0, "Muğla", 3303m, 33.0, 2, 1, "Hakkari", "Active", "Hakkari - Muğla Paletli Gıda Kolileri", "LY-5320" },
                    { 1150, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 367000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 920.0, "Gümüşhane", 7491m, 18.0, 2, 1, "Hatay", "Active", "Hatay - Gümüşhane Beyaz Eşya Dağıtımı", "LY-6532" },
                    { 1151, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 370000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 113.0, "Batman", 2090m, 27.0, 2, 1, "Hatay", "Active", "Hatay - Batman Oto Yedek Parça Nakliyesi", "LY-9601" },
                    { 1152, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 116000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 786.0, "Van", 5646m, 16.0, 3, 1, "Hatay", "Active", "Hatay - Van Oto Yedek Parça Nakliyesi", "LY-6174" },
                    { 1153, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 397000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 649.0, "Kilis", 5829m, 19.0, 2, 1, "Hatay", "Active", "Hatay - Kilis Plastik Hammadde Sevkiyatı", "LY-5935" },
                    { 1154, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 250000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 842.0, "Çanakkale", 5802m, 15.0, 2, 1, "Hatay", "Active", "Hatay - Çanakkale Paletli Gıda Kolileri", "LY-4964" },
                    { 1155, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 322000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 825.0, "Edirne", 8742m, 24.0, 2, 1, "Isparta", "Active", "Isparta - Edirne Plastik Hammadde Sevkiyatı", "LY-3168" },
                    { 1156, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 55000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 228.0, "Karaman", 2105m, 17.0, 3, 1, "Isparta", "Active", "Isparta - Karaman Makine Teçhizat Parçaları", "LY-4262" },
                    { 1157, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 42000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 185.0, "Kilis", 1948m, 19.0, 2, 1, "Isparta", "Active", "Isparta - Kilis Tekstil Ürünleri Sevkiyatı", "LY-3915" },
                    { 1158, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 52000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 369.0, "Elazığ", 3356m, 19.0, 3, 1, "Isparta", "Active", "Isparta - Elazığ Oto Yedek Parça Nakliyesi", "LY-6023" },
                    { 1159, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 380000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 393.0, "Kırıkkale", 2609m, 11.0, 1, 1, "Isparta", "Active", "Isparta - Kırıkkale Mobilya ve Ev Eşyası Taşıma", "LY-3730" },
                    { 1160, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 152000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 212.0, "Niğde", 3620m, 35.0, 2, 1, "Mersin", "Active", "Mersin - Niğde Tekstil Ürünleri Sevkiyatı", "LY-5453" },
                    { 1161, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 289000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 281.0, "Nevşehir", 2700m, 17.0, 1, 1, "Mersin", "Active", "Mersin - Nevşehir Oto Yedek Parça Nakliyesi", "LY-4696" },
                    { 1162, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 41000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 768.0, "Eskişehir", 6685m, 20.0, 3, 1, "Mersin", "Active", "Mersin - Eskişehir İnşaat Malzemeleri Götürme", "LY-3056" },
                    { 1163, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 487000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 289.0, "Iğdır", 2143m, 10.0, 1, 1, "Mersin", "Active", "Mersin - Iğdır Oto Yedek Parça Nakliyesi", "LY-7745" },
                    { 1164, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 155000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 100.0, "Balıkesir", 2015m, 34.0, 3, 1, "Mersin", "Active", "Mersin - Balıkesir Oto Yedek Parça Nakliyesi", "LY-7055" },
                    { 1165, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 385000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 359.0, "Kars", 2608m, 12.0, 1, 1, "İstanbul", "Active", "İstanbul - Kars Plastik Hammadde Sevkiyatı", "LY-6947" },
                    { 1166, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 319000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 590.0, "Osmaniye", 5067m, 18.0, 1, 1, "İstanbul", "Active", "İstanbul - Osmaniye Paletli Gıda Kolileri", "LY-3560" },
                    { 1167, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 25000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 640.0, "Giresun", 3853m, 13.0, 3, 1, "İstanbul", "Active", "İstanbul - Giresun Beyaz Eşya Dağıtımı", "LY-4805" },
                    { 1168, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 105000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 122.0, "Düzce", 2264m, 34.0, 1, 1, "İstanbul", "Active", "İstanbul - Düzce Paletli Gıda Kolileri", "LY-7804" },
                    { 1169, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 171000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 242.0, "Iğdır", 1639m, 10.0, 2, 1, "İstanbul", "Active", "İstanbul - Iğdır Mobilya ve Ev Eşyası Taşıma", "LY-6679" },
                    { 1170, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 394000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 516.0, "Bayburt", 7705m, 33.0, 1, 1, "İzmir", "Active", "İzmir - Bayburt Beyaz Eşya Dağıtımı", "LY-6052" },
                    { 1171, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 298000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 464.0, "Çanakkale", 4324m, 19.0, 3, 1, "İzmir", "Active", "İzmir - Çanakkale Karton Kutu Ambalajları", "LY-5393" },
                    { 1172, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 126000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 781.0, "Muğla", 7186m, 21.0, 2, 1, "İzmir", "Active", "İzmir - Muğla İnşaat Malzemeleri Götürme", "LY-2206" },
                    { 1173, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 367000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 119.0, "Edirne", 1486m, 13.0, 1, 1, "İzmir", "Active", "İzmir - Edirne İnşaat Malzemeleri Götürme", "LY-3148" },
                    { 1174, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 193000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 279.0, "Kırşehir", 4041m, 30.0, 1, 1, "İzmir", "Active", "İzmir - Kırşehir Beyaz Eşya Dağıtımı", "LY-8149" },
                    { 1175, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 124000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 397.0, "Kahramanmaraş", 4118m, 22.0, 1, 1, "Kars", "Active", "Kars - Kahramanmaraş Tekstil Ürünleri Sevkiyatı", "LY-2501" },
                    { 1176, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 308000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 634.0, "Trabzon", 8923m, 32.0, 2, 1, "Kars", "Active", "Kars - Trabzon Tekstil Ürünleri Sevkiyatı", "LY-7328" },
                    { 1177, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 37000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 513.0, "Şırnak", 3410m, 14.0, 1, 1, "Kars", "Active", "Kars - Şırnak Mobilya ve Ev Eşyası Taşıma", "LY-8117" },
                    { 1178, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 427000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 291.0, "Aksaray", 3837m, 25.0, 1, 1, "Kars", "Active", "Kars - Aksaray Tarım Gübresi ve Tohum", "LY-6977" },
                    { 1179, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 84000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 139.0, "Niğde", 2530m, 35.0, 3, 1, "Kars", "Active", "Kars - Niğde Tekstil Ürünleri Sevkiyatı", "LY-6340" },
                    { 1180, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 367000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 854.0, "Ankara", 10090m, 27.0, 3, 1, "Kastamonu", "Active", "Kastamonu - Ankara Beyaz Eşya Dağıtımı", "LY-2683" },
                    { 1181, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 52000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 551.0, "Bitlis", 3197m, 12.0, 2, 1, "Kastamonu", "Active", "Kastamonu - Bitlis Oto Yedek Parça Nakliyesi", "LY-9582" },
                    { 1182, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 41000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 860.0, "Denizli", 8109m, 22.0, 2, 1, "Kastamonu", "Active", "Kastamonu - Denizli Tarım Gübresi ve Tohum", "LY-8510" },
                    { 1183, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 57000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 746.0, "Manisa", 7719m, 24.0, 2, 1, "Kastamonu", "Active", "Kastamonu - Manisa Plastik Hammadde Sevkiyatı", "LY-8172" },
                    { 1184, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 58000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 188.0, "Nevşehir", 1912m, 18.0, 3, 1, "Kastamonu", "Active", "Kastamonu - Nevşehir Makine Teçhizat Parçaları", "LY-8538" },
                    { 1185, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 376000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 569.0, "Samsun", 7021m, 27.0, 2, 1, "Kayseri", "Active", "Kayseri - Samsun Makine Teçhizat Parçaları", "LY-3236" },
                    { 1186, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 396000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 115.0, "Balıkesir", 1678m, 17.0, 2, 1, "Kayseri", "Active", "Kayseri - Balıkesir Tekstil Ürünleri Sevkiyatı", "LY-5447" },
                    { 1187, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 238000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 168.0, "Tunceli", 3090m, 35.0, 1, 1, "Kayseri", "Active", "Kayseri - Tunceli Beyaz Eşya Dağıtımı", "LY-2068" },
                    { 1188, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 277000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 235.0, "Niğde", 1905m, 12.0, 2, 1, "Kayseri", "Active", "Kayseri - Niğde Karton Kutu Ambalajları", "LY-6602" },
                    { 1189, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 288000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 789.0, "Kilis", 6784m, 19.0, 3, 1, "Kayseri", "Active", "Kayseri - Kilis Oto Yedek Parça Nakliyesi", "LY-7306" },
                    { 1190, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 139000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 803.0, "Niğde", 9311m, 27.0, 1, 1, "Kırklareli", "Active", "Kırklareli - Niğde İnşaat Malzemeleri Götürme", "LY-7786" },
                    { 1191, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 81000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 290.0, "Bitlis", 2553m, 17.0, 2, 1, "Kırklareli", "Active", "Kırklareli - Bitlis Oto Yedek Parça Nakliyesi", "LY-5770" },
                    { 1192, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 268000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 596.0, "Nevşehir", 6013m, 22.0, 1, 1, "Kırklareli", "Active", "Kırklareli - Nevşehir Karton Kutu Ambalajları", "LY-8955" },
                    { 1193, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 348000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 274.0, "Ankara", 2273m, 13.0, 2, 1, "Kırklareli", "Active", "Kırklareli - Ankara Beyaz Eşya Dağıtımı", "LY-7494" },
                    { 1194, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 397000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 416.0, "Bolu", 6555m, 34.0, 1, 1, "Kırklareli", "Active", "Kırklareli - Bolu Karton Kutu Ambalajları", "LY-6379" },
                    { 1195, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 53000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 814.0, "Kilis", 7065m, 20.0, 2, 1, "Kırşehir", "Active", "Kırşehir - Kilis İnşaat Malzemeleri Götürme", "LY-4105" },
                    { 1196, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 444000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 189.0, "Erzincan", 3212m, 30.0, 2, 1, "Kırşehir", "Active", "Kırşehir - Erzincan İnşaat Malzemeleri Götürme", "LY-5102" },
                    { 1197, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 386000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 497.0, "Muş", 6452m, 28.0, 2, 1, "Kırşehir", "Active", "Kırşehir - Muş Plastik Hammadde Sevkiyatı", "LY-9745" },
                    { 1198, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 365000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 798.0, "Bitlis", 8526m, 24.0, 2, 1, "Kırşehir", "Active", "Kırşehir - Bitlis Mobilya ve Ev Eşyası Taşıma", "LY-8337" },
                    { 1199, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 384000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 100.0, "Edirne", 2084m, 30.0, 2, 1, "Kırşehir", "Active", "Kırşehir - Edirne Paletli Gıda Kolileri", "LY-5439" },
                    { 1200, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 97000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 877.0, "Elazığ", 9367m, 25.0, 2, 1, "Kocaeli", "Active", "Kocaeli - Elazığ Oto Yedek Parça Nakliyesi", "LY-2167" },
                    { 1201, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 56000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 520.0, "Çankırı", 6588m, 29.0, 2, 1, "Kocaeli", "Active", "Kocaeli - Çankırı Oto Yedek Parça Nakliyesi", "LY-5706" },
                    { 1202, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 251000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 609.0, "Mardin", 5379m, 19.0, 2, 1, "Kocaeli", "Active", "Kocaeli - Mardin İnşaat Malzemeleri Götürme", "LY-5098" },
                    { 1203, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 180000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 946.0, "Bayburt", 9762m, 24.0, 3, 1, "Kocaeli", "Active", "Kocaeli - Bayburt Tekstil Ürünleri Sevkiyatı", "LY-7196" },
                    { 1204, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 257000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 662.0, "Mardin", 3405m, 10.0, 1, 1, "Kocaeli", "Active", "Kocaeli - Mardin İnşaat Malzemeleri Götürme", "LY-6429" },
                    { 1205, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 269000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 886.0, "Malatya", 7148m, 18.0, 2, 1, "Konya", "Active", "Konya - Malatya Plastik Hammadde Sevkiyatı", "LY-9303" },
                    { 1206, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 157000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 780.0, "Bingöl", 5961m, 17.0, 3, 1, "Konya", "Active", "Konya - Bingöl Tekstil Ürünleri Sevkiyatı", "LY-6037" },
                    { 1207, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 345000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 846.0, "Balıkesir", 9643m, 26.0, 2, 1, "Konya", "Active", "Konya - Balıkesir Karton Kutu Ambalajları", "LY-5332" },
                    { 1208, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 43000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 165.0, "Kütahya", 1995m, 22.0, 3, 1, "Konya", "Active", "Konya - Kütahya Tekstil Ürünleri Sevkiyatı", "LY-8390" },
                    { 1209, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 467000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 378.0, "İzmir", 4596m, 24.0, 2, 1, "Konya", "Active", "Konya - İzmir Makine Teçhizat Parçaları", "LY-4201" },
                    { 1210, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 463000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 343.0, "Kilis", 5353m, 32.0, 1, 1, "Kütahya", "Active", "Kütahya - Kilis Beyaz Eşya Dağıtımı", "LY-6500" },
                    { 1211, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 298000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 828.0, "Bartın", 7091m, 19.0, 2, 1, "Kütahya", "Active", "Kütahya - Bartın Makine Teçhizat Parçaları", "LY-4299" },
                    { 1212, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 275000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 136.0, "Artvin", 1645m, 16.0, 3, 1, "Kütahya", "Active", "Kütahya - Artvin Beyaz Eşya Dağıtımı", "LY-3091" },
                    { 1213, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 324000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 466.0, "Burdur", 6043m, 28.0, 1, 1, "Kütahya", "Active", "Kütahya - Burdur Tarım Gübresi ve Tohum", "LY-2753" },
                    { 1214, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 440000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 137.0, "Muş", 2803m, 34.0, 1, 1, "Kütahya", "Active", "Kütahya - Muş İnşaat Malzemeleri Götürme", "LY-9680" },
                    { 1215, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 95000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 784.0, "Bayburt", 8749m, 26.0, 1, 1, "Malatya", "Active", "Malatya - Bayburt Tekstil Ürünleri Sevkiyatı", "LY-3364" },
                    { 1216, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 190000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 741.0, "Tokat", 10175m, 32.0, 3, 1, "Malatya", "Active", "Malatya - Tokat İnşaat Malzemeleri Götürme", "LY-4851" },
                    { 1217, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 359000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 289.0, "Bursa", 2362m, 13.0, 2, 1, "Malatya", "Active", "Malatya - Bursa Karton Kutu Ambalajları", "LY-7918" },
                    { 1218, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 460000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 285.0, "Kahramanmaraş", 4722m, 33.0, 3, 1, "Malatya", "Active", "Malatya - Kahramanmaraş Tekstil Ürünleri Sevkiyatı", "LY-2691" },
                    { 1219, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 322000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 122.0, "Ardahan", 1749m, 19.0, 1, 1, "Malatya", "Active", "Malatya - Ardahan Makine Teçhizat Parçaları", "LY-3557" },
                    { 1220, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 332000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 307.0, "Bilecik", 2183m, 11.0, 1, 1, "Manisa", "Active", "Manisa - Bilecik Karton Kutu Ambalajları", "LY-6874" },
                    { 1221, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 450000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 219.0, "Amasya", 2439m, 17.0, 2, 1, "Manisa", "Active", "Manisa - Amasya İnşaat Malzemeleri Götürme", "LY-9669" },
                    { 1222, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 429000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 800.0, "Yalova", 4449m, 11.0, 3, 1, "Manisa", "Active", "Manisa - Yalova Tarım Gübresi ve Tohum", "LY-7279" },
                    { 1223, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 99000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 580.0, "Yalova", 3383m, 12.0, 3, 1, "Manisa", "Active", "Manisa - Yalova Oto Yedek Parça Nakliyesi", "LY-6702" },
                    { 1224, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 104000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 874.0, "Tunceli", 12490m, 34.0, 3, 1, "Manisa", "Active", "Manisa - Tunceli Tekstil Ürünleri Sevkiyatı", "LY-3948" },
                    { 1225, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 38000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 119.0, "Balıkesir", 1776m, 26.0, 2, 1, "Kahramanmaraş", "Active", "Kahramanmaraş - Balıkesir Paletli Gıda Kolileri", "LY-1696" },
                    { 1226, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 134000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 341.0, "Hatay", 2953m, 17.0, 3, 1, "Kahramanmaraş", "Active", "Kahramanmaraş - Hatay Beyaz Eşya Dağıtımı", "LY-1694" },
                    { 1227, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 64000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 857.0, "Niğde", 8106m, 22.0, 2, 1, "Kahramanmaraş", "Active", "Kahramanmaraş - Niğde Karton Kutu Ambalajları", "LY-5760" },
                    { 1228, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 37000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 757.0, "Antalya", 10832m, 34.0, 2, 1, "Kahramanmaraş", "Active", "Kahramanmaraş - Antalya Plastik Hammadde Sevkiyatı", "LY-7839" },
                    { 1229, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 485000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 868.0, "Tunceli", 6193m, 15.0, 1, 1, "Kahramanmaraş", "Active", "Kahramanmaraş - Tunceli Plastik Hammadde Sevkiyatı", "LY-9380" },
                    { 1230, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 211000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 538.0, "Diyarbakır", 3509m, 13.0, 3, 1, "Mardin", "Active", "Mardin - Diyarbakır Tarım Gübresi ve Tohum", "LY-6854" },
                    { 1231, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 445000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 123.0, "Muğla", 1978m, 21.0, 1, 1, "Mardin", "Active", "Mardin - Muğla Tarım Gübresi ve Tohum", "LY-8465" },
                    { 1232, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 324000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 384.0, "Malatya", 5125m, 28.0, 2, 1, "Mardin", "Active", "Mardin - Malatya Tekstil Ürünleri Sevkiyatı", "LY-6001" },
                    { 1233, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 433000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 661.0, "Kırıkkale", 7807m, 26.0, 2, 1, "Mardin", "Active", "Mardin - Kırıkkale Plastik Hammadde Sevkiyatı", "LY-5826" },
                    { 1234, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 72000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 683.0, "Bartın", 9588m, 33.0, 1, 1, "Mardin", "Active", "Mardin - Bartın Makine Teçhizat Parçaları", "LY-2594" },
                    { 1235, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 214000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 846.0, "Denizli", 9512m, 26.0, 3, 1, "Muğla", "Active", "Muğla - Denizli Mobilya ve Ev Eşyası Taşıma", "LY-2983" },
                    { 1236, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 84000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 624.0, "Ordu", 3330m, 11.0, 2, 1, "Muğla", "Active", "Muğla - Ordu İnşaat Malzemeleri Götürme", "LY-1714" },
                    { 1237, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 389000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 716.0, "Van", 8622m, 27.0, 2, 1, "Muğla", "Active", "Muğla - Van Karton Kutu Ambalajları", "LY-2680" },
                    { 1238, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 399000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 460.0, "Isparta", 3843m, 16.0, 2, 1, "Muğla", "Active", "Muğla - Isparta Oto Yedek Parça Nakliyesi", "LY-6761" },
                    { 1239, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 125000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 492.0, "Kütahya", 6529m, 30.0, 2, 1, "Muğla", "Active", "Muğla - Kütahya Paletli Gıda Kolileri", "LY-7895" },
                    { 1240, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 314000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 757.0, "Kilis", 5053m, 14.0, 2, 1, "Muş", "Active", "Muş - Kilis Tekstil Ürünleri Sevkiyatı", "LY-4690" },
                    { 1241, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 469000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 506.0, "Ağrı", 5017m, 20.0, 2, 1, "Muş", "Active", "Muş - Ağrı Plastik Hammadde Sevkiyatı", "LY-9175" },
                    { 1242, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 377000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 821.0, "Gümüşhane", 5475m, 14.0, 3, 1, "Muş", "Active", "Muş - Gümüşhane Tarım Gübresi ve Tohum", "LY-2114" },
                    { 1243, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 294000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 589.0, "Çanakkale", 4092m, 14.0, 3, 1, "Muş", "Active", "Muş - Çanakkale Karton Kutu Ambalajları", "LY-8485" },
                    { 1244, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 132000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 760.0, "Kilis", 11272m, 35.0, 3, 1, "Muş", "Active", "Muş - Kilis Tekstil Ürünleri Sevkiyatı", "LY-3103" },
                    { 1245, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 69000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 599.0, "Elazığ", 8236m, 32.0, 3, 1, "Nevşehir", "Active", "Nevşehir - Elazığ Plastik Hammadde Sevkiyatı", "LY-7434" },
                    { 1246, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 165000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 294.0, "Tokat", 4546m, 33.0, 3, 1, "Nevşehir", "Active", "Nevşehir - Tokat İnşaat Malzemeleri Götürme", "LY-7584" },
                    { 1247, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 350000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 501.0, "Erzincan", 6862m, 30.0, 1, 1, "Nevşehir", "Active", "Nevşehir - Erzincan Karton Kutu Ambalajları", "LY-3794" },
                    { 1248, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 102000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 199.0, "Aksaray", 3388m, 35.0, 3, 1, "Nevşehir", "Active", "Nevşehir - Aksaray Plastik Hammadde Sevkiyatı", "LY-4126" },
                    { 1249, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 265000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 182.0, "Tunceli", 2658m, 26.0, 1, 1, "Nevşehir", "Active", "Nevşehir - Tunceli Makine Teçhizat Parçaları", "LY-1602" },
                    { 1250, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 319000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 666.0, "Kocaeli", 8811m, 30.0, 3, 1, "Niğde", "Active", "Niğde - Kocaeli Paletli Gıda Kolileri", "LY-6031" },
                    { 1251, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 64000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 602.0, "Isparta", 5621m, 21.0, 3, 1, "Niğde", "Active", "Niğde - Isparta Plastik Hammadde Sevkiyatı", "LY-5404" },
                    { 1252, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 159000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 575.0, "Iğdır", 4799m, 18.0, 2, 1, "Niğde", "Active", "Niğde - Iğdır Plastik Hammadde Sevkiyatı", "LY-6737" },
                    { 1253, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 400000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 760.0, "Bursa", 5460m, 15.0, 3, 1, "Niğde", "Active", "Niğde - Bursa Tekstil Ürünleri Sevkiyatı", "LY-7957" },
                    { 1254, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 435000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 278.0, "Giresun", 2825m, 17.0, 3, 1, "Niğde", "Active", "Niğde - Giresun İnşaat Malzemeleri Götürme", "LY-3931" },
                    { 1255, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 23000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 664.0, "Artvin", 4773m, 16.0, 3, 1, "Ordu", "Active", "Ordu - Artvin Karton Kutu Ambalajları", "LY-8816" },
                    { 1256, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 91000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 277.0, "Edirne", 1810m, 11.0, 3, 1, "Ordu", "Active", "Ordu - Edirne Oto Yedek Parça Nakliyesi", "LY-9882" },
                    { 1257, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 202000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 604.0, "Malatya", 7467m, 28.0, 3, 1, "Ordu", "Active", "Ordu - Malatya Tekstil Ürünleri Sevkiyatı", "LY-2614" },
                    { 1258, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 499000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 153.0, "Eskişehir", 2468m, 24.0, 2, 1, "Ordu", "Active", "Ordu - Eskişehir Oto Yedek Parça Nakliyesi", "LY-7435" },
                    { 1259, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 245000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 261.0, "Hakkari", 3877m, 30.0, 2, 1, "Ordu", "Active", "Ordu - Hakkari Tekstil Ürünleri Sevkiyatı", "LY-9080" },
                    { 1260, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 56000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 264.0, "Mardin", 2668m, 20.0, 2, 1, "Rize", "Active", "Rize - Mardin Tekstil Ürünleri Sevkiyatı", "LY-3961" },
                    { 1261, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 119000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 701.0, "Amasya", 8751m, 29.0, 1, 1, "Rize", "Active", "Rize - Amasya Tarım Gübresi ve Tohum", "LY-1619" },
                    { 1262, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 409000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 331.0, "Iğdır", 4881m, 30.0, 1, 1, "Rize", "Active", "Rize - Iğdır Paletli Gıda Kolileri", "LY-2109" },
                    { 1263, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 346000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 156.0, "Düzce", 1720m, 14.0, 3, 1, "Rize", "Active", "Rize - Düzce Tekstil Ürünleri Sevkiyatı", "LY-4742" },
                    { 1264, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 294000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 308.0, "Şırnak", 4120m, 27.0, 2, 1, "Rize", "Active", "Rize - Şırnak Tekstil Ürünleri Sevkiyatı", "LY-8452" },
                    { 1265, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 491000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 237.0, "Çorum", 2318m, 14.0, 3, 1, "Sakarya", "Active", "Sakarya - Çorum İnşaat Malzemeleri Götürme", "LY-6635" },
                    { 1266, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 156000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 746.0, "Uşak", 10802m, 34.0, 3, 1, "Sakarya", "Active", "Sakarya - Uşak Oto Yedek Parça Nakliyesi", "LY-6061" },
                    { 1267, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 362000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 421.0, "Malatya", 6419m, 33.0, 3, 1, "Sakarya", "Active", "Sakarya - Malatya Plastik Hammadde Sevkiyatı", "LY-6297" },
                    { 1268, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 349000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 410.0, "Balıkesir", 5933m, 31.0, 1, 1, "Sakarya", "Active", "Sakarya - Balıkesir Mobilya ve Ev Eşyası Taşıma", "LY-9960" },
                    { 1269, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 432000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 110.0, "Niğde", 1416m, 11.0, 2, 1, "Sakarya", "Active", "Sakarya - Niğde Paletli Gıda Kolileri", "LY-7412" },
                    { 1270, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 232000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 616.0, "Amasya", 5660m, 20.0, 2, 1, "Samsun", "Active", "Samsun - Amasya Tarım Gübresi ve Tohum", "LY-9942" },
                    { 1271, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 290000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 543.0, "Balıkesir", 5351m, 21.0, 1, 1, "Samsun", "Active", "Samsun - Balıkesir Mobilya ve Ev Eşyası Taşıma", "LY-1904" },
                    { 1272, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 255000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 181.0, "Van", 2348m, 22.0, 1, 1, "Samsun", "Active", "Samsun - Van Tarım Gübresi ve Tohum", "LY-6181" },
                    { 1273, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 357000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 679.0, "Bursa", 9820m, 33.0, 1, 1, "Samsun", "Active", "Samsun - Bursa Tekstil Ürünleri Sevkiyatı", "LY-7881" },
                    { 1274, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 477000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 673.0, "İzmir", 10399m, 35.0, 3, 1, "Samsun", "Active", "Samsun - İzmir Oto Yedek Parça Nakliyesi", "LY-9852" },
                    { 1275, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 344000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 155.0, "Konya", 2828m, 32.0, 2, 1, "Siirt", "Active", "Siirt - Konya İnşaat Malzemeleri Götürme", "LY-6452" },
                    { 1276, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 284000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 582.0, "Bolu", 5673m, 21.0, 1, 1, "Siirt", "Active", "Siirt - Bolu Karton Kutu Ambalajları", "LY-6828" },
                    { 1277, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 235000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 452.0, "Malatya", 3447m, 15.0, 2, 1, "Siirt", "Active", "Siirt - Malatya İnşaat Malzemeleri Götürme", "LY-1766" },
                    { 1278, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 118000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 818.0, "Edirne", 5853m, 16.0, 2, 1, "Siirt", "Active", "Siirt - Edirne Oto Yedek Parça Nakliyesi", "LY-7957" },
                    { 1279, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 287000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 535.0, "Sinop", 4639m, 18.0, 3, 1, "Siirt", "Active", "Siirt - Sinop Karton Kutu Ambalajları", "LY-8031" },
                    { 1280, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 118000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 843.0, "Kahramanmaraş", 8374m, 23.0, 2, 1, "Sinop", "Active", "Sinop - Kahramanmaraş Oto Yedek Parça Nakliyesi", "LY-5088" },
                    { 1281, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 243000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 156.0, "Edirne", 2053m, 21.0, 1, 1, "Sinop", "Active", "Sinop - Edirne Oto Yedek Parça Nakliyesi", "LY-6984" },
                    { 1282, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 127000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 919.0, "Hatay", 4671m, 11.0, 1, 1, "Sinop", "Active", "Sinop - Hatay İnşaat Malzemeleri Götürme", "LY-6730" },
                    { 1283, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 263000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 930.0, "Osmaniye", 10435m, 26.0, 1, 1, "Sinop", "Active", "Sinop - Osmaniye Tarım Gübresi ve Tohum", "LY-8756" },
                    { 1284, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 39000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 150.0, "Bartın", 1439m, 15.0, 1, 1, "Sinop", "Active", "Sinop - Bartın Tekstil Ürünleri Sevkiyatı", "LY-2026" },
                    { 1285, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 53000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 294.0, "Amasya", 2435m, 16.0, 2, 1, "Sivas", "Active", "Sivas - Amasya Paletli Gıda Kolileri", "LY-1118" },
                    { 1286, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 87000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 384.0, "Bilecik", 4888m, 28.0, 3, 1, "Sivas", "Active", "Sivas - Bilecik Makine Teçhizat Parçaları", "LY-9931" },
                    { 1287, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 319000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 742.0, "Iğdır", 3787m, 10.0, 1, 1, "Sivas", "Active", "Sivas - Iğdır İnşaat Malzemeleri Götürme", "LY-1286" },
                    { 1288, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 27000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 380.0, "Malatya", 4783m, 28.0, 2, 1, "Sivas", "Active", "Sivas - Malatya Tekstil Ürünleri Sevkiyatı", "LY-3011" },
                    { 1289, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 277000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 871.0, "Batman", 7397m, 19.0, 2, 1, "Sivas", "Active", "Sivas - Batman Tekstil Ürünleri Sevkiyatı", "LY-1573" },
                    { 1290, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 135000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 748.0, "Konya", 4525m, 13.0, 3, 1, "Tekirdağ", "Active", "Tekirdağ - Konya Oto Yedek Parça Nakliyesi", "LY-7334" },
                    { 1291, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 435000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 470.0, "Sinop", 7327m, 34.0, 1, 1, "Tekirdağ", "Active", "Tekirdağ - Sinop Beyaz Eşya Dağıtımı", "LY-4658" },
                    { 1292, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 329000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 198.0, "Artvin", 3126m, 29.0, 2, 1, "Tekirdağ", "Active", "Tekirdağ - Artvin Plastik Hammadde Sevkiyatı", "LY-2699" },
                    { 1293, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 479000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 433.0, "Balıkesir", 3404m, 14.0, 2, 1, "Tekirdağ", "Active", "Tekirdağ - Balıkesir Oto Yedek Parça Nakliyesi", "LY-5900" },
                    { 1294, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 254000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 352.0, "Kırklareli", 3429m, 19.0, 2, 1, "Tekirdağ", "Active", "Tekirdağ - Kırklareli Tarım Gübresi ve Tohum", "LY-9754" },
                    { 1295, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 389000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 112.0, "Kastamonu", 2367m, 33.0, 1, 1, "Tokat", "Active", "Tokat - Kastamonu Paletli Gıda Kolileri", "LY-9349" },
                    { 1296, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 229000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 836.0, "Uşak", 6414m, 17.0, 2, 1, "Tokat", "Active", "Tokat - Uşak Karton Kutu Ambalajları", "LY-5064" },
                    { 1297, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 383000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 734.0, "Bolu", 9985m, 31.0, 3, 1, "Tokat", "Active", "Tokat - Bolu Mobilya ve Ev Eşyası Taşıma", "LY-1282" },
                    { 1298, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 430000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 609.0, "Gaziantep", 7507m, 27.0, 3, 1, "Tokat", "Active", "Tokat - Gaziantep Mobilya ve Ev Eşyası Taşıma", "LY-2166" },
                    { 1299, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 37000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 398.0, "Bursa", 3562m, 19.0, 2, 1, "Tokat", "Active", "Tokat - Bursa Plastik Hammadde Sevkiyatı", "LY-1728" },
                    { 1300, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 294000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 129.0, "Kilis", 2136m, 26.0, 1, 1, "Trabzon", "Active", "Trabzon - Kilis Makine Teçhizat Parçaları", "LY-5807" },
                    { 1301, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 220000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 687.0, "Karabük", 3468m, 10.0, 2, 1, "Trabzon", "Active", "Trabzon - Karabük Tekstil Ürünleri Sevkiyatı", "LY-1358" },
                    { 1302, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 405000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 891.0, "Elazığ", 13023m, 34.0, 2, 1, "Trabzon", "Active", "Trabzon - Elazığ Beyaz Eşya Dağıtımı", "LY-9656" },
                    { 1303, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 91000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 211.0, "Karabük", 1773m, 14.0, 2, 1, "Trabzon", "Active", "Trabzon - Karabük Makine Teçhizat Parçaları", "LY-4120" },
                    { 1304, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 346000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 741.0, "Kırklareli", 5588m, 16.0, 1, 1, "Trabzon", "Active", "Trabzon - Kırklareli Mobilya ve Ev Eşyası Taşıma", "LY-9588" },
                    { 1305, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 191000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 761.0, "Bitlis", 10736m, 33.0, 3, 1, "Tunceli", "Active", "Tunceli - Bitlis Beyaz Eşya Dağıtımı", "LY-9813" },
                    { 1306, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 481000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 534.0, "Bolu", 3544m, 12.0, 2, 1, "Tunceli", "Active", "Tunceli - Bolu Tarım Gübresi ve Tohum", "LY-4629" },
                    { 1307, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 319000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 263.0, "Yozgat", 2081m, 12.0, 1, 1, "Tunceli", "Active", "Tunceli - Yozgat Tekstil Ürünleri Sevkiyatı", "LY-3563" },
                    { 1308, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 277000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 656.0, "Muş", 6812m, 23.0, 2, 1, "Tunceli", "Active", "Tunceli - Muş Tekstil Ürünleri Sevkiyatı", "LY-2648" },
                    { 1309, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 404000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 221.0, "Muş", 3114m, 25.0, 2, 1, "Tunceli", "Active", "Tunceli - Muş Karton Kutu Ambalajları", "LY-2587" },
                    { 1310, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 397000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 775.0, "Hatay", 11127m, 33.0, 2, 1, "Şanlıurfa", "Active", "Şanlıurfa - Hatay Tekstil Ürünleri Sevkiyatı", "LY-2305" },
                    { 1311, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 188000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 232.0, "Amasya", 3472m, 30.0, 2, 1, "Şanlıurfa", "Active", "Şanlıurfa - Amasya Oto Yedek Parça Nakliyesi", "LY-4418" },
                    { 1312, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 22000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 640.0, "Denizli", 9226m, 34.0, 2, 1, "Şanlıurfa", "Active", "Şanlıurfa - Denizli Paletli Gıda Kolileri", "LY-1227" },
                    { 1313, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 179000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 109.0, "Kayseri", 1856m, 27.0, 2, 1, "Şanlıurfa", "Active", "Şanlıurfa - Kayseri Makine Teçhizat Parçaları", "LY-2774" },
                    { 1314, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 265000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 792.0, "Bolu", 3933m, 10.0, 2, 1, "Şanlıurfa", "Active", "Şanlıurfa - Bolu Mobilya ve Ev Eşyası Taşıma", "LY-4588" },
                    { 1315, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 186000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 309.0, "Mersin", 4147m, 28.0, 2, 1, "Uşak", "Active", "Uşak - Mersin Paletli Gıda Kolileri", "LY-8212" },
                    { 1316, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 363000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 414.0, "Manisa", 3678m, 17.0, 1, 1, "Uşak", "Active", "Uşak - Manisa Plastik Hammadde Sevkiyatı", "LY-7679" },
                    { 1317, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 440000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 715.0, "Mardin", 7804m, 24.0, 3, 1, "Uşak", "Active", "Uşak - Mardin Oto Yedek Parça Nakliyesi", "LY-2168" },
                    { 1318, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 269000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 718.0, "Kırşehir", 5651m, 17.0, 1, 1, "Uşak", "Active", "Uşak - Kırşehir Paletli Gıda Kolileri", "LY-3700" },
                    { 1319, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 276000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 195.0, "Malatya", 2570m, 23.0, 1, 1, "Uşak", "Active", "Uşak - Malatya Karton Kutu Ambalajları", "LY-9772" },
                    { 1320, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 199000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 479.0, "Çanakkale", 6064m, 28.0, 3, 1, "Van", "Active", "Van - Çanakkale Beyaz Eşya Dağıtımı", "LY-3487" },
                    { 1321, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 264000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 542.0, "Kastamonu", 5100m, 20.0, 2, 1, "Van", "Active", "Van - Kastamonu İnşaat Malzemeleri Götürme", "LY-8022" },
                    { 1322, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 107000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 121.0, "Denizli", 1333m, 15.0, 2, 1, "Van", "Active", "Van - Denizli Karton Kutu Ambalajları", "LY-2894" },
                    { 1323, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 401000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 133.0, "Ordu", 2337m, 27.0, 2, 1, "Van", "Active", "Van - Ordu Tarım Gübresi ve Tohum", "LY-6152" },
                    { 1324, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 360000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 202.0, "Aksaray", 3607m, 34.0, 1, 1, "Van", "Active", "Van - Aksaray Tarım Gübresi ve Tohum", "LY-7347" },
                    { 1325, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 80000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 122.0, "Hakkari", 1751m, 24.0, 3, 1, "Yozgat", "Active", "Yozgat - Hakkari Oto Yedek Parça Nakliyesi", "LY-2310" },
                    { 1326, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 470000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 116.0, "Nevşehir", 2501m, 33.0, 2, 1, "Yozgat", "Active", "Yozgat - Nevşehir Beyaz Eşya Dağıtımı", "LY-6923" },
                    { 1327, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 288000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 661.0, "Adana", 3432m, 10.0, 1, 1, "Yozgat", "Active", "Yozgat - Adana Makine Teçhizat Parçaları", "LY-7616" },
                    { 1328, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 181000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 550.0, "Balıkesir", 7281m, 30.0, 3, 1, "Yozgat", "Active", "Yozgat - Balıkesir Tarım Gübresi ve Tohum", "LY-5376" },
                    { 1329, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 205000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 530.0, "Artvin", 3249m, 12.0, 1, 1, "Yozgat", "Active", "Yozgat - Artvin İnşaat Malzemeleri Götürme", "LY-8008" },
                    { 1330, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 213000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 866.0, "Van", 9373m, 25.0, 3, 1, "Zonguldak", "Active", "Zonguldak - Van Beyaz Eşya Dağıtımı", "LY-4787" },
                    { 1331, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 280000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 785.0, "Trabzon", 11142m, 33.0, 2, 1, "Zonguldak", "Active", "Zonguldak - Trabzon Oto Yedek Parça Nakliyesi", "LY-6330" },
                    { 1332, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 39000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 336.0, "Bitlis", 2689m, 16.0, 3, 1, "Zonguldak", "Active", "Zonguldak - Bitlis Tekstil Ürünleri Sevkiyatı", "LY-8855" },
                    { 1333, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 350000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 631.0, "Bitlis", 6908m, 24.0, 2, 1, "Zonguldak", "Active", "Zonguldak - Bitlis İnşaat Malzemeleri Götürme", "LY-9113" },
                    { 1334, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 128000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 704.0, "Ankara", 9076m, 30.0, 3, 1, "Zonguldak", "Active", "Zonguldak - Ankara İnşaat Malzemeleri Götürme", "LY-3354" },
                    { 1335, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 432000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 566.0, "Elazığ", 3422m, 11.0, 3, 1, "Aksaray", "Active", "Aksaray - Elazığ Mobilya ve Ev Eşyası Taşıma", "LY-7804" },
                    { 1336, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 289000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 740.0, "Erzincan", 11149m, 35.0, 1, 1, "Aksaray", "Active", "Aksaray - Erzincan Tarım Gübresi ve Tohum", "LY-5385" },
                    { 1337, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 295000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 152.0, "Kırklareli", 1646m, 14.0, 1, 1, "Aksaray", "Active", "Aksaray - Kırklareli Beyaz Eşya Dağıtımı", "LY-5997" },
                    { 1338, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 132000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 597.0, "Iğdır", 8751m, 34.0, 2, 1, "Aksaray", "Active", "Aksaray - Iğdır İnşaat Malzemeleri Götürme", "LY-3917" },
                    { 1339, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 480000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 829.0, "Erzurum", 4959m, 12.0, 3, 1, "Aksaray", "Active", "Aksaray - Erzurum Tarım Gübresi ve Tohum", "LY-2336" },
                    { 1340, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 408000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 678.0, "Kocaeli", 9858m, 33.0, 1, 1, "Bayburt", "Active", "Bayburt - Kocaeli Beyaz Eşya Dağıtımı", "LY-2801" },
                    { 1341, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 244000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 485.0, "Sinop", 5400m, 24.0, 1, 1, "Bayburt", "Active", "Bayburt - Sinop Plastik Hammadde Sevkiyatı", "LY-8466" },
                    { 1342, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 117000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 540.0, "Gümüşhane", 4505m, 18.0, 3, 1, "Bayburt", "Active", "Bayburt - Gümüşhane Beyaz Eşya Dağıtımı", "LY-2707" },
                    { 1343, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 373000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 188.0, "Isparta", 2076m, 16.0, 3, 1, "Bayburt", "Active", "Bayburt - Isparta İnşaat Malzemeleri Götürme", "LY-1470" },
                    { 1344, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 214000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 201.0, "Ardahan", 2242m, 19.0, 3, 1, "Bayburt", "Active", "Bayburt - Ardahan Mobilya ve Ev Eşyası Taşıma", "LY-4552" },
                    { 1345, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 244000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 805.0, "Kütahya", 9116m, 26.0, 1, 1, "Karaman", "Active", "Karaman - Kütahya Tekstil Ürünleri Sevkiyatı", "LY-8336" },
                    { 1346, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 193000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 354.0, "Manisa", 4799m, 29.0, 2, 1, "Karaman", "Active", "Karaman - Manisa Tekstil Ürünleri Sevkiyatı", "LY-9500" },
                    { 1347, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 100000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 921.0, "Diyarbakır", 9073m, 23.0, 3, 1, "Karaman", "Active", "Karaman - Diyarbakır Paletli Gıda Kolileri", "LY-9800" },
                    { 1348, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 425000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 900.0, "Malatya", 10285m, 26.0, 2, 1, "Karaman", "Active", "Karaman - Malatya Beyaz Eşya Dağıtımı", "LY-8339" },
                    { 1349, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 117000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 884.0, "Erzincan", 4507m, 11.0, 3, 1, "Karaman", "Active", "Karaman - Erzincan Paletli Gıda Kolileri", "LY-9824" },
                    { 1350, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 195000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 575.0, "Kastamonu", 6905m, 27.0, 3, 1, "Kırıkkale", "Active", "Kırıkkale - Kastamonu Makine Teçhizat Parçaları", "LY-6203" },
                    { 1351, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 254000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 407.0, "Gümüşhane", 6126m, 33.0, 1, 1, "Kırıkkale", "Active", "Kırıkkale - Gümüşhane Tekstil Ürünleri Sevkiyatı", "LY-4470" },
                    { 1352, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 119000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 702.0, "Adana", 10166m, 34.0, 3, 1, "Kırıkkale", "Active", "Kırıkkale - Adana Plastik Hammadde Sevkiyatı", "LY-3766" },
                    { 1353, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 213000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 146.0, "Amasya", 1472m, 13.0, 2, 1, "Kırıkkale", "Active", "Kırıkkale - Amasya Makine Teçhizat Parçaları", "LY-9615" },
                    { 1354, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 339000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 245.0, "Amasya", 2113m, 13.0, 2, 1, "Kırıkkale", "Active", "Kırıkkale - Amasya Karton Kutu Ambalajları", "LY-3966" },
                    { 1355, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 484000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 781.0, "Kayseri", 10981m, 32.0, 3, 1, "Batman", "Active", "Batman - Kayseri Mobilya ve Ev Eşyası Taşıma", "LY-7657" },
                    { 1356, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 24000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 309.0, "Zonguldak", 4479m, 32.0, 3, 1, "Batman", "Active", "Batman - Zonguldak Mobilya ve Ev Eşyası Taşıma", "LY-3878" },
                    { 1357, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 471000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 905.0, "Elazığ", 13279m, 34.0, 1, 1, "Batman", "Active", "Batman - Elazığ Tekstil Ürünleri Sevkiyatı", "LY-3705" },
                    { 1358, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 88000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 394.0, "Tokat", 3110m, 16.0, 1, 1, "Batman", "Active", "Batman - Tokat İnşaat Malzemeleri Götürme", "LY-2713" },
                    { 1359, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 367000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 172.0, "Bitlis", 1899m, 15.0, 1, 1, "Batman", "Active", "Batman - Bitlis Plastik Hammadde Sevkiyatı", "LY-6281" },
                    { 1360, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 324000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 136.0, "Malatya", 2021m, 22.0, 3, 1, "Şırnak", "Active", "Şırnak - Malatya Paletli Gıda Kolileri", "LY-8517" },
                    { 1361, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 389000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 547.0, "Konya", 7015m, 28.0, 1, 1, "Şırnak", "Active", "Şırnak - Konya Beyaz Eşya Dağıtımı", "LY-5540" },
                    { 1362, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 273000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 676.0, "Afyonkarahisar", 4288m, 13.0, 3, 1, "Şırnak", "Active", "Şırnak - Afyonkarahisar Beyaz Eşya Dağıtımı", "LY-8009" },
                    { 1363, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 148000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 569.0, "Eskişehir", 7476m, 30.0, 1, 1, "Şırnak", "Active", "Şırnak - Eskişehir Mobilya ve Ev Eşyası Taşıma", "LY-2103" },
                    { 1364, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 60000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 189.0, "Tunceli", 2450m, 25.0, 3, 1, "Şırnak", "Active", "Şırnak - Tunceli Oto Yedek Parça Nakliyesi", "LY-7154" },
                    { 1365, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 336000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 427.0, "Uşak", 5960m, 30.0, 2, 1, "Bartın", "Active", "Bartın - Uşak Plastik Hammadde Sevkiyatı", "LY-6846" },
                    { 1366, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 473000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 111.0, "Kahramanmaraş", 1639m, 15.0, 2, 1, "Bartın", "Active", "Bartın - Kahramanmaraş Makine Teçhizat Parçaları", "LY-9555" },
                    { 1367, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 129000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 305.0, "Muğla", 2703m, 17.0, 2, 1, "Bartın", "Active", "Bartın - Muğla Paletli Gıda Kolileri", "LY-5146" },
                    { 1368, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 447000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 907.0, "Uşak", 11831m, 30.0, 2, 1, "Bartın", "Active", "Bartın - Uşak Paletli Gıda Kolileri", "LY-2901" },
                    { 1369, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 86000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 658.0, "Kastamonu", 3481m, 11.0, 3, 1, "Bartın", "Active", "Bartın - Kastamonu Plastik Hammadde Sevkiyatı", "LY-8453" },
                    { 1370, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 338000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 788.0, "Afyonkarahisar", 7772m, 22.0, 1, 1, "Ardahan", "Active", "Ardahan - Afyonkarahisar Makine Teçhizat Parçaları", "LY-4406" },
                    { 1371, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 310000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 572.0, "Isparta", 3098m, 10.0, 2, 1, "Ardahan", "Active", "Ardahan - Isparta Tekstil Ürünleri Sevkiyatı", "LY-5548" },
                    { 1372, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 65000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 669.0, "Aydın", 6185m, 21.0, 1, 1, "Ardahan", "Active", "Ardahan - Aydın Mobilya ve Ev Eşyası Taşıma", "LY-5205" },
                    { 1373, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 341000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 486.0, "Denizli", 3951m, 16.0, 2, 1, "Ardahan", "Active", "Ardahan - Denizli Beyaz Eşya Dağıtımı", "LY-3346" },
                    { 1374, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 442000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 197.0, "Iğdır", 3306m, 30.0, 3, 1, "Ardahan", "Active", "Ardahan - Iğdır Paletli Gıda Kolileri", "LY-5174" },
                    { 1375, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 498000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 819.0, "Isparta", 6567m, 17.0, 3, 1, "Iğdır", "Active", "Iğdır - Isparta Mobilya ve Ev Eşyası Taşıma", "LY-5308" },
                    { 1376, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 38000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 894.0, "Rize", 10551m, 28.0, 1, 1, "Iğdır", "Active", "Iğdır - Rize Plastik Hammadde Sevkiyatı", "LY-7649" },
                    { 1377, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 237000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 715.0, "Bursa", 10175m, 33.0, 2, 1, "Iğdır", "Active", "Iğdır - Bursa Paletli Gıda Kolileri", "LY-3899" },
                    { 1378, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 154000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 293.0, "Ardahan", 4053m, 29.0, 2, 1, "Iğdır", "Active", "Iğdır - Ardahan Plastik Hammadde Sevkiyatı", "LY-2531" },
                    { 1379, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 394000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 307.0, "Adana", 3841m, 24.0, 3, 1, "Iğdır", "Active", "Iğdır - Adana Paletli Gıda Kolileri", "LY-4776" },
                    { 1380, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 59000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 859.0, "Iğdır", 3995m, 10.0, 1, 1, "Yalova", "Active", "Yalova - Iğdır Paletli Gıda Kolileri", "LY-5542" },
                    { 1381, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 107000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 896.0, "Trabzon", 7058m, 18.0, 2, 1, "Yalova", "Active", "Yalova - Trabzon Beyaz Eşya Dağıtımı", "LY-9883" },
                    { 1382, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 66000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 415.0, "Mersin", 4384m, 23.0, 1, 1, "Yalova", "Active", "Yalova - Mersin Makine Teçhizat Parçaları", "LY-6645" },
                    { 1383, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 379000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 446.0, "Gümüşhane", 6945m, 34.0, 1, 1, "Yalova", "Active", "Yalova - Gümüşhane Paletli Gıda Kolileri", "LY-5217" },
                    { 1384, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 302000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 810.0, "Hatay", 12142m, 35.0, 1, 1, "Yalova", "Active", "Yalova - Hatay Makine Teçhizat Parçaları", "LY-1258" },
                    { 1385, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 25000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 799.0, "Erzurum", 8835m, 26.0, 3, 1, "Karabük", "Active", "Karabük - Erzurum Karton Kutu Ambalajları", "LY-9972" },
                    { 1386, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 56000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 807.0, "Van", 8949m, 26.0, 1, 1, "Karabük", "Active", "Karabük - Van Plastik Hammadde Sevkiyatı", "LY-9107" },
                    { 1387, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 116000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 946.0, "Uşak", 12725m, 32.0, 2, 1, "Karabük", "Active", "Karabük - Uşak Paletli Gıda Kolileri", "LY-7382" },
                    { 1388, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 322000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 789.0, "Edirne", 6503m, 18.0, 1, 1, "Karabük", "Active", "Karabük - Edirne Oto Yedek Parça Nakliyesi", "LY-7946" },
                    { 1389, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 109000m, "Özenle paketlenmiş yük. Hızlı teslimat tercih sebebidir.", 390.0, "Bayburt", 4977m, 28.0, 3, 1, "Karabük", "Active", "Karabük - Bayburt Tekstil Ürünleri Sevkiyatı", "LY-9874" },
                    { 1390, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 194000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 357.0, "Van", 5121m, 31.0, 3, 1, "Kilis", "Active", "Kilis - Van Paletli Gıda Kolileri", "LY-1951" },
                    { 1391, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 269000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 191.0, "Gümüşhane", 2373m, 21.0, 3, 1, "Kilis", "Active", "Kilis - Gümüşhane Makine Teçhizat Parçaları", "LY-6805" },
                    { 1392, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 207000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 241.0, "Sinop", 3213m, 26.0, 2, 1, "Kilis", "Active", "Kilis - Sinop Oto Yedek Parça Nakliyesi", "LY-8477" },
                    { 1393, "https://images.unsplash.com/photo-1506015391300-4802dc74de2e?auto=format&fit=crop&w=600&q=80", 414000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 604.0, "Hatay", 4296m, 14.0, 1, 1, "Kilis", "Active", "Kilis - Hatay Mobilya ve Ev Eşyası Taşıma", "LY-3987" },
                    { 1394, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 125000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 870.0, "Eskişehir", 12109m, 33.0, 3, 1, "Kilis", "Active", "Kilis - Eskişehir Paletli Gıda Kolileri", "LY-4126" },
                    { 1395, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 375000m, "İndirme ve bindirme göndericiye aittir. Güvenli sevkiyat.", 379.0, "Hatay", 4210m, 22.0, 2, 1, "Osmaniye", "Active", "Osmaniye - Hatay Paletli Gıda Kolileri", "LY-4258" },
                    { 1396, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 308000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 448.0, "Adıyaman", 6901m, 34.0, 2, 1, "Osmaniye", "Active", "Osmaniye - Adıyaman Tekstil Ürünleri Sevkiyatı", "LY-4817" },
                    { 1397, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 24000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 553.0, "Kırıkkale", 8266m, 35.0, 1, 1, "Osmaniye", "Active", "Osmaniye - Kırıkkale Beyaz Eşya Dağıtımı", "LY-3738" },
                    { 1398, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 266000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 511.0, "Erzincan", 4445m, 18.0, 1, 1, "Osmaniye", "Active", "Osmaniye - Erzincan Tekstil Ürünleri Sevkiyatı", "LY-4904" },
                    { 1399, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 488000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 644.0, "Artvin", 3564m, 10.0, 3, 1, "Osmaniye", "Active", "Osmaniye - Artvin Karton Kutu Ambalajları", "LY-5264" },
                    { 1400, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 415000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 710.0, "Kırklareli", 6311m, 19.0, 2, 1, "Düzce", "Active", "Düzce - Kırklareli Mobilya ve Ev Eşyası Taşıma", "LY-4002" },
                    { 1401, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 461000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 415.0, "Siirt", 3783m, 17.0, 1, 1, "Düzce", "Active", "Düzce - Siirt Oto Yedek Parça Nakliyesi", "LY-6293" },
                    { 1402, "https://images.unsplash.com/photo-1600585154340-be6161a56a0c?auto=format&fit=crop&w=600&q=80", 452000m, "Hasar görmemesi gereken hassas yük. Frigo veya kapalı kasa.", 530.0, "Kırklareli", 4132m, 15.0, 1, 1, "Düzce", "Active", "Düzce - Kırklareli Paletli Gıda Kolileri", "LY-5246" },
                    { 1403, "https://images.unsplash.com/photo-1616401784845-180882ba9ba8?auto=format&fit=crop&w=600&q=80", 116000m, "Boş dönecek taşıyıcılar için uygun fiyatlı sevkiyat.", 862.0, "Kırklareli", 9236m, 25.0, 2, 1, "Düzce", "Active", "Düzce - Kırklareli Beyaz Eşya Dağıtımı", "LY-1848" },
                    { 1404, "https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80", 470000m, "Paletli standart yük. Bağlama ve sabitleme kayışları gereklidir.", 493.0, "Hatay", 7083m, 31.0, 3, 1, "Düzce", "Active", "Düzce - Hatay Tarım Gübresi ve Tohum", "LY-8891" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1086);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1087);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1088);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1089);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1090);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1093);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1094);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1096);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1097);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1098);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1099);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1128);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1129);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1138);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1139);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1148);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1149);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1152);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1153);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1154);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1155);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1156);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1157);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1158);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1159);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1160);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1161);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1162);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1163);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1164);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1165);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1166);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1167);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1168);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1169);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1170);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1177);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1178);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1179);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1180);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1181);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1182);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1183);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1184);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1185);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1186);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1187);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1188);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1189);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1190);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1191);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1192);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1193);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1194);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1195);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1196);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1197);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1198);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1199);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1223);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1224);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1225);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1226);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1227);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1228);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1229);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1238);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1249);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1250);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1251);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1252);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1253);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1255);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1256);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1257);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1258);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1259);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1260);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1262);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1263);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1265);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1266);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1267);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1268);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1269);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1270);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1272);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1273);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1274);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1275);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1276);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1277);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1278);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1279);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1280);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1281);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1282);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1283);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1284);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1285);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1286);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1287);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1288);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1289);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1290);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1291);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1292);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1293);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1294);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1295);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1296);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1297);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1298);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1299);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1308);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1318);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1319);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1322);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1323);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1324);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1325);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1326);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1327);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1328);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1329);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1330);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1332);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1337);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1338);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1339);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1340);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1342);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1343);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1344);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1345);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1346);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1347);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1348);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1349);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1350);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1351);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1352);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1353);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1354);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1355);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1356);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1357);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1358);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1359);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1360);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1361);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1362);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1363);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1364);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1365);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1366);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1367);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1368);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1369);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1370);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1371);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1372);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1373);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1374);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1375);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1376);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1377);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1378);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1379);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1380);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1381);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1382);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1383);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1384);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1385);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1386);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1387);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1388);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1389);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1390);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1391);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1392);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1393);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1394);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1395);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1396);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1397);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1398);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1399);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1401);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1402);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1403);

            migrationBuilder.DeleteData(
                table: "Ads",
                keyColumn: "Id",
                keyValue: 1404);
        }
    }
}
