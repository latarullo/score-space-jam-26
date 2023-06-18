using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateDisc : MonoBehaviour {

    [SerializeField] private float rotateSpeed = 10;

    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;

    void Start() {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

        //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    void FixedUpdate() {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * rotateSpeed);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }

    //void Update() {
    //    this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.y+15 * rotateSpeed * Time.deltaTime, 0);
    //}
}
