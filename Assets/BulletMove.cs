using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
    public Vector3 direction;
    public float power;
    public Rigidbody rb;
    public bool impacted;
    public Vector3 forceVec;
    public float impactThreshold;
    public bool firstImpact;


	void FixedUpdate () {
        //git Test 무시하셈
        int a = 0;

        if (!impacted)
        {
            rb.velocity = forceVec;

            forceVec += Physics.gravity * Time.deltaTime;
        }
        /*else {
            forceVec = Vector3.zero;
            rb.velocity = Vector3.zero;
            return;
        }*/
    }

	public void Shoot(Vector3 direction_, float power_){
		direction = direction_;
		power = power_;
		rb = gameObject.GetComponent<Rigidbody>();
		forceVec = 100 * power * direction;
		impacted = false;
		firstImpact = false;
	}

    private float getEudDist(Vector3 v)
    {
        return Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
    }
    void OnCollisionEnter(Collision col)
    {
		Debug.Log (col.gameObject);
        if (col.relativeVelocity != Vector3.zero)
        {
            Vector3 v = col.relativeVelocity;
            float damage = getEudDist(v);
            if (damage > impactThreshold)
            {
                impacted = true;
				Instantiate (Resources.Load ("Detonator", typeof(GameObject)), transform.position, Quaternion.identity);
                //detonator.Explode();

                Destroy(this.gameObject);
                
            }
        }
    }
}
