using UnityEngine;
using System.Collections;

public class SoundWave : MonoBehaviour {

    public Vector2 direction;
    private Vector2 waveDistance = new Vector2(10,10);
    private int lerpSpeed = 2;
    public float kBackDistance;
    private Vector3 rangePosition;

    
    // Use this for initialization
	void Start () 
    {
        rangePosition = gameObject.transform.position;

        if (direction.x > 0)
            waveDistance.x *= direction.x;
        else
            waveDistance.x *= -direction.x;
        if (direction.y > 0)
            waveDistance.y *= direction.y;
        else
            waveDistance.y *= -direction.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
        rangePosition.y = Mathf.Lerp(rangePosition.y, waveDistance.y, lerpSpeed * Time.deltaTime);
        rangePosition.x = Mathf.Lerp(rangePosition.x, waveDistance.x, lerpSpeed * Time.deltaTime);
        gameObject.transform.position = rangePosition;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        direction *= kBackDistance;
        if (other.tag == "Player")
            other.GetComponent<MoveSetManager>().KnockBack(direction);
    }
}
