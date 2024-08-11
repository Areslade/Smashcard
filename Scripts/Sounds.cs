using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sounds : MonoBehaviour 
{

    Sprite[] backgrounds = new Sprite[7];
    AudioClip[] backgroundMusic = new AudioClip[7];
    AudioClip[] countdown = new AudioClip[4];
    AudioSource player;
    int playSong;
    float timeStamp;
    int playSound;
    public Image backGround;
    int random;
    public string[] songNames = new string[7];

	// Use this for initialization
	void Start () 
    {
        backGround = GameObject.FindGameObjectWithTag("backgroundImage").GetComponent<Image>();
        random = Random.Range(0, backgrounds.Length);

        

        backgrounds[0] = Resources.Load<Sprite>("Backgrounds/2980051-gameplay_supersmashbros_midgarstage_20151214a") as Sprite;
        backgrounds[1] = Resources.Load<Sprite>("Backgrounds/battlefield") as Sprite;
        backgrounds[2] = Resources.Load<Sprite>("Backgrounds/mainbackground") as Sprite;
        backgrounds[3] = Resources.Load<Sprite>("Backgrounds/PokemonStadium2Anarchy") as Sprite;
        backgrounds[4] = Resources.Load<Sprite>("Backgrounds/SSBWU_Onett") as Sprite;
        backgrounds[5] = Resources.Load<Sprite>("Backgrounds/WiiU_SuperSmashBros_Stage03_Screen_01") as Sprite;
        backgrounds[6] = Resources.Load<Sprite>("Backgrounds/WiiU_SuperSmashBros_Stage05_Screen_01") as Sprite;

        backGround.GetComponent<Image>().sprite = backgrounds[random];
        backGround.GetComponent<Image>().overrideSprite = backgrounds[random];

        countdown[0] = Resources.Load<AudioClip>("3") as AudioClip;
        countdown[1] = Resources.Load<AudioClip>("2") as AudioClip;
        countdown[2] = Resources.Load<AudioClip>("1") as AudioClip;
        countdown[3] = Resources.Load<AudioClip>("GO!") as AudioClip;

        songNames[0] = "Let The Battles Begin (Final Fantasy VII) - Super Smash Bros. Wii U";
        songNames[1] = "Battlefield (Brawl)";
        songNames[2] = "Final Destination (Melee)";
        songNames[3] = "Pokémon Stadium 2";
        songNames[4] = "Onett";
        songNames[5] = "Psycho Bits";
        songNames[6] = "Thunder Cloud Temple";

        //backgroundMusic[0] = Resources.Load<AudioClip>("Let The Battles Begin (Final Fantasy VII) - Super Smash Bros. Wii U") as AudioClip;
        //backgroundMusic[1] = Resources.Load<AudioClip>("Battlefield (Brawl)") as AudioClip;
        //backgroundMusic[2] = Resources.Load<AudioClip>("Final Destination (Melee)") as AudioClip;
        //backgroundMusic[3] = Resources.Load<AudioClip>("Pokémon Stadium 2") as AudioClip;
        //backgroundMusic[4] = Resources.Load<AudioClip>("Onett") as AudioClip;
        //backgroundMusic[5] = Resources.Load<AudioClip>("Psycho Bits") as AudioClip;
        //backgroundMusic[6] = Resources.Load<AudioClip>("Thunder Cloud Temple") as AudioClip;
        //backgroundMusic[0] = Resources.Load<AudioClip>(songNames[random]) as AudioClip;

        backgroundMusic[random] = Resources.Load<AudioClip>(songNames[random]) as AudioClip;

        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        player.clip = countdown[0];
        player.Play();
        timeStamp = Time.time;
        playSound = 3;
        
        


	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.time > (timeStamp + 1) && playSound == 3)
        {
            player.clip = countdown[1];
            player.Play();
            timeStamp = Time.time;
            playSound = 2;
        }
        if (Time.time > (timeStamp + 1) && playSound == 2)
        {
            player.clip = countdown[2];
            player.Play();
            timeStamp = Time.time;
            playSound = 1;
        }
        if (Time.time > (timeStamp + 1) && playSound == 1)
        {
            player.clip = countdown[3];
            player.Play();
            timeStamp = Time.time;
            playSound = 0;
        }
        if (Time.time > (timeStamp + 1) && playSound == 0)
        {
            player.clip = backgroundMusic[random];
            player.Play();
            playSound = 4;
        }
	}
}
