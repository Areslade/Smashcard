using UnityEngine;
using System.Collections;

public class Common : MonoBehaviour {

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
        //calling it like .GetComponent<Common>().FindCard("mario", "attack") will return you a string equal to 70;
        //When you get this variable back, you must make sure you cast it appopriately. In this case, you must parse the attack string to an int
        //if you want to use it to compare to another stat. 
        switch (name)
        {
            case "bowser":
                attack = 74;
                toughness = 78;
                grab = 55;
                shield = 56;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Bowser/bowserCommon";

                break;

            case "bowserjr":
                attack = 70;
                toughness = 65;
                grab = 60;
                shield = 69;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Bowser Jr/bowserjrCommon";
                break;

            case "falcon":
                attack = 70;
                toughness = 66;
                grab = 66;
                shield = 66;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Capt. Falcon/falconCommon";

                break;

            case "charizard":
                attack = 71;
                toughness = 72;
                grab = 65;
                shield = 66;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Charizard/charizardCommon";
                break;

            case "darkpit":
                attack = 66;
                toughness = 66;
                grab = 66;
                shield = 70;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Dark Pit/darkPitCommon";
                break;

            case "deedeedee":
                attack = 74;
                toughness = 71;
                grab = 59;
                shield = 58;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/DeeDeeDee/deedeedeeCommon";
                break;

            case "diddy":
                attack = 63;
                toughness = 63;
                grab = 70;
                shield = 70;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Diddy/diddyCommon";
                break;

            case "donkey":
                attack = 70;
                toughness = 70;
                grab = 62;
                shield = 62;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Donkey Kong/donkeykongCommon";
                break;

            case "drmario":
                attack = 65;
                toughness = 70;
                grab = 60;
                shield = 68;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/DrMario/drmarioCommon";
                break;

            case "duckhunt":
                attack = 65;
                toughness = 67;
                grab = 65;
                shield = 66;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/DuckHunt/duckhuntCommon";
                break;

            case "falco":
                attack = 71;
                toughness = 61;
                grab = 71;
                shield = 61;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Falco/falcoCommon";
                break;

            case "fox":
                attack = 61;
                toughness = 71;
                grab = 61;
                shield = 71;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Fox/foxCommon";
                break;

            case "gamewatch":
                attack = 70;
                toughness = 68;
                grab = 62;
                shield = 65;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Game&Watch/gamewatchCommon";
                break;

            case "ganondorf":
                attack = 73;
                toughness = 68;
                grab = 61;
                shield = 65;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Gannondorf/gannondorfCommon";
                break;

            case "greninja":
                attack = 71;
                toughness = 64;
                grab = 62;
                shield = 73;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Greninja/greninjaCommon";
                break;

            case "ike":
                attack = 71;
                toughness = 68;
                grab = 62;
                shield = 68;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Ike/ikeCommon";
                break;

            case "jigglypuff":
                attack = 70;
                toughness = 59;
                grab = 73;
                shield = 65;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Jigglypuff/jigglypuffCommon";
                break;

            case "kirby":
                attack = 62;
                toughness = 68;
                grab = 70;
                shield = 64;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Kirby/kirbyCommon";
                break;

            case "link":
                attack = 60;
                toughness = 62;
                grab = 68;
                shield = 66;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Link/linkCommon";
                break;

            case "littlemac":
                attack = 78;
                toughness = 59;
                grab = 63;
                shield = 64;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/LittleMac/littlemacCommon";
                break;

            case "lucario":
                attack = 70;
                toughness = 64;
                grab = 64;
                shield = 68;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Lucario/lucarioCommon";
                break;

            case "lucina":
                attack = 66;
                toughness = 65;
                grab = 65;
                shield = 68;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Lucina/lucinaCommon";
                break;

            case "luigi":
                attack = 67;
                toughness = 64;
                grab = 64;
                shield = 66;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Luigi/luigiCommon";

                break;

            case "mario":
                attack = 70;
                toughness = 68;
                grab = 60;
                shield = 65;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Mario/marioCommon";
                break;

            case "marth":
                attack = 68;
                toughness = 65;
                grab = 61;
                shield = 71;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Marth/marthCommon";
                break;

            case "megaman":
                attack = 68;
                toughness = 67;
                grab = 64;
                shield = 65;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/MegaMan/megamanCommon";
                break;

            case "metaknight":
                attack = 68;
                toughness = 62;
                grab = 64;
                shield = 68;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/MetaKnight/metaknightCommon";
                break;

            case "ness":
                attack = 66;
                toughness = 62;
                grab = 65;
                shield = 72;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Ness/nessCommon";
                break;

            case "olimar":
                attack = 64;
                toughness = 64;
                grab = 72;
                shield = 64;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Olimar/olimarCommon";
                break;

            case "pacman":
                attack = 66;
                toughness = 66;
                grab = 66;
                shield = 66;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/PacMan/pacmanCommon";
                break;

            case "palutena":
                attack = 70;
                toughness = 60;
                grab = 61;
                shield = 68;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Palutena/palutenaCommon";
                break;

            case "peach":
                attack = 65;
                toughness = 61;
                grab = 68;
                shield = 69;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Peach/peachCommon";
                break;

            case "pikachu":
                attack = 64;
                toughness = 65;
                grab = 73;
                shield = 65;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Pikachu/pikachuCommon";
                break;

            case "pit":
                attack =67;
                toughness = 68;
                grab = 64;
                shield = 66;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Pit/PitCommon";
                break;

            case "rob":
                attack = 69;
                toughness = 66;
                grab = 62;
                shield = 66;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Rob/robCommon";
                break;

            case "robin":
                attack = 66;
                toughness = 68;
                grab = 64;
                shield = 66;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Robin/robinCommon";
                break;

            case "rosalina":
                attack = 77;
                toughness = 63;
                grab = 69;
                shield = 63;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Rosalina/rosalinaCommon";
                break;

            case "samus":
                attack = 70;
                toughness = 67;
                grab = 63;
                shield = 64;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Samus/samusCommon";
                break;

            case "shiek":
                attack = 63;
                toughness = 60;
                grab = 66;
                shield = 66;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Shiek/shiekCommon";
                break;

            case "shulk":
                attack = 70;
                toughness = 70;
                grab = 60;
                shield = 66;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Shulk/shulkCommon";
                break;

            case "sonic":
                attack = 60;
                toughness = 65;
                grab = 70;
                shield = 70;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 3;
                imagePath = "Card Images/Sonic/sonicCommon";
                break;

            case "toonlink":
                attack = 63;
                toughness = 60;
                grab = 66;
                shield = 66;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Toon Link/toonLinkCommon";
                break;

            case "villager":
                attack = 72;
                toughness = 70;
                grab = 62;
                shield = 64;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Villager/villagerCommon";
                break;

            case "wario":
                attack = 65;
                toughness = 69;
                grab = 66;
                shield = 62;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Wario/warioCommon";
                break;

            case "wiifit":
                attack = 66;
                toughness = 68;
                grab = 64;
                shield = 67;

                atkBonus = 0;
                toughBonus = 3;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Wii Fit Trainer/wiifitCommon";
                break;

            case "yoshi":
                attack = 64;
                toughness = 64;
                grab = 70;
                shield = 65;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Yoshi/yoshiCommon";
                break;
            case "zelda":
                attack = 70;
                toughness = 65;
                grab = 61;
                shield = 70;

                atkBonus = 3;
                toughBonus = 0;
                grabBonus = 0;
                shieldBonus = 0;
                imagePath = "Card Images/Zelda/zeldaCommon";
                break;

            case "zerosuit":
                attack = 65;
                toughness = 63;
                grab = 72;
                shield = 65;

                atkBonus = 0;
                toughBonus = 0;
                grabBonus = 3;
                shieldBonus = 0;
                imagePath = "Card Images/Zero Suit Samus/zerosuitCommon";
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
