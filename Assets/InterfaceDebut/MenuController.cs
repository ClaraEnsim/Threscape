using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject instruc1;
    public GameObject instruc2;
    public GameObject instruc3;
    public GameObject enigme;
    public GameObject Jouer;
    public GameObject Quit;
    public GameObject Next;
    public string target;
    public string target2;
    public string target3;
    public Color red1;
    public Color red2;
    public Color red3;

    private int step = 0;

    void Start(){
        instruc1.SetActive(true);
        instruc2.SetActive(false);
        instruc3.SetActive(false);
        enigme.SetActive(false);
        Jouer.SetActive(false);
        Quit.SetActive(false);
        Next.SetActive(true);
    }

    public void btnJouer(){
        SceneManager.LoadScene("Scène_Thread");
    }

    public void btnQuit(){
        Application.Quit();
    }


    public void changementCouleurOeil(){
        GameObject targetObject = GameObject.FindWithTag(target);
        if (targetObject != null)
        {
            Renderer targetRenderer = targetObject.GetComponent<Renderer>();
            if (targetRenderer != null)
            {
                targetRenderer.material.color = red1;
            }
        }
        GameObject targetObject2 = GameObject.FindWithTag(target2);
        if (targetObject2 != null)
        {
            Renderer targetRenderer2 = targetObject2.GetComponent<Renderer>();
            if (targetRenderer2 != null)
            {
                targetRenderer2.material.color = red2;
            }
        }
        GameObject targetObject3 = GameObject.FindWithTag(target3);
        if (targetObject3 != null)
        {
            Renderer targetRenderer3 = targetObject3.GetComponent<Renderer>();
            if (targetRenderer3 != null)
            {
                targetRenderer3.material.color = red3;
            }
        }
    }
    public void btnNext(){
        step++;

        switch (step){
            case 1:
                changementCouleurOeil();
                instruc1.SetActive(false);
                instruc2.SetActive(true);
                break;

            case 2:
                
                instruc2.SetActive(false);
                instruc3.SetActive(true);
                break;

            case 3: 
                instruc3.SetActive(false);
                enigme.SetActive(true);
                Next.SetActive(false);
                Jouer.SetActive(true);
                Quit.SetActive(true);
                break;

            default:
                break;
        }
    }
}
