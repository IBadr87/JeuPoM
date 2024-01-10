using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Info
{
    public class Personne
    {
        #region Attributs
        public string nom, prenom, adresse;
        public int age;
        #endregion


        #region Constructeurs
        public Personne() { }

        public Personne(string Nom, string Prenom)
        {
            nom = Nom;
            prenom = Prenom;
        }

        public Personne(string Nom, string Prenom, string Adresse, int Age)
        {
            nom = Nom;
            prenom = Prenom;
            adresse = Adresse;
            age = Age;
        }
        #endregion


        #region Méthodes
        public string getInfo()
        {
            if (age != 0 && !adresse.Equals(""))
            {
                return nom + " " + prenom + ", " + age + ", ans " + ", habite " + adresse;
            }
            else
            {
                return nom + " " + prenom + ", aucune autre information disponible";
            }
        }
    }
    #endregion
}
