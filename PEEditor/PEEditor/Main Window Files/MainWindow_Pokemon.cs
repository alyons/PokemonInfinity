using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PEEditor
{
    partial class MainWindow
    {
        #region Variables
        private string pokemonFileName = "\\pokemon.txt";
        #endregion

        #region Properties
        String PokemonFilePath { get { return folderPath + pokemonFileName; } }
        //ObservableList<Pokemon>
        #endregion

        #region Methods
        private void InitializePokemon()
        {
            
        }

        private void LoadPokemon()
        {
            List<String> data = new List<String>();
            data.AddRange(File.ReadAllLines(PokemonFilePath));
            int lastIndex = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if ((data[i].StartsWith("[") && i != 0) || i == data.Count - 1)
                {
                    pokemon.Add(new Pokemon(data.GetRange(lastIndex, i - lastIndex)));
                    lastIndex = i;
                }
            }
        }
        #endregion
    }
}
