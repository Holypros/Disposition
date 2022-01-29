using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;
    [SerializeField] private Animator myDoor = null;

    public string code = "";
    public string attemptedCode;

    private void Start()
    {
        codeLength = code.Length;
    }

    public void SetValue(string value)
    {
        placeInCode++;
        if(placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            myDoor.Play("OpenDoor", 0, 0);
        }
        else
        {
            Debug.Log("WrongCode");
        }
    }

}
