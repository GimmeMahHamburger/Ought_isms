shader_type canvas_item;
uniform vec2 offset;
uniform vec2 size;
uniform vec2 currentPos;
void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	vec4 color = texture(TEXTURE,UV);
	float correctPosX=FRAGCOORD.x+offset.x-currentPos.x-0.5/SCREEN_PIXEL_SIZE.x+size.x*75.0/2.0; //wtf are these magic numbers
	float correctPosY=FRAGCOORD.y+offset.y-currentPos.y-0.5/SCREEN_PIXEL_SIZE.y+size.y*75.0/2.0;
	if(correctPosX<size.x*75.0f && correctPosX>0.0 //Idk why these numbers work. they work and thats all I care about rn
	&&
	correctPosY<size.y*75.0f && correctPosY>0.0){
		color=mix(color, vec4(1,0,1,1),0.5);
	}
	
	COLOR = color; //mix(color,vec4(0,1,1,1),cos(FRAGCOORD.x+offset.x));
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
