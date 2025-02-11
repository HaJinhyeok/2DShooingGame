using UnityEngine;

public class Monster : MonoBehaviour
{
    float _speed = 3f;
    int _hp = 5;

    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shot"))
        {
            _hp--;
            Destroy(collision.gameObject);
            if (_hp <= 0)
            {
                GameManager.Scoring();
                Destroy(gameObject);
            }
        }
    }
}
