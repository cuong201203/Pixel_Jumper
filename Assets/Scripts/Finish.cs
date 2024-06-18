using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishsound;
    private bool levelcomplete = false;

    private void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelcomplete)
        {
            bool cherriesCollected = FindObjectOfType<ItemCollector>().checkCherries();
            if (cherriesCollected)
            {
                finishsound.Play();
                levelcomplete = true;
                Invoke("Completelevel", 2f);

                int currentLevel = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("Level" + currentLevel, 1);
                PlayerPrefs.Save();
            }
        }
    }

    private void Completelevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
