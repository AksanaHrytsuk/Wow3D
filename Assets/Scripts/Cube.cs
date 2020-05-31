using UnityEngine;

public class Cube : MonoBehaviour
{
    MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // если коллизия произошла с игроком
        if (collision.gameObject.CompareTag("Player"))
        {
            // у обЪекта , с которым произошла коллизия берём компонент MeshRenderer
            MeshRenderer ballRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            // получаем материал плеера ballMaterial
            Material ballMaterial = ballRenderer.material;
            // меняем цвет материала у куба на цвет материала плеера(но можно менять сам материал без color)
            rend.material.color = ballMaterial.color;

            BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rend.material.color = Color.blue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rend.material.color = Color.black;
        }
    }
}
