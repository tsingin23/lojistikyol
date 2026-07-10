import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';
import 'package:frontend/screens/bid_details_screen.dart';

class ExploreScreen extends StatefulWidget {
  const ExploreScreen({Key? key}) : super(key: key);

  @override
  State<ExploreScreen> createState() => _ExploreScreenState();
}

class _ExploreScreenState extends State<ExploreScreen> {
  // Segmented control: 'ads' or 'carriers'
  String _activeTab = 'ads';

  // --- Ad filters state ---
  String _adStartCity = 'Tümü';
  String _adEndCity = 'Tümü';

  // --- Carrier directory filters state ---
  String _carrierCity = 'Tümü';
  String _carrierLevel = 'Tümü';
  String _carrierLicense = 'Tümü';
  double _minRating = 0.0;

  final List<String> _cities = ['Tümü'] + ([
    'Adana', 'Adıyaman', 'Afyonkarahisar', 'Ağrı', 'Amasya', 'Ankara', 'Antalya', 'Artvin', 'Aydın', 'Balıkesir',
    'Bilecik', 'Bingöl', 'Bitlis', 'Bolu', 'Burdur', 'Bursa', 'Çanakkale', 'Çankırı', 'Çorum', 'Denizli',
    'Diyarbakır', 'Edirne', 'Elazığ', 'Erzincan', 'Erzurum', 'Eskişehir', 'Gaziantep', 'Giresun', 'Gümüşhane', 'Hakkari',
    'Hatay', 'Isparta', 'Mersin', 'İstanbul', 'İzmir', 'Kars', 'Kastamonu', 'Kayseri', 'Kırklareli', 'Kırşehir',
    'Kocaeli', 'Konya', 'Kütahya', 'Malatya', 'Manisa', 'Kahramanmaraş', 'Mardin', 'Muğla', 'Muş', 'Nevşehir',
    'Niğde', 'Ordu', 'Rize', 'Sakarya', 'Samsun', 'Siirt', 'Sinop', 'Sivas', 'Tekirdağ', 'Tokat',
    'Trabzon', 'Tunceli', 'Şanlıurfa', 'Uşak', 'Van', 'Yozgat', 'Zonguldak', 'Aksaray', 'Bayburt', 'Karaman',
    'Kırıkkale', 'Batman', 'Şırnak', 'Bartın', 'Ardahan', 'Iğdır', 'Yalova', 'Karabük', 'Kilis', 'Osmaniye', 'Düzce'
  ]..sort());
  final List<String> _levels = ['Tümü', 'Level 1', 'Level 2', 'Level 3'];
  final List<String> _licenses = ['Tümü', 'A2 Sınıfı (Moto Kurye)', 'Şahıs Şirketi (Doğrulandı)', 'Bize Bağlı Çalışan (Sözleşmeli)', 'CE (Ağır Vasıta - Sigortalı)'];

  // Add listing dialog controller
  final _titleCtrl = TextEditingController();
  final _descCtrl = TextEditingController();
  final _startCityCtrl = TextEditingController(text: 'İstanbul');
  final _endCityCtrl = TextEditingController(text: 'Ankara');
  final _distanceCtrl = TextEditingController(text: '450');
  final _cargoValueCtrl = TextEditingController(text: '120000');
  int _reqLevel = 1;

  void _showAddAdDialog() {
    showDialog(
      context: context,
      builder: (context) {
        return StatefulBuilder(
          builder: (context, setDialogState) {
            return AlertDialog(
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(24)),
              title: const Row(
                children: [
                  Icon(Icons.add_business, color: Color(0xFFFF8C00)),
                  SizedBox(width: 8),
                  Text('Yeni Sevkiyat İlanı Ekle', style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold)),
                ],
              ),
              content: SingleChildScrollView(
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    TextField(controller: _titleCtrl, decoration: const InputDecoration(labelText: 'İlan Başlığı')),
                    const SizedBox(height: 8),
                    TextField(controller: _descCtrl, decoration: const InputDecoration(labelText: 'Kargo İçerik / Detaylar')),
                    const SizedBox(height: 8),
                    TextField(controller: _startCityCtrl, decoration: const InputDecoration(labelText: 'Nereden (İl)')),
                    const SizedBox(height: 8),
                    TextField(controller: _endCityCtrl, decoration: const InputDecoration(labelText: 'Nereye (İl)')),
                    const SizedBox(height: 8),
                    TextField(controller: _distanceCtrl, keyboardType: TextInputType.number, decoration: const InputDecoration(labelText: 'Mesafe (Km)')),
                    const SizedBox(height: 8),
                    TextField(controller: _cargoValueCtrl, keyboardType: TextInputType.number, decoration: const InputDecoration(labelText: 'Mal Değeri (TL)')),
                    const SizedBox(height: 12),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Text('Min Seviye Yetkisi:', style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold)),
                        DropdownButton<int>(
                          value: _reqLevel,
                          onChanged: (val) {
                            if (val != null) setDialogState(() => _reqLevel = val);
                          },
                          items: const [
                            DropdownMenuItem(value: 1, child: Text('Level 1')),
                            DropdownMenuItem(value: 2, child: Text('Level 2')),
                            DropdownMenuItem(value: 3, child: Text('Level 3')),
                          ],
                        )
                      ],
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
                    final provider = Provider.of<AppProvider>(context, listen: false);
                    final success = await provider.createAd(
                      _titleCtrl.text,
                      _descCtrl.text,
                      _startCityCtrl.text,
                      _endCityCtrl.text,
                      double.tryParse(_distanceCtrl.text) ?? 100.0,
                      double.tryParse(_cargoValueCtrl.text) ?? 50000.0,
                      _reqLevel,
                    );
                    if (success) {
                      _titleCtrl.clear();
                      _descCtrl.clear();
                      Navigator.pop(context);
                      ScaffoldMessenger.of(context).showSnackBar(
                        const SnackBar(content: Text('İlanınız yayına alındı.')),
                      );
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: const Color(0xFFFF8C00),
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                  ),
                  child: const Text('Yayınla'),
                )
              ],
            );
          },
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);
    final user = provider.currentUser;

    // Filter Cargo Ads
    final List<dynamic> filteredAds = provider.ads.where((ad) {
      bool matchesStart = _adStartCity == 'Tümü' || ad['startLocation'] == _adStartCity;
      bool matchesEnd = _adEndCity == 'Tümü' || ad['endLocation'] == _adEndCity;
      return matchesStart && matchesEnd;
    }).toList();

    // Filter Carriers list
    final List<dynamic> filteredCarriers = provider.carriers.where((c) {
      bool matchesCity = _carrierCity == 'Tümü' || c['city'] == _carrierCity;
      bool matchesLevel = _carrierLevel == 'Tümü' || 'Level ${c['userLevel']}' == _carrierLevel;
      
      final profile = c['carrierProfile'];
      bool matchesLicense = _carrierLicense == 'Tümü' ||
          (profile != null && profile['licenseType'].toString().contains(_carrierLicense));
      
      double rating = (profile != null && profile['rating'] != null) ? (profile['rating'] as num).toDouble() : 0.0;
      bool matchesRating = rating >= _minRating;

      return matchesCity && matchesLevel && matchesLicense && matchesRating;
    }).toList();

    return Scaffold(
      backgroundColor: const Color(0xFFF4F7F9),
      body: RefreshIndicator(
        onRefresh: () => provider.refreshAll(),
        child: CustomScrollView(
          slivers: [
            // Segment Switcher tab (Listing vs Carriers Directory)
            SliverToBoxAdapter(
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Container(
                  height: 48,
                  padding: const EdgeInsets.all(4),
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(16),
                    border: Border.all(color: const Color(0xFFE2E8F0)),
                  ),
                  child: Row(
                    children: [
                      Expanded(
                        child: GestureDetector(
                          onTap: () => setState(() => _activeTab = 'ads'),
                          child: Container(
                            decoration: BoxDecoration(
                              color: _activeTab == 'ads' ? const Color(0xFFFF8C00) : Colors.transparent,
                              borderRadius: BorderRadius.circular(12),
                            ),
                            child: Center(
                              child: Text(
                                '🚚 Sevkiyat İlanları',
                                style: TextStyle(
                                  fontSize: 12,
                                  fontWeight: FontWeight.bold,
                                  color: _activeTab == 'ads' ? Colors.white : const Color(0xFF64748B),
                                ),
                              ),
                            ),
                          ),
                        ),
                      ),
                      Expanded(
                        child: GestureDetector(
                          onTap: () => setState(() => _activeTab = 'carriers'),
                          child: Container(
                            decoration: BoxDecoration(
                              color: _activeTab == 'carriers' ? const Color(0xFF1A2B3C) : Colors.transparent,
                              borderRadius: BorderRadius.circular(12),
                            ),
                            child: Center(
                              child: Text(
                                '👥 Taşıyıcı Rehberi',
                                style: TextStyle(
                                  fontSize: 12,
                                  fontWeight: FontWeight.bold,
                                  color: _activeTab == 'carriers' ? Colors.white : const Color(0xFF64748B),
                                ),
                              ),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),

            // Active Filter Drawer / Layout Panel based on Active Tab
            SliverToBoxAdapter(
              child: _activeTab == 'ads'
                  ? _buildAdFilters()
                  : _buildCarrierFilters(),
            ),

            // Main Listing grid / list view
            _activeTab == 'ads'
                ? _buildAdsList(filteredAds)
                : _buildCarriersList(filteredCarriers),
          ],
        ),
      ),
      floatingActionButton: (user != null && user['userType'] == 'Sender' && _activeTab == 'ads')
          ? FloatingActionButton.extended(
              onPressed: _showAddAdDialog,
              backgroundColor: const Color(0xFFFF8C00),
              icon: const Icon(Icons.add, color: Colors.white),
              label: const Text('Yeni İlan Aç', style: TextStyle(fontWeight: FontWeight.bold, color: Colors.white)),
            )
          : null,
    );
  }

  Widget _buildAdFilters() {
    return Container(
      margin: const EdgeInsets.only(left: 16, right: 16, bottom: 12),
      padding: const EdgeInsets.all(12),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(16),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text('İlan Arama Filtreleri', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C))),
          const SizedBox(height: 8),
          Row(
            children: [
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text('Nereden:', style: TextStyle(fontSize: 9, color: Color(0xFF64748B))),
                    DropdownButton<String>(
                      value: _adStartCity,
                      isExpanded: true,
                      style: const TextStyle(fontSize: 12, color: Color(0xFF1A2B3C)),
                      onChanged: (val) {
                        if (val != null) setState(() => _adStartCity = val);
                      },
                      items: _cities.map((c) => DropdownMenuItem(value: c, child: Text(c))).toList(),
                    )
                  ],
                ),
              ),
              const SizedBox(width: 16),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text('Nereye:', style: TextStyle(fontSize: 9, color: Color(0xFF64748B))),
                    DropdownButton<String>(
                      value: _adEndCity,
                      isExpanded: true,
                      style: const TextStyle(fontSize: 12, color: Color(0xFF1A2B3C)),
                      onChanged: (val) {
                        if (val != null) setState(() => _adEndCity = val);
                      },
                      items: _cities.map((c) => DropdownMenuItem(value: c, child: Text(c))).toList(),
                    )
                  ],
                ),
              ),
            ],
          )
        ],
      ),
    );
  }

  Widget _buildCarrierFilters() {
    return Container(
      margin: const EdgeInsets.only(left: 16, right: 16, bottom: 12),
      padding: const EdgeInsets.all(12),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(16),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text('Taşıyıcı Kriter Filtreleri', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C))),
          const SizedBox(height: 8),
          Row(
            children: [
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text('Şehir:', style: TextStyle(fontSize: 9, color: Color(0xFF64748B))),
                    DropdownButton<String>(
                      value: _carrierCity,
                      isExpanded: true,
                      style: const TextStyle(fontSize: 11, color: Color(0xFF1A2B3C)),
                      onChanged: (val) {
                        if (val != null) setState(() => _carrierCity = val);
                      },
                      items: _cities.map((c) => DropdownMenuItem(value: c, child: Text(c))).toList(),
                    )
                  ],
                ),
              ),
              const SizedBox(width: 12),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text('Seviye:', style: TextStyle(fontSize: 9, color: Color(0xFF64748B))),
                    DropdownButton<String>(
                      value: _carrierLevel,
                      isExpanded: true,
                      style: const TextStyle(fontSize: 11, color: Color(0xFF1A2B3C)),
                      onChanged: (val) {
                        if (val != null) setState(() => _carrierLevel = val);
                      },
                      items: _levels.map((c) => DropdownMenuItem(value: c, child: Text(c))).toList(),
                    )
                  ],
                ),
              ),
              const SizedBox(width: 12),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const Text('Ehliyet:', style: TextStyle(fontSize: 9, color: Color(0xFF64748B))),
                    DropdownButton<String>(
                      value: _carrierLicense,
                      isExpanded: true,
                      style: const TextStyle(fontSize: 11, color: Color(0xFF1A2B3C)),
                      onChanged: (val) {
                        if (val != null) setState(() => _carrierLicense = val);
                      },
                      items: _licenses.map((c) => DropdownMenuItem(value: c, child: Text(c))).toList(),
                    )
                  ],
                ),
              ),
            ],
          ),
          const SizedBox(height: 8),
          Wrap(
            alignment: WrapAlignment.spaceBetween,
            crossAxisAlignment: WrapCrossAlignment.center,
            spacing: 8,
            runSpacing: 4,
            children: [
              Text(
                'Minimum Puan: ${_minRating == 0.0 ? "Tümü" : _minRating.toString() + "★"}',
                style: const TextStyle(fontSize: 10, fontWeight: FontWeight.bold, color: Color(0xFF64748B)),
              ),
              Wrap(
                spacing: 4,
                children: [0.0, 4.0, 4.5, 4.8].map((double r) {
                  return ChoiceChip(
                    label: Text(r == 0.0 ? 'Tümü' : '$r★', style: const TextStyle(fontSize: 10)),
                    selected: _minRating == r,
                    onSelected: (val) {
                      if (val) setState(() => _minRating = r);
                    },
                  );
                }).toList(),
              )
            ],
          )
        ],
      ),
    );
  }

  Widget _buildAdsList(List<dynamic> filteredAds) {
    if (filteredAds.isEmpty) {
      return const SliverFillRemaining(
        child: Center(child: Text('Kriterlere uygun yük ilanı bulunamadı.', style: TextStyle(color: Color(0xFF64748B)))),
      );
    }

    return SliverPadding(
      padding: const EdgeInsets.symmetric(horizontal: 16),
      sliver: SliverList(
        delegate: SliverChildBuilderDelegate(
          (context, index) {
            final ad = filteredAds[index];
            return Card(
              margin: const EdgeInsets.only(bottom: 12),
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
              elevation: 0,
              child: InkWell(
                borderRadius: BorderRadius.circular(20),
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => BidDetailsScreen(adId: ad['id']),
                    ),
                  );
                },
                child: Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: Row(
                    children: [
                      Container(
                        width: 70,
                        height: 70,
                        decoration: BoxDecoration(
                          color: const Color(0xFFF1F5F9),
                          borderRadius: BorderRadius.circular(12),
                        ),
                        child: ClipRRect(
                          borderRadius: BorderRadius.circular(12),
                          child: Image.network(
                            ad['cargoImageUrl'] ?? '',
                            fit: BoxFit.cover,
                            errorBuilder: (context, error, stackTrace) => const Icon(Icons.inventory, color: Color(0xFFFF8C00)),
                          ),
                        ),
                      ),
                      const SizedBox(width: 16),
                      Expanded(
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(
                              '${ad['startLocation']} — ${ad['endLocation']}',
                              style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                            ),
                            const SizedBox(height: 4),
                            Text(
                              ad['title'] ?? '',
                              style: const TextStyle(fontSize: 11, color: Color(0xFF64748B)),
                              maxLines: 1,
                              overflow: TextOverflow.ellipsis,
                            ),
                            const SizedBox(height: 8),
                            Wrap(
                              spacing: 6,
                              runSpacing: 4,
                              crossAxisAlignment: WrapCrossAlignment.center,
                              children: [
                                Container(
                                  padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 2),
                                  decoration: BoxDecoration(
                                    color: const Color(0xFFEFF6FF),
                                    borderRadius: BorderRadius.circular(8),
                                  ),
                                  child: Text(
                                    'Lvl ${ad['requiredLevel']}',
                                    style: const TextStyle(fontSize: 9, color: Colors.blue, fontWeight: FontWeight.bold),
                                  ),
                                ),
                                if (ad['isInstantBook'] == true) ...[
                                  Container(
                                    padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 2),
                                    decoration: BoxDecoration(
                                      color: const Color(0xFFFEF3C7),
                                      borderRadius: BorderRadius.circular(8),
                                    ),
                                    child: const Row(
                                      mainAxisSize: MainAxisSize.min,
                                      children: [
                                        Icon(Icons.flash_on, size: 8, color: Colors.amber),
                                        SizedBox(width: 2),
                                        Text(
                                          'Hemen Al',
                                          style: TextStyle(fontSize: 8, color: Color(0xFFD97706), fontWeight: FontWeight.bold),
                                        ),
                                      ],
                                    ),
                                  ),
                                ],
                                Text(
                                  '${ad['distanceKm']} Km',
                                  style: const TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                                ),
                                if (ad['status'] == 'Active' && ad['auctionEndsAt'] != null) ...[
                                  Text(
                                    '⏱️ ${_formatCountdown(ad['auctionEndsAt'])}',
                                    style: const TextStyle(fontSize: 9, color: Colors.red, fontWeight: FontWeight.bold),
                                  ),
                                ],
                              ],
                            )
                            ],
                          ),
                        ),
                        const SizedBox(width: 8),
                        Column(
                          crossAxisAlignment: CrossAxisAlignment.end,
                          children: [
                            Text(ad['isInstantBook'] == true ? 'Hemen Al' : 'Taban Fiyat', style: const TextStyle(fontSize: 8, color: Color(0xFF64748B))),
                            Text(
                              ad['isInstantBook'] == true ? '₺${ad['instantBookPrice']}' : '₺${ad['floorPrice']}',
                              style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold, color: ad['isInstantBook'] == true ? const Color(0xFFD97706) : const Color(0xFFFF8C00)),
                            ),
                          const SizedBox(height: 4),
                          Container(
                            padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 2),
                            decoration: BoxDecoration(
                              color: ad['status'] == 'Active' ? const Color(0xFFD1FAE5) : const Color(0xFFF3F4F6),
                              borderRadius: BorderRadius.circular(10),
                            ),
                            child: Text(
                              ad['status'] == 'Active' ? 'Aktif' : 'Pasif',
                              style: TextStyle(
                                fontSize: 8,
                                color: ad['status'] == 'Active' ? const Color(0xFF065F46) : const Color(0xFF374151),
                                fontWeight: FontWeight.bold,
                              ),
                            ),
                          )
                        ],
                      )
                    ],
                  ),
                ),
              ),
            );
          },
          childCount: filteredAds.length,
        ),
      ),
    );
  }

  Widget _buildCarriersList(List<dynamic> filteredCarriers) {
    if (filteredCarriers.isEmpty) {
      return const SliverFillRemaining(
        child: Center(child: Text('Kriterlere uygun kayıtlı taşıyıcı bulunamadı.', style: TextStyle(color: Color(0xFF64748B)))),
      );
    }

    return SliverPadding(
      padding: const EdgeInsets.symmetric(horizontal: 16),
      sliver: SliverList(
        delegate: SliverChildBuilderDelegate(
          (context, index) {
            final carrier = filteredCarriers[index];
            final profile = carrier['carrierProfile'];
            final rating = (profile != null && profile['rating'] != null) ? (profile['rating'] as num).toDouble() : 0.0;
            final isInsured = profile != null && profile['insuranceNo'] != null && profile['insuranceNo'].toString().isNotEmpty;

            return Card(
              margin: const EdgeInsets.only(bottom: 12),
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
              elevation: 0,
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Row(
                  children: [
                    CircleAvatar(
                      radius: 24,
                      backgroundColor: const Color(0xFFFEF3C7),
                      child: Icon(
                        (profile != null && (profile['licenseType'].toString().contains('A2') || profile['licenseType'].toString().contains('Motosiklet')))
                            ? Icons.motorcycle
                            : Icons.local_shipping,
                        color: const Color(0xFFFF8C00),
                        size: 20,
                      ),
                    ),
                    const SizedBox(width: 16),
                    Expanded(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Row(
                            children: [
                              Text(
                                carrier['name'] ?? '',
                                style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                              ),
                              const SizedBox(width: 8),
                              Container(
                                padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 1.5),
                                decoration: BoxDecoration(
                                  color: const Color(0xFFFEF3C7),
                                  borderRadius: BorderRadius.circular(8),
                                ),
                                child: Text(
                                  'Lvl ${carrier['userLevel']}',
                                  style: const TextStyle(fontSize: 8, color: Color(0xFFFF8C00), fontWeight: FontWeight.bold),
                                ),
                              )
                            ],
                          ),
                          const SizedBox(height: 4),
                          Text(
                            'Kayıt Yeri: ${carrier['city']} • Ehliyet: ${profile != null ? profile['licenseType'] : 'Belirtilmemiş'}',
                            style: const TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                          ),
                          const SizedBox(height: 8),
                          Row(
                            children: [
                              Container(
                                padding: const EdgeInsets.symmetric(horizontal: 6, vertical: 2),
                                decoration: BoxDecoration(
                                  color: (isInsured || (profile != null && profile['licenseType'].toString().contains('Bize Bağlı')))
                                      ? const Color(0xFFD1FAE5)
                                      : const Color(0xFFFEE2E2),
                                  borderRadius: BorderRadius.circular(8),
                                ),
                                child: Text(
                                  profile != null && profile['licenseType'].toString().contains('Şahıs Şirketi')
                                      ? '🏢 Şahıs Şirketi Doğrulandı'
                                      : profile != null && profile['licenseType'].toString().contains('Bize Bağlı')
                                          ? '🤝 Bize Bağlı Sözleşmeli Kurye'
                                          : isInsured
                                              ? '🛡️ Taşımacılık Sigortası Aktif'
                                              : '⚠️ Sigortasız / Teminatsız',
                                  style: TextStyle(
                                    fontSize: 8,
                                    color: (isInsured || (profile != null && profile['licenseType'].toString().contains('Bize Bağlı')))
                                        ? const Color(0xFF065F46)
                                        : const Color(0xFF991B1B),
                                    fontWeight: FontWeight.bold,
                                  ),
                                ),
                              ),
                            ],
                          )
                        ],
                      ),
                    ),
                    const SizedBox(width: 8),
                    Column(
                      crossAxisAlignment: CrossAxisAlignment.end,
                      children: [
                        Row(
                          children: [
                            const Icon(Icons.star, color: Colors.amber, size: 14),
                            const SizedBox(width: 2),
                            Text(
                              rating.toString(),
                              style: const TextStyle(fontSize: 12, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                            ),
                          ],
                        ),
                        const SizedBox(height: 4),
                        const Text('Cüzdan Durumu', style: TextStyle(fontSize: 8, color: Color(0xFF64748B))),
                        Text(
                          '₺${carrier['balance']}',
                          style: const TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF10B981)),
                        )
                      ],
                    )
                  ],
                ),
              ),
            );
          },
          childCount: filteredCarriers.length,
        ),
      ),
    );
  }

  String _formatCountdown(String? endsAtStr) {
    if (endsAtStr == null) return '';
    final endsAt = DateTime.parse(endsAtStr).toLocal();
    final now = DateTime.now();
    final diff = endsAt.difference(now);
    if (diff.isNegative) {
      return 'Süre Doldu';
    }
    
    if (diff.inHours > 0) {
      return '${diff.inHours}sa ${diff.inMinutes.remainder(60)}dk';
    } else if (diff.inMinutes > 0) {
      return '${diff.inMinutes}dk ${diff.inSeconds.remainder(60)}sn';
    } else {
      return '${diff.inSeconds}sn';
    }
  }
}
