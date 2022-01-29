using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
   public bool isWorldOneActive;
    public bool isWorldTwoActive;
    [SerializeField] GameObject worldOne;
    [SerializeField] GameObject worldTwo;
    [SerializeField] SkinnedMeshRenderer mRendererOne;
    [SerializeField] SkinnedMeshRenderer mRendererTwo;
    [SerializeField] SkinnedMeshRenderer mRendererOneOne;
    [SerializeField] SkinnedMeshRenderer mRendererTwoTwo;
    [SerializeField] MeshRenderer mRendererOneOneOne;
    [SerializeField] MeshRenderer mRendererTwoTwoTwo;
    public GameObject uiBlue;
    public GameObject uiRed;


    private void Awake()
    {
        isWorldOneActive = true;
        isWorldTwoActive = false;

    }
    private void Start()
    {
        

        mRendererTwo.enabled = false;
        mRendererTwoTwo.enabled = false;
        mRendererTwoTwoTwo.enabled = false;
        uiRed.SetActive(true);
        
        

    }
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.T))
        //{
        //    ChangeWorld();
        //}
    }
   public void ChangeWorld()
    {
        if(isWorldOneActive == true && isWorldTwoActive == false)
        {
            worldOne.SetActive(false);
            worldTwo.SetActive(true);
            mRendererTwo.enabled = true;
            mRendererOne.enabled = false;
            mRendererTwoTwo.enabled = true;
            mRendererOneOne.enabled = false;
            mRendererTwoTwoTwo.enabled = true;
            mRendererOneOneOne.enabled = false;
            uiRed.SetActive(false);
            uiBlue.SetActive(true);

            isWorldTwoActive = true;
            isWorldOneActive = false;
        }
        else if (isWorldOneActive == false && isWorldTwoActive == true)
        {
            worldOne.SetActive(true);
            worldTwo.SetActive(false);
            mRendererTwo.enabled = false;
            mRendererOne.enabled = true;
            mRendererTwoTwo.enabled = false;
            mRendererOneOne.enabled = true;
            mRendererTwoTwoTwo.enabled = false;
            mRendererOneOneOne.enabled = true;
             uiBlue.SetActive(false);
            uiRed.SetActive(true);
            isWorldTwoActive = false;
            isWorldOneActive = true;
           
        }
    }
}