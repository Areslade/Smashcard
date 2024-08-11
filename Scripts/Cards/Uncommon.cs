using UnityEngine;
using System.Collections;

public class Uncommon : MonoBehaviour {

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
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



    }

    public string FindCard(string name, string variable)
    {
        //from within another script call this script when looking for the stats of a character, or the path to the image
        //the first variable your send in is the name, the second is what youre looking for
        //calling it like gameObject.GetComponent<Uncommon>().FindCard("mario", "attack") will return you a string equal to 70;
        //When you get this variable back, you must make sure you cast it appopriately. In this case, you must parse the attack string to an int
        //if you want to use it to compare to another stat. 
        switch (name)
        {
            case "bowser":
                attack = 80;
                toughness = 84;
                grab = 60;
                shield = 61;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Bowser/bowserUncommon";

                break;

            case "bowserjr":
                attack = 75;
                toughness = 70;
                grab = 64;
                shield = 70;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 55;
                imagePath = "Card Images/Bowser Jr/bowserjrUncommon";
                break;

            case "falcon":
                attack = 75;
                toughness = 71;
                grab = 71;
                shield = 71;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Capt. Falcon/falconUncommon";

                break;

            case "charizard":
                attack = 75;
                toughness = 76;
                grab = 69;
                shield = 70;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Charizard/charizardUncommon";
                break;

            case "darkpit":
                attack = 76;
                toughness = 71;
                grab = 71;
                shield = 75;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Dark Pit/darkPitUncommon";
                break;

            case "deedeedee":
                attack = 80;
                toughness = 79;
                grab = 63;
                shield = 62;

                atkBonus = 5;
                toughBonus = 62;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/DeeDeeDee/deedeedeeUncommon";
                break;

            case "diddy":
                attack = 68;
                toughness = 68;
                grab = 75;
                shield = 75;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 5;
                imagePath = "Card Images/Diddy/diddyUncommon";
                break;

            case "donkey":
                attack = 75;
                toughness = 75;
                grab = 67;
                shield = 67;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Donkey Kong/donkeykongUncommon";
                break;

            case "drmario":
                attack = 70;
                toughness = 75;
                grab = 66;
                shield = 72;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/DrMario/drmarioUncommon";
                break;

            case "duckhunt":
                attack = 70;
                toughness = 73;
                grab = 69;
                shield = 70;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/DuckHunt/duckhuntUncommon";
                break;

            case "falco":
                attack = 77;
                toughness = 65;
                grab = 77;
                shield = 65;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Falco/falcoUncommon";
                break;

            case "fox":
                attack = 65;
                toughness = 77;
                grab = 65;
                shield = 77;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Fox/foxUncommon";
                break;

            case "gamewatch":
                attack = 75;
                toughness = 73;
                grab = 67;
                shield = 72;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Game&Watch/gamewatchUncommon";
                break;

            case "ganondorf":
                attack = 77;
                toughness = 74;
                grab = 66;
                shield = 70;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Gannondorf/gannondorfUncommon";
                break;

            case "greninja":
                attack = 75;
                toughness = 68;
                grab = 66;
                shield = 78;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Greninja/greninjaUncommon";
                break;

            case "ike":
                attack = 78;
                toughness = 75;
                grab = 65;
                shield = 71;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Ike/ikeUncommon";
                break;

            case "jigglypuff":
                attack = 74;
                toughness = 63;
                grab = 79;
                shield = 69;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Jigglypuff/jigglypuffUncommon";
                break;

            case "kirby":
                attack = 67;
                toughness = 73;
                grab = 76;
                shield = 68;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Kirby/kirbyUncommon";
                break;

            case "link":
                attack = 68;
                toughness = 67;
                grab = 74;
                shield = 74;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Link/linkUncommon";
                break;

            case "littlemac":
                attack = 83;
                toughness = 64;
                grab = 68;
                shield = 69;

                atkBonus = 7;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/LittleMac/littlemacUncommon";
                break;

            case "lucario":
                attack = 74;
                toughness = 65;
                grab = 68;
                shield = 73;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Lucario/lucarioUncommon";
                break;

            case "lucina":
                attack = 71;
                toughness = 71;
                grab = 70;
                shield = 73;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Lucina/lucinaUncommon";
                break;

            case "luigi":
                attack = 74;
                toughness = 69;
                grab = 70;
                shield = 71;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 5;
                imagePath = "Card Images/Luigi/luigiUncommon";

                break;

            case "mario":
                attack = 75;
                toughness = 72;
                grab = 66;
                shield = 70;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Mario/marioUncommon";
                break;

            case "marth":
                attack = 72;
                toughness = 69;
                grab = 66;
                shield = 77;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Marth/marthUncommon";
                break;

            case "megaman":
                attack = 74;
                toughness = 72;
                grab = 68;
                shield = 69;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/MegaMan/megamanUncommon";
                break;

            case "metaknight":
                attack = 74;
                toughness = 67;
                grab = 69;
                shield = 73;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/MetaKnight/metaknightUncommon";
                break;

            case "ness":
                attack = 70;
                toughness = 67;
                grab = 70;
                shield = 78;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Ness/nessUncommon";
                break;

            case "olimar":
                attack = 68;
                toughness = 68;
                grab = 78;
                shield = 70;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 5;
                imagePath = "Card Images/Olimar/olimarUncommon";
                break;

            case "pacman":
                attack = 71;
                toughness = 71;
                grab = 71;
                shield = 71;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/PacMan/pacmanUncommon";
                break;

            case "palutena":
                attack = 75;
                toughness = 65;
                grab = 65;
                shield = 74;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Palutena/palutenaUncommon";
                break;

            case "peach":
                attack = 69;
                toughness = 65;
                grab = 74;
                shield = 75;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 5;
                imagePath = "Card Images/Peach/peachUncommon";
                break;

            case "pikachu":
                attack = 69;
                toughness = 70;
                grab = 79;
                shield = 68;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Pikachu/pikachuUncommon";
                break;

            case "pit":
                attack = 72;
                toughness = 73;
                grab = 69;
                shield = 71;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Pit/PitUncommon";
                break;

            case "rob":
                attack = 74;
                toughness = 70;
                grab = 68;
                shield = 71;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Rob/robUncommon";
                break;

            case "robin":
                attack = 71;
                toughness = 73;
                grab = 70;
                shield = 71;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Robin/robinUncommon";
                break;

            case "rosalina":
                attack = 73;
                toughness = 69;
                grab = 75;
                shield = 68;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Rosalina/rosalinaUncommon";
                break;

            case "samus":
                attack = 75;
                toughness = 72;
                grab = 68;
                shield = 70;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Samus/samusUncommon";
                break;

            case "shiek":
                attack = 76;
                toughness = 66;
                grab = 67;
                shield = 71;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Shiek/shiekUncommon";
                break;

            case "shulk":
                attack = 75;
                toughness = 75;
                grab = 65;
                shield = 70;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Shulk/shulkUncommon";
                break;

            case "sonic":
                attack = 64;
                toughness = 70;
                grab = 75;
                shield = 75;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Sonic/sonicUncommon";
                break;

            case "toonlink":
                attack = 70;
                toughness = 64;
                grab = 72;
                shield = 76;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Toon Link/toonLinkUncommon";
                break;

            case "villager":
                attack = 77;
                toughness = 76;
                grab = 66;
                shield = 69;

                atkBonus = 5;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Villager/villagerUncommon";
                break;

            case "wario":
                attack = 69;
                toughness = 75;
                grab = 71;
                shield = 66;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Wario/warioUncommon";
                break;

            case "wiifit":
                attack = 71;
                toughness = 73;
                grab = 69;
                shield = 72;

                atkBonus = 0;
                toughBonus = 5;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Wii Fit Trainer/wiifitUncommon";
                break;

            case "yoshi":
                attack = 69;
                toughness = 69;
                grab = 76;
                shield = 70;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 5;
                imagePath = "Card Images/Yoshi/yoshiUncommon";
                break;
            case "zelda":
                attack = 75;
                toughness = 66;
                grab = 68;
                shield = 75;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 5;
                imagePath = "Card Images/Zelda/zeldaUncommon";
                break;

            case "zerosuit":
                attack = 70;
                toughness = 68;
                grab = 77;
                shield = 70;

                atkBonus = 5;
                toughBonus = 0;
                grabBonus = 5;
                shieldBonus = 0;
                imagePath = "Card Images/Zero Suit Samus/zerosuitUncommon";
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
