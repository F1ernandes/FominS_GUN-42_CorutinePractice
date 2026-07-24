using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private AudioClip _scoreSound;
    private AudioSource _audioSource;
    private int _score = 0;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            _score++;
            Debug.Log($"Счет: {_score}");
            
            if (_scoreSound != null)
                _audioSource.PlayOneShot(_scoreSound);
            
            Destroy(other.gameObject);
        }
    }
}