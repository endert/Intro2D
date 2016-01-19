//texture die gezeichnet werden soll:
uniform sampler2D texture;

//texture mit der punktweise multipliziert werden soll:
uniform sampler2D overlay;

void main(void)
{
	//pixel position dieses pixels in der textur:
	vec2 texCoord = gl_TexCoord[0].xy;

	//jeweils die farben der pixel aus der textur miteinander multiplizieren:
	//da hier die Farbkan�le auf [0,1] gemappt sind, "verschwinden" Farben bei multiplikation mit schwarz
	//und wei�e bleiben erhalten. Alle anderen Farben werden mit der Farbe "�berlagert" bzw eingef�rbt.
	gl_FragColor = texture2D(texture, texCoord) * texture2D(overlay, texCoord);
}