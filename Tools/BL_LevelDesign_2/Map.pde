class Map{
 
  private char [][] matrix;
  private int mapHeight, mapLength;
  private String direction;
  
  private String fileName = "nyancat_Map.txt";
  
  Map(int mapHeight, int mapLength){
    this.mapLength = mapLength;
    this.mapHeight = mapHeight;
    matrix = new char[mapHeight] [mapLength];
    
    direction = "LEFT";
    
    for(int i=0 ; i<mapHeight; i++){
      for(int j=0; j<mapLength; j++){
        matrix[i][j] = MapChars.InitChar();
      }
    }
    
  }
  
  Map(String mapToLoad){
    String tmp;
    String[] data = loadStrings(mapToLoad);
    String [] params = data[0].split(" ");
    mapHeight = Integer.parseInt(params[0]);
    mapLength = Integer.parseInt(params[1]);
    direction = params[2];
    
    if(mapLength != data.length-1){
      println("ERROR_PARSING(length)");
    }
    
    matrix = new char [mapHeight][mapLength];
    
    for(int i=0;i<mapLength; i++){
      tmp = data[1+i];
      if(tmp.length() != mapHeight){
        println("ERROR_PARSING(line "+i+")");
        break;
      }
      for(int j=0; j<mapHeight; j++){
        matrix[j][i] = tmp.charAt(j);
      }
    }
  }
  
  public void changeElement(int x, int y){
    matrix[x][y] = MapChars.nextChar(matrix[x][y]);
  }
  
  public void changeElement(int x, int y, char newElement){
    matrix[x][y] = newElement;
  }
  
  public char element(int x, int y){
    return matrix[x][y];
  }
  
  public void setFileName(String newFileName){
   fileName = newFileName; 
  }
  
  public int height(){
    return mapHeight;
  }
  
  public int length(){
    return mapLength;
  }
  
  void saveMap(){
    int i=0;
    String [] content = new String[mapLength+1];
    
    for(int k=0; k<content.length; k++){
      content[k]="";
    }
    
    content[i]+=mapHeight+" "+mapLength+" "+direction;
    
    for(i=1;i<=mapLength;i++){
      for(int j=0; j<mapHeight; j++){
        content[i]+=matrix[j][i-1];
      }
    }
    
    saveStrings(fileName, content);
    println(content);
  }
  
}
