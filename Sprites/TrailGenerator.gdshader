shader_type canvas_item;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	// Called for every pixel the material is visible on.
	float width=1.0/SCREEN_PIXEL_SIZE.x;
	float height=1.0/SCREEN_PIXEL_SIZE.y;
	float dist1 = (width-FRAGCOORD.x)/(width);
	float dist2 = (height-FRAGCOORD.y)/(height);
	float dist3 = distance(vec2(FRAGCOORD.x,FRAGCOORD.y),vec2(width/2.0,height/2.0));
	float scaledDist=0.2*height/(dist3)-0.2;
	COLOR=vec4(dist1,dist2,1,1.3-1.0/scaledDist);
}

//void light() {
//	// Called for every pixel for every light affecting the CanvasItem.
//	// Uncomment to replace the default light processing function with this one.
//}
