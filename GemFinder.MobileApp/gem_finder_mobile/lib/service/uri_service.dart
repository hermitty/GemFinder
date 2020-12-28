class UriService {
  String _baseUrl = 'http://d2954f73dddf.ngrok.io';
  String getBaseUrl() => _baseUrl;
  String getAcrionUri(String action) => '$_baseUrl/$action';
}