using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreTextObject;
    private SceneChanger singleton;

    private void Awake()
    {
        scoreTextObject = GetComponent<TextMeshProUGUI>();
        singleton = FindObjectOfType<SceneChanger>();
    }
    // Update is called once per frame
    void Update()
    {
        if (scoreTextObject != null)
        {
            scoreTextObject.text = "Score: " + singleton.score;
        }
    }
}
