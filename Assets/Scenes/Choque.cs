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
        Debug.Log("Colisi�n con el obst�culo derecho");

        audioSource.Play();

        
    }

}
