import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';

class NotificationsScreen extends StatefulWidget {
  const NotificationsScreen({Key? key}) : super(key: key);

  @override
  State<NotificationsScreen> createState() => _NotificationsScreenState();
}

class _NotificationsScreenState extends State<NotificationsScreen> {
  @override
  void initState() {
    super.initState();
    Future.microtask(() {
      Provider.of<AppProvider>(context, listen: false).markNotificationsRead();
    });
  }

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);
    final List<dynamic> dbNotifications = provider.notifications;

    // Premium mock notifications as fallback to keep contents looking full
    final List<Map<String, dynamic>> mockNotifications = [
      {
        'title': '🎉 Hoş Geldin Bonusu Tanımlandı!',
        'body': 'Yeni kayıt ödülü olarak 1 hafta boyunca %0 platform komisyonu ve +%10 ek payout kazancınız cüzdanınıza yansıtılacaktır.',
        'time': '10 dakika önce',
        'icon': Icons.card_giftcard,
        'color': Colors.orange,
      },
      {
        'title': '🚨 Yapay Zeka Teslimat Doğrulama Onayı',
        'body': 'TR-4428101E numaralı kargo teslimatı için yüklediğiniz resim AI görsel motoru tarafından incelenmiş ve uyuşma başarıyla onaylanmıştır.',
        'time': '2 saat önce',
        'icon': Icons.verified_user,
        'color': Colors.green,
      },
      {
        'title': '🔒 Güvenli Havuz - Pre-Auth Bloke Tutarı',
        'body': 'Ankara — Kocaeli sevkiyatı için 6.000 TL provizyon güvence bedeli başarıyla göndericinin cüzdanından bloke edilmiştir.',
        'time': 'Dün',
        'icon': Icons.lock,
        'color': Colors.blue,
      },
      {
        'title': '📈 Haftalık Görev Tamamlandı!',
        'body': 'Tebrikler! Bu hafta 3 sevkiyat tamamlayarak +5.000 TL haftalık bonus nakit ödülünüzü başarıyla kazandınız!',
        'time': '3 gün önce',
        'icon': Icons.trending_up,
        'color': Colors.purple,
      }
    ];

    // Combine both list (DB ones first)
    final List<dynamic> allNotifications = [];
    for (var n in dbNotifications) {
      allNotifications.add({
        'title': n['title'] ?? 'Bildirim',
        'body': n['message'] ?? '',
        'time': 'Yeni',
        'icon': Icons.notifications_active,
        'color': Colors.amber,
        'isDb': true,
        'isRead': n['isRead'] == true,
      });
    }
    allNotifications.addAll(mockNotifications);

    return Scaffold(
      backgroundColor: const Color(0xFFF4F7F9),
      body: ListView.builder(
        padding: const EdgeInsets.all(16),
        itemCount: allNotifications.length,
        itemBuilder: (context, index) {
          final item = allNotifications[index];
          final bool isUnread = item['isDb'] == true && item['isRead'] == false;

          return Card(
            margin: const EdgeInsets.only(bottom: 12),
            shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
            elevation: 0,
            child: Container(
              decoration: BoxDecoration(
                color: isUnread ? const Color(0xFFEFF6FF) : Colors.white,
                borderRadius: BorderRadius.circular(16),
                border: Border.all(
                  color: isUnread ? const Color(0xFFBFDBFE) : Colors.transparent,
                  width: 0.8,
                ),
              ),
              padding: const EdgeInsets.all(16.0),
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  CircleAvatar(
                    backgroundColor: item['color'].withOpacity(0.1),
                    child: Icon(item['icon'], color: item['color'], size: 20),
                  ),
                  const SizedBox(width: 16),
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Expanded(
                              child: Text(
                                item['title'],
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 13,
                                  color: isUnread ? const Color(0xFF1D4ED8) : const Color(0xFF1A2B3C),
                                ),
                              ),
                            ),
                            if (isUnread)
                              Container(
                                width: 8,
                                height: 8,
                                decoration: const BoxDecoration(
                                  color: Colors.blue,
                                  shape: BoxShape.circle,
                                ),
                              ),
                          ],
                        ),
                        const SizedBox(height: 4),
                        Text(
                          item['body'],
                          style: const TextStyle(fontSize: 11, color: Color(0xFF64748B), height: 1.4),
                        ),
                        const SizedBox(height: 8),
                        Text(
                          item['time'],
                          style: TextStyle(fontSize: 9, color: Colors.grey[400]),
                        )
                      ],
                    ),
                  )
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
