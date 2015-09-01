using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEEditor
{
    public class Move : ViewModelBase
    {
        #region Variables
        private int id;
        private String internalName;
        private String dispalyName;
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
        }
        #endregion

        #region Methods
        #endregion
    }
}
