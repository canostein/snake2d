using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.Rendering.HableCurve;

public class Snake : MonoBehaviour
{

    public Vector2 direction = Vector2.right;
    public Vector2 lastDirection = Vector2.right;
    public List<Transform> segments; // Lista de segmentos 
    public Transform segmentPrefab;
    public int initialSize = 6;

    public int puntaje = 0;
    public Text puntacionText;

    private bool juegoPausado = false;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);

        // Generar el tamaño inicial de la serpiente
        for (int i = 1; i < initialSize; i++)
        {
            Grow();
        }

      


    }

    private void Update()
    {
        var keyboard = Keyboard.current; // Accede al teclado con el nuevo sistema

        if (keyboard.upArrowKey.wasPressedThisFrame && lastDirection != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if (keyboard.downArrowKey.wasPressedThisFrame && lastDirection != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if (keyboard.leftArrowKey.wasPressedThisFrame && lastDirection != Vector2.right)
        {
            direction = Vector2.left;
        }
        else if (keyboard.rightArrowKey.wasPressedThisFrame && lastDirection != Vector2.left)
        {
            direction = Vector2.right;
        }else if (keyboard.escapeKey.wasPressedThisFrame)
        {
            if (juegoPausado)
            {
                Time.timeScale = 1;
                juegoPausado = false;
            }
            else
            {
                Time.timeScale = 0;
                juegoPausado = true;
            }
        }


    }

    private void FixedUpdate()
    {

        lastDirection = direction;
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

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si come la manza va generar la cola
        if (other.CompareTag("Food"))
        {
            Grow();
            puntaje += 1;
            puntacionText.text = "Score:"+ puntaje.ToString();
        }

        else if (other.CompareTag("Obstacle"))
        {
           
            ResetState();
        }
    }

    private void ResetState()

    {
        ResetearPuntaje();
        // Reiniciar el estado de la serpiente
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        transform.position = Vector3.zero;
        direction = Vector2.right;
        lastDirection = Vector2.right;

        // Regenerar el tamaño inicial
        for (int i = 1; i < initialSize; i++)
        {
            Grow();
        }
    }

    public void ResetearPuntaje()
    {
        this.puntaje = 0;
        this.puntacionText.text = puntaje.ToString();

    }










}
