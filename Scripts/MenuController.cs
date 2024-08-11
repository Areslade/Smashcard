using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class MenuController : MonoBehaviour
{
    /// <summary>
    /// This script is used to control the menu
    /// This scripts changes all the panels
    /// This will also generate the random cards for the player to be put into their deck.
    /// 
    /// </summary>


    public GameObject mainMenu;
    public GameObject playerCards;
    public GameObject largeCardDisplayPanel;
    public GameObject loadProfile;
    public GameObject startGamePanel;
    public GameObject challengerPanel;
    public GameObject logoImage;
    public GameObject rewardPanel;
    public GameObject replacePlayerCardPanel;
    public GameObject loadingPanel;
    public GameObject companyPanel;
    public GameObject[] opponentWins;
    public GameObject[] opponentsText = new GameObject[6];
    public GameObject[] rewards = new GameObject[9];
    public Button largeDisplayButton;
    public Button cardSelected;
    public Button cardToSee;
    public Button confirmLoad;
    public Button returnToMenu;
    public Button tempReplaceButton;
    public Button rewardCardButton;
    public Button[] playersGeneratedCards;
    public Button[] playerDeckForRewards;
    public Button[] rewardButtons;
    public Button confirmReplaceButton;
    public Button declineReplaceButton;
    public Button declineRewardButton;
    public Button backToCards;
    public string currentImage;
    public string cardName;
    public Image logo;

    public InputField loadNameField;
    public InputField playerNameField;
    public InputField setPasswordField;
    public InputField playerPasswordField;
    public Text[] opponents = new Text[6];
    public Text playerName;
    public Text loadSuccess;
    public Text nameTakenText;
    public int numberOfCharactersCompleted = 55;
    int buttonNumber = 1;
    string profileName;
    public string[] listOfCharacters;
    string rare;
    string uncommon;
    string common;
    public string passwordEntered;
    bool nameAllowed = false;
    bool getRandomCardReward = false;
    bool cardSelectedToReplace = false;
    bool nameTaken = false;
    bool passwordCorrect;
    public bool getReward = false;
    bool playerFound = false;
    public int debugButton1 = 0;
    public int debugButton2 = 0;
    public int debugButton3 = 0;

    public string nameOfRewardCard;
    public string rewardRarity;

    public string tempCardToReplace;
    public string tempCardRarity;


    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameObject.GetComponent<MenuController>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<MenuController>().enabled = true;
        }
        Application.runInBackground = true;
    }
    

    // Use this for initialization
    void Start ()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        playerCards = GameObject.FindGameObjectWithTag("PlayerCard");
        largeCardDisplayPanel = GameObject.FindGameObjectWithTag("UseCard");
        loadProfile = GameObject.FindGameObjectWithTag("LoadProfile");
        startGamePanel = GameObject.FindGameObjectWithTag("StartNew");
        challengerPanel = GameObject.FindGameObjectWithTag("Challenger");
        rewardPanel = GameObject.FindGameObjectWithTag("rewardPanel");
        replacePlayerCardPanel = GameObject.FindGameObjectWithTag("replace");
        confirmReplaceButton = GameObject.FindGameObjectWithTag("confirmReplace").GetComponent<Button>();
        declineReplaceButton = GameObject.FindGameObjectWithTag("declineReplace").GetComponent<Button>();
        declineRewardButton = GameObject.FindGameObjectWithTag("tossReward").GetComponent<Button>();
        logo = GameObject.FindGameObjectWithTag("logo").GetComponent<Image>();
        opponentWins = GameObject.FindGameObjectsWithTag("opponentWins");
        nameTakenText = GameObject.FindGameObjectWithTag("nameTaken").GetComponent<Text>();
        playerPasswordField = GameObject.FindGameObjectWithTag("loadPassword").GetComponent<InputField>();
        setPasswordField = GameObject.FindGameObjectWithTag("createPassword").GetComponent<InputField>();
        loadingPanel = GameObject.FindGameObjectWithTag("loadingPanel");
        mainMenu.SetActive(true);
        playerCards.SetActive(false);
        largeCardDisplayPanel.SetActive(false);
        loadProfile.SetActive(false);
        rewardPanel.SetActive(false);
        replacePlayerCardPanel.SetActive(false);
        startGamePanel.SetActive(false);
        playersGeneratedCards = new Button[20];
        playerDeckForRewards = new Button[20];
        loadSuccess.gameObject.SetActive(false);
        challengerPanel.SetActive(false);
        confirmReplaceButton.gameObject.SetActive(false);
        declineReplaceButton.gameObject.SetActive(false);
        nameTakenText.gameObject.SetActive(false);
        listOfCharacters = new string[numberOfCharactersCompleted];
        CharacterNames();
        //}
        Debug.Log("run start");
       // playersDeck = new List<PlayerCards>();
       
    }
    void disablePanelForReward()
    {
        confirmReplaceButton.gameObject.SetActive(false);
        declineReplaceButton.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        mainMenu.SetActive(false);
        playerCards.SetActive(false);
        largeCardDisplayPanel.SetActive(false);
        loadProfile.SetActive(false);
        startGamePanel.SetActive(false);
        replacePlayerCardPanel.SetActive(false);
        loadingPanel.SetActive(false);
        companyPanel.SetActive(false);
        loadingPanel.GetComponent<FadeLogoPanel>().enabled = false;

        for (int i = 0; i < rewards.Length; i++)
        {
            rewardButtons[i] = rewards[i].GetComponentInChildren<Button>();
            rewardButtonSetup(rewardButtons[i].GetComponent<Button>());
        }
        if (System.IO.File.Exists("Profiles.ini"))
        {
            System.IO.File.Delete("Profiles.ini");
        }
        SaveLoad.instance.levelCount = 0;
        if (getReward)
        {
            challengerPanel.SetActive(false);
            rewardPanel.SetActive(true);
        }
        else
        {
            challengerPanel.SetActive(true);
            rewardPanel.SetActive(false);
            ReloadOpponents();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!Application.runInBackground)
        {
            Application.runInBackground = true;
        }

        if (SaveLoad.instance.levelCount == 1)
        {
            //gameObject.GetComponent<MainGameControl>().enabled = true;
            gameObject.GetComponent<MenuController>().enabled = false;
        }
        if (SaveLoad.instance.levelCount == 2 && !MainGameControl.gameOver)
        {
            loadingPanel = GameObject.FindGameObjectWithTag("loadingPanel");
            companyPanel = GameObject.FindGameObjectWithTag("companyPanel");
            mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
            playerCards = GameObject.FindGameObjectWithTag("PlayerCard");
            largeCardDisplayPanel = GameObject.FindGameObjectWithTag("UseCard");
            loadProfile = GameObject.FindGameObjectWithTag("LoadProfile");
            startGamePanel = GameObject.FindGameObjectWithTag("StartNew");
            challengerPanel = GameObject.FindGameObjectWithTag("Challenger");
            rewardPanel = GameObject.FindGameObjectWithTag("rewardPanel");
            replacePlayerCardPanel = GameObject.FindGameObjectWithTag("replace");
            logoImage = GameObject.FindGameObjectWithTag("logo");
            opponentsText = GameObject.FindGameObjectsWithTag("opponent");
            rewardButtons = new Button[9];
            rewards = GameObject.FindGameObjectsWithTag("rewards");
            opponentWins = GameObject.FindGameObjectsWithTag("opponentWins");
            //playerPasswordField = GameObject.FindGameObjectWithTag("loadPassword").GetComponent<InputField>();
            //setPasswordField = GameObject.FindGameObjectWithTag("createPassword").GetComponent<InputField>();
            confirmReplaceButton = GameObject.FindGameObjectWithTag("confirmReplace").GetComponent<Button>();
            declineReplaceButton = GameObject.FindGameObjectWithTag("declineReplace").GetComponent<Button>();
            logo = logoImage.GetComponent<Image>();
            
            disablePanelForReward();
           
        }
        CheckCharacterCards();
    }
    
    void buttonSetup(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => handleButton(button));
    }

    void handleButton(Button b)
    {
        gameObject.GetComponent<OpponentProfiles>().OpponentSelected(b.GetComponent<Image>());
    }

    void ReturnToDeckButton(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => ReturnToDeckHandle(button));
    }

    void ReturnToDeckHandle(Button b)
    {
        ReturnToDeck();
    }

    void ReloadOpponents()
    {
        logo.gameObject.SetActive(false);
        mainMenu.SetActive(false);
        playerCards.SetActive(false);
        largeCardDisplayPanel.SetActive(false);
        loadProfile.SetActive(false);
        startGamePanel.SetActive(false);
        confirmReplaceButton.gameObject.SetActive(false);
        declineReplaceButton.gameObject.SetActive(false);
        challengerPanel.SetActive(true);
        rewardPanel.SetActive(false);
        replacePlayerCardPanel.SetActive(false);
        for (int i = 0; i < opponentsText.Length; i++)
        {
            opponents[i] = opponentsText[i].GetComponentInChildren<Text>();
            buttonSetup(opponentsText[i].GetComponent<Button>());
            // opponentsText[i].GetComponent<Button>().onClick.AddListener(action1);
        }
        //  gameObject.GetComponent<OpponentProfiles>().LoadData();
        SaveLoad.instance.levelCount = 0;
        ShowOpponents();
    }

    public void Return()
    {
        mainMenu.SetActive(true);
        playerCards.SetActive(false);
        largeCardDisplayPanel.SetActive(false);
        loadProfile.SetActive(false);
        startGamePanel.SetActive(false);
    }

    public void LoadProfilePanel()
    {
        mainMenu.SetActive(false);
        loadProfile.SetActive(true);
    }
    public void NewGamePanel()
    {
        
        mainMenu.SetActive(false);
        startGamePanel.SetActive(true);
        
    }
    public void ShowCardsPanel()
    {
        profileName = playerNameField.GetComponent<InputField>().text;
        passwordEntered = setPasswordField.GetComponent<InputField>().text;

        for (int i = 0; i < gameObject.GetComponent<SaveLoad>().profiles.Count; i++)
        {
            if (profileName.ToUpper() == gameObject.GetComponent<SaveLoad>().profiles[i].playerName.ToUpper())
            {
                nameTaken = true;
            }
            else
            {
                nameTaken = false;
            }
        }

        if (nameTaken)
        {
            nameTakenText.gameObject.SetActive(true);
        }
        else
        {
            playerName.text = profileName;
            mainMenu.SetActive(false);
            startGamePanel.SetActive(false);
            playerCards.SetActive(true);
            logo.gameObject.SetActive(false);
            largeCardDisplayPanel.SetActive(true);
            GenerateCards();
        }
       
    }

    public void OnMouseOverStartButton(Button button)
    {
        Sprite buttonImage;
        string texture = "Game Imagery/startNewGameHover";
        buttonImage = Resources.Load<Sprite>(texture) as Sprite;
        button.GetComponent<Image>().sprite = buttonImage;
    }
    public void OnMouseOverLoadButton(Button button)
    {
        Sprite buttonImage;
        string texture = "Game Imagery/loadProfileHover";
        buttonImage = Resources.Load<Sprite>(texture) as Sprite;
        button.GetComponent<Image>().sprite = buttonImage;
    }
    public void OnMouseExitStartButton(Button button)
    {
        Sprite buttonImage;
        string texture = "Game Imagery/startNewGame";
        buttonImage = Resources.Load<Sprite>(texture) as Sprite;
        button.GetComponent<Image>().sprite = buttonImage;
    }
    public void OnMouseExitLoadButton(Button button)
    {
        Sprite buttonImage;
        string texture = "Game Imagery/loadProfile";
        buttonImage = Resources.Load<Sprite>(texture) as Sprite;
        button.GetComponent<Image>().sprite = buttonImage;
    }
    public void ShowLargeCard(Button button)
    {
        //cardName = button.name;
        
        //cardToSee = button;
        Sprite buttonImage;
        buttonImage = button.GetComponent<Image>().sprite;
        //string texture = "Card Images/Mario/" + currentImage;
        //buttonImage = Resources.Load<Sprite>(texture) as Sprite;

       // Debug.Log();
        largeDisplayButton.GetComponent<Image>().overrideSprite = buttonImage;
        largeCardDisplayPanel.SetActive(true);

    }
    public void GenerateCards()
    {
        for (int i = 0; i < playersGeneratedCards.Length; i++)
        {
            playersGeneratedCards[i] = GameObject.Find("Player Card " + buttonNumber.ToString()).GetComponent<Button>();
            buttonNumber++;
        }
        //find the cards spots to generate cards to

        string nameToFind;
        int randomCardName;
        string path;
        if(gameObject.GetComponent<SaveLoad>() != null)
        {
            gameObject.GetComponent<SaveLoad>().myData.MakeNewLists();
            gameObject.GetComponent<SaveLoad>().myData.playerName = profileName;
            gameObject.GetComponent<SaveLoad>().myData.totalWins = 0;
            gameObject.GetComponent<SaveLoad>().myData.playerPassword = passwordEntered;
        }


        for (int i = 0; i < playersGeneratedCards.Length; i++)
        {
            do
            {
                randomCardName = Random.Range(0, numberOfCharactersCompleted);
                nameToFind = listOfCharacters[randomCardName];
                
                //if the card being generated is a unique card, reroll the random until its not
                if(nameToFind == "corrin" || nameToFind == "bayonetta" || nameToFind == "roy" || nameToFind == "ryu" || nameToFind == "cloud" || nameToFind == "lucas" || nameToFind == "mewtwo")
                {
                    nameAllowed = false;
                }
                else
                {
                    nameAllowed = true;
                }
                
            } while (nameAllowed == false);
           
            
            if(i < 2)
            {
                //give the player 2 rares
                path = gameObject.GetComponent<RareCards>().FindCard(nameToFind, "imagePath");
                if (i==0)
                {
                    largeDisplayButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                    largeDisplayButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                   
                }
                playersGeneratedCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                playersGeneratedCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                gameObject.GetComponent<SaveLoad>().myData.cardNames.Add(nameToFind);
                gameObject.GetComponent<SaveLoad>().myData.rarities.Add("rare");
            }
            else if (i > 1 && i < 7)
            {
                //give the player 5 uncommons
                path = gameObject.GetComponent<Uncommon>().FindCard(nameToFind, "imagePath");
                playersGeneratedCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                playersGeneratedCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                gameObject.GetComponent<SaveLoad>().myData.cardNames.Add(nameToFind);
                gameObject.GetComponent<SaveLoad>().myData.rarities.Add("uncommon");
            }
            else
            {
                //fill the rest with uncommons
                path = gameObject.GetComponent<Common>().FindCard(nameToFind, "imagePath");
                playersGeneratedCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                playersGeneratedCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                gameObject.GetComponent<SaveLoad>().myData.cardNames.Add(nameToFind);
                gameObject.GetComponent<SaveLoad>().myData.rarities.Add("common");
            }

        }
        gameObject.GetComponent<SaveLoad>().startProfile = true;
        gameObject.GetComponent<SaveLoad>().SaveData();
    }

    public void LoadPlayerCards()
    {
        
        profileName = loadNameField.GetComponent<InputField>().text;
        Debug.Log(profileName);
        passwordEntered = playerPasswordField.GetComponent<InputField>().text;
        for (int i = 0; i < gameObject.GetComponent<SaveLoad>().profiles.Count; i++)
        {
            if (gameObject.GetComponent<SaveLoad>().profiles[i].playerName.ToUpper() == profileName.ToUpper())
            {
                gameObject.GetComponent<SaveLoad>().myData = gameObject.GetComponent<SaveLoad>().profiles[i];
                playerFound = true;
                Debug.Log("I did it");

            }
            if (playerFound)
            {
                if(gameObject.GetComponent<SaveLoad>().myData.playerPassword == passwordEntered)
                {
                    passwordCorrect = true;
                }
            }
        }

        //gameObject.GetComponent<SaveLoad>().showList = true;

        if (playerFound && passwordCorrect)
        {
            for (int i = 0; i < gameObject.GetComponent<SaveLoad>().profiles.Count; i++)
            {
                if (gameObject.GetComponent<SaveLoad>().profiles[i].playerName.ToUpper() == profileName.ToUpper())
                {
                    gameObject.GetComponent<SaveLoad>().myData = gameObject.GetComponent<SaveLoad>().profiles[i];
                }
            }
            playerName.text = profileName;
            mainMenu.SetActive(false);
            startGamePanel.SetActive(false);
            playerCards.SetActive(true);
            logo.gameObject.SetActive(false);
            largeCardDisplayPanel.SetActive(true);
            for (int i = 0; i < playersGeneratedCards.Length; i++)
            {
                playersGeneratedCards[i] = GameObject.Find("Player Card " + buttonNumber.ToString()).GetComponent<Button>();
                buttonNumber++;
            }
            //find the cards spots to generate cards to
           
            
            string nameToFind;
            string path = "";


            for (int i = 0; i < gameObject.GetComponent<SaveLoad>().myData.cardNames.Count; i++)
            {
                nameToFind = gameObject.GetComponent<SaveLoad>().myData.cardNames[i];

                if (gameObject.GetComponent<SaveLoad>().myData.rarities[i] == "rare")
                {
                    path = gameObject.GetComponent<RareCards>().FindCard(nameToFind, "imagePath");
                    playersGeneratedCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                    playersGeneratedCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                }
                else if (gameObject.GetComponent<SaveLoad>().myData.rarities[i] == "uncommon")
                {
                    path = gameObject.GetComponent<Uncommon>().FindCard(nameToFind, "imagePath");
                    playersGeneratedCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                    playersGeneratedCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                }
                else if (gameObject.GetComponent<SaveLoad>().myData.rarities[i] == "common")
                {
                    //fill the rest with uncommons
                    path = gameObject.GetComponent<Common>().FindCard(nameToFind, "imagePath");
                    playersGeneratedCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                    playersGeneratedCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                }
                if (i == 0)
                {
                    largeDisplayButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                    largeDisplayButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                }

            }
            loadProfile.SetActive(false);
        }
        else if(playerFound && !passwordCorrect)
        {
            loadSuccess.gameObject.SetActive(true);
            loadSuccess.text = "Incorrect Password";
        }
        else
        {
            loadSuccess.gameObject.SetActive(true);
            loadSuccess.text = "PROFILE NOT FOUND";
        }
    }

    void CharacterNames()
    {
        //as characters cards and stats are finished, uncomment their names out and put them in the right order. 
        //If you do Roy before yoshi, make sure you change their numbers so that Roy is #12. 
        //Change the number at the top in the value of numberOfCharactersCompleted to match the cards that are done.

        listOfCharacters[0] = "mario";
        listOfCharacters[1] = "luigi";
        listOfCharacters[2] = "bowser";
        listOfCharacters[3] = "bowserjr";
        listOfCharacters[4] = "drmario";
        listOfCharacters[5] = "ganondorf";
        listOfCharacters[6] = "link";
        listOfCharacters[7] = "peach";
        listOfCharacters[8] = "rosalina";
        listOfCharacters[9] = "shiek";
        listOfCharacters[10] = "toonlink";
        listOfCharacters[11] = "zelda";
        listOfCharacters[12] = "yoshi";
        listOfCharacters[13] = "donkey";
        listOfCharacters[14] = "diddy";
        listOfCharacters[15] = "samus";
        listOfCharacters[16] = "zerosuit";
        listOfCharacters[17] = "kirby";
        listOfCharacters[18] = "charizard";
        listOfCharacters[19] = "marth";
        listOfCharacters[20] = "metaknight";
        listOfCharacters[21] = "deedeedee";
        listOfCharacters[22] = "fox";
        listOfCharacters[23] = "falco";
        listOfCharacters[24] = "pikachu";
        listOfCharacters[25] = "jigglypuff";
        listOfCharacters[26] = "mewtwo";
        listOfCharacters[27] = "lucario";
        listOfCharacters[28] = "falcon";
        listOfCharacters[29] = "ness";
        listOfCharacters[30] = "lucas";
        listOfCharacters[31] = "roy";
        listOfCharacters[32] = "ike";
        listOfCharacters[33] = "gamewatch";
        listOfCharacters[34] = "pit";
        listOfCharacters[35] = "wario";
        listOfCharacters[36] = "olimar";
        listOfCharacters[37] = "rob";
        listOfCharacters[38] = "sonic";
        listOfCharacters[39] = "greninja";
        listOfCharacters[40] = "robin";
        listOfCharacters[41] = "lucina";
        listOfCharacters[42] = "corrin";
        listOfCharacters[43] = "palutena";
        listOfCharacters[44] = "darkpit";
        listOfCharacters[45] = "littlemac";
        listOfCharacters[46] = "wiifit";
        listOfCharacters[47] = "shulk";
        listOfCharacters[48] = "duckhunt";
        listOfCharacters[49] = "megaman";
        listOfCharacters[50] = "pacman";
        listOfCharacters[51] = "villager";
        listOfCharacters[52] = "ryu";
        listOfCharacters[53] = "cloud";
        listOfCharacters[54] = "bayonetta";
    }

    public void CheckCharacterCards()
    {
     
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    string first = listOfCharacters[debugButton1];
            //    string firstpath = gameObject.GetComponent<RareCards>().FindCard(first, "imagePath");
            //    playersGeneratedCards[0].GetComponent<Image>().sprite = Resources.Load<Sprite>(firstpath) as Sprite;
            //    playersGeneratedCards[0].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(firstpath) as Sprite;
            //    debugButton1++;

            //}

            //if (Input.GetKeyDown(KeyCode.W))
            //{
              
            //    string second = listOfCharacters[debugButton2];
            //    string secondpath = gameObject.GetComponent<Uncommon>().FindCard(second, "imagePath");
            //    playersGeneratedCards[3].GetComponent<Image>().sprite = Resources.Load<Sprite>(secondpath) as Sprite;
            //    playersGeneratedCards[3].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(secondpath) as Sprite;
            //    debugButton2++;

                
            //}

            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    string third = listOfCharacters[debugButton3];
            //    string thirdpath = gameObject.GetComponent<Common>().FindCard(third, "imagePath");
            //    playersGeneratedCards[9].GetComponent<Image>().sprite = Resources.Load<Sprite>(thirdpath) as Sprite;
            //    playersGeneratedCards[9].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(thirdpath) as Sprite;
            //    debugButton3++;

                
            //}

    }

    public void ReturnToDeck()
    {
        playerCards.SetActive(true);
        largeCardDisplayPanel.SetActive(true);
        challengerPanel.SetActive(false);
    }


    public void PlayGame()
    {
        playerCards.SetActive(false);
        largeCardDisplayPanel.SetActive(false);
        challengerPanel.SetActive(true);
        gameObject.GetComponent<OpponentProfiles>().LoadData();
        ShowOpponents();
    }

    public void ShowOpponents()
    {
        bool nameUsed = false;
        int random;
        List<string> usedNames = new List<string>();

        if(backToCards == null)
        {
            backToCards = GameObject.FindGameObjectWithTag("backToCards").GetComponent<Button>();
            ReturnToDeckButton(backToCards);
            backToCards.gameObject.SetActive(false);
        }

       
        
        for(int i = 0; i < opponents.Length; i++)
        {
           
            //for (int j = 0; j < opponents.Length; j++)
            //{
            //    if (opponents[j].text == gameObject.GetComponent<OpponentProfiles>().profiles[i].playerName)
            //    {
            //        nameUsed = true;
            //    }
                
            //}
            do
            {
                random = Random.Range(0, gameObject.GetComponent<OpponentProfiles>().profiles.Count);
                for (int j = 0; j < opponents.Length; j++)
                {
                    if (usedNames.Contains(gameObject.GetComponent<OpponentProfiles>().profiles[random].playerName))
                    {
                        nameUsed = true;
                    }
                    else if (gameObject.GetComponent<SaveLoad>().myData.playerName == gameObject.GetComponent<OpponentProfiles>().profiles[random].playerName)
                    {
                        nameUsed = true;
                    }
                    else
                    {
                        nameUsed = false;
                    }
                }

            } while (nameUsed == true);

            if (!nameUsed)
            {
                usedNames.Add(gameObject.GetComponent<OpponentProfiles>().profiles[random].playerName);
                opponents[i].text = gameObject.GetComponent<OpponentProfiles>().profiles[random].playerName;
                opponentWins[i].GetComponent<Text>().text = gameObject.GetComponent<OpponentProfiles>().profiles[i].totalWins.ToString();
                nameUsed = false;
            }

        }
    }

    #region RewardSystem

    public void ShowRewardsPanel()
    {
        challengerPanel.SetActive(false);
        rewardPanel.SetActive(true);
    }

    public void GenerateRandomCard(Button button)
    {

        if(!getRandomCardReward)
        {
            int randomCardName;
            int randomCardRarity;

            string nameToFind;
            string path;

            randomCardName = Random.Range(0, listOfCharacters.Length);
            randomCardRarity = Random.Range(0, 9);
            nameToFind = listOfCharacters[randomCardName];
            if (randomCardRarity < 1)
            {
                path = gameObject.GetComponent<RareCards>().FindCard(nameToFind, "imagePath");
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                button.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                rewardRarity = "rare";
            }
            else if (randomCardRarity > 0 && randomCardRarity <= 3)
            {
                path = gameObject.GetComponent<Uncommon>().FindCard(nameToFind, "imagePath");
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                button.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                rewardRarity = "uncommon";
            }
            else
            {
                path = gameObject.GetComponent<Common>().FindCard(nameToFind, "imagePath");
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                button.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                rewardRarity = "common";
            }
            getRandomCardReward = true;
            nameOfRewardCard = nameToFind;
            Invoke("ShowDeckForRewardPlacement", 1.5f);
        }
       

       
    }

    public void ShowDeckForRewardPlacement()
    {
        rewardPanel.SetActive(false);
        replacePlayerCardPanel.SetActive(true);
        int buttonNumberToUse = 1 ;
        for (int i = 0; i < playerDeckForRewards.Length; i++)
        {
            playerDeckForRewards[i] = GameObject.Find("Reward - Player Card " + buttonNumberToUse.ToString()).GetComponent<Button>();
            buttonNumberToUse++;
        }
        rewardCardButton = GameObject.FindGameObjectWithTag("rewardButton").GetComponent<Button>();
        declineRewardButton = GameObject.FindGameObjectWithTag("tossReward").GetComponent<Button>();
        for (int i = 0; i < playerDeckForRewards.Length; i++)
        {
            replaceCardButton(playerDeckForRewards[i].GetComponent<Button>());
            // opponentsText[i].GetComponent<Button>().onClick.AddListener(action1);
        }
        ConfirmButton(confirmReplaceButton.GetComponent<Button>());
        DenyButton(declineReplaceButton.GetComponent<Button>());
        DeclineButton(declineRewardButton.GetComponent<Button>());
        string nameToFind;
        string path;
        string rewardpath;
        switch (rewardRarity)
        {
            case "common":
                rewardpath = gameObject.GetComponent<Common>().FindCard(nameOfRewardCard, "imagePath");

                rewardCardButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(rewardpath) as Sprite;
                rewardCardButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(rewardpath) as Sprite;
                break;
            case "uncommon":
                rewardpath = gameObject.GetComponent<Uncommon>().FindCard(nameOfRewardCard, "imagePath");
                rewardCardButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(rewardpath) as Sprite;
                rewardCardButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(rewardpath) as Sprite;
                break;
            case "rare":
                rewardpath = gameObject.GetComponent<RareCards>().FindCard(nameOfRewardCard, "imagePath");

                rewardCardButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(rewardpath) as Sprite;
                rewardCardButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(rewardpath) as Sprite;
                break;
            default:
                break;
        }



        for (int i = 0; i < gameObject.GetComponent<SaveLoad>().myData.cardNames.Count; i++)
        {
            nameToFind = gameObject.GetComponent<SaveLoad>().myData.cardNames[i];

            if (gameObject.GetComponent<SaveLoad>().myData.rarities[i] == "rare")
            {
                path = gameObject.GetComponent<RareCards>().FindCard(nameToFind, "imagePath");
                if (i == 0)
                {
                    //largeDisplayButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                    //largeDisplayButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                }
                playerDeckForRewards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                playerDeckForRewards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
            }
            else if (gameObject.GetComponent<SaveLoad>().myData.rarities[i] == "uncommon")
            {
                path = gameObject.GetComponent<Uncommon>().FindCard(nameToFind, "imagePath");
                playerDeckForRewards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                playerDeckForRewards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
            }
            else if (gameObject.GetComponent<SaveLoad>().myData.rarities[i] == "common")
            {
                //fill the rest with uncommons
                path = gameObject.GetComponent<Common>().FindCard(nameToFind, "imagePath");
                playerDeckForRewards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                playerDeckForRewards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
            }

        }
    }

    public void ReplaceCardInDeck(Button button)
    {
        if(!cardSelectedToReplace)
        {
            tempReplaceButton = button;
            for(int i = 0; i < playerDeckForRewards.Length; i ++)
            {
                if (playerDeckForRewards[i] == button)
                {
                    tempCardRarity = gameObject.GetComponent<SaveLoad>().myData.rarities[i];
                    tempCardToReplace = gameObject.GetComponent<SaveLoad>().myData.cardNames[i];

                    playerDeckForRewards[i].GetComponent<Image>().sprite = rewardCardButton.GetComponent<Image>().sprite as Sprite;
                    playerDeckForRewards[i].GetComponent<Image>().overrideSprite = rewardCardButton.GetComponent<Image>().overrideSprite as Sprite;

                }
            }
            cardSelectedToReplace = true;
            confirmReplaceButton.gameObject.SetActive(true);
            declineReplaceButton.gameObject.SetActive(true);
        }
    }
    public void ConfirmReplace()
    {
        for (int i = 0; i < playerDeckForRewards.Length; i++)
        {
            if (playerDeckForRewards[i] == tempReplaceButton)
            {
                gameObject.GetComponent<SaveLoad>().myData.cardNames[i] = nameOfRewardCard;
                gameObject.GetComponent<SaveLoad>().myData.rarities[i] = rewardRarity;

                gameObject.GetComponent<SaveLoad>().startProfile = false;
                gameObject.GetComponent<SaveLoad>().overwrite = true;
                gameObject.GetComponent<SaveLoad>().SaveData();


            }
        }
        confirmReplaceButton.gameObject.SetActive(false);
        declineReplaceButton.gameObject.SetActive(false);
        getRandomCardReward = false;
        cardSelectedToReplace = false;
        Invoke("ReloadOpponents", 1f);


    }
    public void DeclineReplace()
    {
        string tempPath;
        switch (tempCardRarity)
        {
            case "common":
                tempPath = gameObject.GetComponent<Common>().FindCard(tempCardToReplace, "imagePath");

                tempReplaceButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(tempPath) as Sprite;
                tempReplaceButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(tempPath) as Sprite;
                break;
            case "uncommon":
                tempPath = gameObject.GetComponent<Uncommon>().FindCard(tempCardToReplace, "imagePath");
                tempReplaceButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(tempPath) as Sprite;
                tempReplaceButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(tempPath) as Sprite;
                break;
            case "rare":
                tempPath = gameObject.GetComponent<RareCards>().FindCard(tempCardToReplace, "imagePath");

                tempReplaceButton.GetComponent<Image>().sprite = Resources.Load<Sprite>(tempPath) as Sprite;
                tempReplaceButton.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(tempPath) as Sprite;
                break;
            default:
                break;
        }
        
        tempCardRarity = "";
        tempCardToReplace = "";
        cardSelectedToReplace = false;
        confirmReplaceButton.gameObject.SetActive(false);
        declineReplaceButton.gameObject.SetActive(false);
    }
    public void DeclineReward()
    {
        confirmReplaceButton.gameObject.SetActive(false);
        declineReplaceButton.gameObject.SetActive(false);
        getRandomCardReward = false;
        cardSelectedToReplace = false;
        gameObject.GetComponent<SaveLoad>().startProfile = false;
        gameObject.GetComponent<SaveLoad>().overwrite = true;
        gameObject.GetComponent<SaveLoad>().SaveData();
        ReloadOpponents();
    }




    void rewardButtonSetup(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => rewardHandleButton(button));
    }
    void rewardHandleButton(Button b)
    {
        GenerateRandomCard(b);
    }

    void replaceCardButton(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => replaceCardHandle(button));
    }
    void replaceCardHandle(Button b)
    {
        ReplaceCardInDeck(b);
    }

    void ConfirmButton(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => ConfirmHandle(button));
    }
    void ConfirmHandle(Button b)
    {
        ConfirmReplace();
    }
    void DenyButton(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => DenyHandle(button));
    }
    void DenyHandle(Button b)
    {
        DeclineReplace();
    }


    void DeclineButton(Button button)
    {
        button.onClick.RemoveAllListeners();
        //Add your new event
        button.onClick.AddListener(() => DeclineHandle(button));
    }
    void DeclineHandle(Button b)
    {
        DeclineReward();
    }

    #endregion RewardSystem
}
