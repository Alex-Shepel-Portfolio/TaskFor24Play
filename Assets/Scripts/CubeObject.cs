using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    bool isDestroy;

    private void Update()
    {
        if(gameObject.transform.position.z < -5 || gameObject.transform.position.y < -3)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isDestroy)
        {
            if (other.gameObject.tag == "CubeWall")
            {
                CubeHolder.Instance.DestroyCube(this);
                isDestroy = true;
            }
            if(other.gameObject.tag == "PicUpCube")
            {
                other.transform.parent.gameObject.SetActive(false);
                CubeHolder.Instance.AddCube();

            }
        }
    }

}
