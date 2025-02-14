using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;
    public Vector3 InputData;
    public bool    Jump=false;

    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        InputData = new Vector3();
        InputData.x= Input.GetAxis("Horizontal");
        InputData.z= Input.GetAxis("Vertical");
        Jump = Input.GetKey(KeyCode.Space);

    }
}
