import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';

class ChatbotModal extends StatefulWidget {
  const ChatbotModal({Key? key}) : super(key: key);

  @override
  State<ChatbotModal> createState() => _ChatbotModalState();
}

class _ChatbotModalState extends State<ChatbotModal> {
  final _msgCtrl = TextEditingController();
  final _scrollCtrl = ScrollController();
  bool _isSending = false;

  @override
  void initState() {
    super.initState();
    // Welcome message if list is empty
    WidgetsBinding.instance.addPostFrameCallback((_) {
      final provider = Provider.of<AppProvider>(context, listen: false);
      if (provider.chatMessages.isEmpty) {
        provider.sendChatMessage("merhaba");
      }
    });
  }

  @override
  void dispose() {
    _msgCtrl.dispose();
    _scrollCtrl.dispose();
    super.dispose();
  }

  void _scrollToBottom() {
    Future.delayed(const Duration(milliseconds: 150), () {
      if (_scrollCtrl.hasClients) {
        _scrollCtrl.animateTo(
          _scrollCtrl.position.maxScrollExtent,
          duration: const Duration(milliseconds: 200),
          curve: Curves.easeOut,
        );
      }
    });
  }

  void _sendMessage([String? quickText]) async {
    final text = quickText ?? _msgCtrl.text;
    if (text.trim().isEmpty) return;

    if (quickText == null) {
      _msgCtrl.clear();
    }

    setState(() {
      _isSending = true;
    });

    final provider = Provider.of<AppProvider>(context, listen: false);
    _scrollToBottom();
    
    await provider.sendChatMessage(text);
    
    if (mounted) {
      setState(() {
        _isSending = false;
      });
      _scrollToBottom();
    }
  }

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);
    final messages = provider.chatMessages;

    return Container(
      decoration: const BoxDecoration(
        color: Color(0xFFF4F7F9),
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(28),
          topRight: Radius.circular(28),
        ),
      ),
      child: Column(
        children: [
          // Header Bar
          Container(
            padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 16),
            decoration: const BoxDecoration(
              color: Color(0xFF1A2B3C),
              borderRadius: BorderRadius.only(
                topLeft: Radius.circular(28),
                topRight: Radius.circular(28),
              ),
            ),
            child: Row(
              children: [
                Container(
                  width: 38,
                  height: 38,
                  decoration: BoxDecoration(
                    shape: BoxShape.circle,
                    image: const DecorationImage(
                      image: AssetImage('assets/images/logo.jpg'),
                      fit: BoxFit.cover,
                    ),
                    border: Border.all(color: const Color(0xFFFF8C00), width: 1.5),
                  ),
                ),
                const SizedBox(width: 12),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text(
                        'LojistikYol AsistanÄ±',
                        style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 14),
                      ),
                      Row(
                        children: [
                          Container(
                            width: 6,
                            height: 6,
                            decoration: const BoxDecoration(color: Color(0xFF10B981), shape: BoxShape.circle),
                          ),
                          const SizedBox(width: 6),
                          const Text(
                            'Ã‡evrimiÃ§i â€¢ GÃ¼venli Havuz DesteÄŸi',
                            style: TextStyle(color: Color(0xFF94A3B8), fontSize: 10),
                          ),
                        ],
                      )
                    ],
                  ),
                ),
                IconButton(
                  icon: const Icon(Icons.close, color: Colors.white70, size: 20),
                  onPressed: () => Navigator.pop(context),
                )
              ],
            ),
          ),

          // Message Thread List
          Expanded(
            child: ListView.builder(
              controller: _scrollCtrl,
              padding: const EdgeInsets.all(16),
              itemCount: messages.length,
              itemBuilder: (context, idx) {
                final msg = messages[idx];
                final isUser = msg['sender'] == 'user';

                return Align(
                  alignment: isUser ? Alignment.centerRight : Alignment.centerLeft,
                  child: Container(
                    margin: const EdgeInsets.only(bottom: 12),
                    padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
                    constraints: BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.75),
                    decoration: BoxDecoration(
                      color: isUser ? const Color(0xFFFF8C00) : Colors.white,
                      borderRadius: BorderRadius.only(
                        topLeft: const Radius.circular(16),
                        topRight: const Radius.circular(16),
                        bottomLeft: isUser ? const Radius.circular(16) : Radius.zero,
                        bottomRight: isUser ? Radius.zero : const Radius.circular(16),
                      ),
                      boxShadow: [
                        BoxShadow(
                          color: Colors.black.withOpacity(0.02),
                          blurRadius: 5,
                          offset: const Offset(0, 2),
                        )
                      ],
                      border: isUser ? null : Border.all(color: const Color(0xFFE2E8F0)),
                    ),
                    child: Text(
                      msg['text'] ?? '',
                      style: TextStyle(
                        color: isUser ? Colors.white : const Color(0xFF1A2B3C),
                        fontSize: 12.5,
                        height: 1.4,
                      ),
                    ),
                  ),
                );
              },
            ),
          ),

          // FAQ Chips / Suggestions
          Container(
            height: 44,
            padding: const EdgeInsets.symmetric(horizontal: 8),
            child: ListView(
              scrollDirection: Axis.horizontal,
              children: [
                _buildFaqChip('ğŸ”’ GÃ¼venli Havuz?'),
                _buildFaqChip('ğŸ“ˆ Seviye YÃ¼kseltme?'),
                _buildFaqChip('ğŸ Aktif Bonuslar?'),
                _buildFaqChip('ğŸ§® Taban Fiyat FormÃ¼lÃ¼?'),
              ],
            ),
          ),

          // Input Bar
          SafeArea(
            top: false,
            child: Container(
              padding: const EdgeInsets.all(12),
              decoration: const BoxDecoration(
                color: Colors.white,
                border: Border(top: BorderSide(color: Color(0xFFE2E8F0))),
              ),
              child: Row(
                children: [
                  Expanded(
                    child: TextField(
                      controller: _msgCtrl,
                      style: const TextStyle(fontSize: 13),
                      decoration: InputDecoration(
                        hintText: 'Sorunuzu buraya yazÄ±n...',
                        hintStyle: const TextStyle(color: Color(0xFF94A3B8)),
                        border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(24),
                          borderSide: const BorderSide(color: Color(0xFFE2E8F0)),
                        ),
                        contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 8),
                        fillColor: const Color(0xFFF8FAFC),
                        filled: true,
                      ),
                      textInputAction: TextInputAction.send,
                      onSubmitted: (_) => _sendMessage(),
                    ),
                  ),
                  const SizedBox(width: 8),
                  GestureDetector(
                    onTap: _isSending ? null : () => _sendMessage(),
                    child: CircleAvatar(
                      backgroundColor: const Color(0xFFFF8C00),
                      radius: 20,
                      child: _isSending
                          ? const SizedBox(
                              width: 16,
                              height: 16,
                              child: CircularProgressIndicator(color: Colors.white, strokeWidth: 2),
                            )
                          : const Icon(Icons.send, color: Colors.white, size: 16),
                    ),
                  )
                ],
              ),
            ),
          )
        ],
      ),
    );
  }

  Widget _buildFaqChip(String label) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 4),
      child: ActionChip(
        label: Text(label, style: const TextStyle(fontSize: 10, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C))),
        backgroundColor: Colors.white,
        side: const BorderSide(color: Color(0xFFE2E8F0)),
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
        onPressed: () {
          // Map chip labels to raw query strings
          String raw = label;
          if (label.contains('Havuz')) raw = "gÃ¼venli havuz nedir";
          if (label.contains('Seviye')) raw = "nasÄ±l seviye atlarÄ±m";
          if (label.contains('Bonus')) raw = "aktif bonuslar neler";
          if (label.contains('FormÃ¼lÃ¼')) raw = "taban fiyat hesaplama formÃ¼lÃ¼";
          _sendMessage(raw);
        },
      ),
    );
  }
}
