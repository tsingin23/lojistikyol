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
            return BadRequest(new { response = "LÃ¼tfen bir mesaj yazÄ±n." });
        }

        string msg = request.Message.ToLowerInvariant();
        string reply;

        if (msg.Contains("havuz") || msg.Contains("escrow") || msg.Contains("gÃ¼venli") || msg.Contains("bloke") || msg.Contains("para"))
        {
            reply = "ğŸ”’ *LojistikYol GÃ¼venli Havuz (Escrow) Sistemi*:\nNavlun bedeli ve taÅŸÄ±yÄ±cÄ± teminatÄ±, taÅŸÄ±ma tamamlanana kadar gÃ¼venli havuzda kilitli kalÄ±r. Teslimat resmi Yapay Zeka ve OCR tarafÄ±ndan onaylandÄ±ÄŸÄ± anda para anÄ±nda serbest kalÄ±r ve cÃ¼zdanÄ±nÄ±za aktarÄ±lÄ±r.";
        }
        else if (msg.Contains("seviye") || msg.Contains("level") || msg.Contains("yetki") || msg.Contains("src") || msg.Contains("yÃ¼ksel"))
        {
            reply = "ğŸ“ˆ *TaÅŸÄ±yÄ±cÄ± Seviye Kriterleri*:\n- *Level 1 (Temel)*: %100 Kargo DeÄŸeri kadar teminat bloke edilir.\n- *Level 2 (DoÄŸrulanmÄ±ÅŸ)*: SRC belgesi gerekir, teminat blokajÄ± %30'a dÃ¼ÅŸer.\n- *Level 3 (SigortalÄ±)*: Ticari Sigorta PoliÃ§esi gerekir, %0 teminat blokajÄ± uygulanÄ±r.";
        }
        else if (msg.Contains("yakÄ±t") || msg.Contains("akaryakÄ±t") || msg.Contains("fiyat") || msg.Contains("litre"))
        {
            reply = "â›½ *AkaryakÄ±t FiyatlandÄ±rmasÄ±*:\nSistemdeki gÃ¼ncel yakÄ±t litre fiyatÄ± taban fiyat formÃ¼llerini doÄŸrudan etkiler. KeÅŸfet ekranÄ±ndaki yakÄ±t dÃ¼zenleme menÃ¼sÃ¼nden fiyatÄ± deÄŸiÅŸtirerek taban fiyatlarÄ±n nasÄ±l dinamik olarak dalgalandÄ±ÄŸÄ±nÄ± test edebilirsiniz.";
        }
        else if (msg.Contains("taban") || msg.Contains("formÃ¼l") || msg.Contains("hesaplama"))
        {
            reply = "ğŸ§® *Taban Fiyat AlgoritmasÄ±*:\nTabanFiyat = (Mesafe * (TÃ¼ketim/100) * YakÄ±tFiyatÄ±) + 500 TL Sabit Bedel + (KargoDeÄŸeri * %0.1). TaÅŸÄ±yÄ±cÄ±lar bu fiyatÄ±n altÄ±nda teklif veremezler.";
        }
        else if (msg.Contains("bonus") || msg.Contains("kampanya") || msg.Contains("hediye") || msg.Contains("indirim"))
        {
            reply = "ğŸ *Aktif Bonus & Payout KampanyalarÄ±*:\n- *HoÅŸ Geldin Bonusu*: Yeni kaydolan taÅŸÄ±yÄ±cÄ±lara 1 hafta boyunca %0 platform Ã¼creti ve teslimatlarda ekstra *+%10 navlun bonusu* saÄŸlanÄ±r!\n- *Periyodik GÃ¶revler*: Profil sayfanÄ±zdan haftalÄ±k gÃ¶revleri takip ederek ek cÃ¼zdan bakiyesi kazanabilirsiniz.";
        }
        else if (msg.Contains("logo") || msg.Contains("gÃ¶rsel"))
        {
            reply = "ğŸ¨ *LojistikYol Kurumsal KimliÄŸi*:\nLogomuz, lacivert ve turuncu renk geÃ§iÅŸleriyle modern taÅŸÄ±macÄ±lÄ±k yollarÄ±nÄ± ve tÄ±r silÃ¼etini simgeler. GÃ¼venli akÄ±ÅŸÄ± temsil eder.";
        }
        else
        {
            reply = "ğŸ‘‹ Merhaba! Ben LojistikYol AkÄ±llÄ± Ä°ÅŸlem AsistanÄ±yÄ±m.\n\nSÃ¼reÃ§lerimiz hakkÄ±nda bilgi almak iÃ§in aÅŸaÄŸÄ±daki anahtar kelimeleri iÃ§eren sorular sorabilirsiniz:\n- *GÃ¼venli Havuz (Escrow) nasÄ±l Ã§alÄ±ÅŸÄ±r?*\n- *TaÅŸÄ±yÄ±cÄ± seviyemi (Level 1/2/3) nasÄ±l yÃ¼kseltirim?*\n- *Taban fiyat hesaplama formÃ¼lÃ¼ nedir?*\n- *HoÅŸ Geldin Bonusu ve Kampanyalar nelerdir?*";
        }

        return Ok(new { response = reply });
    }
}

public class ChatRequest
{
    public string Message { get; set; } = string.Empty;
}
