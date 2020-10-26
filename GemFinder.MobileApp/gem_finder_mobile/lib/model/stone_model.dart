class StoneModel {
  String name;
  String label;

  StoneModel(String label) {
    this.label = label;
    this.name = label.replaceAll(RegExp('_'), ' ');
  }
}
