using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(StartRun);
        //EventManager.OnCharacterJump.AddListener(ControlRun);
        EventManager.OnCharacterJump.AddListener(() => InvokeTrigger("Jump"));
        EventManager.OnPreDieAnimate.AddListener(() => InvokeTrigger("Stumble"));
        EventManager.OnLevelFail.AddListener(EndRun);
        EventManager.OnLevelFail.AddListener(() => InvokeTrigger("Die"));
    }
    void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(StartRun);
        //EventManager.OnCharacterJump.RemoveListener(ControlRun);
        EventManager.OnCharacterJump.RemoveListener(() => InvokeTrigger("Jump"));
        EventManager.OnPreDieAnimate.RemoveListener(() => InvokeTrigger("Stumble"));
        EventManager.OnLevelFail.RemoveListener(EndRun);
        EventManager.OnLevelFail.RemoveListener(() => InvokeTrigger("Die"));
    }

    /*private void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        Animator.SetBool("isRunning", GameManager.Instance.IsLevelStarted);
        //Animator.SetBool("isDying", GameManager.Instance.IsDead);
    }*/

    void StartRun()
    {
        Animator.SetBool("isRunning", true);
    }
    void EndRun()
    {
        Animator.SetBool("isRunning", false);
    }
    /*void ControlRun()
    {
        StartCoroutine(WaitAfterJump());
    }
    IEnumerator WaitAfterJump()
    {
        Animator.SetBool("isRunning", false);
        yield return new WaitForSeconds(1.0f);

        if(!GameManager.Instance.IsDead)
            Animator.SetBool("isRunning", true);
    }*/

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
}
