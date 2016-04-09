using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public ItemManager.Effect itemEffect = ItemManager.Effect.NONE;
    /// <summary>
    /// Right now the amout is doing different things depending on effectType:
    /// HEALTH: Amount of health restored
    /// SPEED: Duration of +3 speed
    /// REDUCEBLEED: ???
    /// </summary>
    public float amount = 0;

    public void OnEnable()
    {
        ItemManager.GetInstance().AddItem(this);
    }

    public void OnDissable()
    {
        ItemManager.GetInstance().RemoveItem(this);
    }

   /* void OnTriggerEnter(Collider other)
    {
        if (other.transform.IsChildOf(ItemManager.GetInstance().gameObject.transform))
        {
            ItemManager.GetInstance().ApplyEffect(this);
        }
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.transform == ItemManager.GetInstance().player.transform)
        {
            ItemManager.GetInstance().ApplyEffect(this);
        }
        
    }

}
