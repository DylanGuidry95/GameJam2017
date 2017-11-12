using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityMovement))]
public class EntityBehaviour : MonoBehaviour
{
    public int mHealth;
    public string mName;
    public int mDamage;

    protected void Start()
    {
        if (mName == "")
            mName = this.GetType().ToString();
        gameObject.name = mName;
        if (mHealth == 0)
            mHealth = 1;
        if (mDamage == 0)
            mDamage = 1;
    }

    protected void Update()
    {
        if (mHealth <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        mHealth -= amount;
    }
}
