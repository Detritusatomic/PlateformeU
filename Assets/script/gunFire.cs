using UnityEngine;
using System.Collections;

public class gunFire : MonoBehaviour {

    [SerializeField]public float firerate = 0;
    [SerializeField]public float damage = 10;
    [SerializeField]public LayerMask notToHit;

    [SerializeField]public Transform bulletPrefab;

    private float timeToFire = 0;
    Transform firePoint;

    // Use this for initialization
    void Start () {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null){
            Debug.LogError("Pas de FirePoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (firerate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire){
                timeToFire = Time.time + 1 / firerate;
                Shoot();
            }
        }
	}
    void Shoot()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(x, y, -Camera.main.transform.position.z)).x, Camera.main.ScreenToWorldPoint(new Vector3(x, y, -Camera.main.transform.position.z)).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition,10, notToHit);
        Effect();
        Debug.DrawLine(firePointPosition, mousePosition, Color.green);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }
    }

    void Effect()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
