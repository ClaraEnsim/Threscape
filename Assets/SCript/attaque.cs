using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class attaque : MonoBehaviour
{
    public GameObject chaser; // Référence au GameObject qui poursuit
    public Transform player;   // Référence au joueur
    public float movementThreshold = 0.01f; // Seuil pour déclencher la poursuite
    //public float chaseThreshold = 3f;
    public string target;
    public string target2;
    public string target3;
    public Color red1;
    public Color red2;
    public Color red3;
    private Vector3 lastPosition;
    private bool isPursuing = false;
    private NavMeshAgent agent;
    public GameObject UIgameOver;

    public void changementCouleurOeil()
    {
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

/*
    void Start()
    {
        UIgameOver.SetActive(false);
        lastPosition = transform.position;
        agent = chaser.GetComponent<NavMeshAgent>();
    }

    void Update()
{
    float distanceMoved = Vector3.Distance(lastPosition, transform.position);

    if (distanceMoved > movementThreshold && !isPursuing)
    {
        isPursuing = true;
        changementCouleurOeil();
        Debug.Log("La poursuite commence !");
    }

    if (isPursuing && agent.isOnNavMesh)
    {
        agent.SetDestination(player.position);
    }

    lastPosition = transform.position;
}

// Détecte la collision avec le joueur pour déclencher le Game Over
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) {
            StartCoroutine(GameOVer());
        }
    }
*/


void Start()
{
    if (UIgameOver != null)
    {
        UIgameOver.SetActive(false);
    }
    else
    {
        print("UIgameOver n'est pas assigné !");
    }

    lastPosition = transform.position;
    agent = chaser.GetComponent<NavMeshAgent>();

    if (agent == null)
    {
        print("NavMeshAgent manquant sur chaser !");
    }
    else if (!agent.isOnNavMesh)
    {
        print("Le monstre n'est pas sur le NavMesh !");
    }
}

void Update()
{
    float distanceMoved = Vector3.Distance(lastPosition, transform.position);

    if (distanceMoved > movementThreshold && !isPursuing)
    {
        isPursuing = true;
        changementCouleurOeil();
        print("La poursuite commence !");
    }

    if (isPursuing && agent.isOnNavMesh)
    {
        agent.SetDestination(player.position);
        print("Le monstre poursuit le joueur.");
    }

    lastPosition = transform.position;
}

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("MainCamera"))
    {
        print("Collision détectée avec le joueur !");
        StartCoroutine(GameOVer());
    }
}

    IEnumerator GameOVer()
    {
        UIgameOver.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("InterfaceDemarrage");
    }


}
