using UnityEngine;
using System.Collections;

public class ennemieController : MonoBehaviour
{

    public float velocity;
    public Transform target;
    public LayerMask mask;
    public int distanceAgro;
    public Transform bullet;
    public float firerate = 0;
    public int rotationOffset = 90;

    private float timeToFire = 0;
    private Vector3 dir;

    void Start()
    {
        
    }

    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, this.GetComponent<Rigidbody2D>().velocity.y);
        Transform feu = this.transform.FindChild("firePoint");
        
        dir = target.position - feu.position;

        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        feu.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        RaycastHit2D hit = Physics2D.Raycast(feu.position, dir.normalized, distanceAgro,mask);
        if (hit.collider != null && hit.collider.gameObject.tag=="Player")
        {
            
            Debug.DrawLine(feu.position, hit.point, Color.green, 2);
            if (Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / firerate;
                Instantiate(bullet, feu.position, feu.rotation);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        flip();
        
    }

    void flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        velocity *= -1;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, this.GetComponent<Rigidbody2D>().velocity.y);
    }


}
