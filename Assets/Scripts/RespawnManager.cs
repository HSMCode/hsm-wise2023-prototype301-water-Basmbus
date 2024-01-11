using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    public GameObject buttonContinue; // Todesnachricht und Zurücksetzschaltfläche
    public GameObject buttonWin; // Gewinnnachricht und Neustartschaltfläche
    public GameObject jellyFish;
    public bool Death;
    public bool GameWon;

    void Start()
    {
        buttonContinue.SetActive(false); // Zurücksetzschaltfläche ausblenden
        buttonWin.SetActive(false);
    }

    void Update()
    {
        Death = jellyFish.GetComponent<DestroyOnCollision>().Death;
        if (Death)
        {
            buttonContinue.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                StartCoroutine(ResetWithDelay());
            }
        }

        GameWon = jellyFish.GetComponent<CubeController>().GameWon;
        if (GameWon)
        {
            buttonWin.SetActive(true);
            if (Input.GetKeyDown("space"))
            {
                StartCoroutine(ResetWithDelay());
            }
        }
    }

    IEnumerator ResetWithDelay()
    {
        yield return new WaitForSeconds(1f); // Wartezeit von 2 Sekunden

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Szene neu laden
    }
}