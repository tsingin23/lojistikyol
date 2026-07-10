using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotController : ControllerBase
{
    [HttpPost]
    public IActionResult PostMessage([FromBody] ChatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest(new { reply = "Lütfen bir mesaj yazın." });
        }

        string msg = request.Message.ToLowerInvariant();
        string reply;

        if (msg.Contains("havuz") || msg.Contains("escrow") || msg.Contains("güvenli") || msg.Contains("bloke") || msg.Contains("para"))
        {
            reply = "🔒 *LojistikYol Güvenli Havuz (Escrow) Sistemi*:\nNavlun bedeli ve taşıyıcı teminatı, taşıma tamamlanana kadar güvenli havuzda kilitli kalır. Teslimat resmi Yapay Zeka ve OCR tarafından onaylandığı anda para anında serbest kalır ve cüzdanınıza aktarılır.";
        }
        else if (msg.Contains("seviye") || msg.Contains("level") || msg.Contains("yetki") || msg.Contains("src") || msg.Contains("yüksel"))
        {
            reply = "📈 *Taşıyıcı Seviye Kriterleri*:\n- *Level 1 (Temel)*: %100 Kargo Değeri kadar teminat bloke edilir.\n- *Level 2 (Doğrulanmış)*: SRC belgesi gerekir, teminat blokajı %30'a düşer.\n- *Level 3 (Sigortalı)*: Ticari Sigorta Poliçesi gerekir, %0 teminat blokajı uygulanır.";
        }
        else if (msg.Contains("yakıt") || msg.Contains("akaryakıt") || msg.Contains("fiyat") || msg.Contains("litre"))
        {
            reply = "⛽ *Akaryakıt Fiyatlandırması*:\nSistemdeki güncel yakıt litre fiyatı taban fiyat formüllerini doğrudan etkiler. Keşfet ekranındaki yakıt düzenleme menüsünden fiyatı değiştirerek taban fiyatların nasıl dinamik olarak dalgalandığını test edebilirsiniz.";
        }
        else if (msg.Contains("taban") || msg.Contains("formül") || msg.Contains("hesaplama"))
        {
            reply = "🧮 *Taban Fiyat Algoritması*:\nTabanFiyat = (Mesafe * (Tüketim/100) * YakıtFiyatı) + 500 TL Sabit Bedel + (KargoDeğeri * %0.1). Taşıyıcılar bu fiyatın altında teklif veremezler.";
        }
        else if (msg.Contains("bonus") || msg.Contains("kampanya") || msg.Contains("hediye") || msg.Contains("indirim"))
        {
            reply = "🎁 *Aktif Bonus & Payout Kampanyaları*:\n- *Hoş Geldin Bonusu*: Yeni kaydolan taşıyıcılara 1 hafta boyunca %0 platform ücreti ve teslimatlarda ekstra *+%10 navlun bonusu* sağlanır!\n- *Periyodik Görevler*: Profil sayfanızdan haftalık görevleri takip ederek ek cüzdan bakiyesi kazanabilirsiniz.";
        }
        else if (msg.Contains("logo") || msg.Contains("görsel"))
        {
            reply = "🎨 *LojistikYol Kurumsal Kimliği*:\nLogomuz, lacivert ve turuncu renk geçişleriyle modern taşımacılık yollarını ve tır silüetini simgeler. Güvenli akışı temsil eder.";
        }
        else
        {
            reply = "👋 Merhaba! Ben LojistikYol Akıllı İşlem Asistanıyım.\n\nSüreçlerimiz hakkında bilgi almak için aşağıdaki anahtar kelimeleri içeren sorular sorabilirsiniz:\n- *Güvenli Havuz (Escrow) nasıl çalışır?*\n- *Taşıyıcı seviyemi (Level 1/2/3) nasıl yükseltirim?*\n- *Taban fiyat hesaplama formülü nedir?*\n- *Hoş Geldin Bonusu ve Kampanyalar nelerdir?*";
        }

        return Ok(new { reply = reply });
    }
}

public class ChatRequest
{
    public string Message { get; set; } = string.Empty;
}
