using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour {
    private float timerMax = 5f;
    private float timer;

    [SerializeField] private Transform ball;

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = Random.Range(0f, timerMax);
            Vector3 randomPosition = new Vector3(transform.position.x + Random.Range(-3f, 3f), transform.position.y + Random.Range(0f, 5f), transform.position.z);
            Transform ball = Instantiate(this.ball, randomPosition, Quaternion.identity);
            float ballSize = Random.Range(1f, 3f);
            ball.transform.localScale = new Vector3(ballSize, ballSize, ballSize);
        }
    }
}
