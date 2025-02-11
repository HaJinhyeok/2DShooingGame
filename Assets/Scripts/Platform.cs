using UnityEngine;

public class Platform : MonoBehaviour
{
    float _speed = 3f;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
}
