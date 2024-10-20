using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayTransition : MonoBehaviour
{
    [SerializeField] public Animator animator;

    [SerializeField] private string currentState = "Idle";
    // Start is called before the first frame update

    public void StartTransition()
    {
        ChangeAnimatiionState("loadup");
    }
    private void ChangeAnimatiionState(string newState)
    {
        if (currentState == newState){
            return;
        }
        currentState = newState;
        animator.Play(currentState);
    }

    public void Update()
    {
        if(IsAnimationPlaying("Finished"))
        {
            OnTransitionComplete();
        }
    }

    private bool IsAnimationPlaying(string animName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animName);
    }

    public void OnTransitionComplete()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
