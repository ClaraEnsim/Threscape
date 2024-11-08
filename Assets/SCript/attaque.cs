using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


public class attaque : MonoBehaviour
{
    public GameObject chaser; // Référence au GameObject qui poursuit
    public Transform player;   // Référence au joueur
    public float movementThreshold = 0.1f; // Seuil pour déclencher la poursuite
    public float chaseThreshold = 3f;
    public string target;
    public string target2;
    public string target3;
    public Color red1;
    public Color red2;
    public Color red3;
    private Vector3 lastPosition;
    private bool isPursuing = false;
    private NavMeshAgent agent;


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

    void Start()
    {
        lastPosition = transform.position;
        agent = chaser.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(lastPosition, transform.position);

        if (distanceMoved > movementThreshold && !isPursuing)
        {
            isPursuing = true;
        }

        if (isPursuing && agent.isOnNavMesh)
        {
            changementCouleurOeil();
            agent.SetDestination(player.position);
        }

        lastPosition = transform.position;
    }

    
}
