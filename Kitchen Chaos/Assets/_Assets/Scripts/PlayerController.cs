using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float movingSpeed;
    [SerializeField] private float rotationSpeed;
    private bool isWalking;
  

    private void Update() {
        /*  float horizontalInput = Input.GetAxis("Horizontal");
          float verticalInput = Input.GetAxis("Vertical");
          Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
          isWalking = movementDirection.magnitude>0.01f ;
          transform.forward = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
          transform.Translate(movementDirection * movingSpeed * Time.deltaTime,Space.World);*/


        //if we use space.self then it will not behave accordingly as its cordinates will be on its own space, so 
        // we used space.world so that wherever we are facing it always moves in global coordinates
        // and by using transform.forward we are getting current direction 
        // transform.Translate( movementDirection* movingSpeed * Time.deltaTime,Space.World);


        testRun();
       

    }
    public bool IsWalking() {
        Debug.Log(isWalking);
        return isWalking;
    }
    public void testRun() {

        if(Input.GetKey(KeyCode.Space))
        transform.Translate(transform.forward * 3 * Time.deltaTime);

    }
    private void PlayerMovement() {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;

        Vector3 movementDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += movementDirection * movingSpeed * Time.deltaTime;
        isWalking = movementDirection != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
    }
}

