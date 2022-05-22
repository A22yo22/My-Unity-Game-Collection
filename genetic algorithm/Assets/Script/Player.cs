using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _rotationSpeed = 70f;
    public float _movementSpeed = 10f;
    private Vector3 _horizontzalMovment;
    public bool _hit = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (_hit == true)
        {
            transform.position += -transform.up * Time.deltaTime * _movementSpeed;
        }

        _horizontzalMovment = new Vector3(0f, 0f, -Input.GetAxis("Horizontal"));
        transform.Rotate(_horizontzalMovment * _rotationSpeed * Time.deltaTime);

        //RayCast
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10f, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5f);

            if (hit)
            {
                _hit = false;
            }
        }
    }
}
