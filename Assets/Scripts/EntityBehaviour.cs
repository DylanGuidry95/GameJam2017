using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityMovement))]
public class EntityBehaviour : MonoBehaviour
{
    public int mHealth;
    public string mName;
    public int mDamage;
    public bool mIsImmune;
    public float mDamageDelay;

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

    private float mImuneTimer = 0;

    protected void Update()
    {
        if (mIsImmune)
            mImuneTimer += Time.deltaTime;
        if(mImuneTimer >= mDamageDelay)
        {
            mImuneTimer = 0;
            mIsImmune = false;
        }
        if (mHealth <= 0)
            StartCoroutine(DeathAnimation());
    }

    public void TakeDamage(int amount)
    {
        if (mIsImmune)
            return;
        mIsImmune = true;
        if (amount < mHealth)
        {
            StartCoroutine(DamageAnimation());
        }
        mHealth -= amount;
    }

    [ContextMenu("test")]
    public void test()
    {
        StartCoroutine(DamageAnimation());
    }

    IEnumerator DamageAnimation()
    {
        int counter = 0;
        while(true)
        {
            GetComponent<Renderer>().material.color = Color.Lerp(
                GetComponent<Renderer>().material.color, Color.yellow, .5f);
            counter++;
            yield return new WaitForSeconds(0.1f);
            if (counter == 5)
            {
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            }
        }
        yield return null;
    }

    IEnumerator DeathAnimation()
    {
        GetComponent<BoxCollider>().enabled = false;
        int counter = 0;
        while(true)
        {
            transform.Rotate(new Vector3(0,0,Mathf.Cos(Time.deltaTime)));
            transform.position += new Vector3(0, -Time.deltaTime, 0);
            yield return new WaitForSeconds(Time.deltaTime);
            counter++;
            if (counter == 120)
                break;
        }
        Destroy(gameObject);
    }
}
