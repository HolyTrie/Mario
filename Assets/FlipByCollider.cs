using UnityEngine;

public class FlipByCollider : MonoBehaviour
{
    MovingPlatform _mp;
    
    void Start()
    {
        _mp = GameObject.Find("PigEnemy").GetComponent<MovingPlatform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Start")
            _mp.setDirection(true);
        
        if (other.tag == "End")
            _mp.setDirection(false);
    }
}