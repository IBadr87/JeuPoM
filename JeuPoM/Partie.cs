﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPoM
{
    class Partie
    {
        #region Attributs

        private int valeur { get; set; }
        public int tentatives { get; set; }

        #endregion

        #region Membres statiques

        private static int compteurParties = 0;

        public static int getNbParties()
        {
            return compteurParties;
        }

        #endregion

        #region Constructeurs
        public Partie()
        {
        }

        public Partie(int Valeur, int Tentatives)
        {
            valeur = Valeur;
            tentatives = Tentatives;
            compteurParties++;
        }
        #endregion

        #region Méthodes

        public int getValeur()
        {
            return valeur;
        }
        
        public string info()
        {
            return valeur.ToString() + " trouvé en " + tentatives.ToString() + " coup(s)";
        }

        #endregion
    }
}
