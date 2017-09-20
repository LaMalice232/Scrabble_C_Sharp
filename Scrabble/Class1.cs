using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace test
{

    public class Jeton
    {
        [XmlAttribute()] public int Code { get; set; } // 64-117 : code ASCII de la lettre  
        [XmlAttribute()] public char Caractere { get; set; } // A-Z, @ pour le joker + lettres minuscules pour caracteres speciaux
        [XmlAttribute()] public int Valeur { get; set; } // 0-10 - utilisee pour le calcul du score d'un COUP 
        [XmlAttribute()] public int Quantite { get; set; } // 1-10 - utilisee pour initialiser la PIOCHE

        public void Save(string FileName){
            using (var stream = new FileStream(FileName, FileMode.Create)){
                var XML = new XmlSerializer(typeof(Jeton));
                XML.Serialize(stream, this);
            }
        }
    }

    public class Joueur
    {
        [XmlAttribute()] public string Nom { get; set; } /* identifiant unique - provient du login d'un PROFIL donc pas saisi         */
        [XmlAttribute()] public int Score { get; set; } /* 0 en debut de PARTIE                                                      */
        [XmlAttribute()] public int Nbre_jetons_sur_chevalet { get; set; }/* 0 en debut de PARTIE - est utilise pour determiner la fin de la PARTIE    */
        [XmlAttribute()] public List<Jeton> Chevalet { get; set; } /* represente le CHEVALET, support des jetons pioches par le JOUEUR          */
    }



    public class Adresse
    {
        [XmlAttribute()]public int Numero { get; set; }
        [XmlAttribute()]public string Rue { get; set; }
        [XmlAttribute()]public string Ville { get; set; }
        [XmlAttribute()]public string Pays { get; set; }
    }

    public class Jetons : List<Jeton>     //On hérite d'une liste de personnes.
    {
        /// Enregistre l'état courant de la classe dans un fichier au format XML.
        public void Save(string FileName){
            using (var stream = new FileStream(FileName, FileMode.Create)){
                var XML = new XmlSerializer(typeof(Jetons));
                XML.Serialize(stream, this);
            }
        }

        /// Charger des données depuis un fichier XML.
        public static Jetons LoadFromFile(string FileName){
            using (var stream = new FileStream(FileName, FileMode.Open)){
                var XML = new XmlSerializer(typeof(Jetons));
                return (Jetons)XML.Deserialize(stream);
            }
        }

    }

    public class Dico : List<string>     //On hérite d'une liste de personnes.
    {
        /// Enregistre l'état courant de la classe dans un fichier au format XML.
        public void Save(string FileName){
            using (var stream = new FileStream(FileName, FileMode.Create)){
                var XML = new XmlSerializer(typeof(Dico));
                XML.Serialize(stream, this);
            }
        }
    }

}