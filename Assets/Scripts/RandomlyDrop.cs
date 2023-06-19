using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class RandomlyDrop : MonoBehaviour {
    private float timeToDrop;
    private float timeToDisapear;

    void Start() {
        timeToDisapear = 10;
        this.GetComponent<Rigidbody>().useGravity = true; //timeToDrop = Random.Range(1, 3);
    }

    void Update() {
        //timeToDrop -= Time.deltaTime;

        //if (timeToDrop < 0) {
        //    this.GetComponent<Rigidbody>().useGravity = true;
        //    Destroy(this);
        //}

        timeToDisapear -= Time.deltaTime;
        if (timeToDisapear < 0) {
            Destroy(this.gameObject);
        }
    }
}
