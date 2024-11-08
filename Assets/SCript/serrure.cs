using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class serrure : MonoBehaviour
{
    public GameObject instruc;
    public GameObject succes;
    public GameObject defaite;
    

    void Start()
    {
        instruc.SetActive(true);
        succes.SetActive(false);
        defaite.SetActive(false);

    }

    IEnumerator WaitingSuccess(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("InterfaceDemarrage");
    }

    IEnumerator WaitingFailed(){
        yield return new WaitForSeconds(4);
        defaite.SetActive(false);
        instruc.SetActive(true);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider key)
    {
        if (key.gameObject.tag == "keySuccess"){
            instruc.SetActive(false);
            succes.SetActive(true);
            StartCoroutine(WaitingSuccess());
        }
        if (key.gameObject.tag == "keyFailed"){
            instruc.SetActive(false);
            defaite.SetActive(true);
            StartCoroutine(WaitingFailed());
        }
    }
}
