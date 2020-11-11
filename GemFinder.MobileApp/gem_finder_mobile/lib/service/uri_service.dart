class UriService {
  String _baseUrl = 'https://localhost:44370';
  String getBaseUrl() => _baseUrl;
  String getAcrionUri(String action) => '{_baseUrl}/{action}';
}