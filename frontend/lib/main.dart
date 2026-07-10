import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:frontend/providers/app_provider.dart';
import 'package:frontend/screens/login_screen.dart';
import 'package:frontend/screens/explore_screen.dart';
import 'package:frontend/screens/my_bids_screen.dart';
import 'package:frontend/screens/notifications_screen.dart';
import 'package:frontend/screens/profile_screen.dart';
import 'package:frontend/widgets/chatbot_modal.dart';

void main() {
  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => AppProvider()),
      ],
      child: const MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Lojistik Yol',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        textTheme: GoogleFonts.outfitTextTheme(Theme.of(context).textTheme),
        primaryColor: const Color(0xFFFF8C00),
        scaffoldBackgroundColor: const Color(0xFFF4F7F9),
      ),
      home: Consumer<AppProvider>(
        builder: (context, provider, child) {
          return provider.isLoggedIn ? const AppNavigationLayout() : const LoginScreen();
        },
      ),
    );
  }
}

class AppNavigationLayout extends StatefulWidget {
  const AppNavigationLayout({Key? key}) : super(key: key);

  @override
  State<AppNavigationLayout> createState() => _AppNavigationLayoutState();
}

class _AppNavigationLayoutState extends State<AppNavigationLayout> {
  int _currentIndex = 0;

  final List<Widget> _screens = [
    const ExploreScreen(),
    const MyBidsScreen(),
    const NotificationsScreen(),
    const ProfileScreen(),
  ];

  @override
  Widget build(BuildContext context) {
    final provider = Provider.of<AppProvider>(context);

    if (provider.isLoading && provider.users.isEmpty) {
      return const Scaffold(
        backgroundColor: Color(0xFFF4F7F9),
        body: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              CircularProgressIndicator(color: Color(0xFFFF8C00)),
              SizedBox(height: 16),
              Text(
                'LojistikYol API Bağlantısı Kuruluyor...',
                style: TextStyle(color: Color(0xFF64748B), fontWeight: FontWeight.bold),
              ),
            ],
          ),
        ),
      );
    }

    if (provider.errorMessage != null && provider.users.isEmpty) {
      return Scaffold(
        backgroundColor: const Color(0xFFF4F7F9),
        body: Padding(
          padding: const EdgeInsets.all(24.0),
          child: Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Icon(Icons.cloud_off, size: 64, color: Color(0xFFEF4444)),
                const SizedBox(height: 16),
                const Text(
                  'API Bağlantı Hatası!',
                  style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold, color: Color(0xFF1A2B3C)),
                ),
                const SizedBox(height: 8),
                const Text(
                  'Lütfen backend projenizin (http://localhost:5279) ve SQL Server hizmetinizin çalıştığından emin olun.',
                  textAlign: TextAlign.center,
                  style: TextStyle(color: Color(0xFF64748B)),
                ),
                const SizedBox(height: 20),
                ElevatedButton.icon(
                  onPressed: () => provider.refreshAll(),
                  style: ElevatedButton.styleFrom(
                    backgroundColor: const Color(0xFFFF8C00),
                    foregroundColor: Colors.white,
                    shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
                  ),
                  icon: const Icon(Icons.refresh),
                  label: const Text('Tekrar Dene'),
                )
              ],
            ),
          ),
        ),
      );
    }

    return Scaffold(
      backgroundColor: const Color(0xFFF4F7F9),
      appBar: AppBar(
        backgroundColor: Colors.white,
        elevation: 0.5,
        title: Row(
          children: [
            Container(
              padding: const EdgeInsets.all(6),
              decoration: BoxDecoration(
                color: const Color(0xFF1A2B3C),
                borderRadius: BorderRadius.circular(8),
              ),
              child: const Icon(Icons.local_shipping, color: Colors.white, size: 16),
            ),
            const SizedBox(width: 8),
            const Text(
              'Lojistik Yol',
              style: TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 15,
                color: Color(0xFF1A2B3C),
              ),
            ),
          ],
        ),
        actions: [

          IconButton(
            icon: const Icon(Icons.logout, color: Color(0xFF64748B), size: 20),
            onPressed: () {
              provider.logoutUser();
            },
          ),
        ],
      ),
      body: _screens[_currentIndex],
      bottomNavigationBar: Container(
        decoration: const BoxDecoration(
          border: Border(top: BorderSide(color: Color(0xFFE2E8F0), width: 0.5)),
        ),
        child: BottomNavigationBar(
          currentIndex: _currentIndex,
          onTap: (index) {
            setState(() {
              _currentIndex = index;
            });
          },
          backgroundColor: Colors.white,
          selectedItemColor: const Color(0xFFFF8C00),
          unselectedItemColor: const Color(0xFF64748B),
          selectedLabelStyle: const TextStyle(fontWeight: FontWeight.bold, fontSize: 11),
          unselectedLabelStyle: const TextStyle(fontSize: 11),
          type: BottomNavigationBarType.fixed,
          items: [
            const BottomNavigationBarItem(
              icon: Icon(Icons.search),
              label: 'Keşfet',
            ),
            const BottomNavigationBarItem(
              icon: Icon(Icons.assignment),
              label: 'Tekliflerim',
            ),
            BottomNavigationBarItem(
              icon: Badge(
                isLabelVisible: provider.notifications.any((n) => n['isRead'] == false),
                label: Text(provider.notifications.where((n) => n['isRead'] == false).length.toString()),
                child: const Icon(Icons.notifications),
              ),
              label: 'Bildirimler',
            ),
            const BottomNavigationBarItem(
              icon: Icon(Icons.person),
              label: 'Profil',
            ),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          showModalBottomSheet(
            context: context,
            isScrollControlled: true,
            backgroundColor: Colors.transparent,
            builder: (context) => const FractionallySizedBox(
              heightFactor: 0.75,
              child: ChatbotModal(),
            ),
          );
        },
        backgroundColor: const Color(0xFF1A2B3C),
        foregroundColor: Colors.white,
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
        child: const Icon(Icons.forum),
      ),
    );
  }
}
