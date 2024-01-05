using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPoM
{
    internal class Jeu
    {

        // This code is designed to allow users to guess a random number and track their best score and game history.
        // The game loop ensures that the user can play multiple times if they wish. 

        static void Jouer()
        {
            // Variables declaration and initiation 
            int valeurSecrete, valeurSaisie;
            string reponse;

            int nbTentative = 0;
            int meilleurScore = 50;

            int [] historiqueTentative = new int [20];
            int[] historiqueValeur = new int[20];
            int nbParties = 0;

            Random rnd = new Random();
            valeurSecrete = rnd.Next(100);

            bool Trouve = false;
            while(!Trouve)
            {
                Console.Write("Veuillez saisir un nombre entier entre 0 et 100 : ");
                reponse = Console.ReadLine();

                valeurSaisie = int.Parse(reponse);
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

                    historiqueValeur [nbParties] = valeurSecrete;
                    historiqueTentative [nbParties] = nbTentative;
                    nbParties++;

                    Console.WriteLine("Voulez vous rejouer une nouvelle partie ? (O/N) : \n");
                    reponse = Console.ReadLine();

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

            Console.WriteLine("Historique des parties : ");

            for (int i = 0; i < nbParties; i++)
            {
                Console.WriteLine("Partie " + (i + 1) + ": Valeur secrète = " + historiqueValeur[i] + ", Tentatives = " + historiqueTentative[i]);
            }
        }

        static void Main (string [] args)
        {

            Jouer();

            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter...");
            Console.ReadKey();
        }
    }
}