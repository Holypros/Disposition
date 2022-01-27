using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    int horizntal;
    int vertical;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizntal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }
    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        //Animation Snapping
        float snappedHorizontal;
        float snappedVertical;

        #region SnappedHorizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
            snappedHorizontal = 0.5f;
        else if (horizontalMovement > 0.55f)
            snappedHorizontal = 1;
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
            snappedHorizontal = -0.55f;
        else if (horizontalMovement < -0.55f)
            snappedHorizontal = -1;
        else
            snappedHorizontal = 0;
        #endregion

        #region SnappedVertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
            snappedVertical = 0.5f;
        else if (verticalMovement > 0.55f)
            snappedVertical = 1;
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
            snappedVertical = -0.55f;
        else if (verticalMovement < -0.55f)
            snappedVertical = -1;
        else
            snappedVertical = 0; 
        #endregion

        animator.SetFloat(horizntal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);

    }
}
