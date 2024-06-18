using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int totalCherries;
    [SerializeField] private Text CherriesText;
    [SerializeField] private Text LevelText;
    [SerializeField] private AudioSource collectsoundeffect;

    private int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        totalCherries = GameObject.FindGameObjectsWithTag("cheery").Length;
        CherriesText.text = "Cherries: " + cherries + "/" + totalCherries;
        LevelText.text =  "Level: " + currentLevelIndex ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cheery"))
        {
            collectsoundeffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            CherriesText.text = "Cherries: " + cherries + "/" + totalCherries;
            LevelText.text =  "Level: " + currentLevelIndex ;
        }
    }
    public bool checkCherries()
    {
        return cherries == totalCherries;
    }
}

