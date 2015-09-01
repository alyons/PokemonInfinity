using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PEEditor
{
    public enum GenderRatio
    {
        Genderless = 0,
        AlwaysMale,
        FemaleOneEigth,
        Female25Percent,
        Female50Percent,
        Female75Percent,
        FemaleSevenEigths,
        AlwaysFemale
    }
    public enum GrowthRate
    {
        Fast = 0,
        Medium = 1,
        Slow = 2,
        Parabolic = 3,
        Erratic = 4,
        Fluctuating = 5,
        MediumFast = 1,
        MediumSlow = 3
    }
    [Flags]
    public enum EggGroups : uint
    {
        Undiscovered = 0x00,
        Amorphous = 0x01,
        Bug = Amorphous << 1,
        Dragon = Bug << 1,
        Fairy = Dragon << 1,
        Field = Fairy << 1,
        Flying = Field << 1,
        Grass = Flying << 1,
        Humanlike = Grass << 1,
        Mineral = Humanlike << 1,
        Monster = Mineral << 1,
        Water1 = Monster << 1,
        Water2 = Water1 << 1,
        Water3 = Water2 << 1,
        Ditto = unchecked((uint)~0)
    }
    public enum PokemonColor
    {
        Black,
        Blue,
        Brown,
        Gray,
        Green,
        Pink,
        Purple,
        Red,
        White,
        Yellow
    }
    public enum Habitat
    {
        Cave,
        Forest,
        Grassland,
        Mountain,
        Rare,
        RoughTerrain,
        Sea,
        Urban,
        WatersEdge
    }

    public class PokemonNumberConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Pokemon)) throw new NotSupportedException();
            Pokemon p = value as Pokemon;
            return String.Format("[{0}]: {1}", p.NationalDex, p.Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Pokemon : ViewModelBase
    {
        #region Variables
        private int nationalDex;
        private String name;
        private PokemonType type1;
        private PokemonType type2;
        private int[] baseStats;
        private GenderRatio genderRatio;
        private GrowthRate growthRate;
        private int baseExp;
        private int[] effortPoints;
        private int catchRate;
        private int happiness;
        private List<Tuple<int, Move>> levelMoves;
        private EggGroups eggGroups;
        private int stepsToHatch;
        private double height;
        private double weight;
        private PokemonColor color;
        private String kind;
        private String pokedexEntry;
        private Ability[] standardAbilities;
        private Ability[] hiddenAbilities;
        private List<Move> eggMoves;
        private Dictionary<int, int> regionalNumbers;
        private String[] wildItems;
        private int battlerPlayerY;
        private int battlerEnemyY;
        private int battlerAltitue;
        private List<Tuple<string, string, object>> evolutions;
        private List<String> formNames;
        #endregion

        #region Properties
        public int NationalDex
        {
            get { return nationalDex; }
            set
            {
                if (nationalDex != value)
                {
                    nationalDex = value;
                    OnPropertyChanged("NationalDex");
                }
            }
        }
        public String Name
        {
            get { return name; }
            set
            {
                if (name == null || !name.Equals(value))
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        #endregion

        #region Constructors
        public Pokemon() { }
        public Pokemon(IEnumerable<String> data)
        {
            foreach (String datum in data)
            {
                if (datum.StartsWith("["))
                {
                    nationalDex = Convert.ToInt32(datum.Replace("[", "").Replace("]", ""));
                }
                else if (datum.StartsWith("Name="))
                {
                    name = datum.Replace("Name=", "");
                }
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
