using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace jeuMemo2WPF
{
    public class CarteGraphique : Button
    {
        private Carte maCarte;
        private MainWindow jeu;
        public CarteGraphique(string valeurCarte, MainWindow m)
        {
            //à completer
            maCarte = new Carte(valeurCarte);

            //en tant que bouton
            Content = "?";
            Click += ActionOn_Click;

            //avoir connaissance du plateau de jeu
            this.jeu = m;
        }
        public string ValeurCarte
        {
            get { return maCarte.Valeur; }
        }

        //clic bouton
        public void TournerCarte()
        {
            //1. changer l'etat de la carte
            maCarte.Retourner();
            //2. modifier le contenu de la carte
            if (maCarte.Etat) // pareil que (maCarte.Etat == true)
            {
                Content = maCarte.Valeur; // on va faire apparaitre la lettre ou l'image se trouvant dans la carte
            }
            else
            {
                Content = "?";
            }
        }
        private void ActionOn_Click(object sender, RoutedEventArgs e)
        {
            //methode associé à un clic bouton

            //1.la carte graphique est "autotnome" ==> elle peut se retourner
            TournerCarte();

            //2. lien avec le plateau de jeu
            jeu.MiseAJour(this);
        }
    }
}
