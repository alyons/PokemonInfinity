using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    partial class MainWindow
    {
        #region Variables
        private String movesFileName = "\\moves.txt";
        ObservableList<Move> moves;
        #endregion

        #region Properties
        String MovesFilePath { get { return folderPath + movesFileName; } }
        #endregion

        #region Methods
        private void LoadMoves()
        {
            string[] moveData = File.ReadAllLines(MovesFilePath);
            foreach (String datum in moveData)
            {
                moves.Add(new Move(datum));
            }
        }
        #endregion
    }
}
