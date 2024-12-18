using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;
    public Timer timer;

    // if player enters the trigger, respawn the player and take damage
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {  
            RespawnPlayer();
            TakeDamage();
        }
    }


    // respawn the player
    private void RespawnPlayer()
    {
        
        player.transform.position = respawnPoint.position;
    }

    // take damage
    private void TakeDamage()
    {
        timer.RemoveTime(30);
    }
}