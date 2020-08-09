using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;

    [SerializeField] float rotateSpeed = 200f;
    [SerializeField] float mainSpeed = 0.5f;
    [SerializeField] AudioClip explosionAudio;
    [SerializeField] AudioClip finishAudio;
    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem engineParticles;
    [SerializeField] ParticleSystem sucessParticles;
    public enum States
    {
        Alive,
        Dying,
        Transcending
    }
    States state = States.Alive; 

    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(state == States.Alive)
        {
            RespondToThrust();
            RespondToRotate();
        }
        
    }
    private void RespondToThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyToThrust();
        }
        else
        {
            audioSource.Stop();
            engineParticles.Stop();
        }
    }

    private void ApplyToThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainSpeed);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        engineParticles.Play();
    }

    private void RespondToRotate()
    {
        rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * (Time.deltaTime * rotateSpeed));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * (Time.deltaTime * rotateSpeed));
        }
        rigidbody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != States.Alive) return;
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                SucessSequence();
                break;
            default:
                DeathSequence();
                break;
        }
    }

    private void DeathSequence()
    {
        explosionParticles.Play();
        state = States.Dying;
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(explosionAudio, Camera.main.transform.position);
        Invoke("LoadFirstLevel", 1f);
    }

    private void SucessSequence()
    {
        sucessParticles.Play();
        state = States.Transcending;
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(finishAudio, Camera.main.transform.position);
        Invoke("LoadNextLevel", 1f);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(GetSceneIndex());
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private int GetSceneIndex()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 3)
        {
            sceneIndex = 0;
        }
        else
        {
            sceneIndex++;
        }
        return sceneIndex;
    }
}
