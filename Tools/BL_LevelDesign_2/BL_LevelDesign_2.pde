int position;
Map map;

int elSize;
int visibleMap;
int mapViewHeight = 600;

PImage enemy;
PImage shield;
PImage combo;
PImage invincible;
PImage doubleJump;
PImage empty;
PImage money;

char item;


void setup() {
  // Data Init
  //map = new Map(8,500);
  map = new Map("robot_Map.txt");
 
  // View Init
  size(1400, mapViewHeight+200);
  background(0);
  position = 0; 
  elSize = mapViewHeight/map.height();
  visibleMap = ceil(width/(float)elSize);
  
  enemy = loadImage("Cubes/Enemy.png");
  shield = loadImage("Cubes/Shield.png");
  combo = loadImage("Cubes/Combo.png");
  invincible = loadImage("Cubes/Invincible.png");
  doubleJump = loadImage("Cubes/Double.png");
  empty = loadImage("Cubes/Empty.png");
  money = loadImage("Cubes/Money.png");
  
  textAlign(CENTER, CENTER);
  textSize(20);
  
  item = MapChars.mapChars[0];
}

void draw() {
  background(0);
  drawMap();
  image(imageForChar(item), 0, height-100, elSize, elSize);
}

void drawMap(){
  PImage image = null;
  int x=0,y=0;
  stroke(0);
  strokeWeight(0.5);
  for(int i=0; i<visibleMap;i++){
    for(int j=0; j<map.height(); j++){
      x=elSize*i;
      y=elSize*(map.height()-1)-elSize*j;
      image = imageForChar(map.element(j,position+i));
      rect(x,y,elSize,elSize);
      image(image,x,y,elSize,elSize);
      noFill();
      rect(x,y,elSize,elSize);
    }
    fill(200);
    text(position+i, x+elSize/2, elSize*(map.height())+elSize/2);
  }
  
}


PImage imageForChar(char car){
  PImage image = null;
        switch(car){
         case 'E':{ //Enemy
           image = enemy;
           fill(150);
         }break;
         case '_':{
           image = empty;
           fill(255);
         }break;
         case 'I':{// invincible
           image = invincible;
           fill(255,255,0);
         }break;
         case 'C':{ // combo
           image = combo;
           fill(55,55,255);
         }break;
         case 'D':{ // double
           image = doubleJump;
           fill(255,0,255);
         }break;
         case 'S':{ // shield
           image = shield;
           fill(22,255,172);
         }break;
         case 'M':{ // money
           image = money;
           fill(22,255,172);
         }break;
      }
  return image;
}

void keyReleased(){
  if(key==CODED){
    switch(keyCode){
      case RIGHT:{
        if(position > 0)
        position--;
      }break;
      case LEFT:{
        if(position < map.length()-visibleMap)
          position++;
      }break;
    }
  }else{
    if(key == RETURN || key == ENTER){
      map.saveMap();
    }else{
      int index = key-49;
      if( index >= 0 && index < MapChars.mapChars.length){
          item = MapChars.mapChars[index];
      }
    }
  }
}

void mouseReleased(){
  if(mouseY <= mapViewHeight){
    int x = mouseX/elSize+position;
    int y = map.height()-1-mouseY/elSize;
//    map.changeElement(y,x);
    map.changeElement(y,x,item);
  }
}
