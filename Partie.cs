using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPoM
{
    class Partie
    {
        #region Attributs

        public int valeur { get; set; }
        public int tentatives { get; set; }

        #endregion

        #region Constructeurs
        public Partie()
        {}

        public Partie(int ValeurInti, int Tentatives)
        {
            valeur = ValeurInti;
            tentatives = Tentatives;
        }
        #endregion

        #region Méthodes

        public string info()
        {
            return valeur.ToString() + " trouvé en " + tentatives.ToString() + " coup(s)";
        }

        #endregion
    }
}
