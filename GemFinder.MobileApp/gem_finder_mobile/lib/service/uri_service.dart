class UriService {
  String _baseUrl = 'https://6421e67217b2.ngrok.io';
  String getBaseUrl() => _baseUrl;
  String getAcrionUri(String action) => '$_baseUrl/$action';
}