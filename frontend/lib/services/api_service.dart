import 'dart:convert';
import 'package:flutter/foundation.dart';
import 'package:http/http.dart' as http;

class ApiService {
  // Use 10.0.2.2 for Android emulator, localhost for Web/Desktop
  static final String baseUrl = kIsWeb ? 'http://localhost:5279/api' : 'http://10.0.2.2:5279/api';

  // --- AUTH ---
  static Future<Map<String, dynamic>?> login(String email, String password) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/login'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'email': email, 'password': password}),
      );
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('Login Error: $e');
    }
    return null;
  }

  static Future<Map<String, dynamic>?> register(
      String name, String email, String password, String userType, String city) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/register'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'name': name,
          'email': email,
          'password': password,
          'userType': userType,
          'city': city
        }),
      );
      if (response.statusCode == 200 || response.statusCode == 201) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('Register Error: $e');
    }
    return null;
  }

  static Future<List<dynamic>> getUsers() async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/auth/users'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetUsers Error: $e');
    }
    return [];
  }

  static Future<bool> topUpWallet(int userId, double amount) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/topup'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'userId': userId, 'amount': amount}),
      );
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('TopUp Error: $e');
    }
    return false;
  }

  static Future<Map<String, dynamic>?> upgradeProfile(int userId, String upgradeType, String? insuranceNo) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/profile/upgrade'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'userId': userId,
          'upgradeType': upgradeType,
          'insuranceNo': insuranceNo,
        }),
      );
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('Upgrade Error: $e');
    }
    return null;
  }

  static Future<Map<String, dynamic>?> updateProfile(int userId, String name, String city) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/profile/update'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'userId': userId,
          'name': name,
          'city': city,
        }),
      );
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('UpdateProfile Error: $e');
    }
    return null;
  }

  // --- ADS ---
  static Future<List<dynamic>> getAds() async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/ads'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetAds Error: $e');
    }
    return [];
  }

  static Future<Map<String, dynamic>?> createAd(Map<String, dynamic> adData) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/ads'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode(adData),
      );
      if (response.statusCode == 201 || response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('CreateAd Error: $e');
    }
    return null;
  }

  static Future<Map<String, dynamic>?> placeBid(int adId, int carrierId, double amount, {bool isAutoBidEnabled = false, double? autoBidMinLimit}) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/bids'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'adId': adId,
          'carrierId': carrierId,
          'amount': amount,
          'isAutoBidEnabled': isAutoBidEnabled,
          'autoBidMinLimit': autoBidMinLimit,
        }),
      );
      if (response.statusCode == 200 || response.statusCode == 201) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('PlaceBid Error: $e');
    }
    return null;
  }

  static Future<bool> selectBid(int bidId) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/transactions/accept-bid'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'bidId': bidId}),
      );
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('SelectBid Error: $e');
    }
    return false;
  }

  // --- TRANSACTIONS / WORKFLOW ---
  static Future<Map<String, dynamic>?> getTransactionByBid(int bidId) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/transactions/bid/$bidId'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetTransaction Error: $e');
    }
    return null;
  }

  static Future<bool> updateTransactionStatus(int txId, String status, {String? deliveryImageUrl}) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/transactions/$txId/status'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'status': status,
          'deliveryImageUrl': deliveryImageUrl,
        }),
      );
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('UpdateTxStatus Error: $e');
    }
    return false;
  }

  // --- RETURN RECOMMENDATIONS ---
  static Future<List<dynamic>> getRecommendations(int adId, int level) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/recommendations/$adId?level=$level'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetRecommendations Error: $e');
    }
    return [];
  }

  // --- CHATBOT ---
  static Future<String> askChatbot(String message, String userContext) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/chatbot'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'message': message, 'userContext': userContext}),
      );
      if (response.statusCode == 200) {
        final body = jsonDecode(response.body);
        return body['reply'] ?? 'Bir hata oluştu.';
      }
    } catch (e) {
      debugPrint('Chatbot Error: $e');
    }
    return 'Bağlantı hatası oluştu, asistan şu an yanıt veremiyor.';
  }

  // --- UBER FREIGHT EXTRAS ---

  static Future<Map<String, dynamic>?> instantBook(int adId, int carrierId) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/ads/$adId/instant-book'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'carrierId': carrierId}),
      );
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('InstantBook Error: $e');
    }
    return null;
  }

  static Future<bool> assignDriver(int adId, int driverId) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/ads/$adId/assign-driver'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({'driverId': driverId}),
      );
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('AssignDriver Error: $e');
    }
    return false;
  }

  static Future<String?> uploadWaybill(int adId, String base64Image) async {
    final response = await http.post(
      Uri.parse('$baseUrl/ads/$adId/upload-waybill'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({'waybillUrl': base64Image}),
    );
    if (response.statusCode == 200) {
      final body = jsonDecode(response.body);
      return body['ocrText'] as String?;
    } else {
      final body = jsonDecode(response.body);
      throw Exception(body['message'] ?? 'Belge yüklenemedi (Bilinmeyen Hata).');
    }
  }

  static Future<Map<String, dynamic>?> createPayoutRequest(int userId, double amount, String bankName, String bankAccount) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/payout'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'userId': userId,
          'amount': amount,
          'bankName': bankName,
          'bankAccountNumber': bankAccount
        }),
      );
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('CreatePayout Error: $e');
    }
    return null;
  }

  static Future<List<dynamic>> getPayoutRequests(int userId) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/auth/payouts?userId=$userId'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetPayouts Error: $e');
    }
    return [];
  }

  static Future<List<dynamic>> getNotifications(int userId) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/auth/notifications?userId=$userId'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetNotifications Error: $e');
    }
    return [];
  }

  static Future<bool> markNotificationsRead(int userId) async {
    try {
      final response = await http.post(Uri.parse('$baseUrl/auth/notifications/read?userId=$userId'));
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('MarkNotificationsRead Error: $e');
    }
    return false;
  }

  static Future<Map<String, dynamic>?> addFleetDriver(int parentId, String name, String email, String password) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/auth/fleet/add-driver'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'parentId': parentId,
          'name': name,
          'email': email,
          'password': password
        }),
      );
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('AddFleetDriver Error: $e');
    }
    return null;
  }

  static Future<List<dynamic>> getFleetDrivers(int parentId) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/auth/fleet/drivers?parentId=$parentId'));
      if (response.statusCode == 200) {
        return jsonDecode(response.body);
      }
    } catch (e) {
      debugPrint('GetFleetDrivers Error: $e');
    }
    return [];
  }

  static Future<bool> rateSender(int adId, int senderId, int carrierId, int rating, String comment) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/ads/sender/rate'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'adId': adId,
          'senderId': senderId,
          'carrierId': carrierId,
          'score': rating,
          'comment': comment
        }),
      );
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('RateSender Error: $e');
    }
    return false;
  }

  static Future<bool> rateCarrier(int adId, int carrierId, int senderId, int rating, String comment) async {
    try {
      final response = await http.post(
        Uri.parse('$baseUrl/ads/carrier/rate'),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'adId': adId,
          'carrierId': carrierId,
          'senderId': senderId,
          'score': rating,
          'comment': comment
        }),
      );
      return response.statusCode == 200;
    } catch (e) {
      debugPrint('RateCarrier Error: $e');
    }
    return false;
  }
}
