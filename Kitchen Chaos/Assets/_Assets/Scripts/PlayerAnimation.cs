using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private Animator playerAnim;
   [SerializeField] private PlayerController playerControllerScript;
    private void Awake() {
        playerAnim = GetComponent<Animator>();
    }
    private void Update() {

        playerAnim.SetBool("IsWalking", playerControllerScript.IsWalking());
    }
}
