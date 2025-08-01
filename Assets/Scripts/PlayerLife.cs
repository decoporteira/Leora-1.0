using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
           
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //change color to red
            Debug.Log("Matou player");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("DestroyObj", 1.0f);

        }
        
    }
   
    private void DestroyObj()
    {
        Destroy(gameObject);
        //restart level
        SceneManager.LoadScene(0);
        
    }

}

