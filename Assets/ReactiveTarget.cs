using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public int hitCounter;

    // Start is called before the first frame update
    void Start()
    {
        hitCounter = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reactToHit()
    {

        if (--hitCounter < 0)
        {

            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {

        this.transform.Rotate(0, 0, -90);
        this.transform.Translate(0, -15, 0);
        yield return new WaitForSeconds(1.5F);
        Respawn();//
        Destroy(this.gameObject);


    }

    private void Respawn()
    {
        Instantiate(this.gameObject, new Vector3(-21.34F, 1.39F, -2.62F), Quaternion.Euler(new Vector3(-0.43F, 45F, 1.019F)));
    }

}
