using UnityEngine;

public class Choque : MonoBehaviour
{

    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión con el obstáculo derecho");

        audioSource.Play();

        
    }

}
