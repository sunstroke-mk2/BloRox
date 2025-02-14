using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public Vector3 InputData;


    void Update()
    {
        InputData = new Vector3();
        InputData.x= Input.GetAxis("Horizontal");
        InputData.z= Input.GetAxis("Vertical");
        if (Input.GetKeyUp(KeyCode.Space))
            InputData.y = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            InputData.y = 1;

    }
}
