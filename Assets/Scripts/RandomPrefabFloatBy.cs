using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabFloatBy : MonoBehaviour
{
    #region // ---------- ---------- ---------- ---------- ---------- Variables

    public List<GameObject> m_randomPrefabs = new List<GameObject>();
    public float m_spawnRate;

    [Space]

    public Transform m_target;
    public bool m_orientToTargetX, m_orientToTargetY, m_orientToTargetZ;

    [Space]

    // Fade only applicable where shaders have transparency
    public bool m_growIn;
    public bool m_fadeIn;
    public bool m_growOut;
    public bool m_fadeOut;

    [Space]

    [Range(0.01f, 1.00f)]
    public float m_speedModifier;
    public float m_maxSpeed;

    [Space]

    // If lifetime is 0, object will "die" when it is oppsite it's starting position
    public float m_lifeTime = 0f;


    private Vector3 m_directionToTarget
    {
        get { return (m_target.transform.position - transform.position).normalized; }
    }

    private float m_distanceToTarget
    {
        get { return Vector3.Distance(transform.position, m_target.position); }
    }

    #endregion



    // ---------- ---------- ---------- ---------- ---------- Start
    void Start ()
    {
        gameObject.SetActive(m_target != null);
	}


    // ---------- ---------- ---------- ---------- ---------- Update
    void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = Random.onUnitSphere;
            spawnPos.z = 0;
            spawnPos = spawnPos.normalized * 3f;
            spawnPos += transform.position;

            GameObject go = Instantiate(m_randomPrefabs[Random.Range(0, m_randomPrefabs.Count)], spawnPos, Quaternion.identity) as GameObject;
            StartCoroutine(DriftBy(go));
        }
	}

    public IEnumerator DriftBy(GameObject go)
    {
        float timer = 0;

        float speed = m_maxSpeed * m_speedModifier;

        float rightLeft = Random.Range(1f, 2f);
        rightLeft *= Time.frameCount % 2 == 0 ? 1f : -1f;

        bool drifting = true;

        while(drifting)
        {
            timer += Time.deltaTime;

            if(m_lifeTime > 0)
            {
                drifting = m_lifeTime > timer;
            }

            else
            {
                drifting = Vector3.Distance(go.transform.position, m_target.transform.position) < m_distanceToTarget * 2f;
            }

            // This is the end position of the random prefab, behind the target
            Vector3 velocity = (m_directionToTarget * speed * Time.deltaTime);

            go.transform.Translate(velocity);

            yield return null;
        }

        Destroy(go);
    }

    public Vector3 Vector3Maxamize(Vector3 vector)
    {
        Vector3 returnVector = vector;

        float max = 0;

        max = vector.x > max ? vector.x : max;
        max = vector.y > max ? vector.y : max;
        max = vector.z > max ? vector.z : max;

        returnVector /= max;

        return returnVector;
    }
}
