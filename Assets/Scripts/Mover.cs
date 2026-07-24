using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _start;
    [SerializeField] private Vector3 _end;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _delay = 1f;

    private Rigidbody _rb;

    private IEnumerator Start()
    {
        _rb = GetComponent<Rigidbody>();
        yield return new WaitForFixedUpdate(); 

        while (true)
        {
            yield return StartCoroutine(MoveBetween(_start, _end));
            yield return StartCoroutine(MoveBetween(_end, _start));
        }
    }

  private IEnumerator MoveBetween(Vector3 from, Vector3 to)
{
    float distance = Vector3.Distance(from, to);
    float duration = distance / _speed;
    float elapsed = 0f;

    while (elapsed < duration)
    {
        float t = elapsed / duration;
        Vector3 position = Vector3.Lerp(from, to, t);
        _rb.MovePosition(position);
        elapsed += Time.fixedDeltaTime;
        yield return new WaitForFixedUpdate();
    }

    _rb.MovePosition(to);
    yield return new WaitForSeconds(_delay);
}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying) return;
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(_start, 0.3f);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(_end, 0.3f);
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(_start, _end);
	}
}