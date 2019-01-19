static class MapChars {

  public static char [] mapChars = {'_','E','I','C','D', 'S', 'M'}; //{'_', 'E', 'I'};

  static char InitChar(){
    return mapChars[0];
  }

  static char nextChar(char c) {

    for (int i=0; i<mapChars.length-1; i++) {
      if (c == mapChars[i]) {
        return mapChars[i+1];
      }
    }   
    return mapChars[0];
  }
};

