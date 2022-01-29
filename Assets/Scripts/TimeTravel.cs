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

        if (mRendererOne == null)
            mRendererOne = GameObject.Find("female_zbrush11").GetComponent<SkinnedMeshRenderer>();

        if (mRendererTwo == null)
            mRendererTwo = GameObject.Find("female_zbrush12").GetComponent<SkinnedMeshRenderer>();

        if (mRendererOneOne == null)
            mRendererOneOne = GameObject.Find("female_zbrush1").GetComponent<SkinnedMeshRenderer>();

        if (mRendererTwoTwo == null)
            mRendererTwoTwo = GameObject.Find("female_zbrush2").GetComponent<SkinnedMeshRenderer>();

        if (mRendererOneOneOne == null)
            mRendererOneOneOne = GameObject.Find("Rifle1").GetComponent<MeshRenderer>();

        if (mRendererTwoTwoTwo == null)
            mRendererTwoTwoTwo = GameObject.Find("Rifle2").GetComponent<MeshRenderer>();

        mRendererTwo.enabled = false;
        mRendererTwoTwo.enabled = false;
        mRendererTwoTwoTwo.enabled = false;

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
            mRendererTwo.enabled = true;
            mRendererOne.enabled = false;
            mRendererTwoTwo.enabled = true;
            mRendererOneOne.enabled = false;
            mRendererTwoTwoTwo.enabled = true;
            mRendererOneOneOne.enabled = false;

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
            isWorldTwoActive = false;
            isWorldOneActive = true;
        }
    }
}