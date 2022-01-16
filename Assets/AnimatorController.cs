using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator playerAnim;
    public IEnumerator Eat()
    {
        playerAnim.SetTrigger("Eat");
        playerAnim.SetBool("action", true);
        yield return new WaitForSeconds(0.8f);
        playerAnim.SetBool("action", false);
    }
}
