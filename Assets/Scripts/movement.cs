using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class movement : MonoBehaviour, IDataPersistance
{
    [SerializeField] private float _speed = 2f;

    private CharacterController _charController;
    public bool isWalking = false;


    float vertical, horizontal;


    public bool canmove;



    Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        canmove = true;
        _charController = GetComponent<CharacterController>();




        Cursor.lockState = CursorLockMode.Locked;


    }


    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        this.transform.rotation = data.playerRotation;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
        data.playerRotation = Quaternion.Euler(this.transform.rotation.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {

        if (canmove)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            //move player based on WASD Input
            Vector3 movement = Player.instance.hmdTransform.TransformDirection(new Vector3(horizontal, 0, vertical));
            _charController.Move(movement * Time.deltaTime * _speed);
        }



        moveVector = Vector3.zero;


        if (_charController.isGrounded == false)
        {

            moveVector += Physics.gravity;
        }


        _charController.Move(moveVector * Time.deltaTime);


        if (horizontal != 0.000f || vertical != 0.000f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }


    }


}