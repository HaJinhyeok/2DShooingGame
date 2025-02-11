using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Shot;
    float _speed = 10f;
    
    void Update()
    {
        Move();
        Shoot();
    }

    // Need Normalization
    void Move()
    {
        Vector3 movement = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }
        transform.Translate(movement.normalized * _speed * Time.deltaTime);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Shot, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }
}
