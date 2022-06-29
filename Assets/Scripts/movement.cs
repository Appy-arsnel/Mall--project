using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
public class movement : MonoBehaviour, IDataPersistance
{
   [SerializeField]private float _speed = 7f;
    [SerializeField]private float _mouseSensitivity = 50f;
    [SerializeField]private float _minCameraview = -70f, _maxCameraview = 80f;
    private CharacterController _charController;
    [SerializeField] private Camera _fppcamera;
        [SerializeField] private Camera _tppcamera;
        private Camera _camera =null;
        bool istpp;
          [SerializeField] private GameObject _tppc;
                    [SerializeField] private GameObject _fppc;
    public bool isWalking = false;

    public bool canmove;
    private int n;
    private bool iswaving;
    private float xRotation = 0f;
         Vector3 moveVector;
         private bool iswalking;
 private Animator animator;
  float vertical,horizontal;

    // Start is called before the first frame update
    void Start()
    {       canmove=true;
        _charController = GetComponent<CharacterController>();
        _fppc.SetActive(true);
                _tppc.SetActive(false);

       _camera = _fppcamera;

 Cursor.lockState = CursorLockMode.Locked;
       istpp=false;

        if(_charController == null)
        Debug.Log("No Character Controller Attached to Player");

        Cursor.lockState = CursorLockMode.Locked;
        animator= GetComponent<Animator>();
        iswalking=false;
        
    }
    IEnumerator waiter()
{       canmove=false;
     animator.SetBool("iswaving",true);
    yield return new WaitForSeconds(2);
   animator.SetBool("iswaving",false);
       yield return new WaitForSeconds(1);

           canmove=true;

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
        //Get WASD Input for Player
       // _camera.SetActive(true);
       if(canmove){
             vertical = Input.GetAxis("Vertical");
         horizontal = Input.GetAxis("Horizontal");
        //move player based on WASD Input
        Vector3 movement = transform.forward * vertical + transform.right * horizontal; //changed this line.
        _charController.Move(movement * Time.deltaTime * _speed);

       }
        
       
        //Get Mouse position Input
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity; //changed this line.
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity; //changed this line.
          //Rotate the camera based on the Y input of the mouse
          xRotation -= mouseY;
          //clamp the camera rotation between 80 and -70 degrees
          xRotation = Mathf.Clamp(xRotation, _minCameraview, _maxCameraview);

          _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
          //Rotate the player based on the X input of the mouse
          transform.Rotate(Vector3.up * mouseX * 3);
            
            moveVector = Vector3.zero;
 
         //Check if cjharacter is grounded
         if (_charController.isGrounded == false)
         {
             //Add our gravity Vector
             moveVector += Physics.gravity;
         }
 
         //Apply our move Vector , remeber to multiply by Time.delta
         _charController.Move(moveVector * Time.deltaTime);


         
        //float horizontal = Input.GetAxis("Horizontal");
            if(Input.GetKeyDown(KeyCode.C)){
            if(istpp==false){
            _camera=_tppcamera;
            _fppc.SetActive(false);
                _tppc.SetActive(true);
            istpp=true;
        }
        else if(istpp==true){
            _camera=_fppcamera;
            _fppc.SetActive(true);
                _tppc.SetActive(false);
            istpp=false;
        }
        
        }
            
        if(Input.GetKeyDown(KeyCode.Y)){
                           
                        StartCoroutine(waiter());
        }

        //      if(n%2==0){
        //                 iswaving=true;
        //                 n++;
        //     }
        //     else{
        //                     iswaving=false;
        //                     n++;
        //     }

        if (horizontal != 0.000f || vertical != 0.000f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }


    }
          void FixedUpdate() {
             // _camera.SetActive(true);
               if(vertical>0||vertical<0||horizontal>0||horizontal<0){
                         animator.SetBool("isWalking",true);
              


            }
            else if(horizontal==0&&vertical==0){
             animator.SetBool("isWalking",false);

            }
            else{
                  animator.SetBool("isWalking",false);
            }
            // if(iswaving){
            //     animator.SetBool("iswaving",true);
            //     canmove=false;
            // }
            // else{
            //                     animator.SetBool("iswaving",false);
            //                     canmove=true;

            // }

            
        
    }
    
}