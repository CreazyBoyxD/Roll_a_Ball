using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public TextMeshProUGUI cubesText;
    public TextMeshProUGUI infoText;
    public AudioSource ExitNotGood;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            int maxScore = GameManager.instance.GetMaxScore();

            if (cubesText.text == "Score: " + maxScore)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                ExitNotGood.Play();
                infoText.text = "COLLECT 5 CUBES TO CONTINUE...";
                Invoke("clearText", 2f);
            }
        }
    }
    void clearText()
    {
        infoText.text = " ";
    }
}