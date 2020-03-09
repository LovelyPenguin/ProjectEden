using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Arrow : MonoBehaviour
{
    [SerializeField]
    private float Arrowrange = 15f;
    [SerializeField]
    private float Arrowtime = 2f;
    [SerializeField]
    private float Arrowspeed = 15f;
    [SerializeField]
    private float Cooldown = 2f;

    private GameObject player;
    private bool weaponReady = true;

    public GameObject bullet;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void WeaponFire()
    {
        GameObject setBulletDirection = Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Rigidbody2D bulletDirection = setBulletDirection.GetComponent<Rigidbody2D>();
        Vector2 dirVec = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        bulletDirection.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

        weaponReady = false;
        StartCoroutine(Reload());
    }

    void MoveToPlayer()
    {
        transform.position = new Vector2(
                    Mathf.Lerp(transform.position.x, player.transform.position.x, Arrowspeed * Time.deltaTime),
                    Mathf.Lerp(transform.position.y, player.transform.position.y, Arrowspeed * Time.deltaTime));
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(Cooldown);

        weaponReady = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, Arrowrange);

        Gizmos.color = new Color(255, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, Arrowrange);
    }

}
