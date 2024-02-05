using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    private int score;

    bool dead = false;
    public TextMeshProUGUI Info_MidScreen;
    public AudioSource deathSound;

    public GameObject Player;
    public AudioSource CubeCollected;
    public Collectible[] objectsToCollect;
    public int maxScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Player.transform.position.y < -1 && !dead)
        {
            Die();
        }
    }

    private void Start()
    {
        FindObjectsToCollect();
        CalculateMaxScore();

        score = 0;
        UpdateScoreText();

        foreach (var item in objectsToCollect) 
        { item.pickupEvent += IncrementScore;}
    }

    //Score
    private void FindObjectsToCollect()
    {
        objectsToCollect = GameObject.FindObjectsOfType<Collectible>();
    }

    public void CalculateMaxScore()
    {
        maxScore = objectsToCollect.Length;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }

    public void IncrementScore()
    {
        score++;
        CubeCollected.Play();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    //Death
    public void Die()
    {
        if (!dead)
        {
            Invoke(nameof(ReloadLevel), 1.3f);
            dead = true;
            deathSound.Play();
            Info_MidScreen.text = "YOU DIED";
        }
    }

    public void DieToEnemy()
    {
        if (!dead)
        {

            Invoke(nameof(ReloadLevel), 1.3f);
            dead = true;
            deathSound.Play();
            Info_MidScreen.text = "YOU DIED";
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}