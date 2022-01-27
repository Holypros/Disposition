using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    bool isWorldOneActive;
    bool isWorldTwoActive;
    [SerializeField] GameObject worldOne;
    [SerializeField] GameObject worldTwo;
    private void Awake()
    {
        isWorldOneActive = true;
        isWorldTwoActive = false;

    }
    private void Start()
    {
        if (worldOne == null)
            worldOne = GameObject.FindGameObjectWithTag("WorldOne");

        if (worldTwo == null)
            worldTwo = GameObject.FindGameObjectWithTag("WorldTwo");

          worldTwo.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ChangeWorld();
        }
    }
    void ChangeWorld()
    {
        if(isWorldOneActive == true && isWorldTwoActive == false)
        {
            worldOne.SetActive(false);
            worldTwo.SetActive(true);
            isWorldTwoActive = true;
            isWorldOneActive = false;
        }
        else if (isWorldOneActive == false && isWorldTwoActive == true)
        {
            worldOne.SetActive(true);
            worldTwo.SetActive(false);
            isWorldTwoActive = false;
            isWorldOneActive = true;
        }
    }
}
