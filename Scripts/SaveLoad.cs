using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.Security;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Linq;
using System.Net.Cache;

public class SaveLoad : MonoBehaviour {

    public Profiles myData;
    public List<Profiles> profiles;
    public List<Profiles> tempProfiles;
    public static SaveLoad instance = null;
    public bool startProfile;
    public int levelCount = 0;

    public List<string> profileNames;

    bool timeSet;
    float timeStamp;
    public bool overwrite = false;
    public string password;
    public bool showList = false;
    public string[] playerDeck = new string[20];
    public string[] playerDeckRarities = new string[20];
    //WebClient myWebClient = new WebClient();

    string fileName = "Profiles.ini";
    //string remoteUri = "https://storage.googleapis.com/smashcard/";

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        if (System.IO.File.Exists("Profiles.ini"))
        {
            System.IO.File.Delete("Profiles.ini");
        }
        if (System.IO.File.Exists("temp.ini"))
        {
            System.IO.File.Delete("temp.ini");
        }
        if (System.IO.File.Exists("opponents.ini"))
        {
            System.IO.File.Delete("opponents.ini");
        }

        //download();

    }
    // Use this for initialization
    void Start()
    {
        profileNames = new List<string>();
        myData = new Profiles();
        profiles = new List<Profiles>();
    }

    // Update is called once per frame
    void Update()
    {
        if (showList)
        {
            for (int i = 0; i < myData.cardNames.Count; i++)
            {
                playerDeck[i] = myData.cardNames[i];
                playerDeckRarities[i] = myData.rarities[i];
                password = myData.playerPassword;
            }
            showList = false;
        }

        if (Time.time > timeStamp + 2 && timeSet)
        {
            LoadData();
            timeSet = false;
        }
    }

    ///////

    //The commented out save and load to encrypt

    ///////

    public void SaveData()
    {

        if (startProfile)
        {
            string sKey = "Testing1";
            LoadData();
            profiles.Add(myData);

            string FullFilePath = Application.persistentDataPath + "/" + fileName;
            var serializer = new XmlSerializer(typeof(List<Profiles>));
            var stream = new FileStream(FullFilePath, FileMode.Create);

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
            //upload();

        }
        if (overwrite)
        {
            string sKey = "Testing1";

            string FullFilePath = Application.persistentDataPath + "/" + fileName;
            var serializer = new XmlSerializer(typeof(List<Profiles>));
            var stream = new FileStream(FullFilePath, FileMode.Create);

            //Create Encryption stuff
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            ICryptoTransform desencrypt = DES.CreateEncryptor();
            for (int i = 0; i < profiles.Count; i++)
            {
                if (myData.playerName == profiles[i].playerName)
                {
                    profiles[i] = myData;
                    Debug.Log("name found");
                }

            }

            using (CryptoStream cStream = new CryptoStream(stream, desencrypt, CryptoStreamMode.Write))
            {
                serializer.Serialize(cStream, profiles);
            }
            stream.Close();
        }

        //DeleteFileOnFtpServer(new Uri("https://storage.googleapis.com/smashcard/Profiles.ini"), "schooluser", "school1!");
        //upload();
    }

    //public void SaveUnEncrypted()
    //{
    //    XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
    //    var encoding = System.Text.Encoding.GetEncoding("ASCII");
    //    using (StreamWriter stream = new StreamWriter("tempProfiles.ini", false, encoding))
    //    {
    //        serializer2.Serialize(stream, profiles);
    //    }
    //}


    public void LoadData()
    {
        if (System.IO.File.Exists("Profiles.ini"))
        {
            string sKey = "Testing1";

            string FullFilePath = Application.persistentDataPath + "/" + fileName;
            var serializer = new XmlSerializer(typeof(List<Profiles>));
            var stream = new FileStream(FullFilePath, FileMode.Open);

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

            gameObject.GetComponent<OpponentProfiles>().LoadPlayerData();

            //SaveUnEncrypted();

            //LoadUnencrypted();

        }
    }

    //public void LoadUnencrypted()
    //{
    //    int lines_to_delete = 4;
    //    String line = null;
    //    if (System.IO.File.Exists("tempProfiles.ini"))
    //    {
    //        using (StreamReader reader = new StreamReader("tempProfiles.ini"))
    //        using (StreamWriter writer = new StreamWriter("temp.ini"))
    //        {
    //            while (lines_to_delete-- > 0)
    //                reader.ReadLine();
    //            while ((line = reader.ReadLine()) != null)
    //                writer.WriteLine(line);
    //        }
    //        var lines = System.IO.File.ReadAllLines("temp.ini");
    //        System.IO.File.WriteAllLines("temp.ini", lines.Take(lines.Length - 1).ToArray());
    //        Stream profilesSave = new FileStream("temp.ini", FileMode.Open);
    //        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
    //        profiles = (List<Profiles>)serializer2.Deserialize(profilesSave);
    //        profilesSave.Close();
    //    }
    //    else
    //    {
    //        return;
    //    }



    //    // AmountOfButtons();
    //}
    //public void upload()
    //{
    //    FtpWebRequest ftpRequest;
    //    FtpWebResponse ftpResponse;
    //    try
        //{
    //        //Settings required to establish a connection with the server

    //        ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("https://storage.googleapis.com/smashcard/Profiles.ini"));
    //        ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
    //        //ftpRequest.Proxy = null;
    //        ftpRequest.UseBinary = true;
    //        ftpRequest.Credentials = new NetworkCredential("schooluser", "school1!");
    //        //Selection of file to be uploaded

            //FileInfo ff = new FileInfo("Profiles.ini");//e.g.: c:\\Test.txt

            //byte[] fileContents = new byte[ff.Length];

    //        //will destroy the object immediately after being used

            //using (FileStream fr = ff.OpenRead())
            //{
              //  fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
            //}
          //  using (Stream writer = ftpRequest.GetRequestStream())
        //    {
            //    writer.Write(fileContents, 0, fileContents.Length);
      //      }

    //        //Gets the FtpWebResponse of the uploading operation

    //        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

    //        Debug.Log("Upload status ; " + ftpResponse.StatusDescription + " " + ftpResponse.StatusCode); //Display response
    //    }
    //    catch (WebException webex)
    //    {
    //        Debug.Log(webex.ToString());
    //    }
    //}

    //public void upload()
    //{
    //    using (System.Net.WebClient client = new System.Net.WebClient())
    //    {
    //        Uri Check = new Uri("ftp://ftp.rustyaces.com/" + new FileInfo("Profiles.ini").Name);
    //        client.Headers.Remove("Content-Type");
    //        client.Headers.Remove("Content-Disposition");
    //        client.Credentials = new System.Net.NetworkCredential("schooluser", "school1!");
    //        client.UploadFileAsync(Check, "STOR", "Profiles.ini");
    //        client.UploadFileCompleted += WebClientUploadCompleted;
    //        Debug.Log("uploaded started");
    //    }
    //}
    //void WebClientUploadCompleted(object sender, UploadFileCompletedEventArgs e)
    //{
    //   // System.IO.File.Delete("Profiles.ini");
    //    System.IO.File.Delete("temp.ini");
    //    Debug.Log("uploaded completed");
    //}
    //void WebClientUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
    //{
    //    Debug.Log("Download " + e.ProgressPercentage + " complete. ");
    //}


    //public void download()
    //{
    //    using (System.Net.WebClient client = new System.Net.WebClient())
    //    {
    //        Uri Check = new Uri("https://storage.googleapis.com/smashcard/" + new FileInfo("Profiles.ini").Name);
    //        client.Credentials = new System.Net.NetworkCredential("schooluser", "school1!");
    //        client.DownloadFile(Check, "Profiles.ini");
    //        if (!timeSet)
    //        {
    //            timeStamp = Time.time;
    //            timeSet = true;
    //        }


    //        // Invoke("LoadData", 1.5f);
    //    }

    //}

    public static WebResponse GetResponseNoCache(Uri uri)
    {
        // Set a default policy level for the "http:" and "https" schemes.
        HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
        HttpWebRequest.DefaultCachePolicy = policy;
        // Create the request.
        WebRequest request = WebRequest.Create(uri);
        // Define a cache policy for this request only. 
        HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
        request.CachePolicy = noCachePolicy;
        WebResponse response = request.GetResponse();
        Debug.Log("IsFromCache? " + response.IsFromCache);
        return response;
    }

    //public void SaveData()
    //{

    //    if (startProfile)
    //    {
    //        //LoadData();
    //        profiles.Add(myData);

    //        //Stream profilesSave = new FileStream("Profiles.ini", FileMode.Create);

    //        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));

    //        //serializer2.Serialize(profilesSave, profiles);
    //        //profilesSave.Close();

    //        var encoding = System.Text.Encoding.GetEncoding("ASCII");
    //        using (StreamWriter stream = new StreamWriter("Profiles.ini", false, encoding))
    //        {
    //            serializer2.Serialize(stream, profiles);
    //        }

    //    }

    //    if (overwrite)
    //    {
    //        for (int i = 0; i < profiles.Count; i++)
    //        {
    //            if (myData.playerName == profiles[i].playerName)
    //            {
    //                profiles[i] = myData;

    //            }

    //        }
    //        //Stream profilesSave = new FileStream("Profiles.ini", FileMode.Create);
    //        //XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
    //        //serializer2.Serialize(profilesSave, profiles);
    //        //profilesSave.Close();


    //        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));


    //        //serializer2.Serialize(profilesSave, profiles);
    //        //profilesSave.Close();

    //        var encoding = System.Text.Encoding.GetEncoding("ASCII");
    //        using (StreamWriter stream = new StreamWriter("Profiles.ini", false, encoding))
    //        {
    //            serializer2.Serialize(stream, profiles);
    //        }
    //    }
    //    DeleteFileOnFtpServer(new Uri("ftp://ftp.rustyaces.com/Profiles.ini"), "schooluser", "school1!");
    //    upload();


    //}
    //public void LoadData()
    //{
    //    int lines_to_delete = 4;
    //    String line = null;
    //    if (System.IO.File.Exists("Profiles.ini"))
    //    {
    //        using (StreamReader reader = new StreamReader("Profiles.ini"))
    //        using (StreamWriter writer = new StreamWriter("temp.ini"))
    //        {
    //            while (lines_to_delete-- > 0)
    //                reader.ReadLine();
    //            while ((line = reader.ReadLine()) != null)
    //                writer.WriteLine(line);
    //        }
    //        var lines = System.IO.File.ReadAllLines("temp.ini");
    //        System.IO.File.WriteAllLines("temp.ini", lines.Take(lines.Length - 1).ToArray());
    //        Stream profilesSave = new FileStream("temp.ini", FileMode.Open);
    //        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Profiles>));
    //        profiles = (List<Profiles>)serializer2.Deserialize(profilesSave);
    //        profilesSave.Close();

    //        gameObject.GetComponent<OpponentProfiles>().LoadPlayerData();

    //        Debug.Log("Loaded Profiles");
    //    }
    //    else
    //    {
    //        return;
    //    }

    //    for(int i = 0; i < profiles.Count; i++)
    //    {
    //        profileNames.Add(profiles[i].playerName);
    //    }

    //    System.IO.File.Delete("Profiles.ini");
    //    System.IO.File.Delete("temp.ini");

    //    // AmountOfButtons();
    //}

    public static bool DeleteFileOnFtpServer(Uri serverUri, string ftpUsername, string ftpPassword)
    {

        try
        {
            // The serverUri parameter should use the ftp:// scheme.
            // It contains the name of the server file that is to be deleted.
            // Example: ftp://contoso.com/someFile.txt.

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //Console.WriteLine("Delete status: {0}", response.StatusDescription);
            response.Close();
            return true;
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
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

