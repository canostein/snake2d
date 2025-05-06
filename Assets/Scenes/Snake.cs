using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.HableCurve;

public class Snake : MonoBehaviour
{

    public Vector2 direction = Vector2.right;
    public List<Transform> segments; // Lista de segmentos 
    public Transform segmentPrefab;
    public int initialSize = 5;

    public int puntaje = 0;
    public Text puntacionText;


    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);

        resetearPuntaje();

        // Generar el tamaño inicial de la serpiente
        for (int i = 1; i < initialSize; i++)
        {
            Grow();
        }


    }

    private void Update()
    {
        var keyboard = Keyboard.current; // Accede al teclado con el nuevo sistema

        if (keyboard.upArrowKey.wasPressedThisFrame)
        {
            direction = Vector2.up;
        }
        else if (keyboard.downArrowKey.wasPressedThisFrame)
        {
            direction = Vector2.down;
        }
        else if (keyboard.leftArrowKey.wasPressedThisFrame)
        {
            direction = Vector2.left;
        }
        else if (keyboard.rightArrowKey.wasPressedThisFrame)
        {
            direction = Vector2.right;
        }


    }

    private void FixedUpdate()
    {

            // Mover los segmentos del cuerpo
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }

            // Mover la cabeza de la serpiente
            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x + direction.x),
                Mathf.Round(this.transform.position.y + direction.y),
                0.0f
            );


    }

    public void Grow()
    {
        // Añadir un nuevo segmento al final de la serpiente
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);

        puntaje+=1;
        puntacionText.text = puntaje.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si come la manza va generar la cola
        if (other.CompareTag("Food"))
        {
            Grow();
        }

        else if (other.CompareTag("Obstacle"))
        {
            ResetState();
        }
    }

    private void ResetState()

    {
        resetearPuntaje();
        // Reiniciar el estado de la serpiente
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        transform.position = Vector3.zero;
        direction = Vector2.right;

        // Regenerar el tamaño inicial
        for (int i = 1; i < initialSize; i++)
        {
            Grow();
        }
    }

    public void resetearPuntaje()
    {
        puntaje = 0;
        puntacionText.text = puntaje.ToString();

    }










}
