import 'dart:math';
import 'package:flutter/material.dart';

class RouteTruckAnimator extends StatefulWidget {
  final String startLocation;
  final String endLocation;

  const RouteTruckAnimator({
    Key? key,
    required this.startLocation,
    required this.endLocation,
  }) : super(key: key);

  @override
  State<RouteTruckAnimator> createState() => _RouteTruckAnimatorState();
}

class _RouteTruckAnimatorState extends State<RouteTruckAnimator>
    with SingleTickerProviderStateMixin {
  late AnimationController _controller;
  late Animation<double> _animation;

  // City coordinate database for map drawing
  final Map<String, Offset> _cityPins = {
    'İstanbul': const Offset(80, 80),
    'Ankara': const Offset(180, 140),
    'İzmir': const Offset(50, 180),
    'Kocaeli': const Offset(110, 90),
    'Bursa': const Offset(90, 110),
    'Batman': const Offset(310, 170),
    'İskenderun': const Offset(230, 190),
  };

  // Human readable GPS coordinates database
  final Map<String, String> _cityCoordinates = {
    'İstanbul': '41.00°N, 28.97°E',
    'Ankara': '39.93°N, 32.85°E',
    'İzmir': '38.41°N, 27.12°E',
    'Kocaeli': '40.76°N, 29.91°E',
    'Bursa': '40.18°N, 29.06°E',
    'Batman': '37.88°N, 41.12°E',
    'İskenderun': '36.58°N, 36.17°E',
  };

  @override
  void initState() {
    super.initState();
    _controller = AnimationController(
      duration: const Duration(seconds: 4),
      vsync: this,
    )..repeat();
    _animation = Tween<double>(begin: 0.0, end: 1.0).animate(_controller);
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    // Default coordinate fallbacks
    Offset startPin = _cityPins[widget.startLocation] ?? const Offset(60, 60);
    Offset endPin = _cityPins[widget.endLocation] ?? const Offset(280, 180);

    String startCoords = _cityCoordinates[widget.startLocation] ?? '39.9°N, 32.8°E';
    String endCoords = _cityCoordinates[widget.endLocation] ?? '39.9°N, 32.8°E';

    return Container(
      height: 250,
      width: double.infinity,
      decoration: BoxDecoration(
        color: const Color(0xFF1E293B), // Premium sleek dark mode blue background
        borderRadius: BorderRadius.circular(24),
        boxShadow: [
          BoxShadow(
            color: const Color(0xFF1E293B).withOpacity(0.3),
            blurRadius: 15,
            offset: const Offset(0, 8),
          ),
        ],
      ),
      clipBehavior: Clip.antiAlias,
      child: Stack(
        children: [
          // Grid lines for premium map design effect
          Positioned.fill(
            child: GridPaper(
              color: Colors.white.withOpacity(0.02),
              divisions: 2,
              subdivisions: 1,
              interval: 40,
            ),
          ),
          
          // Animated Live Map Painter
          AnimatedBuilder(
            animation: _animation,
            builder: (context, child) {
              return CustomPaint(
                painter: MapVisualizerPainter(
                  startPin: startPin,
                  endPin: endPin,
                  startCity: widget.startLocation,
                  endCity: widget.endLocation,
                  startCoords: startCoords,
                  endCoords: endCoords,
                  progress: _animation.value,
                ),
                child: Container(),
              );
            },
          ),

          // Badge to show "CANLI YOL HARİTASI"
          Positioned(
            top: 16,
            left: 16,
            child: Container(
              padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
              decoration: BoxDecoration(
                color: const Color(0xFFFF8C00),
                borderRadius: BorderRadius.circular(20),
              ),
              child: const Row(
                children: [
                  Icon(Icons.gps_fixed, color: Colors.white, size: 10),
                  SizedBox(width: 4),
                  Text(
                    'GPS CANLI ROTA',
                    style: TextStyle(color: Colors.white, fontSize: 8, fontWeight: FontWeight.bold, letterSpacing: 0.5),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}

class MapVisualizerPainter extends CustomPainter {
  final Offset startPin;
  final Offset endPin;
  final String startCity;
  final String endCity;
  final String startCoords;
  final String endCoords;
  final double progress;

  MapVisualizerPainter({
    required this.startPin,
    required this.endPin,
    required this.startCity,
    required this.endCity,
    required this.startCoords,
    required this.endCoords,
    required this.progress,
  });

  @override
  void paint(Canvas canvas, Size size) {
    // 1. Draw route line with curve (using Bezier path)
    final path = Path();
    path.moveTo(startPin.dx, startPin.dy);
    
    // Control point for a smooth curve
    double controlX = (startPin.dx + endPin.dx) / 2 + 30;
    double controlY = (startPin.dy + endPin.dy) / 2 - 40;
    path.quadraticBezierTo(controlX, controlY, endPin.dx, endPin.dy);

    final linePaint = Paint()
      ..color = Colors.white.withOpacity(0.15)
      ..style = PaintingStyle.stroke
      ..strokeWidth = 3
      ..strokeCap = StrokeCap.round;

    final activeLinePaint = Paint()
      ..color = const Color(0xFFFF8C00) // Orange active path
      ..style = PaintingStyle.stroke
      ..strokeWidth = 3.5
      ..strokeCap = StrokeCap.round;

    // Draw full inactive line
    canvas.drawPath(path, linePaint);

    // Compute animated path for the active line segment
    final pathMetrics = path.computeMetrics();
    for (final metric in pathMetrics) {
      final extractPath = metric.extractPath(0.0, metric.length * progress);
      canvas.drawPath(extractPath, activeLinePaint);

      // 2. Draw animated truck position along the curve
      final tangent = metric.getTangentForOffset(metric.length * progress);
      if (tangent != null) {
        final truckPos = tangent.position;
        final truckPaint = Paint()
          ..color = Colors.white
          ..style = PaintingStyle.fill;

        // Draw outer glowing halo for the truck
        final glowPaint = Paint()
          ..color = const Color(0xFFFF8C00).withOpacity(0.4)
          ..style = PaintingStyle.fill;
        canvas.drawCircle(truckPos, 10, glowPaint);
        
        // Draw truck dot representation
        canvas.drawCircle(truckPos, 5, truckPaint);
      }
    }

    // 3. Draw City Pin Circles
    final pinPaint = Paint()
      ..color = const Color(0xFFFF8C00)
      ..style = PaintingStyle.fill;
    final pinBorderPaint = Paint()
      ..color = Colors.white.withOpacity(0.3)
      ..style = PaintingStyle.stroke
      ..strokeWidth = 2;

    // Start Pin
    canvas.drawCircle(startPin, 6, pinPaint);
    canvas.drawCircle(startPin, 10, pinBorderPaint);

    // End Pin
    canvas.drawCircle(endPin, 6, Paint()..color = const Color(0xFF10B981)); // Green for destination
    canvas.drawCircle(endPin, 10, pinBorderPaint);

    // 4. Draw Text Labels (City names & GPS coords)
    _drawText(canvas, startCity, Offset(startPin.dx - 20, startPin.dy + 12), Colors.white, 10, isBold: true);
    _drawText(canvas, startCoords, Offset(startPin.dx - 20, startPin.dy + 24), const Color(0xFF94A3B8), 8);

    _drawText(canvas, endCity, Offset(endPin.dx - 20, endPin.dy - 22), Colors.white, 10, isBold: true);
    _drawText(canvas, endCoords, Offset(endPin.dx - 20, endPin.dy - 10), const Color(0xFF94A3B8), 8);
  }

  void _drawText(Canvas canvas, String text, Offset offset, Color color, double fontSize, {bool isBold = false}) {
    final textSpan = TextSpan(
      text: text,
      style: TextStyle(
        color: color,
        fontSize: fontSize,
        fontWeight: isBold ? FontWeight.bold : FontWeight.normal,
        fontFamily: 'monospace',
      ),
    );
    final textPainter = TextPainter(
      text: textSpan,
      textDirection: TextDirection.ltr,
    );
    textPainter.layout();
    textPainter.paint(canvas, offset);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => true;
}
