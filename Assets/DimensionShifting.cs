using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionShifting : MonoBehaviour
{
     
    public TimeTravel _timeTravel;
    public GameObject dialog;
    bool playerEnter;
    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && playerEnter == true)
        {
            _timeTravel.ChangeWorld();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEnter = true;
            dialog.SetActive(true);       
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEnter = false;
            dialog.SetActive(false);
        }

    }
}
