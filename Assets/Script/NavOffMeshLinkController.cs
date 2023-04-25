using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavOffMeshLinkController : MonoBehaviour
{
    [SerializeField]
    GameObject targetObject;

    private NavMeshAgent navAgent;
    private OffMeshLink offmeshLink;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        offmeshLink = this.GetComponent<OffMeshLink>();
        navAgent.destination = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (navAgent.isOnOffMeshLink) StartCoroutine(StartOffMeshLink());
    }

    IEnumerator StartOffMeshLink()
    {
        OffMeshLinkData _data = navAgent.currentOffMeshLinkData;
        Vector3 _startPos = navAgent.transform.position;
        Vector3 _endPos = _data.endPos + (Vector3.up * navAgent.baseOffset);
        float _duration = (_endPos - _startPos).magnitude / 5.0f;

        float _time = 0.0f;
        while (_time < _duration)
        {
            _time += Time.deltaTime;
            float tFactor = _time / _duration;
            navAgent.transform.position = Vector3.Lerp(_startPos, _endPos, tFactor);
            yield return null;
        }

        navAgent.CompleteOffMeshLink();
    }
}
