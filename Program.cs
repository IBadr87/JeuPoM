using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JeuPoM
{
    class Jeu
    {
        // This code is designed to allow users to guess a random number and track their best score and game history.
        // The game loop ensures that the user can play multiple times if they wish. 


        // Variables declaration and initiation 
        static int valeurSecrete, valeurSaisie;
        static string reponse;

        static int tentatives = 0;
        static int meilleurScore = 50;

        static Partie[] historique = new Partie[20];
        static int Parties = 0;

        // TODO : Exercise 1.1 (Modularisation de l’affichage d’historique)
        static void afficheHistorique(int compteur, Partie[] tab)
        {
            Console.WriteLine("Historique des parties : ");

            for (int i = 0; i < compteur; i++)
            {
                Console.WriteLine("Partie N°{0}, " + tab[i].info(), i + 1);
            }
        }

        // TODO Mo.5 (Génération d’un fichier d’historique)
        static void afficheHistorique(int compteur, Partie[] tab, string nomFichier)
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

                sw.WriteLine("Le Meilleur Score est : " + meilleurScore);

                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
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

        static void Jouer()
        {
            Random rnd = new Random();
            valeurSecrete = rnd.Next(100);

            do
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

                tentatives++;

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

                    Console.WriteLine("Nombre du Tentatives : " + tentatives);

                    if (tentatives < meilleurScore)
                    {
                        meilleurScore = tentatives;
                    }

                    Console.WriteLine("Meilleur score : " + meilleurScore + "\n");

                    historique[Parties] = new Partie(valeurSecrete, tentatives);
                    Parties++;
                }
            } while (valeurSaisie != valeurSecrete);
        }

        static void ReJouer()
        {
            Random rnd = new Random();
            valeurSecrete = rnd.Next(100);

            // TODO : Exercice 1.4 (Modularisation des interactions utilisateurs)
            // TODO : Exercice 3.1 (Capture d’exception)
            
            bool continuerJeu = false;
            while (!continuerJeu)
            {
                reponse = GetString("Voulez-vous rejouer une nouvelle partie ? (O/N): \n");
                try
                {
                    if (reponse.ToLower() == "o")
                    {
                        tentatives = 0;

                        Jouer();

                        valeurSecrete = rnd.Next(100);

                    }
                    else if (reponse.ToLower() == "n")
                    {
                        continuerJeu = false;

                        Console.WriteLine("Meilleur score : " + meilleurScore + "\n");

                        break;
                    }
                    else
                    {
                        throw new Exception("La valeur saisie n'est pas valide, SVP entrez 'O' ou 'N'");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                    continue;
                }
            }
            InfoSaveInFile();
        }

        static void InfoSaveInFile()
        {
            // TODO : Exercice 1.2 (Modularisation de l’affichage d’historique)

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.FileName = "GAM.txt";
            saveFileDialog.Title = "Save As";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                afficheHistorique(Parties, historique, saveFileDialog.FileName);
            }
            else
            {
                afficheHistorique(Parties, historique);
            }
        }

        [STAThread]
        static void Main(string[] args)
        {

            Jouer();
            ReJouer();

            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter...");
            Console.ReadKey();
        }
    }
}