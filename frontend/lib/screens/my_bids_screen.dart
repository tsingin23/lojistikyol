import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';
import 'package:frontend/screens/bid_details_screen.dart';

class MyBidsScreen extends StatelessWidget {
  const MyBidsScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);
    final user = provider.currentUser;

    if (user == null) {
      return const Scaffold(
        body: Center(child: Text('Lütfen giriş yapın.')),
      );
    }

    final isSender = user['userType'] == 'Sender';

    // Shippers (Senders) view bids placed on their ads.
    // Carriers view bids they have placed.
    List<dynamic> myBidsList = [];
    if (isSender) {
      // Find all bids placed on ads owned by this sender
      for (var ad in provider.ads) {
        if (ad['senderId'] == user['id']) {
          if (ad['bids'] != null) {
            for (var b in ad['bids']) {
              myBidsList.add({
                'bid': b,
                'ad': ad,
              });
            }
          }
        }
      }
    } else {
      // Find all bids placed by this carrier
      for (var ad in provider.ads) {
        if (ad['bids'] != null) {
          for (var b in ad['bids']) {
            if (b['carrierId'] == user['id']) {
              myBidsList.add({
                'bid': b,
                'ad': ad,
              });
            }
          }
        }
      }
    }

    return Scaffold(
      backgroundColor: const Color(0xFFF4F7F9),
      body: myBidsList.isEmpty
          ? const Center(
              child: Text(
                'Kayıtlı aktif teklifiniz bulunmamaktadır.',
                style: TextStyle(color: Color(0xFF64748B)),
              ),
            )
          : ListView.builder(
              padding: const EdgeInsets.all(16),
              itemCount: myBidsList.length,
              itemBuilder: (context, index) {
                final item = myBidsList[index];
                final ad = item['ad'];
                final bid = item['bid'];
                final isAccepted = bid['status'] == 'Accepted';
                final isPending = bid['status'] == 'Pending';

                return Card(
                  margin: const EdgeInsets.only(bottom: 12),
                  shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
                  elevation: 0,
                  child: Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Text(
                              '${ad['startLocation']} → ${ad['endLocation']}',
                              style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                            ),
                            Container(
                              padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 2),
                              decoration: BoxDecoration(
                                color: isAccepted
                                    ? const Color(0xFFD1FAE5)
                                    : isPending
                                        ? const Color(0xFFFEF3C7)
                                        : const Color(0xFFF3F4F6),
                                borderRadius: BorderRadius.circular(10),
                              ),
                              child: Text(
                                isAccepted
                                    ? 'Onaylandı'
                                    : isPending
                                        ? 'Bekliyor'
                                        : 'Reddedildi',
                                style: TextStyle(
                                  fontSize: 9,
                                  fontWeight: FontWeight.bold,
                                  color: isAccepted
                                      ? const Color(0xFF065F46)
                                      : isPending
                                          ? const Color(0xFFFF8C00)
                                          : const Color(0xFF374151),
                                ),
                              ),
                            )
                          ],
                        ),
                        const SizedBox(height: 6),
                        Text(
                          ad['title'] ?? '',
                          style: const TextStyle(fontSize: 11, color: Color(0xFF64748B)),
                        ),
                        const SizedBox(height: 12),
                        const Divider(height: 1, color: Color(0xFFE2E8F0)),
                        const SizedBox(height: 12),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  isSender ? 'Teklif Veren Taşıyıcı:' : 'Sizin Teklif Tutarınız:',
                                  style: const TextStyle(fontSize: 9, color: Color(0xFF64748B)),
                                ),
                                const SizedBox(height: 2),
                                Text(
                                  isSender ? (bid['carrier']?['name'] ?? 'Mehmet Usta') : '₺${bid['amount']}',
                                  style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                                )
                              ],
                            ),
                            ElevatedButton(
                              onPressed: () {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                    builder: (context) => BidDetailsScreen(adId: ad['id']),
                                  ),
                                );
                              },
                              style: ElevatedButton.styleFrom(
                                backgroundColor: const Color(0xFF1A2B3C),
                                foregroundColor: Colors.white,
                                elevation: 0,
                                shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
                                padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
                              ),
                              child: const Text('Detay →', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold)),
                            )
                          ],
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
