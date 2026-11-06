using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class emenyShootin : MonoBehaviour
{
   public GameObject junk;
   public Transform junkPos;
    public GameObject trash;
   public Transform trashPos;
   
   private float timer;
   private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerScript.Player.transform.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);   
       Debug.Log(distance);//check range & fire
       
        if(distance > 7)// > far away from boss < Close to boss
        {
            if(timer > 2)
        {
            timer = 0;
            shoot();
        }

        }

        
    }
    void shoot()
    {
        Instantiate(junk,junkPos.position, Quaternion.identity);
         Instantiate(trash,trashPos.position, Quaternion.identity);
    }
    
}
