using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
   public GameObject dieEffect;
    [SerializeField] private AudioClip dieSound;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
   {
      Instantiate(dieEffect, transform.position, Quaternion.identity);
      health -= damage;
      audioSource.PlayOneShot(dieSound);
      if (health <= 0)
      { 
          Destroy(gameObject, dieSound != null ? dieSound.length : 0f);
      }
   }
}
