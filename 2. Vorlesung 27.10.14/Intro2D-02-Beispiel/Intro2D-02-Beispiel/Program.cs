using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Game
    {
        // EINBINDEN VON SFML.NET
        //  - Projektmappen-Explorer öffnen
        //  - Rechtklick -> Verweis hinzufügen
        //  - In der Linkenspalte "Durchsuchen"
        //  - Ganz unten erneut auf "Durchsuchen"
        //  - SFML.NET Ordner öffnen -> Libs
        //  - Alle Auswählen und hinzufügen
        //  - Schauen ob alle markiert sind und OK
        //
        //  - Rechtsklick -> Hinzufügen -> Vorhandenes Element
        //  - SFML.NET Ordner öffnen -> extlibs
        //  - ggf. "Alle Dateitypen (.*)" auswählen
        //  - Alle Auswählen und hinzufügen
        //  - Im Projektmappen-Explorer die 5 .dll auswählen
        //  - Rechtsklick -> Eigenschaften
        //  - Ins Ausgabeverzeichniskopieren -> "Immer kopieren" oder "Kopieren wenn neuer"

        // KONSOLE AUSSCHALTEN
        //  - Projektmappen-Explorer öffnen
        //  - Rechtsklick auf das Projekt (Intro2D-02-Beispiel) -> Eigenschaften
        //  - In den Reiter "Anwendung" (automatisch offen) wechseln
        //  - Ausgabetyp -> "Windows-Anwendung"

        // WICHTIG !!!!!!
        //  - WENN IHR DIESES PROJEKT WEITERVERWENDEN WOLLT, MÜSST IHR DIE VERWEISE (erster Teil) NEU HINZUFÜGEN

        // Wird für Programm ablauf benötigt
        static void Main()
        {
            //initialisiert ein RenderWindow
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Test Window");

            //fügt die Close Methode dem Closed Event von dem RenderWindow hinzu
            win.Closed += Close;
            //fancy alternativen:
            //win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };
            //win.Closed += delegate { win.Close(); };

            //solange das Window offen ist
            while (win.IsOpen())
            //in SFML2.2 while(win.IsOpen)
            {
                //hellblau oder so
                win.Clear(new Color(40, 150, 200));

                //trigger alle events
                win.DispatchEvents();

                //zeige alles gezeichnete an
                win.Display();
            }

        }

        /// <summary>
        /// Versucht den sender in ein RenderWindow zu casten und es dann zu schließen
        /// </summary>
        /// <param name="sender">das Object das das Event auslöst</param>
        /// <param name="e">die parameter die mit dem Event übergeben werden</param>
        static void Close(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
