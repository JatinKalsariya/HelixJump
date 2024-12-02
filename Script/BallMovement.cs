using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float abc;
    [SerializeField] GameObject splash;
    ScriptableObject sc;
    public GameObject tryAgain;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 2f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerPrefs.GetInt("Score") >= 3) {
            PlayerPrefs.SetInt("Score", 0);
            var mainObject = collision.transform.parent.parent.gameObject;
            collision.transform.parent.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
            Collider[] colliders = Physics.OverlapSphere(mainObject.transform.position, 2f);

            foreach (var item in colliders)
            {
                //print(item);
                var rb = item.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddExplosionForce(150, item.transform.position, 250);
                item.gameObject.tag = "Untagged";
            }
            collision.gameObject.GetComponentInParent<PillarGenerate>().InfiniteGenerator();
            StartCoroutine(destroyObject(mainObject, mainObject.transform.GetChild(0).gameObject));
        }
        else if (collision.gameObject.tag == "Loose")
        {
            tryAgain.SetActive(true);
        }
        if (tryAgain.active == false)
        {
            if (collision.gameObject.tag == "touch" || collision.gameObject.tag == "Loose")
            {
                
                PlayerPrefs.SetInt("Score", 0);

                rb.velocity = (new Vector3(0, 7.5f, 0));
                Vector3 imgPos = transform.position;
                GameObject splashSS = Instantiate(splash, imgPos, Quaternion.Euler(new Vector3(90, 0, 0)));
                Destroy(splashSS, 1f);
            }

        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            var mainObject = other.gameObject;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Collider[] colliders = Physics.OverlapSphere(mainObject.transform.position, 2f);

            foreach (var item in colliders)
            {
                //print(item);
                var rb = item.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.AddExplosionForce(150, item.transform.position, 250);
                item.gameObject.tag = "Untagged";
            }
            other.gameObject.GetComponentInParent<PillarGenerate>().InfiniteGenerator();
            StartCoroutine(destroyObject(mainObject, mainObject.transform.GetChild(0).gameObject));
        }

    }

    void Update()
    {

    }
    IEnumerator destroyObject(GameObject o, GameObject k)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        yield return new WaitForSeconds(2);
        Destroy(k);
        yield return new WaitForSeconds(2);
        Destroy(o);

    }
   /* IEnumerator destroyObject(GameObject o)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        yield return new WaitForSeconds(2);
        Destroy(o);

    }*/
    public void onClickTryAgain()
    {
        SceneManager.LoadScene("Playing");
    }


}
