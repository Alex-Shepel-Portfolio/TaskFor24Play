using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float movingSpeed;
    private Quaternion camRotation = Quaternion.Euler(20f, -15f, 0f);

    private void Start()
    {
        transform.rotation = camRotation;
    }


    private void Update()
    {
        Vector3 target;

        target = new Vector3()
        {
            x = 4,
            y = this.player.position.y + 10,
            z = this.player.position.z - 10,
        };

        Vector3 pos = Vector3.Lerp(a: this.transform.position, b: target, t: this.movingSpeed * Time.deltaTime);

        this.transform.position = pos;

    }
}
