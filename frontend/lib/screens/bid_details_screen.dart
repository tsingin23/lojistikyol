import 'dart:async';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:frontend/providers/app_provider.dart';
import 'package:frontend/widgets/route_truck_animator.dart';
import 'package:frontend/services/api_service.dart';

class BidDetailsScreen extends StatefulWidget {
  final int adId;
  const BidDetailsScreen({Key? key, required this.adId}) : super(key: key);

  @override
  State<BidDetailsScreen> createState() => _BidDetailsScreenState();
}

class _BidDetailsScreenState extends State<BidDetailsScreen> {
  Map<String, dynamic>? _ad;
  Map<String, dynamic>? _activeTx;
  List<dynamic> _recommendations = [];
  bool _isLoading = true;
  bool _isActionLoading = false;

  // Bid placement amount controller
  final _amountCtrl = TextEditingController();

  // Delivery details state
  final _authCodeCtrl = TextEditingController();
  final _photoUrlCtrl = TextEditingController(
    text: 'https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80',
  );

  // Uber Freight Simulation States
  bool _isGpsSimulating = false;
  double _gpsProgress = 0.0;
  bool _hasArrivedGeofence = false;
  bool _isOcrLoading = false;
  String? _ocrResultText;
  bool _hasRatedSender = false;
  double _ratingScore = 5.0;
  final _ratingCommentCtrl = TextEditingController();
  bool _hasRatedCarrier = false;
  double _carrierRatingScore = 5.0;
  final _carrierRatingCommentCtrl = TextEditingController();

  // Auto-Bid UI State
  bool _isAutoBidEnabled = false;
  final _autoBidMinLimitCtrl = TextEditingController();
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _fetchDetails();
    });
  }

  Future<void> _fetchDetails() async {
    setState(() => _isLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    await provider.refreshAll();
    
    // Find our active ad
    final adItem = provider.ads.firstWhere((a) => a['id'] == widget.adId, orElse: () => null);
    if (adItem != null) {
      _ad = adItem;
      _activeTx = null;
      
      final bidsList = _ad!['bids'] as List;
      final acceptedBid = bidsList.firstWhere((b) => b['status'] == 'Accepted', orElse: () => null);
      if (acceptedBid != null) {
        final tx = await ApiService.getTransactionByBid(acceptedBid['id']);
        if (tx != null) {
          _activeTx = tx;
        }
      }

      // Get recommendations for backhaul
      final user = provider.currentUser;
      if (user != null && user['userType'] == 'Carrier') {
        final recs = await ApiService.getRecommendations(widget.adId, user['userLevel']);
        _recommendations = recs;
      }
    }
    setState(() => _isLoading = false);
  }

  void _placeBid() async {
    final double? amount = double.tryParse(_amountCtrl.text);
    if (amount == null || amount <= 0) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Lütfen geçerli bir teklif tutarı girin.')),
      );
      return;
    }

    if (amount < (_ad!['floorPrice'] as num).toDouble()) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Hata: Taban fiyat (₺${_ad!['floorPrice']}) altında teklif veremezsiniz!')),
      );
      return;
    }

    double? autoBidLimit;
    if (_isAutoBidEnabled) {
      autoBidLimit = double.tryParse(_autoBidMinLimitCtrl.text);
      if (autoBidLimit == null || autoBidLimit <= 0) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Lütfen geçerli bir otomatik teklif alt limiti girin.')),
        );
        return;
      }
      if (autoBidLimit >= amount) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Hata: Otomatik teklif limiti ilk teklif tutarınızdan düşük olmalıdır!')),
        );
        return;
      }
      if (autoBidLimit < (_ad!['floorPrice'] as num).toDouble()) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Hata: Otomatik teklif limiti taban fiyatından (₺${_ad!['floorPrice']}) düşük olamaz!')),
        );
        return;
      }
    }

    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.placeBid(
      widget.adId, 
      amount,
      isAutoBidEnabled: _isAutoBidEnabled,
      autoBidMinLimit: autoBidLimit,
    );
    setState(() => _isActionLoading = false);

    if (success) {
      _amountCtrl.clear();
      _autoBidMinLimitCtrl.clear();
      setState(() {
        _isAutoBidEnabled = false;
      });
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Teklifiniz başarıyla iletildi!')),
      );
      _fetchDetails();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Teklif iletilemedi, yetki seviyeniz yetersiz olabilir.')),
      );
    }
  }

  void _selectBid(int bidId) async {
    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.selectBid(bidId);
    setState(() => _isActionLoading = false);

    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Teklif onaylandı! Provizyon tutarı bloke edildi.')),
      );
      _fetchDetails();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('İşlem başarısız, cüzdan bakiyeniz yetersiz olabilir.')),
      );
    }
  }

  void _submitDelivery(int txId) async {
    if (_authCodeCtrl.text.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Lütfen alıcı doğrulama kodunu girin.')),
      );
      return;
    }

    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    
    // Simulate AI image scan loading effect
    showDialog(
      context: context,
      barrierDismissible: false,
      builder: (context) => AlertDialog(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        content: const Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            CircularProgressIndicator(color: Color(0xFFFF8C00)),
            SizedBox(height: 16),
            Text(
              'Yapay Zeka Görsel Analizi Yapılıyor...',
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13),
            ),
            SizedBox(height: 8),
            Text(
              'Manzara ve alakasız resimler elenir, paket doğruluğu denetlenir.',
              style: TextStyle(fontSize: 10, color: Color(0xFF64748B)),
              textAlign: TextAlign.center,
            )
          ],
        ),
      ),
    );

    await Future.delayed(const Duration(seconds: 3));
    Navigator.pop(context); // close dialog

    final success = await provider.updateTxStatus(txId, 'Delivered', deliveryImageUrl: _photoUrlCtrl.text);
    setState(() => _isActionLoading = false);

    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Teslimat Yapay Zeka Tarafından Doğrulandı! Ödeme serbest bırakıldı.')),
      );
      _fetchDetails();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Hata: Kod uyuşmadı veya doğrulama başarısız oldu.')),
      );
    }
  }

  void _startGpsSimulation(int txId) {
    if (_isGpsSimulating) return;
    setState(() {
      _isGpsSimulating = true;
      _gpsProgress = 0.0;
      _hasArrivedGeofence = false;
    });

    Timer.periodic(const Duration(milliseconds: 300), (timer) {
      if (!mounted) {
        timer.cancel();
        return;
      }
      setState(() {
        _gpsProgress += 0.1;
        if (_gpsProgress >= 1.0) {
          _gpsProgress = 1.0;
          _isGpsSimulating = false;
          _hasArrivedGeofence = true;
          timer.cancel();
          _showGeofenceArrivalDialog();
        }
      });
    });
  }

  void _showGeofenceArrivalDialog() {
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
        title: const Row(
          children: [
            Icon(Icons.location_on, color: Colors.green),
            SizedBox(width: 8),
            Text('Hedefe Ulaşıldı (Geofence)', style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold)),
          ],
        ),
        content: const Text(
          'GPS Telemetrisi: Teslimat adresine başarıyla giriş yapıldı. Sanal çit (Geofence) aşıldı.\nLütfen Sevk İrsaliyesi yükleme adımına geçin.',
          style: TextStyle(fontSize: 11),
        ),
        actions: [
          ElevatedButton(
            onPressed: () => Navigator.pop(context),
            style: ElevatedButton.styleFrom(backgroundColor: Colors.green, foregroundColor: Colors.white),
            child: const Text('Tamam'),
          )
        ],
      ),
    );
  }

  void _handleOcrSimulation(String type) async {
    setState(() {
      _isOcrLoading = true;
      _ocrResultText = null;
    });
    await Future.delayed(const Duration(seconds: 2));
    if (!mounted) return;
    
    try {
      final ocrText = await ApiService.uploadWaybill(widget.adId, type);
      setState(() {
        _isOcrLoading = false;
        _ocrResultText = ocrText;
      });
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Belge OCR analizi başarıyla tamamlandı ve doğrulandı!')),
      );
    } catch (e) {
      setState(() {
        _isOcrLoading = false;
      });
      _showOcrErrorDialog(e.toString());
    }
  }

  void _showWaybillSelector() {
    showModalBottomSheet(
      context: context,
      backgroundColor: Colors.white,
      shape: const RoundedRectangleBorder(borderRadius: BorderRadius.vertical(top: Radius.circular(24))),
      builder: (context) {
        return Container(
          padding: const EdgeInsets.all(24),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const Text(
                'Belge Yükleme Sistemi (Simülatör)',
                style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
              ),
              const SizedBox(height: 6),
              const Text(
                'Sunumda göstermek üzere telefondaki belgelerden birini seçin veya sanal kamerayı açın:',
                style: TextStyle(fontSize: 11, color: Color(0xFF64748B)),
              ),
              const SizedBox(height: 16),
              ListTile(
                leading: const CircleAvatar(backgroundColor: Color(0xFFD1FAE5), child: Icon(Icons.check_circle, color: Colors.green)),
                title: const Text('📄 Doğru Sevk İrsaliyesi Fotoğrafı (Başarılı)', style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold)),
                subtitle: const Text('AI OCR doğrulaması başarıyla geçecek.', style: TextStyle(fontSize: 10)),
                onTap: () {
                  Navigator.pop(context);
                  _handleOcrSimulation('VALID_WAYBILL');
                },
              ),
              const Divider(height: 1),
              ListTile(
                leading: const CircleAvatar(backgroundColor: Color(0xFFFEE2E2), child: Icon(Icons.error, color: Colors.red)),
                title: const Text('📄 Yanlış İrsaliye Belgesi Fotoğrafı (Uyuşmazlık)', style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold)),
                subtitle: const Text('AI uyarısı: Belge başka bir ilana aittir.', style: TextStyle(fontSize: 10)),
                onTap: () {
                  Navigator.pop(context);
                  _handleOcrSimulation('WRONG_WAYBILL');
                },
              ),
              const Divider(height: 1),
              ListTile(
                leading: const CircleAvatar(backgroundColor: Color(0xFFFEF3C7), child: Icon(Icons.image, color: Colors.amber)),
                title: const Text('🖼️ Alakasız Manzara Fotoğrafı (Geçersiz)', style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold)),
                subtitle: const Text('AI uyarısı: Resimde irsaliye belgesi tespit edilemedi.', style: TextStyle(fontSize: 10)),
                onTap: () {
                  Navigator.pop(context);
                  _handleOcrSimulation('INVALID_IMAGE');
                },
              ),
              const Divider(height: 1),
              ListTile(
                leading: const CircleAvatar(backgroundColor: Color(0xFFEFF6FF), child: Icon(Icons.camera_alt, color: Colors.blue)),
                title: const Text('📸 Canlı Kamera Simülatörü', style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold, color: Colors.blue)),
                subtitle: const Text('Kamerayı açarak canlı vizör taraması gerçekleştirin.', style: TextStyle(fontSize: 10)),
                onTap: () {
                  Navigator.pop(context);
                  _showLiveCameraSimulator();
                },
              ),
            ],
          ),
        );
      },
    );
  }

  void _showLiveCameraSimulator() {
    showDialog(
      context: context,
      barrierDismissible: false,
      builder: (context) {
        return Dialog.fullscreen(
          child: Container(
            color: Colors.black,
            child: Stack(
              children: [
                Positioned.fill(
                  child: Container(
                    decoration: const BoxDecoration(
                      gradient: RadialGradient(
                        colors: [Colors.transparent, Colors.black87],
                        radius: 1.2,
                      ),
                    ),
                    child: Center(
                      child: Container(
                        width: 280,
                        height: 400,
                        decoration: BoxDecoration(
                          border: Border.all(color: Colors.green, width: 2),
                          borderRadius: BorderRadius.circular(16),
                        ),
                        child: const Stack(
                          children: [
                            Positioned(
                              top: 16,
                              left: 16,
                              child: Text(
                                '[İRSALİYE TARA]',
                                style: TextStyle(color: Colors.green, fontSize: 10, fontFamily: 'monospace', fontWeight: FontWeight.bold),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  ),
                ),
                Positioned(
                  top: 40,
                  left: 20,
                  child: IconButton(
                    icon: const Icon(Icons.close, color: Colors.white, size: 28),
                    onPressed: () => Navigator.pop(context),
                  ),
                ),
                Positioned(
                  bottom: 50,
                  left: 0,
                  right: 0,
                  child: Column(
                    children: [
                      const Text(
                        'İrsaliyeyi çerçeveye sığdırıp butona basın',
                        style: TextStyle(color: Colors.white70, fontSize: 12),
                      ),
                      const SizedBox(height: 24),
                      GestureDetector(
                        onTap: () {
                          Navigator.pop(context);
                          _handleOcrSimulation('VALID_WAYBILL');
                        },
                        child: Container(
                          width: 72,
                          height: 72,
                          decoration: BoxDecoration(
                            shape: BoxShape.circle,
                            border: Border.all(color: Colors.white, width: 4),
                          ),
                          child: Container(
                            margin: const EdgeInsets.all(4),
                            decoration: const BoxDecoration(
                              shape: BoxShape.circle,
                              color: Colors.white,
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  void _showOcrErrorDialog(String errorMsg) {
    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
          title: const Row(
            children: [
              Icon(Icons.warning, color: Colors.red),
              SizedBox(width: 8),
              Text('Yapay Zeka Belge Hatası', style: TextStyle(fontSize: 14, fontWeight: FontWeight.bold)),
            ],
          ),
          content: Text(
            errorMsg.replaceAll('Exception: ', '').replaceAll('System.Exception: ', ''),
            style: const TextStyle(fontSize: 11),
          ),
          actions: [
            ElevatedButton(
              onPressed: () => Navigator.pop(context),
              style: ElevatedButton.styleFrom(backgroundColor: Colors.red, foregroundColor: Colors.white),
              child: const Text('Kapat'),
            )
          ],
        );
      },
    );
  }

  void _startTransit(int txId) async {
    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.updateTxStatus(txId, 'InTransit');
    setState(() => _isActionLoading = false);
    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Yolculuk başladı! Sürücü transit modunda.')),
      );
      _fetchDetails();
    }
  }

  void _handleInstantBook() async {
    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.instantBook(widget.adId);
    setState(() => _isActionLoading = false);
    if (success) {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Tebrikler! Yükü anında rezerve ettiniz.')),
      );
      _fetchDetails();
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Rezervasyon yapılamadı. Seviyeniz yetersiz veya bakiye eksik olabilir.')),
      );
    }
  }

  void _submitSenderRating(int senderId) async {
    if (_ratingCommentCtrl.text.isEmpty) return;
    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.rateSender(widget.adId, senderId, _ratingScore.toInt(), _ratingCommentCtrl.text);
    setState(() => _isActionLoading = false);
    if (success) {
      setState(() {
        _hasRatedSender = true;
      });
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Değerlendirmeniz başarıyla gönderildi.')),
      );
      _fetchDetails();
    }
  }

  void _submitCarrierRating(int carrierId) async {
    if (_carrierRatingCommentCtrl.text.isEmpty) return;
    setState(() => _isActionLoading = true);
    final provider = Provider.of<AppProvider>(context, listen: false);
    final success = await provider.rateCarrier(widget.adId, carrierId, _carrierRatingScore.toInt(), _carrierRatingCommentCtrl.text);
    setState(() => _isActionLoading = false);
    if (success) {
      setState(() {
        _hasRatedCarrier = true;
      });
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Değerlendirmeniz başarıyla gönderildi.')),
      );
      _fetchDetails();
    }
  }

  @override
  Widget build(BuildContext context) {
    if (_isLoading) {
      return const Scaffold(
        body: Center(child: CircularProgressIndicator(color: Color(0xFFFF8C00))),
      );
    }

    if (_ad == null) {
      return const Scaffold(body: Center(child: Text('İlan bulunamadı.')));
    }

    final provider = Provider.of<AppProvider>(context);
    final user = provider.currentUser;
    final bool isSender = user != null && user['userType'] == 'Sender';
    final bool isCarrier = user != null && user['userType'] == 'Carrier';

    // Find if a transaction exists for this ad's accepted bid
    Map<String, dynamic>? activeTx;
    final bidsList = _ad!['bids'] as List;
    final acceptedBid = bidsList.firstWhere((b) => b['status'] == 'Accepted', orElse: () => null);
    
    // Fallback display code
    final String trackId = 'TR-4428${widget.adId}E';

    return Scaffold(
      backgroundColor: const Color(0xFFF4F7F9),
      appBar: AppBar(
        title: Text(
          'Detay: Sevkiyat İlanı',
          style: const TextStyle(color: Color(0xFF1A2B3C), fontSize: 14, fontWeight: FontWeight.bold),
        ),
        backgroundColor: Colors.white,
        elevation: 0.5,
        iconTheme: const IconThemeData(color: Color(0xFF1A2B3C)),
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // live coordinate map visualizer
            RouteTruckAnimator(
              startLocation: _ad!['startLocation'],
              endLocation: _ad!['endLocation'],
            ),
            const SizedBox(height: 16),

            if (_ad!['status'] == 'Active' && _ad!['auctionEndsAt'] != null) ...[
              Container(
                margin: const EdgeInsets.only(bottom: 12),
                padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 10),
                decoration: BoxDecoration(
                  color: const Color(0xFFFEF2F2),
                  borderRadius: BorderRadius.circular(12),
                  border: Border.all(color: const Color(0xFFFCA5A5), width: 0.5),
                ),
                child: Row(
                  children: [
                    const Icon(Icons.timer_outlined, color: Colors.red, size: 18),
                    const SizedBox(width: 8),
                    Expanded(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          const Text(
                            'Geri Sayım Başladı - Teklif Süresi Sınırlı!',
                            style: TextStyle(fontSize: 10, fontWeight: FontWeight.bold, color: Color(0xFF991B1B)),
                          ),
                          Text(
                            'Bu ihale otomatik olarak kapanacak ve en düşük teklif kazanacaktır.',
                            style: TextStyle(fontSize: 9, color: Colors.red[800]),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
                      decoration: BoxDecoration(
                        color: Colors.red[700],
                        borderRadius: BorderRadius.circular(8),
                      ),
                      child: CountdownTimerWidget(endsAt: _ad!['auctionEndsAt']),
                    )
                  ],
                ),
              ),
            ],

            // Ad summary
            Container(
              padding: const EdgeInsets.all(16),
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20),
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Container(
                        padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 2),
                        decoration: BoxDecoration(
                          color: const Color(0xFFEFF6FF),
                          borderRadius: BorderRadius.circular(8),
                        ),
                        child: Text(
                          'İlan No: $trackId',
                          style: const TextStyle(color: Colors.blue, fontSize: 10, fontWeight: FontWeight.bold),
                        ),
                      ),
                      Text(
                        _ad!['status'] == 'Active' ? 'Aktif İhale' : 'Taşıma Aşamasında',
                        style: TextStyle(
                          color: _ad!['status'] == 'Active' ? const Color(0xFF10B981) : Colors.orange,
                          fontSize: 10,
                          fontWeight: FontWeight.bold,
                        ),
                      )
                    ],
                  ),
                  const SizedBox(height: 12),
                  Text(
                    _ad!['title'] ?? '',
                    style: const TextStyle(fontSize: 15, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                  ),
                  const SizedBox(height: 8),
                  Text(
                    _ad!['description'] ?? '',
                    style: const TextStyle(fontSize: 12, color: Color(0xFF64748B), height: 1.4),
                  ),
                  const SizedBox(height: 16),
                  
                  // Key metrics grid
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      _buildMiniMetric('Taban Fiyat', '₺${_ad!['floorPrice']}', const Color(0xFFFF8C00)),
                      _buildMiniMetric('Kargo Değeri', '₺${_ad!['cargoValue']}', const Color(0xFF1A2B3C)),
                      _buildMiniMetric('Mesafe', '${_ad!['distanceKm']} Km', const Color(0xFF64748B)),
                    ],
                  )
                ],
              ),
            ),
            const SizedBox(height: 16),

            // Dynamic Pricing Info Card (Uber Freight style)
            if (_ad!['weatherDemandMultiplier'] != null && (_ad!['weatherDemandMultiplier'] as num) > 1.0) ...[
              Container(
                margin: const EdgeInsets.only(bottom: 16),
                padding: const EdgeInsets.all(16),
                decoration: BoxDecoration(
                  color: const Color(0xFFFEF3C7),
                  borderRadius: BorderRadius.circular(16),
                  border: Border.all(color: const Color(0xFFFDE68A)),
                ),
                child: Row(
                  children: [
                    const Icon(Icons.cloudy_snowing, color: Color(0xFFD97706)),
                    const SizedBox(width: 12),
                    Expanded(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          const Text(
                            'Yoğun Talep & Hava Katsayısı Aktif',
                            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 12, color: Color(0xFF92400E)),
                          ),
                          const SizedBox(height: 2),
                          Text(
                            'Bölgedeki olumsuz hava koşulları ve araç azlığı sebebiyle fiyatlar %${(((_ad!['weatherDemandMultiplier'] as num) - 1.0) * 100).toInt()} artırılmıştır.',
                            style: const TextStyle(fontSize: 10, color: Color(0xFFB45309)),
                          )
                        ],
                      ),
                    )
                  ],
                ),
              ),
            ],

            // Workflow Actions depending on Status & Role
            if (_ad!['status'] == 'Active') ...[
              if (isCarrier) ...[
                if (_ad!['isInstantBook'] == true) ...[
                  Container(
                    width: double.infinity,
                    margin: const EdgeInsets.only(bottom: 16),
                    padding: const EdgeInsets.all(16),
                    decoration: BoxDecoration(
                      color: Colors.white,
                      borderRadius: BorderRadius.circular(20),
                      border: Border.all(color: const Color(0xFFFDE68A), width: 1),
                    ),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          children: [
                            const Icon(Icons.flash_on, color: Colors.amber),
                            const SizedBox(width: 6),
                            const Text(
                              'Hemen Rezervasyon Seçeneği',
                              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C)),
                            ),
                          ],
                        ),
                        const SizedBox(height: 6),
                        const Text(
                          'Bu yükü ihale süreci olmadan doğrudan belirtilen fiyattan anında cüzdan güvencenizle bağlayabilirsiniz.',
                          style: TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                        ),
                        const SizedBox(height: 12),
                        SizedBox(
                          width: double.infinity,
                          height: 48,
                          child: ElevatedButton.icon(
                            onPressed: _isActionLoading ? null : _handleInstantBook,
                            style: ElevatedButton.styleFrom(
                              backgroundColor: const Color(0xFFFF8C00),
                              foregroundColor: Colors.white,
                              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                              elevation: 0,
                            ),
                            icon: const Icon(Icons.flash_on, size: 16),
                            label: Text(
                              'Hemen Rezerve Et (₺${_ad!['instantBookPrice']})',
                              style: const TextStyle(fontWeight: FontWeight.bold),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
                // Carrier place bid panel
                Container(
                  padding: const EdgeInsets.all(16),
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(20),
                  ),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const Text('İhaleye Katılın / Teklif Verin', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFF1A2B3C))),
                      const SizedBox(height: 6),
                      Text('Not: Teklifiniz taban fiyat olan ₺${_ad!['floorPrice']} tutarından düşük olamaz.', style: const TextStyle(fontSize: 10, color: Color(0xFF64748B))),
                      const SizedBox(height: 12),
                      Row(
                        children: [
                          Expanded(
                            child: TextField(
                              controller: _amountCtrl,
                              keyboardType: TextInputType.number,
                              decoration: InputDecoration(
                                labelText: 'Teklif Tutarı (₺)',
                                border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
                                prefixText: '₺ ',
                              ),
                            ),
                          ),
                          const SizedBox(width: 12),
                          SizedBox(
                            height: 52,
                            child: ElevatedButton(
                              onPressed: _isActionLoading ? null : _placeBid,
                              style: ElevatedButton.styleFrom(
                                backgroundColor: const Color(0xFF1A2B3C),
                                foregroundColor: Colors.white,
                                shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                                elevation: 0,
                              ),
                              child: const Text('Teklifi Gönder'),
                            ),
                          )
                        ],
                      ),
                      const SizedBox(height: 12),
                      const Divider(height: 1, color: Color(0xFFF1F5F9)),
                      const SizedBox(height: 12),
                      Row(
                        children: [
                          Checkbox(
                            value: _isAutoBidEnabled,
                            activeColor: const Color(0xFFFF8C00),
                            onChanged: (val) {
                              setState(() {
                                _isAutoBidEnabled = val ?? false;
                              });
                            },
                          ),
                          const Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  'Otomatik Teklif (Auto-Bid) Sistemini Etkinleştir',
                                  style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                                ),
                                Text(
                                  'Rakipler teklif verdikçe sizin adınıza limiti aşmayacak şekilde ₺50 daha düşük teklif verilir.',
                                  style: TextStyle(fontSize: 9, color: Color(0xFF64748B)),
                                ),
                              ],
                            ),
                          )
                        ],
                      ),
                      if (_isAutoBidEnabled) ...[
                        const SizedBox(height: 8),
                        Padding(
                          padding: const EdgeInsets.only(left: 12, right: 12, bottom: 8),
                          child: TextField(
                            controller: _autoBidMinLimitCtrl,
                            keyboardType: TextInputType.number,
                            decoration: InputDecoration(
                              labelText: 'İneceğiniz En Düşük Limit (₺)',
                              helperText: 'Sistem bu limitin altına teklif vermez.',
                              helperStyle: const TextStyle(fontSize: 8),
                              border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
                              prefixText: '₺ ',
                            ),
                          ),
                        ),
                      ],
                    ],
                  ),
                ),
              ],
            ],

            // Active Shipment Panel for Accepted/InTransit/Completed jobs
            if (_activeTx != null) ...[
              Container(
                margin: const EdgeInsets.only(bottom: 16),
                padding: const EdgeInsets.all(20),
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(24),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withOpacity(0.02),
                      blurRadius: 12,
                      offset: const Offset(0, 4),
                    )
                  ],
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Text(
                          'AKTİF SEVKİYAT İŞ AKIŞI',
                          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 12, color: Color(0xFFFF8C00)),
                        ),
                        Container(
                          padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
                          decoration: BoxDecoration(
                            color: _activeTx!['status'] == 'Pending'
                                ? Colors.blue[50]
                                : _activeTx!['status'] == 'InTransit'
                                    ? Colors.orange[50]
                                    : Colors.green[50],
                            borderRadius: BorderRadius.circular(12),
                          ),
                          child: Text(
                            _activeTx!['status'] == 'Pending'
                                ? 'Yola Çıkmaya Hazır'
                                : _activeTx!['status'] == 'InTransit'
                                    ? 'Taşıma Aşamasında'
                                    : 'Teslim Edildi',
                            style: TextStyle(
                              fontSize: 10,
                              fontWeight: FontWeight.bold,
                              color: _activeTx!['status'] == 'Pending'
                                  ? Colors.blue
                                  : _activeTx!['status'] == 'InTransit'
                                      ? Colors.orange[800]
                                      : Colors.green[800],
                            ),
                          ),
                        )
                      ],
                    ),
                    const SizedBox(height: 16),

                    if (isCarrier) ...[
                      // Sürücü Kontrolleri
                      if (_activeTx!['status'] == 'Pending') ...[
                        const Text(
                          'Yük bağlandı! Hazır olduğunuzda yola çıkış telemetrisini başlatın.',
                          style: TextStyle(fontSize: 11, color: Color(0xFF64748B)),
                        ),
                        const SizedBox(height: 16),
                        SizedBox(
                          width: double.infinity,
                          height: 48,
                          child: ElevatedButton.icon(
                            onPressed: _isActionLoading ? null : () => _startTransit(_activeTx!['id']),
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.blue,
                              foregroundColor: Colors.white,
                              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                            ),
                            icon: const Icon(Icons.play_arrow),
                            label: const Text('Transit Başlat / Yola Çık', style: TextStyle(fontWeight: FontWeight.bold)),
                          ),
                        )
                      ],

                      if (_activeTx!['status'] == 'InTransit') ...[
                        // GPS Simulation
                        const Text(
                          '1. GPS Telemetri Canlı Takip Simülasyonu',
                          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFF1A2B3C)),
                        ),
                        const SizedBox(height: 8),
                        if (_isGpsSimulating) ...[
                          Column(
                            children: [
                              LinearProgressIndicator(
                                value: _gpsProgress,
                                color: Colors.blue,
                                backgroundColor: Colors.blue[50],
                              ),
                              const SizedBox(height: 4),
                              Text(
                                'GPS Telemetrisi gönderiliyor... %${(_gpsProgress * 100).toInt()}',
                                style: const TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                              )
                            ],
                          )
                        ] else if (_hasArrivedGeofence) ...[
                          const Row(
                            children: [
                              Icon(Icons.check_circle, color: Colors.green, size: 16),
                              SizedBox(width: 8),
                              Text('Geofence Uyuşması: Hedefe Ulaşıldı!', style: TextStyle(fontSize: 11, color: Colors.green, fontWeight: FontWeight.bold)),
                            ],
                          )
                        ] else ...[
                          SizedBox(
                            width: double.infinity,
                            height: 38,
                            child: OutlinedButton.icon(
                              onPressed: () => _startGpsSimulation(_activeTx!['id']),
                              icon: const Icon(Icons.location_searching, size: 14),
                              label: const Text('GPS Canlı Telemetri Simüle Et', style: TextStyle(fontSize: 11)),
                              style: OutlinedButton.styleFrom(
                                side: const BorderSide(color: Colors.blue),
                                foregroundColor: Colors.blue,
                              ),
                            ),
                          )
                        ],
                        const SizedBox(height: 16),
                        const Divider(),
                        const SizedBox(height: 12),

                        // BOL / İrsaliye
                        const Text(
                          '2. Dijital Sevk İrsaliyesi & OCR Doğrulama',
                          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFF1A2B3C)),
                        ),
                        const SizedBox(height: 8),
                        if (_isOcrLoading) ...[
                          const Center(
                            child: Column(
                              children: [
                                SizedBox(
                                  width: 20,
                                  height: 20,
                                  child: CircularProgressIndicator(strokeWidth: 2, color: Color(0xFFFF8C00)),
                                ),
                                SizedBox(height: 8),
                                Text('Yapay Zeka OCR Belge Analizi yapılıyor...', style: TextStyle(fontSize: 10, color: Color(0xFF64748B))),
                              ],
                            ),
                          )
                        ] else if (_ocrResultText != null) ...[
                          Container(
                            padding: const EdgeInsets.all(12),
                            decoration: BoxDecoration(
                              color: Colors.grey[50],
                              borderRadius: BorderRadius.circular(12),
                              border: Border.all(color: Colors.grey[200]!),
                            ),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Row(
                                  children: [
                                    const Icon(Icons.verified, color: Colors.green, size: 14),
                                    const SizedBox(width: 6),
                                    Text('Belge OCR Okuması Başarılı', style: TextStyle(fontSize: 10, color: Colors.green[800], fontWeight: FontWeight.bold)),
                                  ],
                                ),
                                const SizedBox(height: 8),
                                Text(
                                  _ocrResultText!,
                                  style: const TextStyle(fontSize: 9, fontFamily: 'monospace', color: Color(0xFF1A2B3C)),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(height: 8),
                          SizedBox(
                            width: double.infinity,
                            height: 38,
                            child: ElevatedButton.icon(
                              onPressed: () {
                                ScaffoldMessenger.of(context).showSnackBar(
                                  const SnackBar(content: Text('Dijital İrsaliye PDF faturası cihazınıza indirildi (Simüle).')),
                                );
                              },
                              icon: const Icon(Icons.download, size: 14),
                              label: const Text('Dijital İrsaliye / Fatura PDF İndir', style: TextStyle(fontSize: 11)),
                              style: ElevatedButton.styleFrom(
                                backgroundColor: const Color(0xFF1A2B3C),
                                foregroundColor: Colors.white,
                              ),
                            ),
                          )
                        ] else ...[
                          SizedBox(
                            width: double.infinity,
                            height: 38,
                            child: OutlinedButton.icon(
                              onPressed: _showWaybillSelector,
                              icon: const Icon(Icons.camera_alt, size: 14),
                              label: const Text('Sevk İrsaliyesi / BOL Fotoğrafı Yükle', style: TextStyle(fontSize: 11)),
                              style: OutlinedButton.styleFrom(
                                side: const BorderSide(color: Color(0xFFFF8C00)),
                                foregroundColor: const Color(0xFFFF8C00),
                              ),
                            ),
                          )
                        ],
                        const SizedBox(height: 16),
                        const Divider(),
                        const SizedBox(height: 12),

                        // Alıcı Doğrulama Kodu ile Kapatma
                        const Text(
                          '3. Alıcı Kodu & Yapay Zeka Son Onay',
                          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFF1A2B3C)),
                        ),
                        const SizedBox(height: 8),
                        Row(
                          children: [
                            Expanded(
                              child: TextField(
                                controller: _authCodeCtrl,
                                decoration: const InputDecoration(
                                  labelText: 'Alıcı Onay Kodu (Örn: LY-XXXX)',
                                  border: OutlineInputBorder(),
                                ),
                              ),
                            ),
                            const SizedBox(width: 8),
                            SizedBox(
                              height: 52,
                              child: ElevatedButton(
                                onPressed: (_isActionLoading || !_hasArrivedGeofence || _ocrResultText == null)
                                    ? null
                                    : () => _submitDelivery(_activeTx!['id']),
                                style: ElevatedButton.styleFrom(
                                  backgroundColor: Colors.green,
                                  foregroundColor: Colors.white,
                                  shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                                ),
                                child: const Text('Onayla'),
                              ),
                            )
                          ],
                        ),
                        if (!_hasArrivedGeofence || _ocrResultText == null)
                          Padding(
                            padding: const EdgeInsets.only(top: 6.0),
                            child: Text(
                              'Gerekli Adımlar Eksik: ' +
                              (!_hasArrivedGeofence ? '[GPS Konum Uyuşması] ' : '') +
                              (_ocrResultText == null ? '[İrsaliye Belge OCR] ' : '') +
                              'tamamlanmalıdır.',
                              style: const TextStyle(fontSize: 9, color: Colors.red),
                            ),
                          )
                      ],

                      if (_activeTx!['status'] == 'Delivered') ...[
                        const Row(
                          children: [
                            Icon(Icons.check_circle, color: Colors.green),
                            SizedBox(width: 8),
                            Text(
                              'Sevkiyat Tamamlandı & AI Onaylandı',
                              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 12, color: Colors.green),
                            )
                          ],
                        ),
                        const SizedBox(height: 16),
                        if (_hasRatedSender) ...[
                          const Text(
                            'Göndericiyi başarıyla değerlendirdiniz. Teşekkürler!',
                            style: TextStyle(fontSize: 11, color: Color(0xFF64748B), fontWeight: FontWeight.bold),
                          )
                        ] else ...[
                          const Divider(),
                          const SizedBox(height: 12),
                          const Text(
                            'Göndericiyi Değerlendirin (İki Yönlü Puanlama)',
                            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 12, color: Color(0xFF1A2B3C)),
                          ),
                          const SizedBox(height: 8),
                          Row(
                            children: [1, 2, 3, 4, 5].map((int score) {
                              return IconButton(
                                icon: Icon(
                                  Icons.star,
                                  color: _ratingScore >= score ? Colors.amber : Colors.grey[300],
                                ),
                                onPressed: () {
                                  setState(() {
                                    _ratingScore = score.toDouble();
                                  });
                                },
                              );
                            }).toList(),
                          ),
                          TextField(
                            controller: _ratingCommentCtrl,
                            decoration: const InputDecoration(
                              labelText: 'Gönderici firmayla ilgili deneyiminiz...',
                              border: OutlineInputBorder(),
                            ),
                          ),
                          const SizedBox(height: 12),
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                              onPressed: () => _submitSenderRating(_ad!['senderId']),
                              style: ElevatedButton.styleFrom(
                                backgroundColor: const Color(0xFFFF8C00),
                                foregroundColor: Colors.white,
                              ),
                              child: const Text('Değerlendirmeyi Gönder'),
                            ),
                          )
                        ]
                      ]
                    ],
                    if (isSender) ...[
                      if (_activeTx!['status'] == 'Pending') ...[
                        const Text(
                          'Taşıyıcı atandı ve ön-provizyon blokajları tamamlandı. Taşıyıcının yola çıkması bekleniyor.',
                          style: TextStyle(fontSize: 11, color: Color(0xFF64748B), height: 1.4),
                        ),
                        const SizedBox(height: 12),
                        const Row(
                          children: [
                            SizedBox(
                              width: 16,
                              height: 16,
                              child: CircularProgressIndicator(strokeWidth: 1.5, color: Color(0xFFFF8C00)),
                            ),
                            SizedBox(width: 8),
                            Text(
                              'Taşıyıcının kalkış yapması bekleniyor...',
                              style: TextStyle(fontSize: 10, color: Color(0xFFFF8C00), fontWeight: FontWeight.bold),
                            )
                          ],
                        )
                      ],

                      if (_activeTx!['status'] == 'InTransit') ...[
                        const Text(
                          'Kargonuz şu an taşıma aşamasında. Canlı telemetri konum takibi yapılıyor.',
                          style: TextStyle(fontSize: 11, color: Color(0xFF64748B), height: 1.4),
                        ),
                        const SizedBox(height: 16),
                        
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            const Text(
                              '📍 Taşıyıcı Konum İlerlemesi:',
                              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFF1A2B3C)),
                            ),
                            Text(
                              _gpsProgress > 0 ? '%${(_gpsProgress * 100).toInt()} tamamlandı' : 'Transit modunda',
                              style: const TextStyle(fontSize: 10, color: Color(0xFF64748B), fontWeight: FontWeight.bold),
                            ),
                          ],
                        ),
                        const SizedBox(height: 8),
                        LinearProgressIndicator(
                          value: _gpsProgress > 0 ? _gpsProgress : 0.4,
                          color: const Color(0xFFFF8C00),
                          backgroundColor: const Color(0xFFFEF3C7),
                        ),
                        const SizedBox(height: 16),

                        if (_ocrResultText != null) ...[
                          const Divider(),
                          const SizedBox(height: 12),
                          const Text(
                            '📄 Taşıyıcı Tarafından Yüklenen Sevk İrsaliyesi:',
                            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFF1A2B3C)),
                          ),
                          const SizedBox(height: 8),
                          Container(
                            padding: const EdgeInsets.all(12),
                            decoration: BoxDecoration(
                              color: Colors.green[50],
                              borderRadius: BorderRadius.circular(12),
                              border: Border.all(color: Colors.green[200]!),
                            ),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Row(
                                  children: [
                                    const Icon(Icons.verified, color: Colors.green, size: 14),
                                    const SizedBox(width: 6),
                                    Text('AI OCR Doğrulaması Geçildi', style: TextStyle(fontSize: 10, color: Colors.green[800], fontWeight: FontWeight.bold)),
                                  ],
                                ),
                                const SizedBox(height: 6),
                                Text(
                                  _ocrResultText!,
                                  style: const TextStyle(fontSize: 9, fontFamily: 'monospace', color: Color(0xFF1A2B3C)),
                                ),
                              ],
                            ),
                          ),
                        ] else ...[
                          const Divider(),
                          const SizedBox(height: 12),
                          const Row(
                            children: [
                              Icon(Icons.pending_actions, color: Colors.amber, size: 16),
                              SizedBox(width: 8),
                              Text(
                                'Taşıyıcının irsaliye/teslimat belgesi yüklemesi bekleniyor.',
                                style: TextStyle(fontSize: 10, color: Color(0xFF64748B)),
                              ),
                            ],
                          )
                        ]
                      ],

                      if (_activeTx!['status'] == 'Delivered') ...[
                        const Row(
                          children: [
                            Icon(Icons.check_circle, color: Colors.green),
                            SizedBox(width: 8),
                            Text(
                              'Sevkiyat Tamamlandı & Yapay Zeka Onaylı!',
                              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 12, color: Colors.green),
                            )
                          ],
                        ),
                        const SizedBox(height: 12),
                        const Text(
                          'Ödemeler taşıyıcıya başarıyla aktarılmış ve taşıyıcı güvence teminatı serbest bırakılmıştır.',
                          style: TextStyle(fontSize: 11, color: Color(0xFF64748B), height: 1.4),
                        ),
                        const SizedBox(height: 16),
                        
                        if (_hasRatedCarrier) ...[
                          const Text(
                            'Taşıyıcıyı başarıyla değerlendirdiniz. Geri bildiriminiz için teşekkürler!',
                            style: TextStyle(fontSize: 11, color: Color(0xFF64748B), fontWeight: FontWeight.bold),
                          )
                        ] else ...[
                          const Divider(),
                          const SizedBox(height: 12),
                          const Text(
                            'Taşıyıcıyı Değerlendirin (İki Yönlü Puanlama)',
                            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 12, color: Color(0xFF1A2B3C)),
                          ),
                          const SizedBox(height: 8),
                          Row(
                            children: [1, 2, 3, 4, 5].map((int score) {
                              return IconButton(
                                icon: Icon(
                                  Icons.star,
                                  color: _carrierRatingScore >= score ? Colors.amber : Colors.grey[300],
                                ),
                                onPressed: () {
                                  setState(() {
                                    _carrierRatingScore = score.toDouble();
                                  });
                                },
                              );
                            }).toList(),
                          ),
                          TextField(
                            controller: _carrierRatingCommentCtrl,
                            decoration: const InputDecoration(
                              labelText: 'Taşıyıcının hızı, iletişimi ve özeni nasıldı?...',
                              border: OutlineInputBorder(),
                            ),
                          ),
                          const SizedBox(height: 12),
                          SizedBox(
                            width: double.infinity,
                            child: ElevatedButton(
                              onPressed: () => _submitCarrierRating(_activeTx!['bid']['carrierId']),
                              style: ElevatedButton.styleFrom(
                                backgroundColor: const Color(0xFFFF8C00),
                                foregroundColor: Colors.white,
                              ),
                              child: const Text('Değerlendirmeyi Gönder'),
                            ),
                          )
                        ]
                      ]
                    ]
                  ],
                ),
              )
            ],

            // Bids Listing section (Only shown if active)
            if (_ad!['status'] == 'Active') ...[
              const SizedBox(height: 16),
              const Text('GÜNCEL İHALE TEKLİFLERİ', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF64748B), letterSpacing: 0.5)),
              const SizedBox(height: 8),
              if (bidsList.isEmpty) ...[
                const Card(
                  child: Padding(
                    padding: EdgeInsets.all(16.0),
                    child: Center(child: Text('Henüz bu ilana teklif verilmedi.', style: TextStyle(fontSize: 11))),
                  ),
                )
              ] else ...[
                Column(
                  children: bidsList.map((b) {
                    final isCarrierMe = user != null && b['carrierId'] == user['id'];
                    return Card(
                      margin: const EdgeInsets.only(bottom: 8),
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
                      elevation: 0,
                      child: ListTile(
                        leading: CircleAvatar(
                          backgroundColor: isCarrierMe ? const Color(0xFFFEF3C7) : const Color(0xFFF1F5F9),
                          child: Icon(Icons.local_shipping, color: isCarrierMe ? const Color(0xFFFF8C00) : const Color(0xFF64748B), size: 16),
                        ),
                        title: Text(
                          b['carrier']?['name'] ?? 'Mehmet Usta',
                          style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 12),
                        ),
                        subtitle: Text(
                          'Cüzdan Bakiyesi: ₺${b['carrier']?['balance'] ?? 20000}',
                          style: const TextStyle(fontSize: 10),
                        ),
                        trailing: Row(
                          mainAxisSize: MainAxisSize.min,
                          children: [
                            Text(
                              '₺${b['amount']}',
                              style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 13, color: Color(0xFFFF8C00)),
                            ),
                            if (isSender) ...[
                              const SizedBox(width: 8),
                              ElevatedButton(
                                onPressed: _isActionLoading ? null : () => _selectBid(b['id']),
                                style: ElevatedButton.styleFrom(
                                  backgroundColor: const Color(0xFF10B981),
                                  foregroundColor: Colors.white,
                                  elevation: 0,
                                  shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
                                  padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
                                ),
                                child: const Text('Kabul Et', style: TextStyle(fontSize: 9)),
                              )
                            ]
                          ],
                        ),
                      ),
                    );
                  }).toList(),
                )
              ],
            ],

            // Backhaul matching recommendations
            if (isCarrier && _ad!['status'] == 'Active') ...[
              const SizedBox(height: 24),
              const Text('DÖNÜŞ YÜKÜ TAVSİYELERİ (Boş Dönmeyin!)', style: TextStyle(fontSize: 11, fontWeight: FontWeight.bold, color: Color(0xFF64748B), letterSpacing: 0.5)),
              const SizedBox(height: 8),
              if (_recommendations.isEmpty) ...[
                const Card(
                  child: Padding(
                    padding: EdgeInsets.all(16.0),
                    child: Center(child: Text('Şu an uygun dönüş yükü eşleşmesi bulunamadı.', style: TextStyle(fontSize: 11, color: Color(0xFF64748B)))),
                  ),
                )
              ] else ...[
                Column(
                  children: _recommendations.map((rec) {
                    return Card(
                      margin: const EdgeInsets.only(bottom: 8),
                      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16), side: const BorderSide(color: Color(0xFFFF8C00), width: 0.5)),
                      elevation: 0,
                      child: ListTile(
                        dense: true,
                        leading: const CircleAvatar(
                          backgroundColor: Color(0xFFFEF3C7),
                          child: Icon(Icons.autorenew, color: Color(0xFFFF8C00), size: 16),
                        ),
                        title: Text(
                          '${rec['startLocation']} → ${rec['endLocation']} Dönüşü',
                          style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFF1A2B3C)),
                        ),
                        subtitle: Text(
                          '${rec['title']} • ${rec['distanceKm']} Km',
                          style: const TextStyle(fontSize: 9),
                        ),
                        trailing: Row(
                          mainAxisSize: MainAxisSize.min,
                          children: [
                            Text(
                              '₺${rec['floorPrice']}',
                              style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 11, color: Color(0xFFFF8C00)),
                            ),
                            const SizedBox(width: 8),
                            ElevatedButton(
                              onPressed: () {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                    builder: (context) => BidDetailsScreen(adId: rec['id']),
                                  ),
                                );
                              },
                              style: ElevatedButton.styleFrom(
                                backgroundColor: const Color(0xFFFF8C00),
                                foregroundColor: Colors.white,
                                elevation: 0,
                                padding: const EdgeInsets.symmetric(horizontal: 10),
                                shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
                              ),
                              child: const Text('Detay →', style: TextStyle(fontSize: 9, fontWeight: FontWeight.bold)),
                            ),
                          ],
                        ),
                      ),
                    );
                  }).toList(),
                )
              ]
            ],
          ],
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

  Widget _buildMiniMetric(String title, String value, Color highlightColor) {
    return Container(
      width: 100,
      padding: const EdgeInsets.all(12),
      decoration: BoxDecoration(
        color: const Color(0xFFF8FAFC),
        borderRadius: BorderRadius.circular(12),
        border: Border.all(color: const Color(0xFFF1F5F9)),
      ),
      child: Column(
        children: [
          Text(title, style: const TextStyle(fontSize: 9, color: Color(0xFF64748B))),
          const SizedBox(height: 4),
          Text(
            value,
            style: TextStyle(fontSize: 12, fontWeight: FontWeight.bold, color: highlightColor),
          )
        ],
      ),
    );
  }
}

class CountdownTimerWidget extends StatefulWidget {
  final String endsAt;
  const CountdownTimerWidget({Key? key, required this.endsAt}) : super(key: key);

  @override
  State<CountdownTimerWidget> createState() => _CountdownTimerWidgetState();
}

class _CountdownTimerWidgetState extends State<CountdownTimerWidget> {
  Timer? _timer;

  @override
  void initState() {
    super.initState();
    _timer = Timer.periodic(const Duration(seconds: 1), (timer) {
      if (mounted) {
        setState(() {});
      }
    });
  }

  @override
  void dispose() {
    _timer?.cancel();
    super.dispose();
  }

  String _formatCountdown(String endsAtStr) {
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

  @override
  Widget build(BuildContext context) {
    return Text(
      _formatCountdown(widget.endsAt),
      style: const TextStyle(
        color: Colors.white,
        fontSize: 11,
        fontWeight: FontWeight.bold,
        fontFamily: 'monospace',
      ),
    );
  }
}
