using UnityEngine;

public class bl_ControllerExample : MonoBehaviour
{
    /// <summary>
    /// Step #1
    /// We need a simple reference of joystick in the script
    /// that we need add it.
    /// </summary>
    private bl_Joystick Joystick; //Joystick reference for assign in inspector

    [SerializeField] private float Speed = 0.25f;
    [SerializeField] private float rotationPower = 1f;
    Rigidbody2D rb;
    private Vector3 m_EulerAngleVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
        Joystick = FindObjectOfType<bl_Joystick>();
    }

    void Update()
    {
        //Step #2
        //Change Input.GetAxis (or the input that you using) to Joystick.Vertical or Joystick.Horizontal
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal; //get the horizontal value of joystick

        //in case you using keys instead of axis (due keys are bool and not float) you can do this:
        //bool isKeyPressed = (Joystick.Horizontal > 0) ? true : false;

        //ready!, you not need more.
        //Vector2 translate = (new Vector2(0, v) * Time.deltaTime) * Speed;
        if (play.playing)
        {
            this.rb.AddForce(transform.up * v * Speed * Time.deltaTime);
            transform.Rotate(0, 0, -h * Time.deltaTime * rotationPower);
        }
        //transform.Translate(translate);
    }
}