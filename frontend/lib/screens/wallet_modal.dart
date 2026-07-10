import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';

class WalletModal extends StatefulWidget {
  const WalletModal({Key? key}) : super(key: key);

  @override
  State<WalletModal> createState() => _WalletModalState();
}

class _WalletModalState extends State<WalletModal> {
  final TextEditingController _amountCtrl = TextEditingController(text: '10000');
  bool _isLoading = false;

  void _handleTopUp() async {
    final double? amount = double.tryParse(_amountCtrl.text);
    if (amount == null || amount <= 0) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Lütfen geçerli bir tutar girin.')),
      );
      return;
    }

    setState(() => _isLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.topUp(amount);
    setState(() => _isLoading = false);

    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Cüzdanınıza ₺$amount başarıyla yüklendi!')),
      );
      Navigator.pop(context);
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Yükleme başarısız, lütfen tekrar deneyin.')),
      );
    }
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
        top: 24,
        left: 24,
        right: 24,
        bottom: MediaQuery.of(context).viewInsets.bottom + 24,
      ),
      child: Column(
        mainAxisSize: MainAxisSize.min,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              const Text(
                'Bakiye Yükleme',
                style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
              ),
              IconButton(
                icon: const Icon(Icons.close),
                onPressed: () => Navigator.pop(context),
              )
            ],
          ),
          const SizedBox(height: 16),
          const Text(
            'Güvenli ödeme altyapımız üzerinden cüzdanınıza bakiye ekleyerek ihale tekliflerini anında yönetebilirsiniz.',
            style: TextStyle(fontSize: 11, color: Color(0xFF64748B), height: 1.4),
          ),
          const SizedBox(height: 20),
          TextField(
            controller: _amountCtrl,
            keyboardType: TextInputType.number,
            style: const TextStyle(fontSize: 20, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
            decoration: InputDecoration(
              labelText: 'Yüklenecek Tutar (₺)',
              labelStyle: const TextStyle(fontSize: 12),
              border: OutlineInputBorder(borderRadius: BorderRadius.circular(16)),
              prefixText: '₺ ',
            ),
          ),
          const SizedBox(height: 20),
          
          // Fast top up chips
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: ['5000', '10000', '25000', '50000'].map((String val) {
              return ActionChip(
                label: Text('₺$val'),
                onPressed: () {
                  setState(() => _amountCtrl.text = val);
                },
              );
            }).toList(),
          ),
          const SizedBox(height: 24),
          
          SizedBox(
            width: double.infinity,
            height: 52,
            child: ElevatedButton(
              onPressed: _isLoading ? null : _handleTopUp,
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color(0xFFFF8C00),
                foregroundColor: Colors.white,
                shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
                elevation: 0,
              ),
              child: _isLoading
                  ? const SizedBox(
                      width: 24,
                      height: 24,
                      child: CircularProgressIndicator(color: Colors.white, strokeWidth: 2),
                    )
                  : const Text('Ödeme Yap ve Yükle', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 14)),
            ),
          )
        ],
      ),
    );
  }
}
