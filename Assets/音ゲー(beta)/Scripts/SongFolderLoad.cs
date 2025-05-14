using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SongFolderLoad : MonoBehaviour
{
    [SerializeField] string[] fs;
    //[SerializeField] string[] filename;

    [SerializeField] GameObject songPreset;

    /*
    [SerializeField] GameObject NameText;
    [SerializeField] GameObject ArtistText;
    [SerializeField] GameObject DifficultText;
    [SerializeField] GameObject JacketImage;
    */

    GameObject canvas;

    [Serializable]
    public class JsonData
    {
        public string Name;
        public string Artist;
        public int Difficult;

        public string jsonPath;
        public string Jacket;
        public string Song;

        public JsonData(string name, string artist, int difficult, string jsonPath, string jacket, string song)
        {
            this.Name = name;
            this.Artist = artist;
            this.Difficult = difficult;
            this.jsonPath = jsonPath;
            this.Jacket = jacket;
            this.Song = song;
        }
    }

    [SerializeField]
    public JsonData[] Songs = new JsonData[0];

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");

        string folderPath = "Assets/âπÉQÅ[(beta)/songs";
        fs = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly);
        
        foreach (string f in fs)
        {
            string stFileName = Path.GetFileName(f);
            string infoJsonPath = "Assets/âπÉQÅ[(beta)/songs/" + stFileName + "/info.json";
            string jsonString = File.ReadAllText(infoJsonPath);
            JsonData json = JsonUtility.FromJson<JsonData>(jsonString);

            Array.Resize(ref Songs, Songs.Length + 1);

            Songs[Songs.Length - 1] = new JsonData(json.Name, json.Artist, json.Difficult, json.jsonPath, json.Jacket, json.Song);

            GameObject songObj = Instantiate(songPreset);
            songObj.transform.position = new Vector3(1000 * (Songs.Length - 1), -200, 0);

            songObj.transform.SetParent(canvas.transform, false);

            /*
            GameObject name = Instantiate(NameText, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject artist = Instantiate(ArtistText, new Vector3(0, -100, 0), Quaternion.identity);
            GameObject difficult = Instantiate(DifficultText, new Vector3(250, 100, 0), Quaternion.identity);
            GameObject jacket = Instantiate(JacketImage, new Vector3(0, 500, 0), Quaternion.identity);
            */

            TextMeshProUGUI nameText = songObj.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
            nameText.text = Songs[Songs.Length - 1].Name;

            TextMeshProUGUI artistText = songObj.transform.Find("Artist").gameObject.GetComponent<TextMeshProUGUI>();
            artistText.text = Songs[Songs.Length - 1].Artist;

            TextMeshProUGUI difficultText = songObj.transform.Find("Difficult").gameObject.GetComponent<TextMeshProUGUI>();
            difficultText.text = Songs[Songs.Length - 1].Difficult.ToString();

            var rawData = File.ReadAllBytes("Assets/âπÉQÅ[(beta)/songs/" + stFileName + "/" + json.Jacket);
            Texture2D texture2D = new Texture2D(0, 0);
            texture2D.LoadImage(rawData);

            Image image_jacket = songObj.transform.Find("Jacket").gameObject.GetComponent<Image>();
            image_jacket.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);

            //Debug.Log($"{json.Name}\n{json.Artist}\n{json.Difficult}\n{json.jsonPath}\n{json.Jacket}\n{json.Song}");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
