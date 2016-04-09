using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {
    public enum Effect
    {
        NONE,
        HEAL,
        SPEED,
        REDUCEBLEED
    }

    static ItemManager ourInstance;

    public GameObject player;
    public Bunny bunny;

    static public ItemManager GetInstance()
    {
        return ourInstance;
    }

    public List<Item> items = new List<Item>();

    // Use this for initialization
    void Awake()
    {
        if (ourInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            ourInstance = this;
        player = GameObject.Find("Bunny");
    }

    public void AddItem(Item item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void ApplyEffect(Item item)
    {
        if(item.itemEffect == Effect.HEAL)
        {
            bunny.increaseHealth(item.amount);
        }
        if(item.itemEffect == Effect.SPEED)
        {
            StartCoroutine(SpeedPickup(item.amount));
        }
        if(item.itemEffect == Effect.REDUCEBLEED)
        {
            // TODO: reducebleed in the gamemmanager for a certain amount of time?
        }
        Debug.Log("Health: " + bunny.getHealth() + ", Speed: " + bunny.speed);
        item.gameObject.SetActive(false);
    }

    private IEnumerator SpeedPickup(float time)
    {
        float origSpeed = bunny.speed;
        bunny.setSpeed(bunny.speed + 3);
        yield return new WaitForSeconds(time);
        bunny.setSpeed(origSpeed);
        yield return null;
    }

}
