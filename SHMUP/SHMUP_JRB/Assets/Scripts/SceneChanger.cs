using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int score;
    // Singleton 
    private static GameObject instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGamerOverScene()
    {
        SceneManager.LoadScene(2);
    }
}
