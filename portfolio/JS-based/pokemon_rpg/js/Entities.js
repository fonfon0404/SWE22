
var player;
var enemyList = {};

Entity = function(type,id,x,y,spdX,spdY,width,height,img){
	var self = {
		type:type,
		id:id,
		x:x,
		y:y,
		spdX:spdX,
		spdY:spdY,
		width:width,
		height:height,
		img:img,
	};
	var originX = self.x;
	var originY = self.y;
	
	self.update = function(){
		self.draw();
		self.updatePosition();
	}

	self.getDistance = function(entity2){	//return distance (number)
		var vx = self.x - entity2.x;
		var vy = self.y - entity2.y;
		return Math.sqrt(vx*vx+vy*vy);
	}

	self.testCollision = function(entity2){	//return if colliding (true/false)
		var rect1 = {
			x:self.x-self.width/2,
			y:self.y-self.height/2,
			width:self.width,
			height:self.height,
		}
		var rect2 = {
			x:entity2.x-entity2.width/2,
			y:entity2.y-entity2.height/2,
			width:entity2.width,
			height:entity2.height,
		}
		return testCollisionRectRect(rect1,rect2);
		
	}
	self.updatePosition = function(){
		if(self.x > originX + 300 || self.x < originX - 300)
			self.spdX = -self.spdX;

		if(self.y > originY + 300 || self.y < originY - 300)
			self.spdY = -self.spdY;
		
		self.x += self.spdX;
		self.y += self.spdY;
		
		self.spriteAnimCounter += 0.2; 
				
		if(self.x < 0 || self.x > currentMap.width){
			self.spdX = -self.spdX;
		}
		if(self.y < 0 || self.y > currentMap.height){
			self.spdY = -self.spdY;
		}
		
		if(Math.abs(self.spdY) <= Math.abs(self.spdX)){
			if(self.spdX > 0)
				self.directionMod = 2;
			else
				self.directionMod = 1;
		}
		else{
			if(self.spdY > 0)
				self.directionMod = 0;
			else
				self.directionMod = 3;
		}

	}
	
	return self;
}

Player = function(){
	var self = Actor('player','myId',WIDTH/2,HEIGHT/2,0,0,50,50,Img.player1,0);
	self.mouseX;
	self.mouseY;
	
	self.updatePosition = function(){
		/*
		if(self.pressingRight)
			self.x += 10;
		if(self.pressingLeft)
			self.x -= 10;	
		if(self.pressingDown)
			self.y += 10;	
		if(self.pressingUp)
			self.y -= 10;	
		*/
		var diffX = self.mouseX - self.x;
		var diffY = self.mouseY - self.y;
		
		if(diffX > 5){
			self.x += 5;
			self.directionMod = 2; // right
		}	
		else if(diffX < -5){
			self.x -= 5;
			self.directionMod = 1; // left
		}

		if(diffY > 5){
			self.y += 5;
			if(Math.abs(diffX) < 6)
				self.directionMod = 0; // down
		}	
		else if(diffY < -5){
			self.y -= 5;
			if(Math.abs(diffX) < 6)
				self.directionMod = 3; // up
		}
			
		
		self.spriteAnimCounter += 0.2
		
		//ispositionvalid
		if(self.x < self.width/2)
			self.x = self.width/2;
		if(self.x > currentMap.width-self.width/2)
			self.x = currentMap.width - self.width/2;
		if(self.y < self.height/2)
			self.y = self.height/2;
		if(self.y > currentMap.height - self.height/2)
			self.y = currentMap.height - self.height/2;
		
	}
	/*
	self.pressingDown = false;
	self.pressingUp = false;
	self.pressingLeft = false;
	self.pressingRight = false;
	*/
	self.mouseDown = false;
	return self;
	
}

Actor = function(type,id,x,y,spdX,spdY,width,height,img,exp){
	var self = Entity(type,id,x,y,spdX,spdY,width,height,img);
	self.exp = exp;
	self.spriteAnimCounter = 0;
	self.directionMod = 0;
	
	self.draw = function(){
		ctx.save();
		var x = self.x - self.width/2;
		var y = self.y - self.height/2;
		
		var frameWidth = self.img.width/4;
		var frameHeight = self.img.height/4;		
			
		var walkingMod = Math.floor(self.spriteAnimCounter) % 4
		
		ctx.drawImage(self.img,
			walkingMod*frameWidth,frameHeight*self.directionMod,frameWidth,frameHeight,
			x,y,self.width,self.height
		);
		
		ctx.restore();
	}	
	
	return self;
}

Enemy = function(id,x,y,spdX,spdY,width,height,img){
	var self = Actor('enemy',id,x,y,spdX,spdY,width,height,img,0);
	enemyList[id] = self;
}

randomlyGenerateEnemy = function(){
	//Math.random() returns a number between 0 and 1
	var x = Math.random()*currentMap.width;
	var y = Math.random()*currentMap.height;
	var height = 64;
	var width = 64;
	var id = Math.random();
	var spdX = 1 + Math.random() * 3;
	var spdY = 1 + Math.random() * 3;
	var randomNum = Math.random();
	if(randomNum < 0.01)
		Enemy(id,x,y,spdX,spdY,width,height,Img.Mewtwo);
	else if(randomNum < 0.03)
		Enemy(id,x,y,spdX,spdY,100,100,Img.Groudon);
	else if(randomNum < 0.25)
		Enemy(id,x,y,spdX,spdY,50,50,Img.Machop);
	else if(randomNum < 0.50)
		Enemy(id,x,y,spdX,spdY,40,40,Img.Bidoof);
	else if(randomNum < 0.75)
		Enemy(id,x,y,spdX,spdY,40,40,Img.Duck);
	else
		Enemy(id,x,y,spdX,spdY,40,40,Img.Slime);	
}
