import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';

class NotificationsDialog extends StatefulWidget {
  const NotificationsDialog({Key? key}) : super(key: key);

  @override
  State<NotificationsDialog> createState() => _NotificationsDialogState();
}

class _NotificationsDialogState extends State<NotificationsDialog> {
  @override
  void initState() {
    super.initState();
    // Mark notifications read when opening the dialog
    Future.microtask(() {
      Provider.of<AppProvider>(context, listen: false).markNotificationsRead();
    });
  }

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);
    final notifications = provider.notifications;

    return Dialog(
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(24)),
      backgroundColor: Colors.white,
      child: Container(
        padding: const EdgeInsets.all(20),
        width: 320,
        height: 400,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text(
                  'Bildirim Merkezi',
                  style: TextStyle(
                    fontSize: 16,
                    fontWeight: FontWeight.bold,
                    color: Color(0xFF1A2B3C),
                  ),
                ),
                IconButton(
                  icon: const Icon(Icons.close, size: 20),
                  onPressed: () => Navigator.pop(context),
                )
              ],
            ),
            const Divider(),
            Expanded(
              child: notifications.isEmpty
                  ? Center(
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Icon(Icons.notifications_off_outlined, size: 48, color: Colors.grey[300]),
                          const SizedBox(height: 12),
                          Text(
                            'Henüz bir bildirim yok.',
                            style: TextStyle(fontSize: 12, color: Colors.grey[500]),
                          ),
                        ],
                      ),
                    )
                  : ListView.builder(
                      itemCount: notifications.length,
                      itemBuilder: (context, index) {
                        final n = notifications[index];
                        final bool isUnread = n['isRead'] == false;
                        final DateTime date = n['createdAt'] != null 
                            ? DateTime.parse(n['createdAt']).toLocal() 
                            : DateTime.now();

                        return Container(
                          padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 8),
                          margin: const EdgeInsets.only(bottom: 8),
                          decoration: BoxDecoration(
                            color: isUnread ? const Color(0xFFEFF6FF) : Colors.white,
                            borderRadius: BorderRadius.circular(12),
                            border: Border.all(
                              color: isUnread ? const Color(0xFFBFDBFE) : Colors.grey[100]!,
                              width: 0.5,
                            ),
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Row(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  if (isUnread)
                                    Container(
                                      margin: const EdgeInsets.only(right: 6, top: 4),
                                      width: 8,
                                      height: 8,
                                      decoration: const BoxDecoration(
                                        color: Colors.blue,
                                        shape: BoxShape.circle,
                                      ),
                                    ),
                                  Expanded(
                                    child: Text(
                                      n['title'] ?? '',
                                      style: TextStyle(
                                        fontSize: 12,
                                        fontWeight: isUnread ? FontWeight.bold : FontWeight.normal,
                                        color: const Color(0xFF1A2B3C),
                                      ),
                                    ),
                                  ),
                                ],
                              ),
                              const SizedBox(height: 4),
                              Text(
                                n['message'] ?? '',
                                style: const TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                              ),
                              const SizedBox(height: 6),
                              Align(
                                alignment: Alignment.bottomRight,
                                child: Text(
                                  '${date.hour.toString().padLeft(2, '0')}:${date.minute.toString().padLeft(2, '0')} - ${date.day}/${date.month}/${date.year}',
                                  style: TextStyle(fontSize: 8, color: Colors.grey[400]),
                                ),
                              ),
                            ],
                          ),
                        );
                      },
                    ),
            ),
          ],
        ),
      ),
    );
  }
}
