import 'package:flutter/material.dart';
import 'package:frontend/services/api_service.dart';

class AppProvider extends ChangeNotifier {
  bool _isLoading = false;
  String? _errorMessage;
  
  List<dynamic> _ads = [];
  List<dynamic> _users = [];
  Map<String, dynamic>? _currentUser;
  
  List<dynamic> _notifications = [];
  List<dynamic> _payouts = [];
  List<dynamic> _fleetDrivers = [];
  
  bool get isLoading => _isLoading;
  String? get errorMessage => _errorMessage;
  List<dynamic> get ads => _ads;
  List<dynamic> get users => _users;
  Map<String, dynamic>? get currentUser => _currentUser;
  
  List<dynamic> get notifications => _notifications;
  List<dynamic> get payouts => _payouts;
  List<dynamic> get fleetDrivers => _fleetDrivers;
  
  bool get isLoggedIn => _currentUser != null;

  // Filtered carriers for directory
  List<dynamic> get carriers => _users.where((u) => u['userType'] == 'Carrier').toList();

  AppProvider() {
    refreshAll();
  }

  void _setLoading(bool val) {
    _isLoading = val;
    notifyListeners();
  }

  void _setError(String? msg) {
    _errorMessage = msg;
    notifyListeners();
  }

  Future<void> refreshAll() async {
    _setLoading(true);
    _setError(null);
    try {
      final fetchedAds = await ApiService.getAds();
      final fetchedUsers = await ApiService.getUsers();
      
      _ads = fetchedAds;
      _users = fetchedUsers;
      
      if (_currentUser != null) {
        final freshMe = _users.firstWhere((u) => u['id'] == _currentUser!['id'], orElse: () => null);
        if (freshMe != null) {
          _currentUser = freshMe;
        }
        
        // Fetch notifications, payouts, and fleet drivers
        _notifications = await ApiService.getNotifications(_currentUser!['id']);
        _payouts = await ApiService.getPayoutRequests(_currentUser!['id']);
        if (_currentUser!['userType'] == 'Carrier' && _currentUser!['userLevel'] >= 2) {
          _fleetDrivers = await ApiService.getFleetDrivers(_currentUser!['id']);
        }
      } else if (_users.isNotEmpty) {
        _currentUser = _users.first;
      }
    } catch (e) {
      _setError('Sunucu bağlantı hatası. Lütfen API sunucusunun çalıştığından emin olun.');
    } finally {
      _setLoading(false);
    }
  }

  void setCurrentUser(Map<String, dynamic> user) {
    _currentUser = user;
    notifyListeners();
  }

  void logoutUser() {
    _currentUser = null;
    notifyListeners();
  }

  Future<bool> login(String email, String password) async {
    _setLoading(true);
    _setError(null);
    final user = await ApiService.login(email, password);
    _setLoading(false);
    if (user != null) {
      _currentUser = user;
      await refreshAll();
      return true;
    }
    return false;
  }

  Future<bool> register(String name, String email, String password, String userType, String city) async {
    _setLoading(true);
    _setError(null);
    final result = await ApiService.register(name, email, password, userType, city);
    _setLoading(false);
    if (result != null) {
      await refreshAll();
      // Select registered user
      final registeredUser = _users.firstWhere((u) => u['email'] == email, orElse: () => null);
      if (registeredUser != null) {
        _currentUser = registeredUser;
      }
      return true;
    }
    return false;
  }

  Future<bool> topUp(double amount) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final success = await ApiService.topUpWallet(_currentUser!['id'], amount);
    if (success) {
      await refreshAll();
    }
    _setLoading(false);
    return success;
  }

  Future<bool> upgradeProfile(String upgradeType, String? insuranceNo) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final res = await ApiService.upgradeProfile(_currentUser!['id'], upgradeType, insuranceNo);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> updateProfile(String name, String city) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final res = await ApiService.updateProfile(_currentUser!['id'], name, city);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> placeBid(int adId, double amount, {bool isAutoBidEnabled = false, double? autoBidMinLimit}) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final res = await ApiService.placeBid(adId, _currentUser!['id'], amount, isAutoBidEnabled: isAutoBidEnabled, autoBidMinLimit: autoBidMinLimit);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> selectBid(int bidId) async {
    _setLoading(true);
    final success = await ApiService.selectBid(bidId);
    if (success) {
      await refreshAll();
    }
    _setLoading(false);
    return success;
  }

  Future<bool> updateTxStatus(int txId, String status, {String? deliveryImageUrl}) async {
    _setLoading(true);
    final success = await ApiService.updateTransactionStatus(txId, status, deliveryImageUrl: deliveryImageUrl);
    if (success) {
      await refreshAll();
    }
    _setLoading(false);
    return success;
  }

  Future<bool> createAd(String title, String desc, String start, String end, double distance, double cargoValue, int reqLevel, {String? cargoImageUrl}) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final adData = {
      'title': title,
      'description': desc,
      'startLocation': start,
      'endLocation': end,
      'distanceKm': distance,
      'cargoValue': cargoValue,
      'requiredLevel': reqLevel,
      'senderId': _currentUser!['id'],
      'cargoImageUrl': cargoImageUrl ?? 'https://images.unsplash.com/photo-1586528116311-ad8dd3c8310d?auto=format&fit=crop&w=600&q=80',
    };
    final res = await ApiService.createAd(adData);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> instantBook(int adId) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final res = await ApiService.instantBook(adId, _currentUser!['id']);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> assignDriver(int adId, int driverId) async {
    _setLoading(true);
    final success = await ApiService.assignDriver(adId, driverId);
    if (success) {
      await refreshAll();
    }
    _setLoading(false);
    return success;
  }

  Future<String?> uploadWaybill(int adId, String base64Image) async {
    _setLoading(true);
    final ocrText = await ApiService.uploadWaybill(adId, base64Image);
    if (ocrText != null) {
      await refreshAll();
    }
    _setLoading(false);
    return ocrText;
  }

  Future<bool> createPayoutRequest(double amount, String bankName, String bankAccount) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final res = await ApiService.createPayoutRequest(_currentUser!['id'], amount, bankName, bankAccount);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> addFleetDriver(String name, String email, String password) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final res = await ApiService.addFleetDriver(_currentUser!['id'], name, email, password);
    if (res != null) {
      await refreshAll();
      _setLoading(false);
      return true;
    }
    _setLoading(false);
    return false;
  }

  Future<bool> rateSender(int adId, int senderId, int rating, String comment) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final success = await ApiService.rateSender(adId, senderId, _currentUser!['id'], rating, comment);
    if (success) {
      await refreshAll();
    }
    _setLoading(false);
    return success;
  }

  Future<bool> rateCarrier(int adId, int carrierId, int rating, String comment) async {
    if (_currentUser == null) return false;
    _setLoading(true);
    final success = await ApiService.rateCarrier(adId, carrierId, _currentUser!['id'], rating, comment);
    if (success) {
      await refreshAll();
    }
    _setLoading(false);
    return success;
  }

  Future<bool> markNotificationsRead() async {
    if (_currentUser == null) return false;
    final success = await ApiService.markNotificationsRead(_currentUser!['id']);
    if (success) {
      for (var n in _notifications) {
        n['isRead'] = true;
      }
      notifyListeners();
    }
    return success;
  }
}
