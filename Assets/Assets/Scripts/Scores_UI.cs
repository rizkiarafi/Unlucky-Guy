using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores_UI : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text scoreText;
    int scoreNumber = 0;

    bool canAddScore;
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreNumber.ToString();
    }

    public void AddScores()
    {
        if (canAddScore == false)
        {
            scoreNumber += 1;
            canAddScore = true;
            StartCoroutine("AllowAddingScore");
        }
    }

    IEnumerator AllowAddingScore()
    {
        yield return new WaitForSeconds(4f);
        canAddScore = false;
    }
}
