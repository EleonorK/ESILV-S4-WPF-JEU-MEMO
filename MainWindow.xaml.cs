using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jeuMemo2WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarteGraphique cartePrecedent;
        public MainWindow()
        {
            InitializeComponent();
            cartePrecedent = null;
            string[] contenuP = { "A", "A", "B", "B", "C", "C", "D", "D", "E", "E" };
            //creation de la grille
            int nbLignes = 2;
            int nbColonnes = 5;
            //creation des lignes de notre grille
            for(int i = 0; i < nbLignes; i++)
            {
                RowDefinition ligne = new RowDefinition();
                //associer la cligne a la grille
                grille.RowDefinitions.Add(ligne);
            }
            //creation des colonnes de notre grille
            for (int i = 0; i < nbColonnes; i++)
            {
                ColumnDefinition colonne = new ColumnDefinition();
                //associer la cligne a la grille
                grille.ColumnDefinitions.Add(colonne);
            }
            int x = 0;
            //jusqu'ici on a unr grille de 10 cases
            for(int i = 0; i < nbLignes; i++)
            {
                for(int c = 0; c < nbColonnes; c++)
                {
                    CarteGraphique cg = new CarteGraphique( contenuP[x], this);
                    x++;
                    //integrer le bouton au niveau de la grille 
                    Grid.SetRow(cg, i);//positinnement de la carte graphique sur la bonne ligne
                    Grid.SetColumn(cg, c);//positionnement de la carte sur la colonne
                    grille.Children.Add(cg);//ajouter le bouton(carte) sur la grille
                }
            }
        }
        public void MiseAJour(CarteGraphique carteRetournee)
        {
            if (cartePrecedent == null)
            {
                //on vient de retourner la première carte d'une paire
                cartePrecedent = carteRetournee;
            }
            else
            {
                if(carteRetournee == cartePrecedent)
                {
                    cartePrecedent = null;
                }
                else
                {
                    //si bonne paire ==> desactiver les 2 cartes 
                    if(cartePrecedent.ValeurCarte == carteRetournee.ValeurCarte)
                    {
                        cartePrecedent.IsEnabled = false;
                        carteRetournee.IsEnabled = false;
                    }
                    else
                    {
                        //mauvaise paire ==> on retourne les deux cartes
                        MessageBox.Show("Mauvaise carte");
                        cartePrecedent.TournerCarte();
                        carteRetournee.TournerCarte();
                    }
                    cartePrecedent = null;
                }
            }
        }
    }
}
