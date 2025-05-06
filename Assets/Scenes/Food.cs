using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la serpiente colisiona con la manzana
       // if (other.CompareTag("Player"))
        //{
            RandomizePosition();
       // }
    }


    private void RandomizePosition()
    {
        // Obtener los límites del área de la cuadrícula
        Bounds bounds = this.gridArea.bounds;

        // Generar una posición aleatoria dentro de los límites
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        // Asignar la nueva posición a la manzana
        this.transform.position = new Vector3(x, y, 0.0f);
    }


}
