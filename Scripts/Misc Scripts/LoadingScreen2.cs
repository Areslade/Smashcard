using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Display a loading screen instead of freezing the game until the next level is loaded.
/// </summary>
public class LoadingScreen2 : MonoBehaviour {
    public Sprite[] frames;
    int totalFrames;
    int currentFrame;
    float timer;

	// Use this for initialization
	void Start () {
        currentFrame = 0;
        totalFrames = frames.Length;
        timer = Time.time;
        GetComponent<Image>().sprite = frames[currentFrame];

        Invoke("StartLoading", 1.5f);
    }

    void StartLoading()
    {
        StartCoroutine(DisplayLoadingScreen());
       
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.time > timer + 0.05)
        {
            if(currentFrame == totalFrames-1)
            {
                currentFrame = 0;
            }
            else  //plays the animation for the loading screen, updating every 0.05 seconds
            { 
                currentFrame++;
            }

            GetComponent<Image>().sprite = frames[currentFrame];

            timer = Time.time;
        }
	}

    IEnumerator DisplayLoadingScreen()
    {
        //Application.backgroundLoadingPriority = ThreadPriority.Low; 
        AsyncOperation async = Application.LoadLevelAsync(Application.loadedLevel + 1);
         yield return async;     //loads the next level in the background, allowing the animation to play, then loading it when it's done.
        
    }
}