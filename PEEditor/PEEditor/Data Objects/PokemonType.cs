using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public class PokemonType : ViewModelBase
    {
        #region Variables
        private int id;
        private String name;
        private String internalName;
        private bool isPseudoType;
        private bool isSpecialType;
        private String[] weaknesses;
        private String[] resistances;
        private String[] immunities;
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
        public String Name
        {
            get { return name; }
            set
            {
                if (name == null || name.Equals(value))
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public String InternalName
        {
            get { return internalName; }
            set
            {
                if (internalName == null || internalName.Equals(value))
                {
                    internalName = value;
                    OnPropertyChanged("InternalName");
                }
            }
        }
        public bool IsPseudoType
        {
            get { return isPseudoType; }
            set
            {
                if (isPseudoType != value)
                {
                    isPseudoType = value;
                    OnPropertyChanged("IsPsuedoValue");
                }
            }
        }
        public bool IsSpecialType
        {
            get { return isSpecialType; }
            set
            {
                if (isSpecialType != value)
                {
                    isSpecialType = value;
                    OnPropertyChanged("IsSpecialType");
                }
            }
        }
        public String[] Weaknesses
        {
            get { return weaknesses; }
            set
            {
                if (weaknesses == null || weaknesses.Equals(value))
                {
                    weaknesses = value;
                    OnPropertyChanged("Weaknesses");
                }
            }
        }
        public String[] Resistances
        {
            get { return resistances; }
            set
            {
                if (resistances == null || resistances.Equals(value))
                {
                    resistances = value;
                    OnPropertyChanged("Resistances");
                }
            }
        }
        public String[] Immunities
        {
            get { return immunities; }
            set
            {
                if (immunities == null || immunities.Equals(value))
                {
                    immunities = value;
                    OnPropertyChanged("Immunities");
                }
            }
        }
        #endregion

        #region Methods
        #endregion

    }
}
