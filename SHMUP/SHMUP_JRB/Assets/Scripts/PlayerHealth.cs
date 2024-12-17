using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 4;
    [SerializeField] RectTransform healthBar;

    public int Health { get { return health; } set { health = value; } }

    // Update is called once per frame
    void Update()
    {
        healthBar.sizeDelta = new Vector2(health * 100, 50);
        if(health <= 0)
        {
            FindObjectOfType<SceneChanger>().LoadGamerOverScene();
            // StartCoroutine(GetComponent<PlayerRespawn>().Respawn());
        }
    }
}
