using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MainGameControl : MonoBehaviour
{
    /// <summary>
    /// This sript is used to figure out which card was selected
    /// </summary>

    public Button largeDisplayButton;
    public GameObject largeCardDisplayPanel;
    public GameObject gameController;
    public GameObject statsPanel;
    public GameObject roundPanel;
    public GameObject winnerPanel;
   

    public string currentImage;
    public string cardName;
    public Button cardSelected;
    public Button cardToSee;
    public Button PlayerBattlePosition;
    public Button OpponentBattlePosition;
    public Button opponentCardSelected;
    public Text playersName;
    public Text opponentsName;
    public Text roundDisplay;
    public Text whoWinsText;
    public Text playersGamesScore;
    public Text opponentsGameScore;
    public Text gameWinnerText;
    //use this to display which stats to compare;
    public Text stat1;

    public string statToCompare = "";

    public Image dealCards;

    public List<string> cardNames;
    public List<string> rarities;
    public List<string> oppCardNames;
    public List<string> oppRarities;

    public int playerCardsCount;
    public int opponentCardsCount;

    //players dealt cards
    public Button[] opponentCards = new Button[6];
    public Button[] playerCards = new Button[6];
    string[] playersCardsBeingUsed = new string[6];
    string[] playerRarities = new string[6];
    //opponents dealt cards
    string[] oppCardsBeingUsed = new string[6];
    string[] oppRaritiesBeingUsed = new string[6];
    Vector2[] playerCardsPosition = new Vector2[6];
    Vector2[] opponentCardsPosition = new Vector2[6];

    public string playerCardToFind;
    public string playerCardRarityToFind;
    public string opponentCardToFind;
    public string opponentCardRarityToFind;

    public bool roundOne = true;
    public bool roundTwo;
    public bool roundThree;
    public bool inBattle;
    bool hidePanels;
    public static bool gameOver = false;

    public int battleCount;

    bool getCards = true;
    public bool cardsDealt;
    bool moveCard;
    bool moveOpponent;
    float speed = 1.5f;
    public int playersStatsScore;
    public int opponentStatScore;
    int playersWins;
    int opponentsWins;
    bool setStamp;
    float loadStamp = 0;
    
    void Awake()
    {
        
    }

	// Use this for initialization
	void Start ()
    {
        cardNames = new List<string>();
        rarities = new List<string>();
        oppCardNames = new List<string>();
        oppRarities = new List<string>();
        roundDisplay.text = "";
        gameWinnerText = GameObject.FindGameObjectWithTag("gameWinnerText").GetComponent<Text>();
        winnerPanel = GameObject.FindGameObjectWithTag("winnerPanel");
        winnerPanel.SetActive(false);
        for (int i = 0; i < playerCards.Length; i++)
        {
            playerCardsPosition[i] = playerCards[i].gameObject.transform.position;
        }
        for (int i = 0; i < opponentCards.Length; i++)
        {
            opponentCardsPosition[i] = opponentCards[i].gameObject.transform.position;
        }
        hidePanels = false;
    }

    // Update is called once per frame
    void Update()
    {
        //find the variables we need to be able to play and display information
        if (gameController == null)
        {
            gameController = GameObject.Find("GameController");

        }
        if (!gameOver && !hidePanels)
        {
            if (playersName.text == "")
            {
                playersName.text = SaveLoad.instance.myData.playerName;
                opponentsName.text = gameController.GetComponent<OpponentProfiles>().opponentData.playerName;
            }

            if (roundOne && roundDisplay.text == "")
            {
                roundDisplay.text = "round one";
                Invoke("DisableRoundText", 3f);

            }
            if (roundTwo && roundDisplay.text == "")
            {
                roundDisplay.gameObject.SetActive(true);
                roundDisplay.text = "round two";
                Invoke("DisableRoundText", 3f);
            }
            if (roundThree && roundDisplay.text == "")
            {
                roundDisplay.text = "round three";
                Invoke("DisableRoundText", 3f);
            }
            if (statToCompare == "" && roundDisplay.enabled == false && cardsDealt)
            {
                Invoke("WhichStatsToCompare", 1f);

            }
        }
        if ((playersWins == 5 || opponentsWins == 5) && !gameOver )
        {
            winnerPanel.SetActive(true);
            dealCards.gameObject.SetActive(false);
            
            largeCardDisplayPanel.SetActive(false);
            statsPanel.SetActive(false);
            roundPanel.SetActive(false);
            OpponentBattlePosition.gameObject.SetActive(false);
            PlayerBattlePosition.gameObject.SetActive(false);

            for (int i = 0; i < playerCards.Length; i++)
            {
                playerCards[i].gameObject.SetActive(false);
                opponentCards[i].gameObject.SetActive(false);
            }
            hidePanels = true;
            gameOver = true;
            SaveLoad.instance.levelCount = 2 ;
            gameController.GetComponent<MenuController>().enabled = true;
            if(playersWins == 5)
            {
                gameController.GetComponent<MenuController>().getReward = true;
                gameController.GetComponent<SaveLoad>().myData.totalWins++;
                gameWinnerText.text = gameController.GetComponent<SaveLoad>().myData.playerName;
            }
            else
            {
                gameController.GetComponent<MenuController>().getReward = false;
                gameWinnerText.text = opponentsName.text;
                gameController.GetComponent<SaveLoad>().overwrite = true;
                gameController.GetComponent<SaveLoad>().startProfile = false;
                gameController.GetComponent<SaveLoad>().SaveData();
            }
           
            inBattle = false;
            playersName.gameObject.SetActive(false);
            opponentsName.gameObject.SetActive(false);
            if (!setStamp)
            {
                loadStamp = Time.time;
                setStamp = true;

            }
        }
        if (setStamp && Time.time > loadStamp + 3)
        {
            LoadMenu();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            playersWins++;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            opponentsWins++;
        }

        //once player has selected a card 
        if (moveCard)
        {
            cardSelected.gameObject.transform.position = Vector3.Lerp(cardSelected.gameObject.transform.position, PlayerBattlePosition.transform.position, speed / 50);
            if (cardSelected.transform.position == PlayerBattlePosition.transform.position)
            {
                moveOpponent = true;
                moveCard = false;
            }
        }
        if (moveCard)
        {
            //move the opponents card to the battle position
            //check stats of the cards
            //reveal the opponents card
            opponentCardSelected.gameObject.transform.position = Vector3.Lerp(opponentCardSelected.gameObject.transform.position, OpponentBattlePosition.transform.position, speed / 50);
            if (opponentCardSelected.transform.position.y - OpponentBattlePosition.transform.position.y < 2)
            {
                moveOpponent = false;
                moveCard = false;
                
                GetPlayersTotal();
                GetOpponentsTotal();
                string path = "";
                if (opponentCardRarityToFind == "rare")
                {
                    path = gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "imagePath");
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    path = gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "imagePath");
                }
                else if (opponentCardRarityToFind == "common")
                {
                    path = gameController.GetComponent<Common>().FindCard(opponentCardToFind, "imagePath");
                }
                opponentCardSelected.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                opponentCardSelected.GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                Invoke("FindWinner", 1f);
            }
        }
    }

    void LoadMenu()
    {
        playersWins = 0;
        opponentsWins = 0;
        SceneManager.LoadScene(0);
        gameOver = false;
    }

    public void ShowLargeCard(Button button)
    {
        if(cardsDealt && stat1.text != "" && !inBattle)
        {
            cardName = button.name;
            largeCardDisplayPanel.SetActive(true);
            cardToSee = button;
            Sprite buttonImage;
            buttonImage = button.GetComponent<Image>().sprite;
            largeDisplayButton.GetComponent<Image>().overrideSprite = buttonImage;
        }
    }
    public void DontUseCard()
    {
        largeCardDisplayPanel.SetActive(false);
    }
    public void UseCard()
    {
        cardSelected = cardToSee;
        largeCardDisplayPanel.SetActive(false);
        moveCard = true;
        inBattle = true;
        switch (cardSelected.name)
        {
            case "Player Card 1":
                opponentCardSelected = opponentCards[0];
                break;
            case "Player Card 2":
                opponentCardSelected = opponentCards[1];
                break;
            case "Player Card 3":
                opponentCardSelected = opponentCards[2];
                break;
            case "Player Card 4":
                opponentCardSelected = opponentCards[3];
                break;
            case "Player Card 5":
                opponentCardSelected = opponentCards[4];
                break;
            case "Player Card 6":
                opponentCardSelected = opponentCards[5];
                break;
            default:
                break;
        }
    }

    public void DealCards()
    {

        if(!cardsDealt && roundDisplay.enabled == false)
        {
            dealCards.enabled = false;
            string path;
            int random;
           
            if (getCards)
            {
                playerCardsCount = SaveLoad.instance.myData.cardNames.Count;
                opponentCardsCount = gameController.GetComponent<OpponentProfiles>().opponentData.cardNames.Count;
                for (int i = 0; i < playerCardsCount; i++)
                {
                    cardNames.Add(SaveLoad.instance.myData.cardNames[i]);
                    rarities.Add(SaveLoad.instance.myData.rarities[i]);
                }
                for (int i = 0; i < opponentCardsCount; i++)
                {
                    oppCardNames.Add(gameController.GetComponent<OpponentProfiles>().opponentData.cardNames[i]);
                    oppRarities.Add(gameController.GetComponent<OpponentProfiles>().opponentData.rarities[i]);
                }
                getCards = false;
            }
            
            for(int i = 0; i < playerCards.Length; i++)
            {
                random = Random.Range(0, cardNames.Count);
                if(rarities[random] == "rare")
                {
                    path = gameController.GetComponent<RareCards>().FindCard(cardNames[random], "imagePath");
                    playerCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                    playerCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                    playersCardsBeingUsed[i] = cardNames[random];
                    playerRarities[i] = rarities[random];
                }
                else if (rarities[random] == "uncommon")
                {
                    path = gameController.GetComponent<Uncommon>().FindCard(cardNames[random], "imagePath");
                    playerCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                    playerCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                    playersCardsBeingUsed[i] = cardNames[random];
                    playerRarities[i] = rarities[random];
                }
                else if (rarities[random] == "common")
                {
                    path = gameController.GetComponent<Common>().FindCard(cardNames[random], "imagePath");
                    playerCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(path) as Sprite;
                    playerCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(path) as Sprite;
                    playersCardsBeingUsed[i] = cardNames[random];
                    playerRarities[i] = rarities[random];
                }
                cardNames.RemoveAt(random);
                rarities.RemoveAt(random);
                playerCardsCount--;
            }
            //deal the opponent their cards
            for (int i = 0; i < opponentCards.Length; i++)
            {
                random = Random.Range(0, oppCardNames.Count);
                if (oppRarities[random] == "rare")
                {
                    oppCardsBeingUsed[i] = oppCardNames[random];
                    oppRaritiesBeingUsed[i] = oppRarities[random];
                }
                else if (oppRarities[random] == "uncommon")
                {
                    oppCardsBeingUsed[i] = oppCardNames[random];
                    oppRaritiesBeingUsed[i] = oppRarities[random];
                }
                else if (oppRarities[random] == "common")
                {
                    oppCardsBeingUsed[i] = oppCardNames[random];
                    oppRaritiesBeingUsed[i] = oppRarities[random];
                }
                oppCardNames.RemoveAt(random);
                oppRarities.RemoveAt(random);
                opponentCardsCount--;
            }
            cardsDealt = true;
            
        }
        
    }

    public void WhichStatsToCompare()
    {
        if (statToCompare == "")
        {
            int random;
            random = Random.Range(0, 10);
            switch (random)
            {
                case 0:
                    statToCompare = "attack";
                    stat1.text = "attack";
                    break;
                case 1:
                    statToCompare = "toughness";
                    stat1.text = "toughness";
                    break;
                case 2:
                    statToCompare = "grab";
                    stat1.text = "grab";
                 
                    break;
                case 3:
                    statToCompare = "shield";
                    stat1.text = "shield";
                   
                    break;
                case 4:
                    statToCompare = "atktough";
                    stat1.text = "attack / toughness";
                
                    break;
                case 5:
                    statToCompare = "atkgrab";
                    stat1.text = "attack / grab";
                 
                    break;
                case 6:
                    statToCompare = "atkshield";
                    stat1.text = "attack / shield";
                    break;
                case 7:
                    statToCompare = "toughgrab";
                    stat1.text = "toughness / grab";
                   
                    break;
                case 8:
                    statToCompare = "toughshield";
                    stat1.text = "toughness / shield";
                  
                    break;
                case 9:
                    statToCompare = "grabshield";
                    stat1.text = "grab / shield";
                    break;

            }
            statsPanel.SetActive(true);
        }
    }
    public void GetPlayersTotal()
    {
        for (int i = 0; i < playerCards.Length; i++ )
        {
            if(cardSelected == playerCards[i])
            {
                playerCardToFind = playersCardsBeingUsed[i];
                playerCardRarityToFind = playerRarities[i];
            }
        }
            switch (statToCompare)
            {
                case "attack":
                    if(playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, statToCompare));
                    }
                    
                    break;
                case "toughness":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, statToCompare));
                    }
                    break;
                case "grab":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, statToCompare));
                    }
                    break;
                case "shield":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, statToCompare));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, statToCompare));
                    }
                    break;
                case "atktough":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "attack"));
                        playersStatsScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "toughness"));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "attack"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "toughness"));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "attack"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "toughness"));
                    }
                        break;
                case "atkgrab":
                        if (playerCardRarityToFind == "rare")
                        {
                            playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "attack"));
                            playersStatsScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "grab"));
                        }
                        else if (playerCardRarityToFind == "uncommon")
                        {
                            playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "attack"));
                            playersStatsScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "grab"));
                        }
                        else if (playerCardRarityToFind == "common")
                        {
                            playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "attack"));
                            playersStatsScore += int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "grab"));
                        }
                    break;
                case "atkshield":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "attack"));
                        playersStatsScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "shield"));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "attack"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "shield"));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "attack"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "shield"));
                    }
                    break;
                case "toughgrab":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "toughness"));
                        playersStatsScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "grab"));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "toughness"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "grab"));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "toughness"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "grab"));
                    }
                    break;
                case "toughshield":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "toughness"));
                        playersStatsScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "shield"));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "toughness"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "shield"));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "toughness"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "shield"));
                    }
                    break;
                case "grabshield":
                    if (playerCardRarityToFind == "rare")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "grab"));
                        playersStatsScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(playerCardToFind, "shield"));
                    }
                    else if (playerCardRarityToFind == "uncommon")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "grab"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(playerCardToFind, "shield"));
                    }
                    else if (playerCardRarityToFind == "common")
                    {
                        playersStatsScore = int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "grab"));
                        playersStatsScore += int.Parse(gameController.GetComponent<Common>().FindCard(playerCardToFind, "shield"));
                    }
                    break;
            }
    }
    public void GetOpponentsTotal()
    {
        for (int i = 0; i < opponentCards.Length; i++)
        {
            if (opponentCardSelected == opponentCards[i])
            {
                opponentCardToFind = oppCardsBeingUsed[i];
                opponentCardRarityToFind = oppRaritiesBeingUsed[i];
            }
        }
        switch (statToCompare)
        {
            case "attack":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, statToCompare));
                }

                break;
            case "toughness":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, statToCompare));
                }
                break;
            case "grab":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, statToCompare));
                }
                break;
            case "shield":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, statToCompare));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, statToCompare));
                }
                break;
            case "atktough":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "toughness"));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "toughness"));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "toughness"));
                }
                break;
            case "atkgrab":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "grab"));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "grab"));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "grab"));
                }
                break;
            case "atkshield":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "shield"));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "shield"));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "attack"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "shield"));
                }
                break;
            case "toughgrab":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "toughness"));
                    opponentStatScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "grab"));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "toughness"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "grab"));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "toughness"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "grab"));
                }
                break;
            case "toughshield":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "toughness"));
                    opponentStatScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "shield"));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "toughness"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "shield"));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "toughness"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "shield"));
                }
                break;
            case "grabshield":
                if (opponentCardRarityToFind == "rare")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "grab"));
                    opponentStatScore += int.Parse(gameController.GetComponent<RareCards>().FindCard(opponentCardToFind, "shield"));
                }
                else if (opponentCardRarityToFind == "uncommon")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "grab"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Uncommon>().FindCard(opponentCardToFind, "shield"));
                }
                else if (opponentCardRarityToFind == "common")
                {
                    opponentStatScore = int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "grab"));
                    opponentStatScore += int.Parse(gameController.GetComponent<Common>().FindCard(opponentCardToFind, "shield"));
                }
                break;
        }
    }
    void DisableRoundText()
    {
        roundDisplay.enabled = false;
    }
    void StartNextBattle()
    {
        cardSelected.gameObject.SetActive(false);
        opponentCardSelected.gameObject.SetActive(false);
        statToCompare = "";
        whoWinsText.text = "";
        statsPanel.SetActive(false);
        inBattle = false;
        WhichStatsToCompare();

    }
    public void NewRound()
    {
        if (roundOne)
        {
            roundOne = false;
            roundTwo = true;
            roundDisplay.gameObject.SetActive(true);
            roundDisplay.text = "";
            roundDisplay.enabled = true;
        }
        else if (roundTwo)
        {
            roundTwo = false;
            roundThree = true;
            roundDisplay.gameObject.SetActive(true);
            roundDisplay.text = "";
            roundDisplay.enabled = true;
        }
        else if (roundThree)
        {
            roundThree = false;
        }
        statToCompare = "";
        whoWinsText.text = "";

        for(int i = 0; i < playerCards.Length; i ++)
        {
            playerCards[i].gameObject.SetActive(true);
            switch (i)
            {
                case 0:
                    playerCards[i].gameObject.transform.position = playerCardsPosition[0];
                    break;
                case 1:
                    playerCards[i].gameObject.transform.position = playerCardsPosition[1];
                    break;
                case 2:
                    playerCards[i].gameObject.transform.position = playerCardsPosition[2];
                    break;
                case 3:
                    playerCards[i].gameObject.transform.position = playerCardsPosition[3];
                    break;
                case 4:
                    playerCards[i].gameObject.transform.position = playerCardsPosition[4];
                    break;
                case 5:
                    playerCards[i].gameObject.transform.position = playerCardsPosition[5];
                    break;
            }
            playerCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Card Images/BackOfCard") as Sprite;
            playerCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Card Images/BackOfCard") as Sprite;
        }

        for (int i = 0; i < opponentCards.Length; i++)
        {
            opponentCards[i].gameObject.SetActive(true);
            switch (i)
            {
                case 0:
                    opponentCards[i].gameObject.transform.position = opponentCardsPosition[0];
                    break;
                case 1:
                    opponentCards[i].gameObject.transform.position = opponentCardsPosition[1];
                    break;
                case 2:
                    opponentCards[i].gameObject.transform.position = opponentCardsPosition[2];
                    break;
                case 3:
                    opponentCards[i].gameObject.transform.position = opponentCardsPosition[3];
                    break;
                case 4:
                    opponentCards[i].gameObject.transform.position = opponentCardsPosition[4];
                    break;
                case 5:
                    opponentCards[i].gameObject.transform.position = opponentCardsPosition[5];
                    break;
            }
            opponentCards[i].GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Card Images/BackOfCard") as Sprite;
            opponentCards[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Card Images/BackOfCard") as Sprite;
        }
        inBattle = false;
        cardsDealt = false;
        dealCards.enabled = true;
        statsPanel.gameObject.SetActive(false);
        battleCount = 0;
    }
    void FindWinner()
    {
        int winner;
        winner = playersStatsScore - opponentStatScore;
        if(winner > 0)
        {
            playersWins++;
            whoWinsText.text = SaveLoad.instance.myData.playerName + " Wins";
            playersGamesScore.text = (playersWins).ToString();
        }
        if (winner == 0)
        {
            whoWinsText.text = "Tie!";
            playersWins++;
            opponentsWins++;
            playersGamesScore.text = (playersWins).ToString();
            opponentsGameScore.text = (opponentsWins).ToString();
        }
        if(winner < 0)
        {
            opponentsWins++;
            whoWinsText.text = gameController.GetComponent<OpponentProfiles>().opponentData.playerName + " Wins";
            opponentsGameScore.text = (opponentsWins).ToString();
        }
        battleCount++;
        if (battleCount == 3)
        {
            Invoke("NewRound", 3f);
        }
        else
        {
            Invoke("StartNextBattle", 3f);
        }
       
        
    }
}
