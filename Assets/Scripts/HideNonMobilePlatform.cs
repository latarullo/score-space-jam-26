using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNonMobilePlatform : MonoBehaviour {
    void Start() {
        if (Application.isMobilePlatform) {
            this.gameObject.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
        }
    }
}
