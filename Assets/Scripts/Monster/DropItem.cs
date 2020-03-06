using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField]
    private GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemSpawn()
    {
        GameObject item = Instantiate(this.item, transform.position, Quaternion.identity);
        Rigidbody2D itemRig = item.GetComponent<Rigidbody2D>();
        itemRig.AddForce(new Vector2(0, 1000), ForceMode2D.Impulse);

        Destroy(gameObject);
    }
}
