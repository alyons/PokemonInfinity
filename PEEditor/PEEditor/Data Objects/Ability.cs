using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public class Ability : ViewModelBase
    {
        private int id;
        private String internalName;
        private String displayName;
        private String description;

        public int ID
        {
            get { return id; }
            set
            {
                if (value != id)
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

        public Ability() { }

        public Ability(string text)
        {
            string[] parts = text.Split(',');
            if (parts.Count() >= 4)
            {
                this.ID = Convert.ToInt32(parts[0]);
                this.InternalName = parts[1];
                this.DisplayName = parts[2];
                string desc = parts[3];
                for (int i = 4; i < parts.Count(); i++)
                {
                    desc += "," + parts[i];
                }
                this.Description = desc;
            }
        }

        public override String ToString()
        {
            return this.ID + "," + this.InternalName + "," + this.DisplayName + "," + this.Description;
        }
    }
}
