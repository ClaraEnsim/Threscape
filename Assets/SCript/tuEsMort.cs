using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tuEsMort : MonoBehaviour
{
    public GameObject monster;
    public GameObject GameOver;

    void Start()
    {
        monster.SetActive(true);
        GameOver.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monster.SetActive(false);
            GameOver.SetActive(true);
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("InterfaceDemarrage");
    }
}
