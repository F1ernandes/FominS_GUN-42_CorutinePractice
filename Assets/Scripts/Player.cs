using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _shootForce = 10f;
    [SerializeField] private float _ballLifetime = 5f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _ballPrefab != null)
        {
            Vector3 spawnPos = transform.position + transform.forward * 1.5f + Vector3.up * 0.5f;
            GameObject ball = Instantiate(_ballPrefab, spawnPos, Quaternion.identity);
            Camera.main.GetComponent<CameraRotator>().Target = ball.transform;
            Destroy(ball, _ballLifetime);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddForce(transform.forward * _shootForce, ForceMode.Impulse);
        }
    }
}