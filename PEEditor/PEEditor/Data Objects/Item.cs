using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public enum ItemPocket : uint
    {
        Items = 1,
        Medicine,
        PokeBalls,
        TM_HM,
        Berries,
        Mail,
        Battle,
        Key
    }
    public enum ItemUsability : uint
    {
        None = 0,
        OnPokemon,
        OnSelf,
        TM,
        HM,
        OnPokemonRetain
    }
    public enum ItemBattle : uint
    {
        None = 0,
        OnPartyPokemon,
        InBattle,
        OnPokemonRetain,
        InBattleRetain
    }
    public enum SpecialItem : uint
    {
        None = 0,
        Mail,
        RefelctMail,
        SnagBall,
        PokeBall,
        Berry,
        KeyItem
    }

    public class Item : ViewModelBase
    {
        #region Variables
        private int id;
        private String internalName;
        private String displayName;
        private ItemPocket pocket;
        private int price;
        private String description;
        private ItemUsability itemUse;
        private ItemBattle battleUse;
        private SpecialItem specialItemType;
        private String taughtMove;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
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
        public String DisplayName
        {
            get { return displayName; }
            set
            {
                if (displayName == null || !displayName.Equals(value))
                {
                    displayName = value;
                    OnPropertyChanged("DisplayName");
                }
            }
        }
        public ItemPocket Pocket
        {
            get { return pocket; }
            set
            {
                if (pocket != value)
                    pocket = value;
                OnPropertyChanged("Pocket");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }
        }
        public String Description
        {
            get { return description; }
            set
            {
                if (description == null || !description.Equals(value))
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public ItemUsability ItemUse
        {
            get { return itemUse; }
            set
            {
                if (itemUse != value)
                    itemUse = value;
                OnPropertyChanged("ItemUse");
            }
        }
        public ItemBattle BattleUse
        {
            get { return battleUse; }
            set
            {
                if (battleUse != value)
                    battleUse = value;
                OnPropertyChanged("BattleUse");
            }
        }
        public SpecialItem SpecialItemType
        {
            get { return specialItemType; }
            set
            {
                if (specialItemType != value)
                    specialItemType = value;
                OnPropertyChanged("SpecialItemType");
            }
        }
        public String TaughtMove
        {
            get { return taughtMove; }
            set
            {
                if (taughtMove == null || !taughtMove.Equals(value))
                {
                    taughtMove = value;
                    OnPropertyChanged("TaughtMove");
                }
            }
        }
        #endregion

        #region Constructors
        public Item() { }
        public Item(String text)
        {
            // Split string and assign values
        }
        #endregion

        #region Methods
        public override String ToString()
        {
            return id + ","
                + internalName + ","
                + displayName + ","
                + (int)pocket + ","
                + price + ","
                + description + ","
                + (int)itemUse + ","
                + (int)battleUse + ","
                + (int)specialItemType + ","
                + taughtMove;
        }
        #endregion
    }
}
