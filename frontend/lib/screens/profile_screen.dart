import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';
import 'package:frontend/screens/wallet_modal.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({Key? key}) : super(key: key);

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  final _driverNameCtrl = TextEditingController();
  final _driverEmailCtrl = TextEditingController();
  final _driverPasswordCtrl = TextEditingController();
  final _payoutAmountCtrl = TextEditingController();
  final _payoutBankCtrl = TextEditingController();
  final _payoutIbanCtrl = TextEditingController();

  void _openWalletModal() {
    showModalBottomSheet(
      context: context,
      isScrollControlled: true,
      backgroundColor: Colors.transparent,
      builder: (context) => const WalletModal(),
    );
  }

  void _handleUpgrade(String type, {String? insuranceNo}) async {
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.upgradeProfile(type, insuranceNo);
    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Hesabınız başarıyla yükseltildi!')),
      );
    }
  }

  void _showUpgradeDialog() {
    final provider = Provider.of<AppProvider>(context, listen: false);
    final user = provider.currentUser;
    if (user == null) return;
    
    final level = user['userLevel'] ?? 1;

    showDialog(
      context: context,
      builder: (context) {
        String level1UpgradeType = 'license';
        final taxCtrl = TextEditingController();
        final insuranceCtrl = TextEditingController();

        return StatefulBuilder(
          builder: (context, setDialogState) {
            return AlertDialog(
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(24)),
              title: const Text('Hesap Seviyesini Yükselt', style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold)),
              content: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text('Mevcut Seviyeniz: Level $level', style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13)),
                    const SizedBox(height: 12),
                    if (level == 1) ...[
                      const Text('Yükseltme Türü Seçin:', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF64748B))),
                      const SizedBox(height: 6),
                      DropdownButton<String>(
                        value: level1UpgradeType,
                        isExpanded: true,
                        style: const TextStyle(fontSize: 12, color: Color(0xFF1A2B3C), fontWeight: FontWeight.bold),
                        onChanged: (val) {
                          if (val != null) {
                            setDialogState(() => level1UpgradeType = val);
                          }
                        },
                        items: const [
                          DropdownMenuItem(value: 'license', child: Text('🏍️ A2/B Sınıfı Kurye Ehliyeti')),
                          DropdownMenuItem(value: 'company', child: Text('🏢 Şahıs Şirketi (Vergi Levhası)')),
                          DropdownMenuItem(value: 'contract', child: Text('🤝 Bize Bağlı Çalışan Kurye')),
                        ],
                      ),
                      const SizedBox(height: 12),
                      if (level1UpgradeType == 'license') ...[
                        const Text('• A2 Motosiklet ya da B sınıfı kurye ehliyetinizi doğrulayarak Level 2 kurye onayına geçebilirsiniz.', style: TextStyle(fontSize: 11, color: Color(0xFF64748B))),
                      ] else if (level1UpgradeType == 'company') ...[
                        const Text('• Kendi adınıza şahıs şirketi açarak fatura kesen bağımsız kurye olabilirsiniz.', style: TextStyle(fontSize: 11, color: Color(0xFF64748B))),
                        const SizedBox(height: 8),
                        TextField(
                          controller: taxCtrl,
                          decoration: const InputDecoration(
                            labelText: 'Vergi Dairesi & Vergi No',
                            hintText: 'İstanbul V.D. - 9821038101',
                            labelStyle: TextStyle(fontSize: 11),
                          ),
                        ),
                      ] else ...[
                        const Text('• LojistikYol bünyesinde sabit maaş + sefer başı primle çalışmak için sözleşmeli kurye kadrosuna dahil olabilirsiniz.', style: TextStyle(fontSize: 11, color: Color(0xFF64748B))),
                        const SizedBox(height: 8),
                        Container(
                          padding: const EdgeInsets.all(8),
                          decoration: BoxDecoration(
                            color: const Color(0xFFEFF6FF),
                            borderRadius: BorderRadius.circular(10),
                          ),
                          child: const Text('📜 Sözleşme Metni:\nLojistikYol standart taşımacılık kurallarına ve ekipman teslimat şartlarına uymayı taahhüt ederim.', style: TextStyle(fontSize: 9, color: Colors.blue)),
                        )
                      ]
                    ] else if (level == 2) ...[
                      const Text('Level 3 Yükseltme Şartları:\n• C veya CE Ağır Vasıta Ehliyeti.\n• Taşımacılık sigorta poliçe numaranızı girin.', style: TextStyle(fontSize: 11, color: Color(0xFF64748B))),
                      const SizedBox(height: 8),
                      TextField(
                        controller: insuranceCtrl,
                        decoration: const InputDecoration(
                          labelText: 'Sigorta Poliçe No',
                          hintText: 'POL-XXXXX-XYZ',
                        ),
                      )
                    ] else ...[
                      const Text('Tebrikler! Zaten en üst seviye olan Level 3 (Ağır Vasıta Teminatlı) seviyesindesiniz.', style: TextStyle(fontSize: 12)),
                    ]
                  ],
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () => Navigator.pop(context),
                  child: const Text('İptal', style: TextStyle(color: Color(0xFF64748B))),
                ),
                if (level < 3)
                  ElevatedButton(
                    onPressed: () {
                      if (level == 1) {
                        if (level1UpgradeType == 'license') {
                          _handleUpgrade('license');
                        } else if (level1UpgradeType == 'company') {
                          _handleUpgrade('company', insuranceNo: taxCtrl.text);
                        } else {
                          _handleUpgrade('contract');
                        }
                      } else if (level == 2) {
                        _handleUpgrade('insurance', insuranceNo: insuranceCtrl.text);
                      }
                      Navigator.pop(context);
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: const Color(0xFFFF8C00),
                      foregroundColor: Colors.white,
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                    ),
                    child: const Text('Onayla ve Yükselt'),
                  )
              ],
            );
          },
        );
      },
    );
  }

  void _showEditProfileDialog() {
    final provider = Provider.of<AppProvider>(context, listen: false);
    final user = provider.currentUser;
    if (user == null) return;

    final nameCtrl = TextEditingController(text: user['name']);
    String selectedCity = user['city'] ?? 'İstanbul';

    final List<String> editCities = [
      'Adana', 'Adıyaman', 'Afyonkarahisar', 'Ağrı', 'Amasya', 'Ankara', 'Antalya', 'Artvin', 'Aydın', 'Balıkesir',
      'Bilecik', 'Bingöl', 'Bitlis', 'Bolu', 'Burdur', 'Bursa', 'Çanakkale', 'Çankırı', 'Çorum', 'Denizli',
      'Diyarbakır', 'Edirne', 'Elazığ', 'Erzincan', 'Erzurum', 'Eskişehir', 'Gaziantep', 'Giresun', 'Gümüşhane', 'Hakkari',
      'Hatay', 'Isparta', 'Mersin', 'İstanbul', 'İzmir', 'Kars', 'Kastamonu', 'Kayseri', 'Kırklareli', 'Kırşehir',
      'Kocaeli', 'Konya', 'Kütahya', 'Malatya', 'Manisa', 'Kahramanmaraş', 'Mardin', 'Muğla', 'Muş', 'Nevşehir',
      'Niğde', 'Ordu', 'Rize', 'Sakarya', 'Samsun', 'Siirt', 'Sinop', 'Sivas', 'Tekirdağ', 'Tokat',
      'Trabzon', 'Tunceli', 'Şanlıurfa', 'Uşak', 'Van', 'Yozgat', 'Zonguldak', 'Aksaray', 'Bayburt', 'Karaman',
      'Kırıkkale', 'Batman', 'Şırnak', 'Bartın', 'Ardahan', 'Iğdır', 'Yalova', 'Karabük', 'Kilis', 'Osmaniye', 'Düzce'
    ]..sort();

    if (!editCities.contains(selectedCity)) {
      editCities.add(selectedCity);
      editCities.sort();
    }

    showDialog(
      context: context,
      builder: (context) {
        return StatefulBuilder(
          builder: (context, setDialogState) {
            return AlertDialog(
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(24)),
              title: const Text('Profili Düzenle', style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold)),
              content: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    TextField(
                      controller: nameCtrl,
                      decoration: const InputDecoration(
                        labelText: 'Ad Soyad',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 16),
                    const Align(
                      alignment: Alignment.centerLeft,
                      child: Text('Şehir:', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF64748B))),
                    ),
                    const SizedBox(height: 6),
                    Container(
                      padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 4),
                      decoration: BoxDecoration(
                        border: Border.all(color: const Color(0xFFCBD5E1)),
                        borderRadius: BorderRadius.circular(12),
                      ),
                      child: DropdownButtonHideUnderline(
                        child: DropdownButton<String>(
                          value: selectedCity,
                          isExpanded: true,
                          style: const TextStyle(fontSize: 13, color: Color(0xFF1A2B3C)),
                          onChanged: (val) {
                            if (val != null) {
                              setDialogState(() => selectedCity = val);
                            }
                          },
                          items: editCities.map((c) {
                            return DropdownMenuItem(
                              value: c,
                              child: Text(c),
                            );
                          }).toList(),
                        ),
                      ),
                    )
                  ],
                ),
              ),
              actions: [
                TextButton(
                  onPressed: () => Navigator.pop(context),
                  child: const Text('İptal', style: TextStyle(color: Color(0xFF64748B))),
                ),
                ElevatedButton(
                  onPressed: () async {
                    if (nameCtrl.text.trim().isEmpty) return;
                    final success = await provider.updateProfile(nameCtrl.text.trim(), selectedCity);
                    if (success) {
                      Navigator.pop(context);
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(content: Text('Profil başarıyla güncellendi.')),
                      );
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: const Color(0xFFFF8C00),
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                  ),
                  child: const Text('Kaydet'),
                )
              ],
            );
          },
        );
      },
    );
  }

  void _addFleetDriver() async {
    final name = _driverNameCtrl.text.trim();
    final email = _driverEmailCtrl.text.trim();
    final pwd = _driverPasswordCtrl.text;
    
    if (name.isEmpty || email.isEmpty || pwd.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Lütfen tüm alanları doldurun.')),
      );
      return;
    }

    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.addFleetDriver(name, email, pwd);
    if (success) {
      _driverNameCtrl.clear();
      _driverEmailCtrl.clear();
      _driverPasswordCtrl.clear();
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Sürücü başarıyla eklendi ve filonuza bağlandı.')),
      );
      await provider.refreshAll();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Hata: Sürücü eklenemedi veya e-posta zaten kayıtlı.')),
      );
    }
  }

  void _submitPayoutRequest() async {
    final amtText = _payoutAmountCtrl.text.trim();
    final bank = _payoutBankCtrl.text.trim();
    final iban = _payoutIbanCtrl.text.trim();

    final amt = double.tryParse(amtText);
    if (amt == null || amt <= 0 || bank.isEmpty || iban.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Lütfen tüm çekim detaylarını eksiksiz girin.')),
      );
      return;
    }

    final provider = Provider.of<AppProvider>(context, listen: false);
    final user = provider.currentUser;
    if (user != null && amt > (user['balance'] as num).toDouble()) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Hata: Yetersiz cüzdan bakiyesi!')),
      );
      return;
    }

    final success = await provider.createPayoutRequest(amt, bank, iban);
    if (success) {
      _payoutAmountCtrl.clear();
      _payoutBankCtrl.clear();
      _payoutIbanCtrl.clear();
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('QuickPay para çekme talebiniz işleme alındı!')),
      );
      await provider.refreshAll();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Hata: Çekim talebi iletilemedi.')),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);
    final user = provider.currentUser;

    if (user == null) {
      return const Scaffold(body: Center(child: Text('Lütfen giriş yapın.')));
    }

    final isSender = user['userType'] == 'Sender';
    final profile = user['carrierProfile'];
    final rating = (profile != null && profile['rating'] != null) ? (profile['rating'] as num).toDouble() : 0.0;
    
    // Check bonus campaigns
    final bool hasWelcomeBonus = user['welcomeBonusExpiry'] != null &&
        DateTime.parse(user['welcomeBonusExpiry']).isAfter(DateTime.now());
    final bool hasPeriodicBonus = user['periodicBonusActive'] == true;

    return Scaffold(
      backgroundColor: const Color(0xFFF4F7F9),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(24),
        child: Column(
          children: [
            // Profile Card Header with custom logo
            Container(
              padding: const EdgeInsets.all(24),
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(28),
                boxShadow: [
                  BoxShadow(
                    color: Colors.black.withOpacity(0.01),
                    blurRadius: 10,
                    offset: const Offset(0, 8),
                  )
                ],
              ),
              child: Column(
                children: [
                  CircleAvatar(
                    radius: 40,
                    backgroundColor: const Color(0xFFF1F5F9),
                    backgroundImage: const AssetImage('assets/logo.jpg'),
                    child: Image.asset(
                      'assets/logo.jpg',
                      fit: BoxFit.cover,
                      errorBuilder: (context, error, stackTrace) => const Icon(Icons.person, color: Color(0xFF1A2B3C), size: 40),
                    ),
                  ),
                  const SizedBox(height: 12),
                  Text(
                    user['name'] ?? '',
                    style: const TextStyle(fontSize: 16, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                  ),
                  const SizedBox(height: 4),
                  Text(
                    isSender ? 'Kargo Gönderici Üye' : 'Lojistik Taşıyıcı • Level ${user['userLevel']}',
                    style: const TextStyle(fontSize: 11, color: Color(0xFF64748B)),
                  ),
                  if (!isSender && profile != null) ...[
                    const SizedBox(height: 8),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const Icon(Icons.star, color: Colors.amber, size: 16),
                        const SizedBox(width: 4),
                        Text(
                          '$rating ★ Rating',
                          style: const TextStyle(fontSize: 12, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                        )
                      ],
                    ),
                  ],
                  const SizedBox(height: 8),
                  OutlinedButton.icon(
                    onPressed: _showEditProfileDialog,
                    icon: const Icon(Icons.edit, size: 12),
                    label: const Text('Profili Düzenle', style: TextStyle(fontSize: 10, fontWeight: FontWeight.bold)),
                    style: OutlinedButton.styleFrom(
                      foregroundColor: const Color(0xFFFF8C00),
                      side: const BorderSide(color: Color(0xFFFF8C00), width: 1),
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
                      padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 4),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 16),

            // Balance Wallet Panel
            Container(
              padding: const EdgeInsets.all(20),
              decoration: BoxDecoration(
                gradient: const LinearGradient(
                  colors: [Color(0xFF1A2B3C), Color(0xFF2E4057)],
                  begin: Alignment.topLeft,
                  end: Alignment.bottomRight,
                ),
                borderRadius: BorderRadius.circular(24),
              ),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        const Text(
                          'Cüzdan Bakiye Durumu',
                          style: TextStyle(color: Colors.white70, fontSize: 10),
                        ),
                        const SizedBox(height: 4),
                        FittedBox(
                          fit: BoxFit.scaleDown,
                          alignment: Alignment.centerLeft,
                          child: Text(
                            '₺${user['balance']}',
                            style: const TextStyle(color: Colors.white, fontSize: 22, fontWeight: FontWeight.bold),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(width: 12),
                  ElevatedButton.icon(
                    onPressed: _openWalletModal,
                    icon: const Icon(Icons.add, size: 16),
                    label: const Text('Bakiye Ekle'),
                    style: ElevatedButton.styleFrom(
                      backgroundColor: const Color(0xFFFF8C00),
                      foregroundColor: Colors.white,
                      elevation: 0,
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
                    ),
                  )
                ],
              ),
            ),
            const SizedBox(height: 20),

            // Active Payout / Welcome Bonus details
            if (hasWelcomeBonus || hasPeriodicBonus) ...[
              const Align(
                alignment: Alignment.centerLeft,
                child: Padding(
                  padding: EdgeInsets.only(left: 8.0, bottom: 8.0),
                  child: Text(
                    'Aktif Payout Bonus Kampanyaları',
                    style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                  ),
                ),
              ),
              if (hasWelcomeBonus)
                Container(
                  margin: const EdgeInsets.only(bottom: 12),
                  padding: const EdgeInsets.all(16),
                  decoration: BoxDecoration(
                    gradient: const LinearGradient(
                      colors: [Color(0xFFFEF3C7), Color(0xFFFFFBEB)],
                      begin: Alignment.topLeft,
                      end: Alignment.bottomRight,
                    ),
                    borderRadius: BorderRadius.circular(20),
                    border: Border.all(color: const Color(0xFFFDE68A)),
                  ),
                  child: Row(
                    children: [
                      const Icon(Icons.workspace_premium, color: Color(0xFFFF8C00), size: 36),
                      const SizedBox(width: 12),
                      Expanded(
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            const Text(
                              'Hoş Geldin Kampanyası',
                              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF92400E)),
                            ),
                            const SizedBox(height: 2),
                            const Text(
                              '%0 Komisyon & +%10 Ekstra Kazanç Payout',
                              style: TextStyle(fontSize: 10, color: Color(0xFFB45309)),
                            ),
                            const SizedBox(height: 4),
                            Text(
                              'Geçerlilik: 1 Hafta (Son Gün: ${user['welcomeBonusExpiry'].toString().split('T').first})',
                              style: const TextStyle(fontSize: 9, fontWeight: FontWeight.bold, color: Color(0xFFD97706)),
                            ),
                          ],
                        ),
                      )
                    ],
                  ),
                ),
              if (hasPeriodicBonus)
                Container(
                  padding: const EdgeInsets.all(16),
                  decoration: BoxDecoration(
                    gradient: const LinearGradient(
                      colors: [Color(0xFFF3E8FF), Color(0xFFFAF5FF)],
                      begin: Alignment.topLeft,
                      end: Alignment.bottomRight,
                    ),
                    borderRadius: BorderRadius.circular(20),
                    border: Border.all(color: const Color(0xFFE9D5FF)),
                  ),
                  child: const Row(
                    children: [
                      Icon(Icons.flash_on, color: Colors.purple, size: 36),
                      SizedBox(width: 12),
                      Expanded(
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(
                              'Haftalık Görev Bonusu',
                              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF6B21A8)),
                            ),
                            SizedBox(height: 2),
                            Text(
                              'Görevi Tamamla: 3 Sevkiyat Bitir',
                              style: TextStyle(fontSize: 10, color: Color(0xFF7E22CE)),
                            ),
                            SizedBox(height: 4),
                            Text(
                              'Kazanılacak Ödül: +₺5.000 Nakit',
                              style: TextStyle(fontSize: 9, fontWeight: FontWeight.bold, color: Color(0xFF9333EA)),
                            ),
                          ],
                        ),
                      )
                    ],
                  ),
                ),
              const SizedBox(height: 20),
            ],

            if (!isSender) ...[
              Container(
                margin: const EdgeInsets.only(bottom: 20),
                padding: const EdgeInsets.all(20),
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(24),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Row(
                      children: [
                        Icon(Icons.payment, color: Color(0xFFFF8C00)),
                        SizedBox(width: 8),
                        Text(
                          'QuickPay Anında Banka Çekimi',
                          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                        ),
                      ],
                    ),
                    const SizedBox(height: 6),
                    const Text(
                      'Cüzdanınızdaki bakiyeyi 7/24 anında dilediğiniz banka hesabına aktarabilirsiniz.',
                      style: TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                    ),
                    const SizedBox(height: 12),
                    TextField(
                      controller: _payoutAmountCtrl,
                      keyboardType: TextInputType.number,
                      decoration: const InputDecoration(
                        labelText: 'Çekilecek Tutar (₺)',
                        border: OutlineInputBorder(),
                        prefixText: '₺ ',
                      ),
                    ),
                    const SizedBox(height: 8),
                    TextField(
                      controller: _payoutBankCtrl,
                      decoration: const InputDecoration(
                        labelText: 'Banka Adı',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 8),
                    TextField(
                      controller: _payoutIbanCtrl,
                      decoration: const InputDecoration(
                        labelText: 'IBAN Numarası (TR...)',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 12),
                    SizedBox(
                      width: double.infinity,
                      height: 44,
                      child: ElevatedButton(
                        onPressed: _submitPayoutRequest,
                        style: ElevatedButton.styleFrom(
                          backgroundColor: const Color(0xFF1A2B3C),
                          foregroundColor: Colors.white,
                          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                        ),
                        child: const Text('Çekim Talebi Gönder', style: TextStyle(fontWeight: FontWeight.bold)),
                      ),
                    ),
                  ],
                ),
              ),
            ],

            if (!isSender && (user['userLevel'] == 2 || user['userLevel'] == 3)) ...[
              Container(
                margin: const EdgeInsets.only(bottom: 20),
                padding: const EdgeInsets.all(20),
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(24),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Row(
                          children: [
                            const Icon(Icons.people, color: Color(0xFFFF8C00)),
                            const SizedBox(width: 8),
                            Text(
                              user['userLevel'] == 2 ? 'Şahıs Şirketi - Kurye Paneli' : 'Filo Şoför Yönetim Paneli',
                              style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                            ),
                          ],
                        ),
                        Container(
                          padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 2),
                          decoration: const BoxDecoration(
                            color: Color(0xFFD1FAE5),
                            borderRadius: BorderRadius.all(Radius.circular(8)),
                          ),
                          child: const Text(
                            'Aktif',
                            style: TextStyle(color: Colors.green, fontSize: 8, fontWeight: FontWeight.bold),
                          ),
                        )
                      ],
                    ),
                    const SizedBox(height: 6),
                    const Text(
                      'Bünyenizde çalışan kurye/sürücü ekleyerek sevkiyatları onlara atayabilirsiniz.',
                      style: TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                    ),
                    const SizedBox(height: 16),
                    const Text(
                      'KAYITLI SÜRÜCÜLER',
                      style: TextStyle(fontWeight: FontWeight.bold, fontSize: 10, color: Color(0xFF64748B), letterSpacing: 0.5),
                    ),
                    const SizedBox(height: 8),
                    if (user['fleetDrivers'] == null || (user['fleetDrivers'] as List).isEmpty)
                      const Padding(
                        padding: EdgeInsets.symmetric(vertical: 8.0),
                        child: Text(
                          'Henüz kayıtlı bir sürücünüz bulunmuyor.',
                          style: TextStyle(fontSize: 11, color: Color(0xFF94A3B8), fontStyle: FontStyle.italic),
                        ),
                      )
                    else
                      ListView.builder(
                        shrinkWrap: true,
                        physics: const NeverScrollableScrollPhysics(),
                        itemCount: (user['fleetDrivers'] as List).length,
                        itemBuilder: (context, idx) {
                          final dr = user['fleetDrivers'][idx];
                          return Card(
                            margin: const EdgeInsets.only(bottom: 8),
                            color: const Color(0xFFF8FAFC),
                            shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                            elevation: 0,
                            child: ListTile(
                              dense: true,
                              leading: const CircleAvatar(
                                radius: 14,
                                backgroundColor: Color(0xFFEFF6FF),
                                child: Icon(Icons.person, size: 14, color: Colors.blue),
                              ),
                              title: Text(dr['name'] ?? '', style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 11)),
                              subtitle: Text(dr['email'] ?? '', style: const TextStyle(fontSize: 9)),
                              trailing: const Icon(Icons.check_circle, color: Colors.green, size: 16),
                            ),
                          );
                        },
                      ),
                    const Divider(height: 24),
                    const Text(
                      'YENİ SÜRÜCÜ EKLE',
                      style: TextStyle(fontWeight: FontWeight.bold, fontSize: 10, color: Color(0xFF64748B)),
                    ),
                    const SizedBox(height: 8),
                    TextField(
                      controller: _driverNameCtrl,
                      decoration: const InputDecoration(
                        labelText: 'Sürücü Adı Soyadı',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 8),
                    TextField(
                      controller: _driverEmailCtrl,
                      decoration: const InputDecoration(
                        labelText: 'Sürücü E-posta',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 8),
                    TextField(
                      controller: _driverPasswordCtrl,
                      obscureText: true,
                      decoration: const InputDecoration(
                        labelText: 'Sürücü Geçici Şifre',
                        border: OutlineInputBorder(),
                      ),
                    ),
                    const SizedBox(height: 12),
                    SizedBox(
                      width: double.infinity,
                      height: 44,
                      child: ElevatedButton.icon(
                        onPressed: _addFleetDriver,
                        icon: const Icon(Icons.add, size: 16),
                        label: const Text('Sürücü Ekle & Bağla', style: TextStyle(fontWeight: FontWeight.bold)),
                        style: ElevatedButton.styleFrom(
                          backgroundColor: const Color(0xFFFF8C00),
                          foregroundColor: Colors.white,
                          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ],

            // User Info Grid / List details
            Container(
              padding: const EdgeInsets.all(12),
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(24),
              ),
              child: Column(
                children: [
                  ListTile(
                    leading: const Icon(Icons.location_city, color: Color(0xFF64748B)),
                    title: const Text('Kayıtlı Bulunduğu Şehir', style: TextStyle(fontSize: 12)),
                    trailing: Text(user['city'] ?? 'İstanbul', style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 12)),
                  ),
                  const Divider(height: 1),
                  ListTile(
                    leading: const Icon(Icons.email, color: Color(0xFF64748B)),
                    title: const Text('E-posta Adresi', style: TextStyle(fontSize: 12)),
                    trailing: Text(user['email'] ?? '', style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 12)),
                  ),
                  if (!isSender) ...[
                    const Divider(height: 1),
                    ListTile(
                      leading: const Icon(Icons.verified, color: Color(0xFF64748B)),
                      title: const Text('Ehliyet / Lisans Tipi', style: TextStyle(fontSize: 12)),
                      trailing: Text(profile != null ? profile['licenseType'] : 'B Sınıfı', style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 12)),
                    ),
                    const Divider(height: 1),
                    ListTile(
                      leading: const Icon(Icons.security, color: Color(0xFF64748B)),
                      title: const Text('Seviye Yükseltme', style: TextStyle(fontSize: 12)),
                      trailing: const Icon(Icons.arrow_forward_ios, size: 12),
                      onTap: _showUpgradeDialog,
                    ),
                  ],
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
