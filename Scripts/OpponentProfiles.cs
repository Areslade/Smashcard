using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Security;
using System.Text;
using System.Linq;

public class OpponentProfiles : MonoBehaviour {

    // Use this for initialization
    public Profiles opponentData;

    public Profiles tempCreateNewOpponents;
    public List<Profiles> playerProfiles;
    public List<Profiles> profiles;
    public static OpponentProfiles instance = null;
    public bool startProfile;
    public int profileCount;
    public int nameCount;
    public string[] cardNamesToShow;
    List<string> characterNames;
    bool nameAllowed;

    void Awake()
    {
        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    gameObject.GetComponent<MainGameControl>().enabled = true;
        //}
    }
    // Use this for initialization
    void Start()
    {
        profileCount = 0;
        opponentData = new Profiles();
        tempCreateNewOpponents = new Profiles();
        profiles = new List<Profiles>();
        playerProfiles = new List<Profiles>();
        cardNamesToShow = new string[20];
        characterNames = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        profileCount = profiles.Count;
    }

    public void SaveData()
    {
        string sKey = "Testing1";

        var serializer = new XmlSerializer(typeof(List<Profiles>));
        var stream = new FileStream("opponents.ini", FileMode.Create);

        //Create Encryption stuff
        DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

        ICryptoTransform desencrypt = DES.CreateEncryptor();

        using (CryptoStream cStream = new CryptoStream(stream, desencrypt, CryptoStreamMode.Write))
        {
            serializer.Serialize(cStream, profiles);
        }

        stream.Close();

    }

    public void LoadData()
    {
        if (System.IO.File.Exists("opponents.ini"))
        {
            string sKey = "Testing1";

            var serializer = new XmlSerializer(typeof(List<Profiles>));
            var stream = new FileStream("opponents.ini", FileMode.Open);

            //Create Encryption stuff
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            ICryptoTransform desdecrypt = DES.CreateDecryptor();

            using (CryptoStream cStream = new CryptoStream(stream, desdecrypt, CryptoStreamMode.Read))
            {
                profiles = (List<Profiles>)serializer.Deserialize(cStream);
            }

            stream.Close();
        }
        else
        {

            newOpponents();

        }
        // AmountOfButtons();
    
    }

    void newOpponents()
    {
        for (int c = 0; c < gameObject.GetComponent<MenuController>().numberOfCharactersCompleted; c++)
        {
            characterNames.Add(gameObject.GetComponent<MenuController>().listOfCharacters[c]);
        }
        nameCount = characterNames.Count;
        for (int i = 0; i < 10; i++)
        {
            tempCreateNewOpponents = new Profiles();
            tempCreateNewOpponents.MakeNewLists();
            string nameToFind;
            int randomCardName;
            string path;


            randomCardName = Random.Range(0, characterNames.Count);
            tempCreateNewOpponents.playerName = characterNames[randomCardName];
            characterNames.RemoveAt(randomCardName);

            tempCreateNewOpponents.totalWins = Random.Range(0, 500);
            for (int j = 0; j < 20; j++)
            {
                //do a random number to find a character name
                //randomCardName = Random.Range(0, gameObject.GetComponent<MenuController>().numberOfCharactersCompleted);
                do
                {
                    randomCardName = Random.Range(0, characterNames.Count);
                    nameToFind = characterNames[randomCardName];

                    //if the card being generated is a unique card, reroll the random until its not
                    if (nameToFind == "corrin" || nameToFind == "bayonetta" || nameToFind == "roy" || nameToFind == "ryu" || nameToFind == "cloud" || nameToFind == "lucas" || nameToFind == "mewtwo")
                    {
                        nameAllowed = false;
                    }
                    else
                    {
                        nameAllowed = true;
                    }

                } while (nameAllowed == false);
                //   nameToFind = gameObject.GetComponent<MenuController>().listOfCharacters[randomCardName];

                if (j < 2)
                {
                    //give the opponent 2 rare cards to start
                    path = gameObject.GetComponent<RareCards>().FindCard(nameToFind, "imagePath");
                    tempCreateNewOpponents.cardNames.Add(nameToFind);
                    tempCreateNewOpponents.rarities.Add("rare");
                }
                else if (j > 1 && j < 7)
                {
                    //give the player 5 uncommons
                    path = gameObject.GetComponent<Uncommon>().FindCard(nameToFind, "imagePath");
                    tempCreateNewOpponents.cardNames.Add(nameToFind);
                    tempCreateNewOpponents.rarities.Add("uncommon");
                }
                else
                {
                    //fill the rest with uncommons
                    path = gameObject.GetComponent<Common>().FindCard(nameToFind, "imagePath");
                    tempCreateNewOpponents.cardNames.Add(nameToFind);
                    tempCreateNewOpponents.rarities.Add("common");
                }

            }
            profiles.Add(tempCreateNewOpponents);
        }
        for(int i = 0; i < playerProfiles.Count; i ++)
        {
            profiles.Add(playerProfiles[i]);
        }

        SaveData();
    }

    public void LoadPlayerData()
    {
        string sKey = "Testing1";


        var serializer = new XmlSerializer(typeof(List<Profiles>));
        var stream = new FileStream("Profiles.ini", FileMode.Open);

        //Create Encryption stuff
        DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

        ICryptoTransform desdecrypt = DES.CreateDecryptor();

        using (CryptoStream cStream = new CryptoStream(stream, desdecrypt, CryptoStreamMode.Read))
        {
            playerProfiles = (List<Profiles>)serializer.Deserialize(cStream);
        }

        stream.Close();
        //Stream profilesSave = new FileStream("temp.ini", FileMode.Open);
        //XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
        //playerProfiles = (List<Profiles>)serializer2.Deserialize(profilesSave);
        //profilesSave.Close();
    }


    /*
    public void SaveData()
    {

       // if (startProfile)
        //{
            //LoadData();
           // profiles.Add(opponentData);
          //  Stream profilesSave = new FileStream("opponents.ini", FileMode.Create);
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
           // serializer2.Serialize(profilesSave, profiles);
            //profilesSave.Close();
        var encoding = System.Text.Encoding.GetEncoding("UTF-8");
        using (StreamWriter stream = new StreamWriter("opponents.ini", false, encoding))
        {
            serializer2.Serialize(stream, profiles);
        }
        //  }
    }
    public void LoadData()
    {

        if (System.IO.File.Exists("opponents.ini"))
        {
            Stream profilesSave = new FileStream("opponents.ini", FileMode.Open);
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
            profiles = (List<Profiles>)serializer2.Deserialize(profilesSave);
            profilesSave.Close();
            
        }
        else
        {
            for(int c = 0; c < gameObject.GetComponent<MenuController>().numberOfCharactersCompleted;c++)
            {
                characterNames.Add(gameObject.GetComponent<MenuController>().listOfCharacters[c]);
            }
            nameCount = characterNames.Count;
            for(int i = 0; i < 10; i++)
            {
                tempCreateNewOpponents = new Profiles();
                tempCreateNewOpponents.MakeNewLists();
                string nameToFind;
                int randomCardName;
                string path;
               

                randomCardName = Random.Range(0, characterNames.Count);
                tempCreateNewOpponents.playerName = characterNames[randomCardName];
                characterNames.RemoveAt(randomCardName);
                
                tempCreateNewOpponents.totalWins = Random.Range(0,500);
                for (int j = 0; j < 20; j++)
                {
                    //do a random number to find a character name
                    //randomCardName = Random.Range(0, gameObject.GetComponent<MenuController>().numberOfCharactersCompleted);
                    do
                    {
                        randomCardName = Random.Range(0, characterNames.Count);
                        nameToFind = characterNames[randomCardName];

                        //if the card being generated is a unique card, reroll the random until its not
                        if (nameToFind == "corrin" || nameToFind == "bayonetta" || nameToFind == "roy" || nameToFind == "ryu" || nameToFind == "cloud" || nameToFind == "lucas" || nameToFind == "mewtwo")
                        {
                            nameAllowed = false;
                        }
                        else
                        {
                            nameAllowed = true;
                        }

                    } while (nameAllowed == false);
                 //   nameToFind = gameObject.GetComponent<MenuController>().listOfCharacters[randomCardName];

                    if (j < 2)
                    {
                        //give the opponent 2 rare cards to start
                        path = gameObject.GetComponent<RareCards>().FindCard(nameToFind, "imagePath");
                        tempCreateNewOpponents.cardNames.Add(nameToFind);
                        tempCreateNewOpponents.rarities.Add("rare");
                    }
                    else if (j > 1 && j < 7)
                    {
                        //give the player 5 uncommons
                        path = gameObject.GetComponent<Uncommon>().FindCard(nameToFind, "imagePath");
                        tempCreateNewOpponents.cardNames.Add(nameToFind);
                        tempCreateNewOpponents.rarities.Add("uncommon");
                    }
                    else
                    {
                        //fill the rest with uncommons
                        path = gameObject.GetComponent<Common>().FindCard(nameToFind, "imagePath");
                        tempCreateNewOpponents.cardNames.Add(nameToFind);
                        tempCreateNewOpponents.rarities.Add("common");
                    }

                }
                profiles.Add(tempCreateNewOpponents);
            }
            SaveData();

        }

        // AmountOfButtons();
    }
    */

    public void OpponentSelected(Image opponentsName)
    {
        for (int i = 0; i < profiles.Count; i++)
        {
            if(profiles[i].playerName == opponentsName.GetComponentInChildren<Text>().text)
            {
                opponentData = profiles[i];
            }
        }
        for (int i = 0; i < opponentData.cardNames.Count;i++)
        {
            cardNamesToShow[i] = opponentData.cardNames[i];
        }
        SaveLoad.instance.levelCount++;
        MusicFade.fadeMusic = true;
        Invoke("LoadScene", 1f);

        
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }


    public class Profiles
    {
        public string playerName;
        public string playerPassword;
        public int totalWins;
        public List<string> cardNames;
        public List<string> rarities;

        public void MakeNewLists()
        {
            cardNames = new List<string>();
            rarities = new List<string>();
        }


    }
}
