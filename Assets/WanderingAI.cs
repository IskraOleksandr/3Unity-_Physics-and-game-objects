
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 16.0F;
    [SerializeField]
    private float obstacleRange = 5.0F;

    public bool Alive { get; private set; } = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75F, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    Debug.Log(System.String.Format("Distance to player {0}", hit.distance));
                }
                else if (hit.distance < obstacleRange)
                {
                    transform.Rotate(0, Random.Range(-110, 110), 0);
                }
            }
        }
    }

    void Kill()
    {
        Alive = false;
    }
}
