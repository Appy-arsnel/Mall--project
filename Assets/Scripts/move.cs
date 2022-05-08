using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class move : MonoBehaviour
{ 
   [SerializeField]private float _speed = 2f;

private CharacterController _charController;
[SerializeField] private Camera _fppcamera;
private Camera _camera = null;





Vector3 moveVector;

float vertical, horizontal;

// Start is called before the first frame update
void Start()
{
   
    _charController = GetComponent<CharacterController>();
   

    _camera = _fppcamera;

 
    Cursor.lockState = CursorLockMode.Locked;
   
}


// Update is called once per frame
void Update()
{
    //Get WASD Input for Player
    // _camera.SetActive(true);
  
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        //move player based on WASD Input

        Vector3 movement = Player.instance.hmdTransform.TransformDirection(new Vector3(horizontal, 0, vertical));
        _charController.Move(movement * Time.deltaTime * _speed);

    


  

    moveVector = Vector3.zero;

    //Check if cjharacter is grounded
    if (_charController.isGrounded == false)
    {
        //Add our gravity Vector
        moveVector += Physics.gravity;
    }

    //Apply our move Vector , remeber to multiply by Time.delta
    _charController.Move(moveVector * Time.deltaTime);



}

    
}