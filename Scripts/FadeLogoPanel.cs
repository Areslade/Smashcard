using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeLogoPanel : MonoBehaviour {

    public GameObject logoPanel;
    public GameObject logo;
    public GameObject companyPanel;
    public GameObject obMonkey;
    public GameObject namco;
    public Text copyrightText;

    public Image namcoImage;
    public Image obmonketImage;
    public Image companyPanelImage;
    public Image myPanel;
    
    public RawImage movie; 
    float fadeTime = 2f;
    Color colorToFadeTo;

    float timeStamp;
    // Use this for initialization
    void Start()
    {
        timeStamp = Time.time;
        
    }

    // Update is called once per frame
    void Update ()
    {
	    if (Time.time > timeStamp + 4)
        {
            myPanel = logoPanel.GetComponent<Image>();
            movie = logo.GetComponent<RawImage>();
            namcoImage = namco.GetComponent<Image>();
            obmonketImage = obMonkey.GetComponent<Image>();
            companyPanelImage = companyPanel.GetComponent<Image>();
            colorToFadeTo = new Color(1f, 1f, 1f, 0f);
            
            movie.CrossFadeColor(colorToFadeTo, 0.2f, true, true);
            myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
        }

        if(Time.time > timeStamp + 8)
        {
            companyPanelImage.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
            namcoImage.CrossFadeColor(colorToFadeTo, 0.2F, true, true);
            obmonketImage.CrossFadeColor(colorToFadeTo, 0.2F, true, true);
            copyrightText.CrossFadeAlpha(0.0f, 0.2f,true);
        }
        if (Time.time > timeStamp + 11)
        {
            logoPanel.SetActive(false);
            companyPanel.SetActive(false);
        }

    }
}
