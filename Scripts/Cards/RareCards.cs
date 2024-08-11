using UnityEngine;
using System.Collections;

public class RareCards : MonoBehaviour {

    public int attack;
    public int toughness;
    public int grab;
    public int shield;
    public string characterName;

    public int atkBonus;
    public int toughBonus;
    public int grabBonus;
    public int shieldBonus;

    public string imagePath;

    // Use this for initialization
    void Start ()
    {


	
	}
	
	// Update is called once per frame
	void Update ()
    {
	


	}

    public string FindCard(string name, string variable)
    {
        //from within another script call this script when looking for the stats of a character, or the path to the image
        //the first variable your send in is the name, the second is what youre looking for
        //calling it like .GetComponent<Common>().FindCard("mario", "attack") will return you a string equal to 70;
        //When you get this variable back, you must make sure you cast it appopriately. In this case, you must parse the attack string to an int
        //if you want to use it to compare to another stat. 
        switch (name)
        {
            case "bayonetta":
                attack = 75;
                toughness = 85;
                grab = 75;
                shield = 70;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 15;
                shieldBonus = 0;
                imagePath = "Card Images/Bayonetta/bayonettaUnique";

                break;

            case "bowser":
                attack = 85;
                toughness = 89;
                grab = 64;
                shield = 66;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Bowser/bowserRare";

                break;

            case "bowserjr":
                attack = 78;
                toughness = 78;
                grab = 66;
                shield = 79;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Bowser Jr/bowserjrRare";
                break;

            case "falcon":
                attack = 80;
                toughness = 76;
                grab = 76;
                shield = 76;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Capt. Falcon/falconRare";

                break;

            case "charizard":
                attack = 80;
                toughness = 81;
                grab = 73;
                shield = 75;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Charizard/charizardRare";
                break;

            case "cloud":
                attack = 88;
                toughness = 87;
                grab = 70;
                shield = 70;

                atkBonus = 12;
                toughBonus = 12;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Cloud/CloudUnique";
                break;

            case "corrin":
                attack = 88;
                toughness = 75;
                grab = 75;
                shield = 77;

                atkBonus = 15;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Corrin/corrinUnique";
                break;

            case "darkpit":
                attack = 76;
                toughness = 76;
                grab = 76;
                shield = 80;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Dark Pit/darkPitRare";
                break;

            case "deedeedee":
                attack = 87;
                toughness = 84;
                grab = 67;
                shield = 66;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/DeeDeeDee/deedeedeeRare";
                break;

            case "diddy":
                attack = 73;
                toughness = 73;
                grab = 80;
                shield = 80;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 10;
                imagePath = "Card Images/Diddy/diddyRare";
                break;

            case "donkey":
                attack = 80;
                toughness = 80;
                grab = 72;
                shield = 72;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Donkey Kong/donkeykongRare";
                break;

            case "drmario":
                attack = 74;
                toughness = 80;
                grab = 71;
                shield = 76;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/DrMario/drmarioRare";
                break;

            case "duckhunt":
                attack = 75;
                toughness = 78;
                grab = 75;
                shield = 74;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/DuckHunt/duckhuntRare";
                break;

            case "falco":
                attack = 82;
                toughness = 71;
                grab = 82;
                shield = 71;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Falco/falcoRare";
                break;

            case "fox":
                attack = 71;
                toughness = 82;
                grab = 71;
                shield = 82;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Fox/foxRare";
                break;

            case "gamewatch":
                attack = 80;
                toughness = 79;
                grab = 72;
                shield = 76;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Game&Watch/gamewatchRare";
                break;

            case "ganondorf":
                attack = 88;
                toughness = 83;
                grab = 70;
                shield = 71;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Gannondorf/gannondorfRare";
                break;

            case "greninja":
                attack = 79;
                toughness = 73;
                grab = 70;
                shield = 84;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Greninja/greninjaRare";
                break;

            case "ike":
                attack = 87;
                toughness = 82;
                grab = 69;
                shield = 74;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Ike/ikeRare";
                break;

            case "jigglypuff":
                attack = 79;
                toughness = 67;
                grab = 85;
                shield = 74;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Jigglypuff/jigglypuffRare";
                break;

            case "kirby":
                attack = 72;
                toughness = 78;
                grab = 81;
                shield = 73;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Kirby/kirbyRare";
                break;
   
            case "link":
                attack = 73;
                toughness = 71;
                grab = 81;
                shield = 80;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Link/linkRare";
                break;

            case "littlemac":
                attack = 88;
                toughness = 69;
                grab = 72;
                shield = 73;

                atkBonus = 12;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/LittleMac/littlemacRare";
                break;

            case "lucario":
                attack = 80;
                toughness = 70;
                grab = 73;
                shield = 79;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Lucario/lucarioRare";
                break;

            case "lucas":
                attack = 74;
                toughness = 74;
                grab = 78;
                shield = 88;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 15;
                imagePath = "Card Images/Lucas/lucasUnique";
                break;

            case "lucina":
                attack = 77;
                toughness = 75;
                grab = 75;
                shield = 79;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Lucina/lucinaRare";
                break;

            case "luigi":
                attack = 78;
                toughness = 73;
                grab = 75;
                shield = 76;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 10;
                imagePath = "Card Images/Luigi/luigiRare";

                break;

            case "mario":
                attack = 80;
                toughness = 76;
                grab = 71;
                shield = 74;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Mario/marioRare";
                break;

            case "marth":
                attack = 78;
                toughness = 74;
                grab = 70;
                shield = 82;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Marth/marthRare";
                break;

            case "megaman":
                attack = 80;
                toughness = 77;
                grab = 72;
                shield = 74;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/MegaMan/megamanRare";
                break;

            case "metaknight":
                attack = 79;
                toughness = 72;
                grab = 74;
                shield = 78;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/MetaKnight/metaknightRare";
                break;

            case "mewtwo":
                attack = 76;
                toughness = 75;
                grab = 88;
                shield = 76;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 15;
                shieldBonus = 0;
                imagePath = "Card Images/Mewtwo/MewtwoUnique";
                break;

            case "ness":
                attack = 75;
                toughness = 72;
                grab = 74;
                shield = 84;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Ness/nessRare";
                break;

            case "olimar":
                attack = 72;
                toughness = 72;
                grab = 86;
                shield = 78;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 10;
                imagePath = "Card Images/Olimar/olimarRare";
                break;

            case "pacman":
                attack = 76;
                toughness = 76;
                grab = 76;
                shield = 76;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/PacMan/pacmanRare";
                break;

            case "palutena":
                attack = 80;
                toughness = 70;
                grab = 74;
                shield = 81;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Palutena/palutenaRare";
                break;

            case "peach":
                attack = 73;
                toughness = 70;
                grab = 80;
                shield = 81;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 10;
                imagePath = "Card Images/Peach/peachRare";
                break;

            case "pikachu":
                attack = 75;
                toughness = 76;
                grab = 86;
                shield = 70;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Pikachu/pikachuRare";
                break;

            case "pit":
                attack = 77;
                toughness = 78;
                grab = 75;
                shield = 76;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Pit/PitRare";
                break;

            case "rob":
                attack = 79;
                toughness = 75;
                grab = 73;
                shield = 77;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Rob/robRare";
                break;

            case "robin":
                attack = 76;
                toughness = 79;
                grab = 74;
                shield = 75;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Robin/robinRare";
                break;

            case "rosalina":
                attack = 77;
                toughness = 73;
                grab = 79;
                shield = 72;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Rosalina/rosalinaRare";
                break;

            case "roy":
                attack = 85;
                toughness = 75;
                grab = 70;
                shield = 85;

                atkBonus = 15;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Roy/royUnique";
                break;

            case "ryu":
                attack = 78;
                toughness = 88;
                grab = 75;
                shield = 74;

                atkBonus = 0;
                toughBonus = 15;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Ryu/ryuUnique";
                break;

            case "samus":
                attack = 80;
                toughness = 78;
                grab = 73;
                shield = 75;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Samus/samusRare";
                break;

            case "shiek":
                attack = 78;
                toughness = 79;
                grab = 75;
                shield = 74;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Shiek/shiekRare";
                break;

            case "shulk":
                attack = 80;
                toughness = 80;
                grab = 70;
                shield = 75;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Shulk/shulkRare";
                break;

            case "sonic":
                attack = 68;
                toughness = 75;
                grab = 80;
                shield = 80;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Sonic/sonicRare";
                break;

            case "toonlink":
                attack = 76;
                toughness = 70;
                grab = 78;
                shield = 82;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Toon Link/toonLinkRare";
                break;

            case "villager":
                attack = 82;
                toughness = 81;
                grab = 71;
                shield = 74;

                atkBonus = 10;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Villager/villagerRare";
                break;

            case "wario":
                attack = 74;
                toughness = 80;
                grab = 76;
                shield = 71;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Wario/warioRare";
                break;

            case "wiifit":
                attack = 76;
                toughness = 77;
                grab = 75;
                shield = 77;

                atkBonus = 0;
                toughBonus = 10;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Wii Fit Trainer/wiifitRare";
                break;

            case "yoshi":
                attack = 73;
                toughness = 73;
                grab = 85;
                shield = 75;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 10;
                imagePath = "Card Images/Yoshi/yoshiRare";
                break;
            case "zelda":
                attack = 76;
                toughness = 69;
                grab = 76;
                shield = 84;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 10;
                imagePath = "Card Images/Zelda/zeldaRare";
                break;

            case "zerosuit":
                attack = 75;
                toughness = 72;
                grab = 82;
                shield = 75;

                atkBonus = 10;
                toughBonus = 0;
                grabBonus = 10;
                shieldBonus = 0;
                imagePath = "Card Images/Zero Suit Samus/zerosuitRare";
                break;

            default:
                break;

        }

        switch (variable)
        {
            case "attack":
                variable = attack.ToString();
                break;
            case "toughness":
                variable = toughness.ToString();
                break;
            case "grab":
                variable = grab.ToString();
                break;
            case "shield":
                variable = shield.ToString();
                break;
            case "atkBonus":
                variable = atkBonus.ToString();
                break;
            case "toughBonus":
                variable = toughBonus.ToString();
                break;
            case "grabBonus":
                variable = grabBonus.ToString();
                break;
            case "shieldBonus":
                variable = shieldBonus.ToString();
                break;
            case "imagePath":
                variable = imagePath.ToString();
                break;
        }
        return variable;

    }
}
