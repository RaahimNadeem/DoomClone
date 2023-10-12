using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // we use float since we only have one axis to deal with
    public float sensitivity = 1.5f; 
    public float smoothing = 1.5f;

    private void Start()
    {
        // we lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // we need variable to rotate our player
    private float currentLookingPos;

    private float xMousePos; 
    private float smoothMousePos; 

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        // we multiply by sensitivity to make the rotation faster
        xMousePos = xMousePos * sensitivity * smoothing;
        // we smooth the mouse movement
        smoothMousePos = Mathf.Lerp(smoothMousePos, xMousePos, 1f / smoothing);
    }
    
    void MovePlayer()
    {
        currentLookingPos = currentLookingPos + smoothMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
        
    }
}
