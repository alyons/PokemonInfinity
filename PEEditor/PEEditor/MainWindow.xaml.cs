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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        private String folderPath;
        bool[] successfullyLoaded = new bool[15];
        ObservableList<Ability> abilities = new ObservableList<Ability>();
        ObservableList<PokemonType> pokemonTypes = new ObservableList<PokemonType>();
        ObservableList<Pokemon> pokemon = new ObservableList<Pokemon>();

        #region File Names
        private String abilityFileName = "\\abilities.txt";
        private String itemFileName = "\\items.txt";
        #endregion

        #region Tab Index Constants
        const int abilitiesTabIndex = 0;
        const int connectionsTabIndex = 1;
        const int encountersTabIndex = 2;
        const int itemsTabIndex = 3;
        const int metadataTabIndex = 4;
        const int movesTabIndex = 5;
        const int phoneTabIndex = 6;
        const int pokemonTabIndex = 7;
        const int shadowMovesTabIndex = 8;
        const int tmTabIndex = 9;
        const int townMapTabIndex = 10;
        const int trainerListTabIndex = 11;
        const int trainersTabIndex = 12;
        const int trainerTypesTabIndex = 13;
        const int pokemonTypesTabIndex = 14;
        #endregion
        #endregion

        #region Properties
        ObservableList<Ability> Abilities { get { return (AbilityListBox.ItemsSource as ObservableList<Ability>); } }

        //File Paths
        String AbilitiesFilePath { get { return folderPath + abilityFileName; } }
        #endregion

        #region Initialization
        public MainWindow()
        {
            InitializeComponent();

            RecentFileList.MenuClick += (s, e) =>
            {
                folderPath = e.Filepath;
                OpenFiles(folderPath);
            };

            init();
        }

        private void init()
        {
            abilities = new ObservableList<Ability>();
            pokemonTypes = new ObservableList<PokemonType>();
            moves = new ObservableList<Move>();
            pokemon = new ObservableList<Pokemon>();

            AbilityListBox.ItemsSource = abilities;
            PokemonTypeListBox.ItemsSource = pokemonTypes;
            PTypeImmunityListBox.ItemsSource = pokemonTypes;
            PTypeResistanceListBox.ItemsSource = pokemonTypes;
            PTypeWeaknessListBox.ItemsSource = pokemonTypes;
            PokemonComboBox.ItemsSource = pokemon;
        }
        #endregion
        #region Closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        #endregion

        #region Menu Interactions
        private void OpenClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = dialog.SelectedPath;
            }

            // System.Windows.MessageBox.Show("The folder path you selected is:\n" + folderPath);

            OpenFiles(folderPath);
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            switch (MainTabControl.SelectedIndex)
            {
                case abilitiesTabIndex:
                    SaveAbilities();
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("You are saving the tab with an id of " + MainTabControl.SelectedIndex + ".");
                    break;
            }
        }
        private void SaveAllClick(object sender, RoutedEventArgs e)
        {
            SaveAllFiles();
        }
        #endregion
        #region Tab Control Interactions
        private void TabControl_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
        #endregion

        #region Abilities Tab Interactions
        private void AbilityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ability temp = (Ability)AbilityListBox.SelectedItem;
            AbilityIDTextBox.Text = "" + temp.ID;
            AbilityInternalNameTextBox.Text = temp.InternalName;
            AbilityDisplayNameTextBox.Text = temp.DisplayName;
            AbilityDescriptionTextBox.Text = temp.Description;
        }
        private void AddAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            Ability temp = new Ability();
            int i = 1;
            for (i = 1; i < 256; i++)
            {
                if (!Abilities.Exists(a => a.ID == i))
                {
                    temp.ID = i;
                    break;
                }
            }
            if (i == 256)
            {
                System.Windows.MessageBox.Show("You have reached the maximum number of abilities.");
            }
            else
            {
                temp.DisplayName = "New Ability";
                temp.InternalName = "NEWABILITY" + i;
                temp.Description = "\"The effect which the new ability has.\"";
                Abilities.Add(temp);
            }
        }
        private void RemoveAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            if (AbilityListBox.SelectedIndex != -1)
            {
                int toRemove = AbilityListBox.SelectedIndex;
                Abilities.RemoveAt(toRemove);
                AbilityIDTextBox.Text = "";
                AbilityInternalNameTextBox.Text = "";
                AbilityDisplayNameTextBox.Text = "";
                AbilityDescriptionTextBox.Text = "";
            }
        }
        private void SaveAbilityButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate Internal Name
            // Check description for quotation marks
            // Save changes
            Abilities[AbilityListBox.SelectedIndex].InternalName = AbilityInternalNameTextBox.Text;
            Abilities[AbilityListBox.SelectedIndex].DisplayName = AbilityDisplayNameTextBox.Text;
            Abilities[AbilityListBox.SelectedIndex].Description = AbilityDescriptionTextBox.Text;
        }
        #endregion

        #region Helper Methods
        #region Loading Methods
        public void OpenFiles(string folderPath)
        {
            // TO-DO: Check if the folder has the appropriate data (i.e. check for the files)

            RecentFileList.InsertFile(folderPath);

            LoadAbilities();
            LoadPokemonTypes();
            //LoadMoves();
            LoadPokemon();
        }
        public void LoadAbilities()
        {
            try
            {
                string[] abilityLines = File.ReadAllLines(AbilitiesFilePath);
                foreach (string al in abilityLines)
                {
                    Abilities.Add(new Ability(al));
                }
                successfullyLoaded[abilitiesTabIndex] = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Failed to load abilities: " + ex.Message);
            }
        }
        #endregion
        #region Saving Methods
        public void SaveAllFiles()
        {
            SaveAbilities();
        }
        public void SaveAbilities()
        {
            if (successfullyLoaded[abilitiesTabIndex])
            {
                try
                {
                    String abilityContent = "";
                    foreach (Ability ability in Abilities)
                    {
                        abilityContent += ability.ToString() + "\n";
                    }

                    File.WriteAllText(AbilitiesFilePath, abilityContent);
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show("Failed to save abilities: " + ex.Message);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("The abilities were not loaded successfully. Cancelling save...");
            }
        }
        #endregion
        #endregion
    }
}
