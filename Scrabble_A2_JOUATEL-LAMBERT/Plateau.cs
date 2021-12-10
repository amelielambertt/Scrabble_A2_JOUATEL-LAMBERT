using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scabble_JOUATEL
{
    class Plateau
    {
        private char[,] plato;

        public char[,] Plato
        {
            get { return this.plato; }
        }

        public Plateau()
        {
            string fullpath = Path.GetFullPath("PlateauVierge.Txt");
            string[][] tiréDuTexte = new string[15][];
            try
            {
                //Créez une instance de StreamReader pour lire à partir d'un fichier
                using (StreamReader sr = new StreamReader(fullpath))
                {
                    string line;

                    for(int i = 0; i < 15; i++)
                    {
                        line = sr.ReadLine();
                        tiréDuTexte[i] = line.Split(';', 15);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le fichier n'a pas pu être lu.");
                Console.WriteLine(e.Message);
            }
            this.plato = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    this.plato[i, j] = Convert.ToChar(tiréDuTexte[i][j]);
                }
            }
        }
        public Plateau(string sauvegarde)
        {
            string fullpath = Path.GetFullPath(sauvegarde + "-Plateau.txt");
            string[][] tiréDuTexte = new string[15][];
            try
            {
                //Créez une instance de StreamReader pour lire à partir d'un fichier
                using (StreamReader sr = new StreamReader(fullpath))
                {
                    string line;

                    for (int i = 0; i < 15; i++)
                    {
                        line = sr.ReadLine();
                        tiréDuTexte[i] = line.Split(';', 15);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Le fichier n'a pas pu être lu.");
                Console.WriteLine(e.Message);
            }
            this.plato = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    this.plato[i, j] = Convert.ToChar(tiréDuTexte[i][j]);
                }
            }
        }


        public void AffichageOMG(List<Joueur> listeDesJoueurs)
        {
            for (int i = 0; i < 15; i++)
            {
                Console.Write('\t');
                for (int j = 0; j < 15; j++)
                {
                    switch (this.plato[i, j])
                    {
                        case '3':
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case '2':
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case '7':
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case '8':
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case '*':
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("**");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '_':
                            Console.Write("  ");
                            break;
                        default:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(this.plato[i, j] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                if (i == 5)
                {
                    Console.Write('\t');
                    Console.Write('\t');
                    Console.Write("R |Pts| Nom");
                }
                if(i>5 && i <= listeDesJoueurs.Count + 5)
                {
                    Console.Write('\t');
                    Console.Write('\t');
                    Console.Write((i - 5) + " | " + listeDesJoueurs[i - 6].Score + " | " + listeDesJoueurs[i - 6].Nom);
                }
                
                Console.WriteLine();

            }
        }

        public void AffichageOMGFactice(List<Joueur> listeDesJoueurs, char[,] plateauCurseur, char[,] plateauFactice, int curseurx, int curseury, bool SURLEPLATEAU)
        {
            for (int i = 0; i < 15; i++)
            {
                Console.Write('\t');
                for (int j = 0; j < 15; j++)
                {
                    switch (plateauFactice[i, j])
                    {
                    case '3':
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(plateauCurseur[i,j] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        break;
                    case '2':
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(plateauCurseur[i,j] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        break;
                    case '7':
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            }        
                        }
                        break;
                    case '8':
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("  ");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(plateauCurseur[i,j] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        break;
                    case '*':
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("**");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(plateauCurseur[i,j] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        break;
                    case '_':
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.Write("  ");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(plateauCurseur[i,j] + " ");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        break;
                    default:
                        if(i==curseurx && j == curseury && SURLEPLATEAU)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(plateauCurseur[i,j] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            if(plateauFactice[i,j] == plateauCurseur[i, j])
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(plateauFactice[i, j] + " ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write(plateauFactice[i, j] + " ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        break;    
                    }
                }
                if (i == 5)
                {
                    Console.Write('\t');
                    Console.Write('\t');
                    Console.Write("R |Pts| Nom");
                }
                if(i>5 && i <= listeDesJoueurs.Count + 5)
                {
                    Console.Write('\t');
                    Console.Write('\t');
                    Console.Write((i - 5) + " | " + listeDesJoueurs[i - 6].Score + " | " + listeDesJoueurs[i - 6].Nom);
                }
                
                Console.WriteLine();

            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        
        public int LaFonctionQuiMePerdra(char[,] plateauCurseur, char[,] plateauFactice)
        {
            //retourne 0 si la lettre est plaçable, 1 si la lettre est peut-être plaçable mais pas encore et 2 Si elle n'est pas plaçable

            /* Ordre des vérifications :
             * Reconnaître toutes les lettres posées 2/10
             * Toutes les lettres posées sont alignées 1/10
             * Reconnaître tous les nouveaux mots crées 9/10
             * Toutes les lettres alignées verticalement forment des mots valides 4-6/10
             * Toutes les lettres alignées horizontalement forment des mots valides 4-6/10
             * 
             * Une fonction récursive devrait aller plus vite et devrait être bien plus facile à coder
             * 
             * Difficulté de la fonction : argh
             * Est-ce que c'est fini après ça ? Absolument pas...
             * 
             * 
             * Elements nécessaires :
             * Le plateau déja posé -> this.plato ok
             * Le plateau en cours de pose -> plateauFactice ok
             * La lettre à vérifier -> plateauCurseur ok
             * 
             * Question : Comment mettre en forme facilement les lettres déjà posées et celle qui ont besoin d'être testées ?
             * Réponse : Supprimer l'ancien tableau du plateauFactice
             * 
             * Question : Comment reconnaître tous les mots nouvellement créés ?
             * 
             * Question : Comment vérifier facilement et rapidement tous les mots créés ?
             * 
             */

            return 3;

        }


        /* Test plateau à faire plutôt à la fin
        public bool TestPlateau(string mot, int ligne, int colonne, char direction)
        {

        }
        */
    }
}
