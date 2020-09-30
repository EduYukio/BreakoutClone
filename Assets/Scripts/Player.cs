using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    void Start() {
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");

        int speedFactor = 25;
        transform.Translate(x / speedFactor, 0, 0);
    }
}
