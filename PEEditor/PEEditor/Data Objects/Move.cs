using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public enum MoveFunction : int
    {
        Normal,
        NothingHappens,
        Struggle,
        Sleep,
        Drowsy,
        Posion,
        Toxic,
        Paralyze,
        ParalyzeDuringFly,
        ParalyzeAndFlinch,
        Burn,
        BurnAndFlinch,
        Freeze,
        FreezeAndBlizzard,
        FreezeAndFlinch,
        Flinch,
        FlinchAndDouble,
        Snore,
        FakeOut,
        Confuse,
        Chatter,
        Hurricane,
        Attract,
        TriAttack,
        Refresh,
        HealStatus,
        Safegaurd,
        PsychoShift,
        UserAtkUpOne,
        UserDefUpOne,
        UserDefUpOneBall,
        UserSpdUpOne,
        UserSpAUpOne
    }
    public enum MoveCategory
    {
        Physical,
        Special,
        Status
    }
    public enum Target : int
    {
        SingleTarget = 0,
        NoTarget = 1,
        RandomOpponent = 2,
        AllOpponents = 4,
        AllBattlersExceptUser = 8,
        User = 10,
        BothSides = 20,
        UserSide = 40,
        OpoonentsSide = 80,
        UserPartner = 100,
        ChoosePartner = 200,
        SingleOpponent = 400,
        DirectOpponent = 800
    }
    public enum MoveProperties : uint
    {
        None = 0x000,
        PhysicalContact = 0x01,
        Protect = PhysicalContact << 1,
        MagicCoat = Protect << 1,
        Snatch = MagicCoat << 1,
        MirrorMove = Snatch << 1,
        KingsRock = MirrorMove << 1,
        ThawUser = KingsRock << 1,
        HighCritRate = ThawUser << 1,
        HealingMove = HighCritRate << 1,
        PunchMove = HealingMove << 1,
        SoundMove = PunchMove << 1,
        Gravity = SoundMove << 1,
        NoSkyBattle = Gravity << 1,
        SlashingMove = NoSkyBattle << 1
    }

    public class Move : ViewModelBase
    {
        #region Variables
        private int id;
        private String internalName;
        private String dispalyName;
        private int functionCode; // Change to Enum once all 306 have been entered
        private int baseDamage;
        private String type;
        private MoveCategory moveCategory;
        private int accuracy;
        private int totalPP;
        private int additionalEffectChance;
        private Target target;
        private int priority;
        private MoveProperties moveProperties;
        private String description;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public String InternalName
        {
            get { return internalName; }
            set
            {
                if (internalName == null || !internalName.Equals(value))
                {
                    internalName = value;
                    OnPropertyChanged("InternalName");
                }
            }
        }
        public String DispalyName
        {
            get { return dispalyName; }
            set
            {
                if (dispalyName == null || !dispalyName.Equals(value))
                {
                    dispalyName = value;
                    OnPropertyChanged("DispalyName");
                }
            }
        }
        #endregion

        #region Constructors
        public Move() { }
        public Move(String dataString)
        {
            string[] data = dataString.Split(',');
            id = Convert.ToInt32(data[0]);
            internalName = data[1];
            dispalyName = data[2];
            functionCode = Int32.Parse(data[3]);
            baseDamage = Convert.ToInt32(data[4]);
            type = data[5];
            moveCategory = (MoveCategory)Enum.Parse(typeof(MoveCategory), data[6]);
            accuracy = Convert.ToInt32(data[7]);
            totalPP = Convert.ToInt32(data[8]);
            additionalEffectChance = Convert.ToInt32(data[9]);
            target = (Target)Enum.Parse(typeof(Target), data[10]);
            priority = Convert.ToInt32(data[11]);
            moveProperties = MovePropertiesFromString(data[12]);
            description = data[13];
        }
        #endregion

        #region Methods
        private MoveProperties MovePropertiesFromString(String value)
        {
            MoveProperties props = MoveProperties.None;

            if (value.Contains("a"))
                props |= MoveProperties.PhysicalContact;
            if (value.Contains("b"))
                props |= MoveProperties.Protect;
            if (value.Contains("c"))
                props |= MoveProperties.MagicCoat;
            if (value.Contains("d"))
                props |= MoveProperties.Snatch;
            if (value.Contains("e"))
                props |= MoveProperties.MirrorMove;
            if (value.Contains("f"))
                props |= MoveProperties.KingsRock;
            if (value.Contains("g"))
                props |= MoveProperties.ThawUser;
            if (value.Contains("h"))
                props |= MoveProperties.HighCritRate;
            if (value.Contains("i"))
                props |= MoveProperties.HealingMove;
            if (value.Contains("j"))
                props |= MoveProperties.PunchMove;
            if (value.Contains("k"))
                props |= MoveProperties.SoundMove;
            if (value.Contains("l"))
                props |= MoveProperties.Gravity;
            if (value.Contains("m"))
                props |= MoveProperties.NoSkyBattle;
            if (value.Contains("n"))
                props |= MoveProperties.SlashingMove;

            return props;
        }
        private String MovePropertiesToDataString(MoveProperties props)
        {
            String value = "";

            if ((props & MoveProperties.PhysicalContact)==MoveProperties.PhysicalContact)
                value += "a";
            if ((props & MoveProperties.Protect) == MoveProperties.Protect)
                value += "b";
            if ((props & MoveProperties.MagicCoat) == MoveProperties.MagicCoat)
                value += "c";
            if ((props & MoveProperties.Snatch) == MoveProperties.Snatch)
                value += "d";
            if ((props & MoveProperties.MirrorMove) == MoveProperties.MirrorMove)
                value += "e";
            if ((props & MoveProperties.KingsRock) == MoveProperties.KingsRock)
                value += "f";
            if ((props & MoveProperties.ThawUser) == MoveProperties.ThawUser)
                value += "g";
            if ((props & MoveProperties.HighCritRate) == MoveProperties.HighCritRate)
                value += "h";
            if ((props & MoveProperties.HealingMove) == MoveProperties.HealingMove)
                value += "i";
            if ((props & MoveProperties.PunchMove) == MoveProperties.PunchMove)
                value += "j";
            if ((props & MoveProperties.SoundMove) == MoveProperties.SoundMove)
                value += "k";
            if ((props & MoveProperties.Gravity) == MoveProperties.Gravity)
                value += "l";
            if ((props & MoveProperties.NoSkyBattle) == MoveProperties.NoSkyBattle)
                value += "m";
            if ((props & MoveProperties.SlashingMove) == MoveProperties.SlashingMove)
                value += "n";

            return value;
        }
        #endregion
    }
}
