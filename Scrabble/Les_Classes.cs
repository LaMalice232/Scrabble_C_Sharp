using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace Scrabble
{
    public class maClasseGlobale
    {
        public static int indice=0;
        public static int Capacite_Chevalet = 7; // correspond a la capacite usuelle d'un chevalet du JEU, toutes versions       
        public static int Nbre_de_lignes = 15;         // correspond a la capacite usuelle d'un plateau de SCRABBLE, toutes versions   
        public static int Bonus_SCRABBLE = 50;         // bonus pour le coup special SCRABBLE, toutes versions                         
        public static int Lgr_case = 44;
        public static int NombreJoueurs = 2;         // 2-4 JOUEURS possibles - indicateur de fin de PARTIE.JOUEURS               
        public static int TypeEchange = 0;
        public static VraiJeton[] chevalet_temp = new VraiJeton[maClasseGlobale.Capacite_Chevalet];
        public static List<string> Historique = new List<string>();
        public static Jetons jetons;
        public static List<int> pioche = new List<int>();
        public static int CompteurJetons; // 0-149: nbre de jetons dans la pioche
        public static List<MotForme> MotsValides = new List<MotForme>();
        public static List<string> Joueurs = new List<string>();
        public static int Langue=0; //0 : FR - 1 : EN
    }

    [Serializable]
    public class PartieSave
    {
        [XmlAttribute()]
        public int Etat;
        [XmlAttribute()]
        public int IdLangue;
        [XmlAttribute()]
        public int CompteurTours;
        [XmlAttribute()]
        public int JoueurActif;
        [XmlAttribute()]
        public int CompteurPasse;
        [XmlAttribute()]
        public List<string> Historique;
        [XmlAttribute()]
        public List<Jeton> Test = new List<Jeton>();
        //[XmlAttribute()]
        //public List<Joueur> joueurs;
        //[XmlAttribute()]
        //public Case[,] VraiPlateau;
        [XmlAttribute()]
        public List<int> pioche;
        [XmlAttribute()]
        public int CompteurJetons;
        //[XmlAttribute()]
        //public List<MotForme> MotsValides;

        // Enregistre l'état courant de la classe dans un fichier au format XML.
        public void Save(string FileName)
        {
            XmlSerializer XML = new XmlSerializer(typeof(PartieSave));
            using (StreamWriter stream = new StreamWriter(FileName))
            {
                XML.Serialize(stream, this);
            }
        }
    }

    [Serializable]
    public class Jeton
    {
        [XmlAttribute()]
        public char Caractere { get; set; } // A-Z, @ pour le joker + lettres minuscules pour caracteres speciaux
        [XmlAttribute()]
        public int Valeur { get; set; } // 0-10 - utilisee pour le calcul du score d'un COUP 
        [XmlAttribute()]
        public int Quantite { get; set; } // 1-10 - utilisee pour initialiser la PIOCHE
    }

    [Serializable]
    public class VraiJeton
    {
        [XmlAttribute()]
        public int Code { get; set; } // 0-26
        [XmlAttribute()]
        public char Caractere { get; set; } // @ + A-Z
        [XmlAttribute()]
        public int Valeur { get; set; } // 0-10                        
    }

    [Serializable]
    public class Joueur
    {
        [XmlAttribute()]
        public string Nom { get; set; } // identifiant unique - provient du login d'un PROFIL donc pas saisi         
        [XmlAttribute()]
        public int Score { get; set; } // 0 en debut de PARTIE                                                      
        [XmlAttribute()]
        public int Nbre_jetons_sur_chevalet { get; set; }// 0 en debut de PARTIE - est utilise pour determiner la fin de la PARTIE    
        [XmlAttribute()]
        public VraiJeton[] VraiChevalet { get; set; } // represente le CHEVALET, support des jetons pioches par le JOUEUR          
    }

    [Serializable]
    public class Case : Label
    {
        [XmlAttribute()]
        public int Code { get; set; }// 0-26
        [XmlAttribute()]
        public int Valeur { get; set; } // 0-10
        [XmlAttribute()]
        public char Caractere { get; set; } // A-Z
        [XmlAttribute()]
        public bool EtatValide { get; set; } // 0: pas de lettre validee dessus - 1 : lettre validee dessus               
        [XmlAttribute()]
        public int Bonus { get; set; } // 0 : non - 1 : LCD  - 2 : LCT - 3 : MCD - 4 : MCT - 5 : Centre - 6 : Chevalet
        [XmlAttribute()]
        public int EmplacementVertical { get; set; } // 0 à 14 
        [XmlAttribute()]
        public int EmplacementHorizontal { get; set; } // 0 à 14 
        [XmlAttribute()]
        public bool Joker { get; set; } // false : non - true : oui 
    }

    public class Jetons : List<Jeton>     //On hérite d'une liste de jetons.
    {
        /// Enregistre l'état courant de la classe dans un fichier au format XML.
        public void Save(string FileName)
        {
            using (var stream = new FileStream(FileName, FileMode.Create))
            {
                var XML = new XmlSerializer(typeof(Jetons));
                XML.Serialize(stream, this);
            }
        }

        /// Charger des données depuis un fichier XML.
        public static Jetons LoadFromFile(string FileName)
        {
            using (var stream = new FileStream(FileName, FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(Jetons));
                return (Jetons)XML.Deserialize(stream);
            }
        }
    }

    public class Vecteur // VECTEUR (du nouveau mot formé)                                              
    {                          
        public int Axe; // 0 : horizontal - 1 : vertical                                             
        public int Indice; // numero de ligne ou de colonne (en fonction de l'axe)                      
    }

    [Serializable]
    public class Lettre  // LETTRE (d'un mot formé) :                                                   
    {
        [XmlAttribute()]
        public int LignCase; // 0-14 : numero de ligne de la CASE qui accueille la LETTRE                 
        [XmlAttribute()]
        public int ColCase; // 0-14 : numero de colonne de la CASE qui accueille la LETTRE               
        [XmlAttribute()]
        public int IndiceJetonAValider; // donne l'indice du JETON dans JETONS_A_VALIDER; inutile pour les lettres deja validées
        [XmlAttribute()]
        public int Valeur; // 1-10 : valeur du JETON correspondant                                      
        [XmlAttribute()]
        public int TypeBonus; // 0 : pas de bonus, 1 : sur lettre, 2 : sur mot                             
        [XmlAttribute()]
        public int Bonus; // 1 : pas de bonus, 2 : double, 3 : triple                                  
    }

    [Serializable]
    public class MotForme
    {
        [XmlAttribute()]
        public string Libelle; // pour contenir un mot max de 15 lettres et le caractere \0                 
        [XmlAttribute()]
        public List <Lettre> Lettres ; // les lettres qui composent le mot                                        
        [XmlAttribute()]
        public int Longueur;
        [XmlAttribute()]
        public int ScoreBrut; // somme des valeurs des LETTRES                                             
        [XmlAttribute()]
        public int ScoreBonus; // somme des valeurs des LETTRES pondérées par les BONUS                     
        [XmlAttribute()]
        public string Auteur;
    }
}