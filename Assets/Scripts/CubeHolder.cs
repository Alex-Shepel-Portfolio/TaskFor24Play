using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : Singleton<CubeHolder>
{ 
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject cubePref;
    [SerializeField] private GameObject playerBody;
    [SerializeField] private Animator camAnim;

    public List<Transform> circleHvost = new List<Transform>();

    private void Update()
    {

        if (circleHvost.Count > 0 )
        {
             playerBody.transform.localPosition = new Vector3(0, circleHvost[circleHvost.Count - 1].localPosition.y-0.2f, 0);
            for (int i = 0; i < circleHvost.Count; i++)
            {
              
                if (circleHvost[i].localPosition.z > 0 || circleHvost[i].localPosition.x != 0)
                {
                        circleHvost[i].localPosition = new Vector3(0, circleHvost[i].localPosition.y, 0);
                }
            }
        }
    }

    public void AddCube()
    {
        PlayerControler.Instance.Jump();
        GameObject scor = PoolManager.Instance.Spawn(score, circleHvost[circleHvost.Count - 1].position + new Vector3(-2, 5, 0), Quaternion.identity);
        GameObject par = PoolManager.Instance.Spawn(particle.gameObject, circleHvost[circleHvost.Count - 1].position + new Vector3(0,2,0), Quaternion.identity);
        
        StartCoroutine(Efect(scor));
        StartCoroutine(Efect(par));

        GameObject cub = Instantiate(cubePref, circleHvost[circleHvost.Count - 1].localPosition + new Vector3(0, 1, 0), Quaternion.identity, transform);
        circleHvost.Add(cub.transform);

    }


    public void DestroyCube(CubeObject cub)
    {
        circleHvost.RemoveAt(circleHvost.IndexOf(cub.transform));
        cub.transform.SetParent(null);
        camAnim.SetTrigger("Shake");

        if (circleHvost.Count == 0)
        {
            GameManager.Instance.EndGame();
        }
    }

   IEnumerator Efect(GameObject efect)
    {  
        yield return new WaitForSeconds(0.5f);
        PoolManager.Instance.Despawn(efect);
    }

}
