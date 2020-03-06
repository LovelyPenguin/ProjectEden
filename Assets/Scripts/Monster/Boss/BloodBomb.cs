using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBomb : MonoBehaviour
{
    public float bloodTimer;
    public float bloodPoolTimer;
    [SerializeField]
    private GameObject blood;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplodeSequance()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(bloodTimer);
        Instantiate(blood, transform.position, Quaternion.identity);
        blood.GetComponent<DestroyObject>().timer = bloodPoolTimer;
        Destroy(gameObject);
    }

    public float GetBloodBombTimer()
    {
        return bloodTimer + bloodPoolTimer;
    }
}
