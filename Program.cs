using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPoM
{
    class Jeu
    {
        // This code is designed to allow users to guess a random number and track their best score and game history.
        // The game loop ensures that the user can play multiple times if they wish. 

        // TODO : Exercise 1.1 (Modularisation de l’affichage d’historique)
        static void afficheHistorique(int compteur, int[] tabValeur, int[] tabCoup)
        {
            Console.WriteLine("Historique des parties : ");

            for (int i = 0; i < compteur; i++)
            {
                Console.WriteLine("Partie " + (i + 1) + ": Valeur secrète = " + tabValeur[i] + ", Tentatives = " + tabCoup[i]);
            }
        }

        // TODO : Exercice 1.3 (Modularisation des interactions utilisateurs)
        static string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static int GetInt(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("La saisie n'est pas un entier valide. La valeur par défaut (0) sera utilisée.");
                return 0;
            }
        }

        static void Main (string [] args)
        {

            // Variables declaration and initiation 
            int valeurSecrete, valeurSaisie;
            string reponse;

            int nbTentative = 0;
            int meilleurScore = 50;

            int[] historiqueTentative = new int[20];
            int[] historiqueValeur = new int[20];
            int nbParties = 0;

            Random rnd = new Random();
            valeurSecrete = rnd.Next(100);

            bool Trouve = false;
            while (!Trouve)
            {
                // TODO : Exercice 1.5 (Modularisation des interactions utilisateurs)
                valeurSaisie = GetInt("Veuillez saisir un nombre entier entre 0 et 100: ");

                nbTentative++;

                if (valeurSaisie > valeurSecrete)
                {
                    Console.WriteLine("Désolé, la valeur est trop grande. \n");
                }
                else if (valeurSaisie < valeurSecrete)
                {
                    Console.WriteLine("Désolé, la valeur est trop petite. \n");
                }
                else
                {
                    Console.WriteLine("Félicitations ! Vous avez trouvé la valeur correcte. \n");

                    Console.WriteLine("Nombre du Tentative: " + nbTentative);

                    if (nbTentative < meilleurScore)
                    {
                        meilleurScore = nbTentative;
                    }

                    Console.WriteLine("Meilleur score : " + meilleurScore + "\n");

                    historiqueValeur[nbParties] = valeurSecrete;
                    historiqueTentative[nbParties] = nbTentative;
                    nbParties++;

                    // TODO : Exercice 1.4 (Modularisation des interactions utilisateurs)
                    reponse = GetString("Voulez-vous rejouer une nouvelle partie ? (O/N): \n");


                    if (reponse != "O" && reponse != "o")
                    {
                        Trouve = true;
                    }
                    else
                    {
                        nbTentative = 0;
                        valeurSecrete = rnd.Next(100);
                    }
                }
            }

            // TODO : Exercice 1.2 (Modularisation de l’affichage d’historique)
            afficheHistorique(nbParties, historiqueValeur, historiqueTentative);

            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter...");
            Console.ReadKey();
        }
    }
}