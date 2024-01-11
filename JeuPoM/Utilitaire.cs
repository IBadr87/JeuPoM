using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info;

namespace JeuPoM
{
    internal class Utilitaire
    {
        // TODO : Exercise 1.1 (Modularisation de l’affichage d’historique)


        public static void afficheHistorique(int compteur, Partie[] tab)
        {
            Console.WriteLine("Historique des parties : ");

            for (int i = 0; i < compteur; i++)
            {
                Console.WriteLine("Partie N°{0}, " + tab[i].info(), i + 1);
            }
        }

        // TODO Mo.5 (Génération d’un fichier d’historique)
        public static void afficheHistorique(int compteur, Partie[] tab, string nomFichier)
        {
            try
            {
                FileStream fs = new FileStream(nomFichier, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("Historique des parties : ");

                for (int i = 0; i < compteur; i++)
                {
                    sw.WriteLine("Partie N°{0}, " + tab[i].info(), i + 1);
                }

                sw.Close();
                fs.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
        }
    }
}
