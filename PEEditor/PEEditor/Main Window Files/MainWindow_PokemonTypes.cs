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
        private String pokemonTypesFileName = "\\types.txt";
        #endregion

        #region Properties
        String PokemonTypesFilePath { get { return folderPath + pokemonTypesFileName; } }
        ObservableList<PokemonType> PokemonTypes { get { return (PokemonTypeListBox.ItemsSource as ObservableList<PokemonType>); } }
        ObservableList<PokemonType> Weaknesses { get { return (PTypeWeaknessListBox.ItemsSource as ObservableList<PokemonType>); } }
        ObservableList<PokemonType> Resistances { get { return (PTypeResistanceListBox.ItemsSource as ObservableList<PokemonType>); } }
        ObservableList<PokemonType> Immunities { get { return (PTypeImmunityListBox.ItemsSource as ObservableList<PokemonType>); } }
        #endregion

        #region Methods
        private void LoadPokemonTypes()
        {
            try
            {
                string[] data = File.ReadAllLines(PokemonTypesFilePath);
                PokemonType temp = new PokemonType();
                foreach (string datum in data)
                {
                    if (datum.StartsWith("["))
                    {
                        temp = new PokemonType();
                        temp.ID = Convert.ToInt32(datum.Replace("[", "").Replace("]", ""));
                    }
                    else if (datum.StartsWith("Name="))
                    {
                        temp.Name = datum.Replace("Name=", "");
                    }
                    else if (datum.StartsWith("InternalName="))
                    {
                        temp.InternalName = datum.Replace("InternalName=", "");
                    }
                    else if (datum.StartsWith("IsPseudoType="))
                    {
                        temp.IsPseudoType = Convert.ToBoolean(datum.Replace("IsPseudoType=", ""));
                    }
                    else if (datum.StartsWith("IsSpecialType="))
                    {
                        temp.IsSpecialType = Convert.ToBoolean(datum.Replace("IsSpecialType=", ""));
                    }
                    else if (datum.StartsWith("Weaknesses="))
                    {
                        temp.Weaknesses = datum.Replace("Weaknesses=", "").Split(',');
                    }
                    else if (datum.StartsWith("Resistances="))
                    {
                        temp.Resistances = datum.Replace("Resistances=", "").Split(',');
                    }
                    else if (datum.StartsWith("Immunities="))
                    {
                        temp.Immunities = datum.Replace("Immunities=", "").Split(',');
                    }
                    else
                    {
                        if (temp != null)
                            pokemonTypes.Add(temp);
                    }
                }
                pokemonTypes.Add(temp);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load Pokémon Types: " + ex.Message);
            }
        }

        private void PokemonTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PokemonType temp = (PokemonType)PokemonTypeListBox.SelectedItem;
            PTypeNameTextBox.Text = temp.Name;
            PTypeInternalNameTextBox.Text = temp.InternalName;
            PTypePseudoCheckBox.IsChecked = temp.IsPseudoType;
            PTypeSpecialCheckBox.IsChecked = temp.IsSpecialType;

            PTypeWeaknessListBox.UnselectAll();
            if (temp.Weaknesses != null)
                foreach (String type in temp.Weaknesses)
                    PTypeWeaknessListBox.SelectedItems.Add(Weaknesses.Find(p => p.InternalName.Equals(type)));

            PTypeResistanceListBox.UnselectAll();
            if (temp.Resistances != null)
            foreach (String type in temp.Resistances)
                PTypeResistanceListBox.SelectedItems.Add(Resistances.Find(p => p.InternalName.Equals(type)));

            PTypeImmunityListBox.UnselectAll();
            if (temp.Immunities != null)
                foreach (String type in temp.Immunities)
                    PTypeImmunityListBox.SelectedItems.Add(Immunities.Find(p => p.InternalName.Equals(type)));
        }
        private void WeaknessTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ResistanceTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ImmunityTypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion
    }
}
