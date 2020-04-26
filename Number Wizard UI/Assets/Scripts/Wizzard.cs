using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.Examples;

public class Wizzard : MonoBehaviour
{

    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] TextMeshProUGUI responseText;

    int response;
    // Start is called before the first frame update
    void Start()
    {
        NextGuess();
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //responseText.text = response.ToString();
    }

    public void OnPressHIGH()
    {
        min = response;
        NextGuess();
    }

    public void OnPressLOW()
    {
        max = response;
        NextGuess();
    }

    public void NextGuess()
    {
        //response = (max + min) / 2;
        response = Random.Range(min , max + 1);
        responseText.text = response.ToString();


    }
}
