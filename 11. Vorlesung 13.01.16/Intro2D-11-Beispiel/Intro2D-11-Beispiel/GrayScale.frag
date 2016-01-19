uniform sampler2D texture;

uniform float time;

void main(void)
{
	vec2 texCoord = gl_TexCoord[0].xy;
	
	vec4 color = texture2D(texture, texCoord).rgba;

	float t = sin(time) * 0.5 + 0.5;
	float g = cos(time) * 0.5 + 0.5;
	float h = (-sin(time)) * 0.5 + 0.5;

	float help = (color.r + color.g + color.b) * 0.333;
	
	vec4 grau = vec4(help, help, help, color.a); 

	vec4 lol = vec4(color.r * t, color.g * g, color.b* h, 1);

	gl_FragColor = lol; //(1-t)*color + t*grau;
}