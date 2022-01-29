using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionShifting : MonoBehaviour
{
    TimeTravel _timeTravel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
               _timeTravel = other.GetComponent<TimeTravel>();
               _timeTravel.ChangeWorld();
            }
        }
    }
}
