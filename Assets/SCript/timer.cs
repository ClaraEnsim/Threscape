using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _timeRemaining;
    
    public GameObject timerText;
    public GameObject UIgameOver;
    void Start()
    {
        UIgameOver.SetActive(false);
        timerText.SetActive(true);
        
    }

    IEnumerator WaitingFailed()
    {
        timerText.SetActive(false);
        UIgameOver.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("InterfaceDemarrage");
    }

    
    // Update is called once per frame
    void Update()
    {
        if(_timeRemaining < 0)return;
        _timeRemaining -= Time.deltaTime;
        if (_timeRemaining < 0){
        _timeRemaining = 0;
        StartCoroutine(WaitingFailed());
        }
        UpdateText();
        
    }

    private void UpdateText(){
        int minutes = Mathf.FloorToInt(_timeRemaining / 60);
        int seconds = Mathf.FloorToInt(_timeRemaining % 60);
        _text.text = $"{minutes:00}:{seconds:00}";
    }
}
