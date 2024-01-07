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
            int Output;

            // TODO : Exercice 2 (Mise en œuvre de la levée d’exception)
            if (int.TryParse(input, out Output))
            {
                return Output;
            }
            else
            {
                throw new Exception("La valeur saisie n'est pas valide.");
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
                // TODO : Exercice 3 (Capture d’exception)
                try
                {
                    valeurSaisie = GetInt("Veuillez saisir un nombre entier entre 0 et 100: ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                    continue;
                }

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
                    // TODO : Exercice 3.1 (Capture d’exception)
                    reponse = GetString("Voulez-vous rejouer une nouvelle partie ? (O/N): ");

                    try
                    {
                        if (reponse != "O" && reponse != "o")
                        {
                            throw new Exception("La valeur saisie n'est pas valide, SVP entrez 'O' ou 'N'");
                        }
                        else
                        {
                            nbTentative = 0;
                            valeurSecrete = rnd.Next(100);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur : " + ex.Message);
                        continue;
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