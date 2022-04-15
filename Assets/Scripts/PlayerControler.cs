using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler Instance;

    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem warpEffect;
    [SerializeField] private GameObject player;

    private float speed = 0;
    public void SetSpeed(float speed) {
        if (speed >= 0)
        {
            this.speed = speed;
        }
            
    }

    private Vector2 startPos;
    private float targetPos;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(speed == 0) { warpEffect.gameObject.SetActive(false); return; }
        if(speed > 5)
        {
            warpEffect.gameObject.SetActive(true);
        }
        else
        {
            warpEffect.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0)) startPos = Input.mousePosition;
        else if (Input.GetMouseButton(0))
        {
            float pos = (Input.mousePosition.x - startPos.x) / 1000f;

            targetPos = Mathf.Clamp(transform.position.x + pos, -2f, 2f);

        }

        float move = transform.position.z + speed * Time.deltaTime;
        transform.position = new Vector3(targetPos, transform.position.y, move);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CubeWall")
        {
            GameManager.Instance.EndGame();
        }
    }
    
    public void End()
    {
       // speed = 0;
        player.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

}
