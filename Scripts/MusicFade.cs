using UnityEngine;
using System.Collections;

public class MusicFade : MonoBehaviour 
{

    AudioSource player;
    AudioClip menuSong;
    public int loopcount = 100;
    public static bool fadeMusic = false;

	// Use this for initialization
	void Start () 
    {
        
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        menuSong = Resources.Load<AudioClip>("Menu 2 (Melee)") as AudioClip;


        fadeMusic = false;
        player.volume = 1;
        player.clip = menuSong;
        player.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (fadeMusic)
        {
            MakeMusicFade();
        }
        if(player.volume <= 0.05f)
        {
            fadeMusic = false;
            player.volume = 0;
        }
	}

    void MakeMusicFade()
    {
        player.volume = Mathf.Lerp(player.volume, 0, Time.deltaTime * 1.3f);   
    }
}
