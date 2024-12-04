using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRespawn : MonoBehaviour
{
    [SerializeField] float respawnTime = 1f;
    Camera cam;
    float camHeight;
    float camWidth;

    AgentMovement[] agents;

    private void Start()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;

        agents = FindObjectsOfType<AgentMovement>();
    }

    private void Update()
    {
        CheckForEdgeScreen();
    }

    public IEnumerator Respawn(AgentMovement agent)
    {
        agent.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnTime);

        agent.gameObject.SetActive(true);
    }

    private void CheckForEdgeScreen()
    {
        foreach(AgentMovement agent in agents)
        {
            if (agent.transform.position.x <= -camWidth / 2f)
            {
                StartCoroutine(Respawn(agent));
            }
        }
    }
}
