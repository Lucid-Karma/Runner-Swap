using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private Animator animator;

    void OnEnable()
    {
        EventManager.OnPlayerStartedRunning.AddListener(StartRun);
        EventManager.OnCharacterJump.AddListener(StartJump);
        EventManager.OnPreLevelFail.AddListener(StartStumble);
        EventManager.OnLevelFail.AddListener(StartDie);
    }
    void OnDisable()
    {
        EventManager.OnPlayerStartedRunning.RemoveListener(StartRun);
        EventManager.OnCharacterJump.RemoveListener(StartJump);
        EventManager.OnPreLevelFail.RemoveListener(StartStumble);
        EventManager.OnLevelFail.RemoveListener(StartDie);
    }

    void StartRun()
    {
        animator.SetBool("isRuning", true);
    } 

    void StartJump()
    {
        animator.SetBool("isJumping", true);
        StartCoroutine(StopJumpAnimation());
    }
    IEnumerator StopJumpAnimation()
    {
        //yield return null;
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("isJumping", false);
    }

    void StartStumble()
    {
        animator.SetBool("isStumbling", true);
    }

    void StartDie()
    {
        animator.SetBool("isDying", true);
    }
}
