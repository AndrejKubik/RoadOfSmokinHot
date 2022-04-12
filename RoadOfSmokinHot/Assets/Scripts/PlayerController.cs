using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform pickupParent;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float joystickAngle;
    public float rotateSpeed = 200f;
    
    void Update()
    {
        joystickAngle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg; //calculate the angle of joystick handle position
        pickupParent.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, joystickAngle + 45f), rotateSpeed * Time.deltaTime); //change the ships rotation according to joystick position over chosen speed
    }
}
