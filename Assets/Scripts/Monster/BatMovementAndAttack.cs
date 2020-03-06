using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatMovementAndAttack : MonoBehaviour
{
    [SerializeField]
    private float shootDistance = 15f;
    [SerializeField]
    private float seekDistance = 30f;
    [SerializeField]
    private float seekSpeed = 15f;
    [SerializeField]
    private float shootDelay = 2f;

    private GameObject player;
    private bool weaponReady = true;

    public GameObject bullet;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float currentDistance = Vector2.Distance(transform.position, player.transform.position);

            if (currentDistance <= seekDistance)
            {
                MoveToPlayer();
                anim.SetBool("ReadyToFire", false);
                if (currentDistance <= shootDistance && weaponReady == true)
                {
                    anim.SetBool("ReadyToFire", true);
                }
            }
        }
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
                    Mathf.Lerp(transform.position.x, player.transform.position.x, seekSpeed * Time.deltaTime),
                    Mathf.Lerp(transform.position.y, player.transform.position.y, seekSpeed * Time.deltaTime));
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(shootDelay);

        weaponReady = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 255, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, seekDistance);

        Gizmos.color = new Color(255, 0, 0, 0.2f);
        Gizmos.DrawSphere(transform.position, shootDistance);
    }
}
