using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDetector_balanceTheObjects : MonoBehaviour
{
    public GameObject Player;
    public Animator animator;


    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag.Equals("Object") == true)
        {
            Debug.Log("object fell");
            Player.GetComponent<playerMovement_balanceTheObjects>().enabled = false;
            animator.SetFloat("Speed", 0f);
        }
    }
}
