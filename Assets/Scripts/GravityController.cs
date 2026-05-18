using System;
using UnityEngine;

using UnityEngine.InputSystem;

public class GravityController : MonoBehaviour
{
    [Tooltip("default gravity is 9.81")]
    [SerializeField]
    private float gravity = 9.81f;
    
    [SerializeField]
    private float gravityScale = 1f;
    
    //
    [SerializeField] 
    private PlayerInput playerInput;
    
    private InputAction moveAction;
    private InputAction gravityAction;

    private void Awake()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }
        
        moveAction = playerInput.actions["Move"];
        gravityAction = playerInput.actions["GravityAction"]; //"Z or Space"
    }
    
    /*private void OnEnable()
    {
        moveAction.performed += ctx =>
        {
            Vector3 vector = ctx.ReadValue<Vector2>();
            Physics.gravity = vector.normalized * (gravity * gravityScale);
        };
        
        gravityAction.performed += ctx =>
        {}
    }*/
    
    


    private void Update()
    {
        Vector3 vector = Vector3.zero;
        
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        
        vector.x = moveInput.x;
        vector.z = moveInput.y;
        

        bool isZPressed = gravityAction.IsPressed();

        if (isZPressed)
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }
        
        Physics.gravity = vector.normalized * (gravity * gravityScale);

    }


    /*
     // old input
    void Update()
    {
        Vector3 vector = new Vector3();
        
        
        vector.x = Input.GetAxis("Horizontal");
        vector.z = Input.GetAxis("Vertical");

        if (Input.GetKey("z"))
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }
        
        Physics.gravity = vector.normalized * (gravity * gravityScale);
    }
    */
    
}
