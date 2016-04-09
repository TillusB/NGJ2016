using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public ItemManager.Effect itemEffect = ItemManager.Effect.NONE;
    public float amount = 0;

    public void OnEnable()
    {
        ItemManager.GetInstance().AddItem(this);
    }

    public void OnDissable()
    {
        ItemManager.GetInstance().RemoveItem(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.IsChildOf(KillerAreaManager.GetInstance().gameObject.transform))
        {
            ItemManager.GetInstance().ApplyEffect(this);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.IsChildOf(KillerAreaManager.GetInstance().gameObject.transform))
        {
            ItemManager.GetInstance().ApplyEffect(this);
        }
        
    }

}
