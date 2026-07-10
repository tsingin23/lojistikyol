import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';
import 'package:frontend/services/api_service.dart';

class ChatbotModal extends StatefulWidget {
  const ChatbotModal({Key? key}) : super(key: key);

  @override
  State<ChatbotModal> createState() => _ChatbotModalState();
}

class _ChatbotModalState extends State<ChatbotModal> {
  final TextEditingController _controller = TextEditingController();
  final ScrollController _scrollController = ScrollController();
  
  final List<Map<String, dynamic>> _messages = [
    {
      'isBot': true,
      'text': 'Merhaba! LojistikYol Asistanı\'na hoş geldiniz. Size nasıl yardımcı olabilirim?',
    }
  ];
  
  bool _isTyping = false;

  final List<String> _suggestedQuestions = [
    '🔒 Güvenli Havuz Nedir?',
    '📈 Nasıl Seviye Yükselirim?',
    '💸 Taban Fiyat Formülü?',
    '🎁 Aktif Bonus Kampanyaları?',
  ];

  void _scrollToBottom() {
    WidgetsBinding.instance.addPostFrameCallback((_) {
      if (_scrollController.hasClients) {
        _scrollController.animateTo(
          _scrollController.position.maxScrollExtent,
          duration: const Duration(milliseconds: 300),
          curve: Curves.easeOut,
        );
      }
    });
  }

  Future<void> _sendMessage(String text) async {
    if (text.trim().isEmpty) return;
    
    setState(() {
      _messages.add({'isBot': false, 'text': text});
      _isTyping = true;
    });
    _controller.clear();
    _scrollToBottom();

    // Context definition for chatbot to give precise replies
    final provider = Provider.of<AppProvider>(context, listen: false);
    final user = provider.currentUser;
    final contextStr = user != null 
        ? "Kullanıcı Adı: ${user['name']}, Tip: ${user['userType']}, Seviye: ${user['userLevel']}, Bakiye: ${user['balance']} TL"
        : "Anonim Ziyaretçi";

    final reply = await ApiService.askChatbot(text, contextStr);

    setState(() {
      _messages.add({'isBot': true, 'text': reply});
      _isTyping = false;
    });
    _scrollToBottom();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(28),
          topRight: Radius.circular(28),
        ),
      ),
      padding: EdgeInsets.only(
        bottom: MediaQuery.of(context).viewInsets.bottom,
      ),
      child: Column(
        children: [
          // Header Drag indicator & Title
          Container(
            padding: const EdgeInsets.symmetric(vertical: 12),
            decoration: const BoxDecoration(
              border: Border(bottom: BorderSide(color: Color(0xFFE2E8F0), width: 1)),
            ),
            child: Column(
              children: [
                Container(
                  width: 40,
                  height: 4,
                  decoration: BoxDecoration(
                    color: const Color(0xFFCBD5E1),
                    borderRadius: BorderRadius.circular(10),
                  ),
                ),
                const SizedBox(height: 10),
                const Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Icon(Icons.smart_toy, color: Color(0xFFFF8C00)),
                    SizedBox(width: 8),
                    Text(
                      'LojistikYol Yapay Zeka Asistanı',
                      style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                    ),
                  ],
                ),
              ],
            ),
          ),

          // Messages View
          Expanded(
            child: ListView.builder(
              controller: _scrollController,
              padding: const EdgeInsets.all(16),
              itemCount: _messages.length,
              itemBuilder: (context, index) {
                final msg = _messages[index];
                final isBot = msg['isBot'] == true;
                return Align(
                  alignment: isBot ? Alignment.centerLeft : Alignment.centerRight,
                  child: Container(
                    margin: const EdgeInsets.symmetric(vertical: 6),
                    padding: const EdgeInsets.symmetric(horizontal: 14, vertical: 10),
                    constraints: BoxConstraints(
                      maxWidth: MediaQuery.of(context).size.width * 0.75,
                    ),
                    decoration: BoxDecoration(
                      color: isBot ? const Color(0xFFF1F5F9) : const Color(0xFF1A2B3C),
                      borderRadius: BorderRadius.only(
                        topLeft: const Radius.circular(16),
                        topRight: const Radius.circular(16),
                        bottomLeft: Radius.circular(isBot ? 4 : 16),
                        bottomRight: Radius.circular(isBot ? 16 : 4),
                      ),
                    ),
                    child: Text(
                      msg['text'] ?? '',
                      style: TextStyle(
                        fontSize: 13,
                        color: isBot ? const Color(0xFF1E293B) : Colors.white,
                        height: 1.4,
                      ),
                    ),
                  ),
                );
              },
            ),
          ),

          // Loading Typing indicator
          if (_isTyping)
            Padding(
              padding: const EdgeInsets.only(left: 20.0, bottom: 8.0),
              child: Align(
                alignment: Alignment.centerLeft,
                child: Row(
                  children: [
                    const SizedBox(
                      width: 12,
                      height: 12,
                      child: CircularProgressIndicator(strokeWidth: 2, color: Color(0xFFFF8C00)),
                    ),
                    const SizedBox(width: 8),
                    Text(
                      'Asistan düşünüyor...',
                      style: TextStyle(fontSize: 11, color: Colors.grey[500], fontStyle: FontStyle.italic),
                    ),
                  ],
                ),
              ),
            ),

          // Suggested Questions Chips
          Container(
            height: 38,
            margin: const EdgeInsets.only(bottom: 8),
            child: ListView.builder(
              scrollDirection: Axis.horizontal,
              padding: const EdgeInsets.symmetric(horizontal: 16),
              itemCount: _suggestedQuestions.length,
              itemBuilder: (context, index) {
                return Padding(
                  padding: const EdgeInsets.only(right: 8.0),
                  child: ActionChip(
                    label: Text(
                      _suggestedQuestions[index],
                      style: const TextStyle(fontSize: 11, color: Color(0xFF1A2B3C), fontWeight: FontWeight.bold),
                    ),
                    backgroundColor: const Color(0xFFEFF6FF),
                    onPressed: () => _sendMessage(_suggestedQuestions[index]),
                  ),
                );
              },
            ),
          ),

          // Input field
          Container(
            padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
            decoration: const BoxDecoration(
              border: Border(top: BorderSide(color: Color(0xFFE2E8F0), width: 1)),
            ),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _controller,
                    textInputAction: TextInputAction.send,
                    onSubmitted: _sendMessage,
                    style: const TextStyle(fontSize: 13),
                    decoration: InputDecoration(
                      hintText: 'Sorunuzu buraya yazın...',
                      hintStyle: TextStyle(color: Colors.grey[400], fontSize: 13),
                      contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 10),
                      border: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(24),
                        borderSide: const BorderSide(color: Color(0xFFE2E8F0)),
                      ),
                      focusedBorder: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(24),
                        borderSide: const BorderSide(color: Color(0xFFFF8C00)),
                      ),
                    ),
                  ),
                ),
                const SizedBox(width: 8),
                IconButton(
                  icon: const Icon(Icons.send, color: Color(0xFFFF8C00)),
                  onPressed: () => _sendMessage(_controller.text),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
