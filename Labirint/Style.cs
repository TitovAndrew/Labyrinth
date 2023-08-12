using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
     /*
      * Класс темы лабиринта
      */
    [Serializable]
    public class Style
    {
        public string pokemonImg = @"..\..\Resources\summer.png";
        public string pathImg = "";
        public Color wallColor = Color.Yellow; 

        public Style(string style)
        {
            switch (style)
            {
                case "Лето":
                    pokemonImg = @"..\..\Resources\summer.png";
                    wallColor = Color.LimeGreen;
                    pathImg = @"..\..\Resources\summer_path.png";
                    break;
                case "Осень":
                    pokemonImg = @"..\..\Resources\autumn.png";
                    wallColor = Color.DarkOrange;
                    pathImg = @"..\..\Resources\autumn_path.png";
                    break;
                case "Зима":
                    pokemonImg = @"..\..\Resources\winter.png";
                    wallColor = Color.LightBlue;
                    pathImg = @"..\..\Resources\winter_path.png";
                    break;
                case "Весна":
                    pokemonImg = @"..\..\Resources\spring.png";
                    wallColor = Color.Yellow;
                    pathImg = @"..\..\Resources\spring_path.png";
                    break;

            }
        }
    }
}
