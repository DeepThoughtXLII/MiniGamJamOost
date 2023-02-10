using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;

public class HighscoreTracker : MonoBehaviour
{


    [SerializeField] GameObject scorePrefab;
    [SerializeField] Transform scoreParent;

    List<ScoreWrapper> highscores = new List<ScoreWrapper>();
    List<string> scores = new List<string>();

    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        //yourScore = UnityEngine.Random.Range(1, 2000);
        textScore.text = Score.instance.yourScore.ToString();
    }



    #region sortScores

    private void sortScores()
    {
        for (int i = 1; i < highscores.Count; i++)
        {
            var key = highscores[i].score;
            var flag = 0;
            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (key > highscores[j].score)
                {
                    highscores[j + 1].score = highscores[j].score;
                    j--;
                    highscores[j + 1].score = key;
                }
                else flag = 1;
            }
        }
    }
    #endregion


    #region writeScores
    public void SaveInput()
    {
        saveScore(textScore.text, input.text);
        ReadHighscoreList();
    }

    private void saveScore(string score, string name)
    {
        string entry = name + "_" + score;

        using (StreamWriter sw = File.AppendText("highscores.txt"))
        {
            sw.WriteLine(entry);
        }
    }
    #endregion


    #region readScores
    private void ReadHighscoreList()
    {
        scores.Clear();
        try
        {
            using (StreamReader sr = new StreamReader("highscores.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Debug.Log(line);
                    scores.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
        parseScores();
        sortScores();
        displayScores();
    }

    private void displayScores()
    {
        for (int i = 0; i < highscores.Count; i++)
        {
            GameObject entry = (GameObject)Instantiate(scorePrefab, scoreParent);
            int placement = i + 1;
            entry.GetComponent<hs_entry>().SetEntry(placement.ToString(), highscores[i].name, highscores[i].score.ToString());
        }
    }

    private void parseScores()
    {
        foreach (string line in scores)
        {
            string[] item = line.Split("_");
            Debug.Log(item.Length);    
            highscores.Add(new ScoreWrapper(int.Parse(item[1]), item[0]));
        }
    }

    #endregion
}



public class ScoreWrapper
{
    public string name;
    public int score;

    public ScoreWrapper(int pScore, string pName)
    {
        score = pScore;
        name = pName;
    }
}