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
        // Obtener los l�mites del �rea de la cuadr�cula
        Bounds bounds = this.gridArea.bounds;

        // Generar una posici�n aleatoria dentro de los l�mites
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        // Asignar la nueva posici�n a la manzana
        this.transform.position = new Vector3(x, y, 0.0f);
    }


}
