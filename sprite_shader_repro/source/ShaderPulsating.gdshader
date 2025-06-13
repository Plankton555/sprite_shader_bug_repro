shader_type canvas_item;

uniform float pulse_speed = 3.f;

void fragment() {
	// Called for every pixel the material is visible on.
	//float pulse_speed = 3.f;
	float t = 0.5f + 0.5f * sin(TIME * pulse_speed); // between [0.0, 1.0]
	float addend = t * 0.2f - 0.1f; // between [-0.1, 0.1]
	COLOR.r = clamp(COLOR.r + addend, 0.f, 1.f);
	COLOR.g = clamp(COLOR.g + addend, 0.f, 1.f);
	COLOR.b = clamp(COLOR.b + addend, 0.f, 1.f);
}
