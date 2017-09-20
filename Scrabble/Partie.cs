using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Scrabble
{
    public partial class Partie : Form
    {
        /* ------------------------------------------ Variables globales  ----------------------------------------------- */


        public bool Succes = false;
        public Case l;
        public Case depart;
        public Label departLabel;
        int Etat = 0; /* 0 : non commencee - 1 : debutee - 2 : terminee                            */
        int CompteurTours = 1; /* 1-... : compteur de TOURS de la PARTIE                                    */
        int JoueurActif = 0; /* 0-3 : donne l'indice du PROFIL du JOUEUR dans le tableau PROFILS_CONNECTES*/
        int CompteurPasse; /* 0-6 : compteur d'actions consécutives "Passer le TOUR" est utilise pour determiner la fin de la PARTIE                       */
        List<string> Historique = new List<string>();
        List<Joueur> joueurs = new List<Joueur>();/* liste les JOUEURS de la PARTIE                           */
        List<Case> jetonsAValider = new List<Case>();
        int compteur_JV = 0; /* indicateur de fin de JETONS_A_VALIDER                                 */
        List<MotForme> motsFormes = new List<MotForme>(); /* liste les mots formes et valides*/             
        Vecteur vecteur = new Vecteur();
        /*initialisation JOUEUR_ACTIF - toute partie*/
        Joueur joueurActif = new Joueur();
        Random truc = new Random();
        Case[,] VraiPlateau = new Case[maClasseGlobale.Nbre_de_lignes, maClasseGlobale.Nbre_de_lignes];
        public static IEnumerable<String> Dico;

        public Partie()
        {
            InitializeComponent();
        }
    
        private void Partie_Load(object sender, EventArgs e)
        {
            maClasseGlobale.pioche.Clear();
            maClasseGlobale.CompteurJetons = 0;
            if (maClasseGlobale.Langue == 0)
            {
                maClasseGlobale.jetons = Jetons.LoadFromFile("FR.xml");
                Dico = File.ReadLines("fr.txt");
            }
            else
            {
                maClasseGlobale.jetons = Jetons.LoadFromFile("EN.xml");
                Dico = File.ReadLines("en.txt");
            }
            
            //transfert de l'historique
            maClasseGlobale.Historique = Historique;
            int i, j;
            /* creation 2 joueurs: */
            List<Case> un_chevalet = new List<Case>();
            for (i=0; i<maClasseGlobale.NombreJoueurs; i++)
            {
                joueurs.Add(new Joueur() { Nbre_jetons_sur_chevalet = 0, Nom = maClasseGlobale.Joueurs[i], Score = 0, VraiChevalet = new VraiJeton[maClasseGlobale.Capacite_Chevalet] });
            }
            /* uniquement pour une nouvelle partie : */
            if (Etat == 0)
            {
                /*Creation de la pioche*/
                for (i = 0; i < 27; i++)
                {
                    for (j = 0; j < maClasseGlobale.jetons[i].Quantite; j++)
                    {
                        maClasseGlobale.pioche.Add(i);
                        maClasseGlobale.CompteurJetons++;
                    }
                }

                /*Lancement de la procedure Pioche() pour chaque JOUEUR */
                for (i = 0; i < maClasseGlobale.NombreJoueurs; i++)
                {
                    joueurActif = null;
                    joueurActif = joueurs[i];
                    for (j = 0; j < maClasseGlobale.Capacite_Chevalet; j++)
                    {
                        Piocher(j);
                    }
                    joueurs[i] = joueurActif;
                }

                /*initialisation JOUEUR_ACTIF - nouvelle partie*/
                JoueurActif = 0;

                // boucle de création des scores
                for (i = 0; i < maClasseGlobale.NombreJoueurs; i++)
                {
                    // création d'un nouveau contrôle
                    Label un_texte = new Label();
                    // rattachement du contrôle au Chevalet
                    groupBox3.Controls.Add(un_texte);
                    // propriete des cases
                    un_texte.Text = "x";
                    un_texte.Width = 200;
                    un_texte.BorderStyle = BorderStyle.None;
                    un_texte.Left = 10;
                    un_texte.Top = 20 + i * 25;
                }
            }

            /*initialisation JOUEUR_ACTIF - toute partie*/
            joueurActif = joueurs[JoueurActif];

            label10.Text = "Tour n° "+Convert.ToString(CompteurTours);
            label12.Text = "Joueur : "+joueurActif.Nom;
            textBox5.Text = Convert.ToString(maClasseGlobale.CompteurJetons);
            // boucle d'initialisation des cases du Plateau
            for (i = 0; i < maClasseGlobale.Nbre_de_lignes; i++)
            {
                for (j = 0; j < maClasseGlobale.Nbre_de_lignes; j++)
                {
                    // création d'un nouveau contrôle
                    Case une_case = new Case();
                    une_case.Code = -1;
                    une_case.EtatValide = false;
                    une_case.Bonus = 0;
                    une_case.EtatValide = false;
                    une_case.EmplacementHorizontal = i;
                    une_case.EmplacementVertical = j;
                    // propriete des cases
                    une_case.AllowDrop = true;
                    une_case.AutoSize = false;
                    une_case.BackColor = Color.White;
                    une_case.BorderStyle = BorderStyle.FixedSingle;
                    une_case.Cursor = Cursors.Cross;
                    une_case.Font = new Font("Arial", 24, FontStyle.Bold);
                    une_case.TextAlign = ContentAlignment.MiddleCenter;
                    une_case.Width = maClasseGlobale.Lgr_case;
                    une_case.Height = maClasseGlobale.Lgr_case;
                    une_case.Left = maClasseGlobale.Lgr_case / 6 + j * (maClasseGlobale.Lgr_case + maClasseGlobale.Lgr_case / 6);
                    une_case.Top = maClasseGlobale.Lgr_case / 6 + i * (maClasseGlobale.Lgr_case + maClasseGlobale.Lgr_case / 6);
                    if ((i == 0 || i == 7 || i == 14) && (j == 0 || j == 7 || j == 14))
                    {
                        une_case.BackColor = Color.Red;
                        une_case.Bonus = 4;
                    }
                    if (i == 7 && i == j)
                    {
                        une_case.BackColor = Color.Black;
                        une_case.Bonus = 5;
                    }
                    if ((i == 1 || i == 5 || i == 9 || i == 13) && (j == 1 || j == 5 || j == 9 || j == 13))
                    {
                        une_case.BackColor = Color.RoyalBlue;
                        une_case.Bonus = 2;
                    }
                    if (((i == 0 || i == 14) && (j == 3 || j == 11)) || (j == 0 || j == 14) && (i == 3 || i == 11) || ((i == 6 || i == 8) && (i == j || i == 14 - j)) || ((i == 2 || i == 12) && (j == 6 || j == 8)) || (j == 2 || j == 12) && (i == 6 || i == 8) || (i == 7 && (j == 3 || j == 11)) || j == 7 && (i == 3 || i == 11))
                    {
                        une_case.BackColor = Color.LightSkyBlue;
                        une_case.Bonus = 1;
                    }
                    if ((i == 1 || i == 2 || i == 3 || i == 4 || i == 10 || i == 11 || i == 12 || i == 13) && (i == j || i == 14 - j))
                    {
                        une_case.BackColor = Color.LightPink;
                        une_case.Bonus = 3;
                    }
                    une_case.DragEnter += new DragEventHandler(Survol);
                    une_case.DragDrop += new DragEventHandler(Largage);
                    // rattachement du contrôle au Plateau
                    VraiPlateau[i, j] = une_case;
                    Plateau.Controls.Add(une_case);
                }
            }
            majChevalet();
        }

        private void Decollage(object sender, MouseEventArgs e)
        {
            depart = (Case)sender;
            depart.DoDragDrop("Nada", DragDropEffects.All);
            if (Succes && depart != l)
            {
                depart.Image = null;
                switch (depart.Bonus)
                {
                    case 0:
                        depart.Code = -1;
                        depart.BackColor = Color.White;
                        break;
                    case 1:
                        depart.Code = -1;
                        depart.BackColor = Color.LightSkyBlue;
                        break;
                    case 2:
                        depart.Code = -1;
                        depart.BackColor = Color.RoyalBlue;
                        break;
                    case 3:
                        depart.Code = -1;
                        depart.BackColor = Color.LightPink;
                        break;
                    case 4:
                        depart.Code = -1;
                        depart.BackColor = Color.Red;
                        break;
                    case 5:
                        depart.Code = -1;
                        depart.BackColor = Color.Black;
                        break;
                    case 6:
                        depart.BackColor = SystemColors.Control;
                        joueurActif.Nbre_jetons_sur_chevalet--;
                        compteur_JV++;
                        break;
                }
                depart.MouseDown -= new MouseEventHandler(Decollage);
                depart.AllowDrop = true;
                button2.Text = "Recuperer";
                button2.Click -= new EventHandler(Melanger);
                button2.Click += new EventHandler(Recuperer);
                textBox1.Text = Convert.ToString(compteur_JV);
                Succes = false;
            }
        }

        private void Survol(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Largage(object sender, DragEventArgs e)
        {
            l = (Case)sender;
            l.Code = depart.Code;

            if (depart.Code == 0)
            {
                if (depart.Bonus == 6)
                {
                    var inviteJoker = new Joker();
                    inviteJoker.ShowDialog();
                }
                l.Caractere = Convert.ToChar(maClasseGlobale.indice + 65);
                l.Image = ListBonus.Images[maClasseGlobale.indice];
                l.BackColor = Color.Red;
                
            }
            else
            {
                l.Caractere = depart.Caractere;
                l.BackColor = Color.Black;
                if (maClasseGlobale.Langue==0)
                {
                    l.Image = ListFR.Images[l.Code];
                }
                else
                {
                    l.Image = ListEN.Images[l.Code];
                }
            }
            l.Valeur = depart.Valeur;
            l.MouseDown += new MouseEventHandler(Decollage);
            l.AllowDrop = false;
            Succes = true;
        }

        private void Recuperer(object sender, EventArgs e)
        {
            foreach (Case une_case in Plateau.Controls)
            {
                if (!une_case.EtatValide)
                {
                    switch (une_case.Bonus)
                    {
                        case 0:
                            une_case.BackColor = Color.White;
                            break;
                        case 1:
                            une_case.BackColor = Color.LightSkyBlue;
                            break;
                        case 3:
                            une_case.BackColor = Color.LightPink;
                            break;
                        case 2:
                            une_case.BackColor = Color.RoyalBlue;
                            break;
                        case 4:
                            une_case.BackColor = Color.Red;
                            break;
                        case 5:
                            une_case.BackColor = Color.Black;
                            break;
                    }
                    une_case.Code = -1;
                    une_case.Image = null;
                    une_case.AllowDrop = true;
                }
            }

            foreach (Case une_case in ChevaletAffichage.Controls)
            {
                une_case.BackColor = Color.Black;
                if (une_case.Code > -1)
                {
                    if (maClasseGlobale.Langue == 0)
                    {
                        une_case.Image = ListFR.Images[une_case.Code];
                    }
                    else
                    {
                        une_case.Image = ListEN.Images[une_case.Code];
                    }
                }
                else
                {
                    une_case.BackColor = Color.White;
                }
                une_case.MouseDown += new MouseEventHandler(Decollage);
            }
            joueurActif.Nbre_jetons_sur_chevalet += compteur_JV;
            compteur_JV = 0;
            textBox1.Text = Convert.ToString(compteur_JV);
            button2.Text = "Melanger";
            button2.Click -= new EventHandler(Recuperer);
            button2.Click += new EventHandler(Melanger);
        }

        private void Piocher(int indice)
        {
            int i, indicePioche;
            if (maClasseGlobale.CompteurJetons > 0)
            {
                indicePioche = truc.Next(0, maClasseGlobale.CompteurJetons + 1);
                joueurActif.VraiChevalet[indice] = new VraiJeton();
                joueurActif.VraiChevalet[indice].Code = maClasseGlobale.pioche[indicePioche];
                joueurActif.VraiChevalet[indice].Valeur = maClasseGlobale.jetons[maClasseGlobale.pioche[indicePioche]].Valeur;
                joueurActif.VraiChevalet[indice].Caractere = Convert.ToChar(maClasseGlobale.pioche[indicePioche] + 64);
                joueurActif.Nbre_jetons_sur_chevalet++;

                for (i = indicePioche; i < maClasseGlobale.CompteurJetons - 1; i++)
                {
                    maClasseGlobale.pioche[i] = maClasseGlobale.pioche[i + 1];
                }
                maClasseGlobale.CompteurJetons--;
            }
        }

        private void Melanger(object sender, EventArgs e)
        {
            //uniquement si tous les jetons sont posés
            int pos, nvlle_pos;
            VraiJeton temp;

            if (joueurActif.Nbre_jetons_sur_chevalet > 1)
            {
                for (pos = 0; pos < joueurActif.Nbre_jetons_sur_chevalet - 1; pos++)
                {
                    nvlle_pos = truc.Next(0, joueurActif.Nbre_jetons_sur_chevalet);
                    if (nvlle_pos > pos)
                    {
                        temp = joueurActif.VraiChevalet[pos];
                        joueurActif.VraiChevalet[pos] = joueurActif.VraiChevalet[nvlle_pos];
                        joueurActif.VraiChevalet[nvlle_pos] = temp;
                    }
                }
            }
            // boucle de RAZ du Chevalet
            for (int i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
            {
                ChevaletAffichage.Controls.RemoveAt(0);
            }
            majChevalet();
        }

        private void Passer(object sender, EventArgs e)
        {
            if (compteur_JV == 0)
            {
                Historique.Add("Tour " + CompteurTours + " : " + joueurActif.Nom + " a passé son tour.");
                CompteurPasse++;
                PasserLeTour();
                check_fin_de_partie();
            }
            else
            {
                MessageBox.Show("Veuillez d'abord reprendre les lettres posees sur le Plateau");
            }
        }

        private void PasserLeTour()
        {
            joueurs[JoueurActif] = joueurActif;
            JoueurActif++;
            if (JoueurActif == maClasseGlobale.NombreJoueurs)
            {
                JoueurActif = 0;
                CompteurTours++;

            }
            joueurActif = joueurs[JoueurActif];
            // boucle de RAZ du Chevalet
            for (int i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
            {
                ChevaletAffichage.Controls.RemoveAt(0);
            }
            majChevalet();
            label10.Text = "Tour n° "+Convert.ToString(CompteurTours);
            label12.Text = "Joueur : " + joueurActif.Nom;
            textBox5.Text = Convert.ToString(maClasseGlobale.CompteurJetons);
        }

        private void Echanger(object sender, EventArgs e)
        {
            /*interdiction d'echanger des lettres si des jetons sont poses sur le PLATEAU ou s'il reste moins de 7 jetons dans la pioche */
            if (compteur_JV == 0 && maClasseGlobale.CompteurJetons > maClasseGlobale.Capacite_Chevalet)
            {
                for (int i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
                {
                    maClasseGlobale.chevalet_temp[i] = joueurActif.VraiChevalet[i];
                }
                var inviteEchange = new Echange();
                inviteEchange.ShowDialog();
                if (maClasseGlobale.TypeEchange == 2)
                {
                    joueurActif.Nbre_jetons_sur_chevalet = 0;
                    for (int i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
                    {
                        Piocher(i);
                    }
                    for (int i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
                    {
                        maClasseGlobale.pioche[maClasseGlobale.CompteurJetons] = maClasseGlobale.chevalet_temp[i].Code;
                        maClasseGlobale.CompteurJetons++;
                    }
                    maClasseGlobale.TypeEchange = 0;
                    Historique.Add("Tour " + CompteurTours + " : " + joueurActif.Nom + " a changé toutes ses lettres.");
                    CompteurPasse = 0;
                    PasserLeTour();
                }

                if (maClasseGlobale.TypeEchange == 1)
                {
                    VraiJeton jeton_temp = new VraiJeton();
                    jeton_temp = joueurActif.VraiChevalet[maClasseGlobale.indice];
                    joueurActif.Nbre_jetons_sur_chevalet--;
                    Piocher(maClasseGlobale.indice);
                    maClasseGlobale.pioche[maClasseGlobale.CompteurJetons] = jeton_temp.Code;
                    maClasseGlobale.CompteurJetons++;
                    maClasseGlobale.TypeEchange = 0;
                    Historique.Add("Tour " + CompteurTours + " : " + joueurActif.Nom + " a changé une lettre.");
                    CompteurPasse = 0;
                    PasserLeTour();
                }
            }
            else
            {
                MessageBox.Show("Veuillez d'abord reprendre les lettres posees sur le Plateau");
            }
        }

        bool CheckDico(string saisie)
        {
            int indice_debut = 0, indice_milieu, indice_fin = Dico.Count();
            bool trouve = false;
            string saisie_normalisee = saisie.ToUpper();
            while (!trouve && ((indice_fin - indice_debut) > 1))
            {
                indice_milieu = (indice_debut + indice_fin) / 2;
                int res = string.Compare(saisie_normalisee,Dico.ElementAt(indice_milieu));

                if (res == 0)
                {
                    trouve = true;
                }
                if (res < 0)
                {
                    indice_fin = indice_milieu;
                }
                else
                {
                    indice_debut = indice_milieu;
                }
            }
            return trouve;
        }

        private void AccederDico(object sender, EventArgs e)
        {
            bool trouve = CheckDico(textBox6.Text);
            label15.Visible = true;
            if (trouve)
            {
                label15.Text = " > Ce mot existe.";
            }
            else
            {
                label15.Text = " > Ce mot n'existe pas.";
            }
        }

        void check_fin_de_partie()
        {
            int i, j, flag = 0;
            /*Contrôle 1*/
            if (maClasseGlobale.CompteurJetons == 0)
            {
                if (joueurActif.Nbre_jetons_sur_chevalet == 0)
                {
                    Etat = 2;
                    flag = 1;
                }
            }

            /*Contrôle 2*/
            if (CompteurPasse == 3 * maClasseGlobale.NombreJoueurs)
            {
                Etat = 2;
                flag = 2;
            }

            if (Etat == 2)
            {
                /*on renvoie les elements du JOUEUR_ACTIF vers la structure JOUEUR correspondante dans PARTIE */
                joueurs[JoueurActif] = joueurActif;
                for (i = 0; i < maClasseGlobale.NombreJoueurs; i++)
                {
                    for (j = 0; j < maClasseGlobale.Capacite_Chevalet; j++)
                    {
                        /*si le joueur actif a placé tous ses jetons, alors il récupère le score des jetons à placer des autres joueurs*/
                        if (flag == 1)
                        {
                            joueurActif.Score += joueurs[i].VraiChevalet[j].Valeur;
                        }
                        /*tous les joueurs perdent en point la Valeur des lettres restantes (aucun point perdu pour celui qui a terminé)*/
                        joueurs[i].Score -= joueurs[i].VraiChevalet[j].Valeur;
                    }
                }
                /*on trie les joueurs par ordre croissant de points */

                bool tab_en_ordre = false;
                int taille = joueurs.Count();
                while (!tab_en_ordre)
                {
                    tab_en_ordre = true;
                    for (i = 0; i < (taille-1); i++)
                    {
                        if (joueurs[i].Score > joueurs[i + 1].Score)
                        {
                            Joueur tempJoueur = joueurs[i];
                            joueurs[i] = joueurs[i + 1];
                            joueurs[i + 1] = tempJoueur;
                            tab_en_ordre = false;
                        }
                    }
                    taille--;
                }
                MessageBox.Show(joueurs[joueurs.Count() - 1].Nom + ", vous avez gagné !!", "Fin de la Partie");

                //rendre les différents boutons inactifs
                foreach (Control le_ctrl in Controls)
                {
                    if (le_ctrl is Button)
                    {
                        le_ctrl.Enabled = false;
                    }
                }
                foreach (Control le_ctrl in groupBox2.Controls)
                {
                    if (le_ctrl is Button || le_ctrl is TextBox)
                    {
                        le_ctrl.Enabled = false;
                    }
                }
            }
        }

        private void Valider(object sender, EventArgs e)
        {
            if (compteur_JV != 0)
            {
                bool check_OK = true;
                int i, score = 0, compteur_mots_faux=0;
                string mots = "", mots_faux="";
                foreach (Case une_case in Plateau.Controls)
                {
                    VraiPlateau[une_case.EmplacementHorizontal, une_case.EmplacementVertical] = une_case;
                    if (une_case.Code != -1 && !une_case.EtatValide)
                    {
                        jetonsAValider.Add(une_case);
                    }
                }
                if (check1() && check2() && check3() && check4())
                {
                    if (check5())
                    {
                        if (compteur_JV > 1)
                        {
                            if (Etat>0)
                            {
                                IdentifierAutresMots();
                            }
                        }
                        else
                        {
                            IdentifierMots();
                        }
                    }
                    foreach (MotForme mot in motsFormes)
                    {
                        bool trouve = CheckDico(mot.Libelle);
                        if (!trouve)
                        {
                            check_OK = false;
                            compteur_mots_faux++;
                            mots_faux += mot.Libelle + "; ";
                        }
                        mots += mot.Libelle + ";";
                        score += mot.ScoreBonus;
                    }
                    if (check_OK)
                    {
                        //insertion des mots formés dans les mots validés
                        foreach (MotForme mot in motsFormes)
                        {
                            maClasseGlobale.MotsValides.Add(mot);
                        }
                        string phrase = "Tour " + CompteurTours + " : " + joueurActif.Nom + " a joué. ";
                        if (motsFormes.Count() > 1)
                        {
                            phrase += "Mots formés : ";
                        }
                        else
                        {
                            phrase += "Mot formé : ";
                        }
                        for (i = 0; i < motsFormes.Count(); i++)
                        {
                            phrase += motsFormes[i].Libelle + ", ";
                        }
                        phrase = phrase.Substring(0, phrase.Length-2);
                        /* test SCRABBLE */
                        if (compteur_JV == maClasseGlobale.Capacite_Chevalet)
                        {
                            score += maClasseGlobale.Bonus_SCRABBLE;
                            phrase += " - " + score + " points - SCRABBLE !!";
                        }
                        else
                        {
                            phrase += " - " + score + " points";
                        }
                        Historique.Add(phrase);
                        /* affecter le score au JOUEUR_ACTIF */
                        joueurActif.Score += score;
                        /* piocher pour chaque emplacement libre sur le chevalet */
                        foreach (Case une_case in ChevaletAffichage.Controls)
                        {
                            if (une_case.Image == null)
                            {
                                int indice = ChevaletAffichage.Controls.IndexOf(une_case);
                                joueurActif.VraiChevalet[indice].Code = -1;
                                Piocher(indice);
                            }
                        }
                        CompteurPasse = 0;
                        /* remise a zero du compteur jetons poses */
                        jetonsAValider.Clear();
                        compteur_JV = 0;
                        motsFormes.Clear();
                        textBox1.Text = Convert.ToString(compteur_JV);
                        foreach (Case une_case in Plateau.Controls)
                        {
                            if (une_case.Code > -1)
                            {
                                une_case.EtatValide = true;
                            }
                        }
                        button2.Click += new EventHandler(Melanger);
                        button2.Click -= new EventHandler(Recuperer);
                        button2.Text = "Melanger";
                        if (Etat == 0)
                        {
                            Etat = 1;
                            groupBox3.Visible = true;
                        }
                        for (i = 0; i < maClasseGlobale.NombreJoueurs; i++)
                        {
                            groupBox3.Controls[i].Text = joueurs[i].Nom + " : " + Convert.ToString(joueurs[i].Score) + " points";
                        }
                        check_fin_de_partie();
                        if (Etat != 2)
                        {
                            PasserLeTour();
                        }
                    }
                    else
                    {
                        mots_faux = mots_faux.Substring(0, mots_faux.Length - 2);
                        string phrase = "";
                        if (compteur_mots_faux>1)
                        {
                            phrase = "Ces mots n'existent pas: ";
                        }
                        else
                        {
                            phrase = "Ce mot n'existe pas: ";
                        }
                        MessageBox.Show(phrase+mots_faux+".");
                        motsFormes.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez d'abord poser au moins une lettre sur le Plateau");
            }
            jetonsAValider.Clear();
        }

        private bool check1()
        {
            int compteur = 0;
            bool flag = false;
            /* check 1: le 1er mot de deux lettres minimum doit recouvrir la case centrale*/
            foreach (Case une_case in Plateau.Controls)
            {
                if (une_case.EtatValide)
                {
                    compteur++;
                }
                
            }
            /* si aucune case n'est validee sur le plateau, alors */
            if (compteur == 0)
            {
                if (VraiPlateau[7, 7].Code != -1 && jetonsAValider.Count()>1)
                {
                    flag = true;
                }
            }
            else
            {
                flag = true;
            }
            if (!flag)
            {
                MessageBox.Show("Dans une nouvelle partie, le 1er mot (compose de 2 lettres minimum) doit recouvrir la case centrale.");
            }
            return flag;
        }

        bool check2()
        {
            int i;
            bool flag = true;
            /* check 2: Les lettres sont sur le même axe; la boucle commence a 1 : pas besoin de ce check si un seul jeton a ete pose */
            for (i = 1; i < compteur_JV; i++)
            {
                /* determination du vecteur du nouveau mot*/
                if (i == 1)
                {
                    /* si les jetons 0 et 1 ne sont pas du tout alignes alors non valide */
                    if ((jetonsAValider[i].EmplacementVertical != jetonsAValider[0].EmplacementVertical) && (jetonsAValider[i].EmplacementHorizontal != jetonsAValider[0].EmplacementHorizontal))
                    {
                        flag = false;
                    }
                    else if (jetonsAValider[i].EmplacementVertical == jetonsAValider[0].EmplacementVertical)
                    {
                        vecteur.Axe = 1;
                        vecteur.Indice = jetonsAValider[i].EmplacementVertical;
                    }
                    else
                    {
                        vecteur.Axe = 0;
                        vecteur.Indice = jetonsAValider[i].EmplacementHorizontal;
                    }
                }
                else
                {
                    if (vecteur.Axe == 1)
                    {
                        if (jetonsAValider[i].EmplacementVertical != vecteur.Indice)
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        if (jetonsAValider[i].EmplacementHorizontal != vecteur.Indice)
                        {
                            flag = false;
                        }
                    }
                }
            }
            if (!flag)
            {
                MessageBox.Show("Certaines de ces lettres ne sont pas sur le même axe.");
            }

            return flag;
        }

        bool check3()
        {
            int min_mot, max_mot;
            bool flag = true;
            if (compteur_JV > 1)
            {
                /* check 3: Verifier que les lettres a valider sont conjointes entre elles ou avec d'autres lettres deja posees
                 JE REGARDE L EMPLACEMENT LIGN/col(en fonction DE L AXE DU VECTEUR) DU 1ER JETON*/
                if (vecteur.Axe == 0)
                {
                    min_mot = jetonsAValider[0].EmplacementVertical;
                }
                else
                {
                    min_mot = jetonsAValider[0].EmplacementHorizontal;
                }
                /* INITIALISATION des limites du nouveau mot pose */
                max_mot = min_mot;

                /* puis je regarde si je peux faire descendre/monter min_mot/max_mot */
                if (vecteur.Axe == 0)
                {
                    while (min_mot > 0 && VraiPlateau[jetonsAValider[0].EmplacementHorizontal, min_mot - 1].Code > -1)
                    {
                        min_mot--;
                    }
                    while (max_mot < 14 && VraiPlateau[jetonsAValider[0].EmplacementHorizontal, max_mot + 1].Code > -1)
                    {
                        max_mot++;
                    }
                }
                else
                {
                    while (min_mot > 0 && VraiPlateau[min_mot - 1, jetonsAValider[0].EmplacementVertical].Code > -1)
                    {
                        min_mot--;
                    }
                    while (max_mot < 14 && VraiPlateau[max_mot + 1, jetonsAValider[0].EmplacementVertical].Code > -1)
                    {
                        max_mot++;
                    }
                }
                /* enfin, boucle sur chaque lettre posee : si son num_lign/col ne rentre pas dans ces limites alors flag=0*/
                foreach (Case une_case in jetonsAValider)
                {
                    if (vecteur.Axe == 1 && une_case.EmplacementVertical < min_mot && une_case.EmplacementVertical > max_mot)
                    {
                        flag = false;
                    }
                    if (vecteur.Axe == 0 && une_case.EmplacementHorizontal < min_mot && une_case.EmplacementHorizontal > max_mot)
                    {
                        flag = false;
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("Certaines de ces lettres ne se touchent pas.");
                }
                else
                {
                    AjouterUnMot(min_mot, max_mot, vecteur.Axe, vecteur.Indice);
                }
            }
            return flag;
        }

        bool check4()
        {
            bool flag = false;
            /* check 4: Verifier que les lettres a valider, touche au moins une autre lettre deja posee, sauf si 1er tour */
            if (Etat != 0)
            {
                /* pour chaque jeton posee, si au moins un des ses 4 emplacements conjoints stocke une lettre deja posee, alors flag passe a vrai*/
                for (int i = 0; i < compteur_JV; i++)
                {
                    bool flag1 = false;
                    bool flag2 = false;
                    bool flag3 = false;
                    bool flag4 = false;
                    /* check sur les emplacements adjacents*/
                    if (jetonsAValider[i].EmplacementHorizontal>0)
                    {
                        if (VraiPlateau[jetonsAValider[i].EmplacementHorizontal - 1, jetonsAValider[i].EmplacementVertical].EtatValide)
                        {
                            flag1 = true;
                        }
                    }
                    if (jetonsAValider[i].EmplacementVertical>0)
                    {
                        if (VraiPlateau[jetonsAValider[i].EmplacementHorizontal, jetonsAValider[i].EmplacementVertical - 1].EtatValide)
                        {
                            flag2 = true;
                        }
                    }
                    if (jetonsAValider[i].EmplacementHorizontal < 14)
                    {
                        if (VraiPlateau[jetonsAValider[i].EmplacementHorizontal + 1, jetonsAValider[i].EmplacementVertical].EtatValide)
                        {
                            flag3 = true;
                        }
                    }
                    if (jetonsAValider[i].EmplacementVertical < 14)
                    {
                        if (VraiPlateau[jetonsAValider[i].EmplacementHorizontal, jetonsAValider[i].EmplacementVertical + 1].EtatValide)
                        {
                            flag3 = true;
                        }
                    }
                    if ( flag1|| flag2 || flag3 || flag4)
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                flag = true;
            }
            if (!flag)
            {
                MessageBox.Show("Le mot forme ne touche pas une lettre deja posee.");
            }
            return flag;
        }

        bool check5()
        {
            int i;
            bool flag = true;
            /* check 5: Verifier que le bonus n'est pas dans le dernier mot joue*/
            /* Comme on ne veut pas se retrouver dans la situation où le joueur n'a plus qu'un bonus sur son chevalet a joueur (il se retrouverait coincer), il faut interdire un coup qui amene a cette configuration :
             - 1 : il n'y a plus qu'un JOKER sur le chevalet + il n'y a plus de jetons dans la pioche
             - 2 : il ne reste plus de jetons sur le chevalet + un des jetons a valider est un JOKER
             > le coup n'est pas valide*/

            if (joueurActif.Nbre_jetons_sur_chevalet == 1 && maClasseGlobale.CompteurJetons == 0)
            {
                for (i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
                {
                    Case une_case = (Case)ChevaletAffichage.Controls[i];
                    if (joueurActif.VraiChevalet[i].Code == 0 && une_case.Image != null)
                    {
                        flag = false;
                    }
                }
            }
            if (joueurActif.Nbre_jetons_sur_chevalet == 0 && maClasseGlobale.CompteurJetons == 0)
            {
                for (i = 0; i < compteur_JV; i++)
                {
                    if (jetonsAValider[i].Code == 0)
                    {
                        flag = false;
                    }
                }
            }
            if (!flag)
            {
                MessageBox.Show("Le dernier mot ne peut contenir un JOKER");
            }
            return flag;
        }

        void IdentifierAutresMots()
        {
            int i, min_mot, max_mot;
            for (i = 0; i < compteur_JV; i++)
            {
                if (vecteur.Axe==0)
                {
                    min_mot = jetonsAValider[i].EmplacementHorizontal;
                }
                else
                {
                    min_mot = jetonsAValider[i].EmplacementVertical;
                }
                /* INITIALISATION des limites du nouveau mot pose */
                max_mot = min_mot;
                /* puis je regarde si je peux faire descendre/monter min_mot/max_mot */
                if (vecteur.Axe == 0)
                {
                    while (min_mot > 0 && VraiPlateau[min_mot - 1,jetonsAValider[i].EmplacementVertical].Code>-1)
                    {
                        min_mot--;
                    }
                    while (max_mot < 14 && VraiPlateau[max_mot + 1, jetonsAValider[i].EmplacementVertical].Code > -1)
                    {
                        max_mot++;
                    }
                    if (max_mot != min_mot)
                    {
                        AjouterUnMot(min_mot, max_mot, 1, jetonsAValider[i].EmplacementVertical);
                    }
                }
                else
                {
                    while (min_mot > 0 && VraiPlateau[jetonsAValider[i].EmplacementHorizontal, min_mot - 1].Code > -1)
                    {
                        min_mot--;
                    }
                    while (max_mot < 14 && VraiPlateau[jetonsAValider[i].EmplacementHorizontal, max_mot + 1].Code > -1)
                    {
                        max_mot++;
                    }
                    if (max_mot != min_mot)
                    {
                        AjouterUnMot(min_mot, max_mot, 0, jetonsAValider[i].EmplacementHorizontal);
                    }
                }
            }
        }

        void IdentifierMots()
        {
            int min_mot, max_mot;
            /* je regarde en horizontal */
            min_mot = jetonsAValider[0].EmplacementVertical;
            max_mot = min_mot;
            while (min_mot > 0 && VraiPlateau[jetonsAValider[0].EmplacementHorizontal, min_mot - 1].Code > -1)
            {
                min_mot--;
            }
            while (max_mot < 14 && VraiPlateau[jetonsAValider[0].EmplacementHorizontal, max_mot + 1].Code > -1)
            {
                max_mot++;
            }
            if (max_mot != min_mot)
            {
                AjouterUnMot(min_mot, max_mot, 0, jetonsAValider[0].EmplacementHorizontal);
            }
            /* je regarde en vertical*/
            min_mot = jetonsAValider[0].EmplacementHorizontal;
            max_mot = min_mot;
            while (min_mot > 0 && VraiPlateau[min_mot - 1, jetonsAValider[0].EmplacementVertical].Code > -1)
            {
                min_mot--;
            }
            while (max_mot < 14 && VraiPlateau[max_mot + 1, jetonsAValider[0].EmplacementVertical].Code > -1)
            {
                max_mot++;
            }
            if (max_mot != min_mot)
            {
                AjouterUnMot(min_mot, max_mot, 1, jetonsAValider[0].EmplacementVertical);
            }
        }

        void AjouterUnMot(int min_mot, int max_mot, int axe, int ind)
        {
            int i, Bonus_mot;
            /* on a identifie le nouveau mot forme, on l'ajoute au tableau*/
            MotForme un_mot = new MotForme() { Longueur = max_mot - min_mot + 1 , ScoreBonus = 0, ScoreBrut = 0, Auteur = joueurActif.Nom};
            List<Lettre> lettres = new List<Lettre>();

            Bonus_mot = 0;
            for (i = 0; i < un_mot.Longueur; i++)
            {
                Lettre une_lettre = new Lettre();
                if (axe==1)
                {
                    une_lettre.LignCase = min_mot + i;
                    une_lettre.ColCase = ind;
                    une_lettre.Valeur = VraiPlateau[min_mot + i,ind].Valeur;
                    un_mot.Libelle += VraiPlateau[min_mot + i,ind].Caractere;
                }
                else
                {
                    une_lettre.LignCase = ind;
                    une_lettre.ColCase = min_mot + i;
                    une_lettre.Valeur = VraiPlateau[ind, min_mot + i].Valeur;
                    un_mot.Libelle += VraiPlateau[ind,min_mot + i].Caractere;
                }

                un_mot.ScoreBrut += une_lettre.Valeur;

                /*  s'il s'agit d'une lettre deja valide, mettre 0 et 1 */
                if (VraiPlateau[une_lettre.LignCase, une_lettre.ColCase].EtatValide)
                {
                    une_lettre.TypeBonus = 0;
                    une_lettre.Bonus = 1;
                }
                else
                {
                    /*test sur la Valeur de la case : 0 à 5  */
                    if (VraiPlateau[une_lettre.LignCase, une_lettre.ColCase].Bonus == 0)
                    {
                        une_lettre.TypeBonus = 0;
                        une_lettre.Bonus = 1;
                    }
                    else
                    {
                        /*si 1 ou 2, Bonus sur lettre */
                        if (VraiPlateau[une_lettre.LignCase, une_lettre.ColCase].Bonus < 3)
                        {
                            une_lettre.TypeBonus = 1;
                        }
                        /*si 3, 4 ou 5, Bonus sur mot */
                        else
                        {
                            une_lettre.TypeBonus = 2;
                        }
                        /*si 2 ou 4, Bonus triple */
                        if (VraiPlateau[une_lettre.LignCase, une_lettre.ColCase].Bonus == 2 || VraiPlateau[une_lettre.LignCase, une_lettre.ColCase].Bonus == 4)
                        {
                            une_lettre.Bonus = 3;
                        }
                        /*sinon, Bonus double */
                        else
                        {
                            une_lettre.Bonus = 2;
                        }
                    }
                }
                if (une_lettre.TypeBonus == 2)
                {
                    Bonus_mot += une_lettre.Bonus;
                    un_mot.ScoreBonus += une_lettre.Valeur;
                }
                else
                {
                    un_mot.ScoreBonus += une_lettre.Valeur * une_lettre.Bonus;
                }
                lettres.Add(une_lettre);
            }
            if (Bonus_mot>0)
            {
                un_mot.ScoreBonus *= Bonus_mot;
            }
            un_mot.Lettres = lettres;
            motsFormes.Add(un_mot);
        }

        private void historiqueDesCoupsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form histo = new Historique();
            histo.ShowDialog();
        }

        private void statistiquesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form stats = new Stats();
            stats.ShowDialog();
        }


        private void modifierLaPiocheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var triche_pioche = new Modif_Pioche();
            triche_pioche.ShowDialog();
            textBox5.Text = maClasseGlobale.CompteurJetons.ToString();
        }

        private void modifierLePlateauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "Drag&Dropper les cases :";
            button6.Visible = true;
            foreach (Label le_label in groupBox1.Controls)
            {
                le_label.MouseDown += new MouseEventHandler(DecollageLabel);
                le_label.AllowDrop = true;
            }
            foreach (Case une_case in Plateau.Controls)
            {
                une_case.DragEnter -= new DragEventHandler(Survol);
                une_case.DragEnter += new DragEventHandler(SurvolLabel);
                une_case.DragDrop -= new DragEventHandler(Largage);
                une_case.DragDrop += new DragEventHandler(LargageLabel);
            }
            MessageBox.Show("Déplacer les carrés de couleur sur les cases du plateau via un drag&drop.");
        }

        private void DecollageLabel(object sender, MouseEventArgs e)
        {
            departLabel = (Label)sender;
            departLabel.DoDragDrop("Nada", DragDropEffects.All);
        }

        private void SurvolLabel(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void LargageLabel(object sender, DragEventArgs e)
        {
            l = (Case)sender;
            l.Bonus = Convert.ToInt32(departLabel.Tag);
            switch (l.Bonus)
            {
                case 1:
                    l.BackColor = Color.LightSkyBlue;
                    break;
                case 2:
                    l.BackColor = Color.RoyalBlue;
                    break;
                case 3:
                    l.BackColor = Color.LightPink;
                    break;
                case 4:
                    l.BackColor = Color.Red;
                    break;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Label le_label in groupBox1.Controls)
            {
                le_label.MouseDown -= new MouseEventHandler(DecollageLabel);
                le_label.AllowDrop = false;
            }
            foreach (Case une_case in Plateau.Controls)
            {
                une_case.DragEnter += new DragEventHandler(Survol);
                une_case.DragEnter -= new DragEventHandler(SurvolLabel);
                une_case.DragDrop += new DragEventHandler(Largage);
                une_case.DragDrop -= new DragEventHandler(LargageLabel);
            }
            groupBox1.Text = "Legende";
            button6.Visible = false;
        }

        private void Sauvegarder()
        {
            PartieSave partie = new PartieSave();
            partie.Etat = Etat;
            partie.CompteurJetons = maClasseGlobale.CompteurJetons;
            partie.CompteurPasse = CompteurPasse;
            partie.CompteurTours = CompteurTours;
            partie.Historique = Historique;
            partie.JoueurActif = JoueurActif;
            //partie.joueurs = joueurs;
            //partie.MotsValides = maClasseGlobale.MotsValides;
            partie.pioche = maClasseGlobale.pioche;
            //partie.VraiPlateau = VraiPlateau;
            //partie.Test = new List<Jeton>();
            partie.Save("test.xml");
            //if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            //{
              //  partie.Save(saveFileDialog1.FileName);
            //}
        }

        private void règlesDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var regle = new Regles();
            regle.ShowDialog();
        }

        private void quitterLaPartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void majChevalet()
        {
            for (int i = 0; i < maClasseGlobale.Capacite_Chevalet; i++)
            {
                // création d'un nouveau contrôle
                Case une_case = new Case();
                // rattachement du contrôle au Chevalet
                ChevaletAffichage.Controls.Add(une_case);
                // propriete des cases
                une_case.Code = joueurActif.VraiChevalet[i].Code;
                une_case.Caractere = joueurActif.VraiChevalet[i].Caractere;
                une_case.Valeur = joueurActif.VraiChevalet[i].Valeur;
                une_case.Bonus = 6;
                une_case.BackColor = Color.Black;
                if (une_case.Code == -1)
                {
                    une_case.Image = null;
                    une_case.BackColor = Color.White;
                }
                else
                {
                    if (maClasseGlobale.Langue == 0)
                    {
                        une_case.Image = ListFR.Images[une_case.Code];
                    }
                    else
                    {
                        une_case.Image = ListEN.Images[une_case.Code];
                    }
                }
                une_case.EmplacementHorizontal = i + 1;
                une_case.AutoSize = false;
                une_case.Width = maClasseGlobale.Lgr_case;
                une_case.Height = maClasseGlobale.Lgr_case;
                une_case.Left = maClasseGlobale.Lgr_case / 6 + i * (maClasseGlobale.Lgr_case + maClasseGlobale.Lgr_case / 6);
                une_case.Top = maClasseGlobale.Lgr_case / 6;
                une_case.MouseDown += new MouseEventHandler(Decollage);
            }
        }
    }
}

