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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(m_randomPrefabs[Random.Range(0, m_randomPrefabs.Count)], transform.position + (Vector3.one * Random.Range(-1f, 1f)), Quaternion.identity) as GameObject;
            StartCoroutine(DriftBy(go));
        }
	}

    public IEnumerator DriftBy(GameObject go)
    {
        float timer = 0;
        float speed = m_maxSpeed * m_speedModifier;
        float rightLeft = Random.Range(-1f, 1f);
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

                print(Vector3.Distance(go.transform.position, m_target.transform.position));
                print(m_distanceToTarget * 2f);
            }

            // This is the end position of the random prefab, behind the target
            Vector3 newPos = m_target.position + (m_directionToTarget * m_distanceToTarget * 1.1f);
            newPos = Vector3.Lerp(transform.position, newPos, timer * speed);
            newPos += ((rightLeft * m_target.transform.right) * (1f / Vector3.Distance(newPos, m_target.transform.position)));

            go.transform.position = newPos;

            print(drifting);
            yield return null;
        }

        Destroy(go);
    }
}
