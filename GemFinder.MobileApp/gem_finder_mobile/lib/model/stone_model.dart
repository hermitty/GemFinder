class StoneModel {
  String name;
  String label;
  List<String> imageUrls;

  StoneModel(this.label) {
    this.name = label.replaceAll(RegExp('_'), ' ');
    imageUrls = new List<String>();
  }
  void addImageUrl(String url) => imageUrls.add(url);
  void addImageUrls(List<String> urls) => imageUrls.addAll(urls);

  StoneModel.formJson(Map<String, dynamic> json) {
    label = json['label'];
    this.name = label.replaceAll(RegExp('_'), ' ');
    imageUrls = (json['url']as List<dynamic>).cast<String>().toList();
  }
}
