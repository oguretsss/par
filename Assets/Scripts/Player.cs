using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//roleplaying system variables
	int discoverRadius = 1; //value can be increased via perk "Explorer"

	public float moveTime = 0.1f;
	float inverseMoveTime;
	public Vector2 coordinates;
	bool isMoving = false;
	
	public delegate void InvestigateHandler(Vector2 coords, int radius);
	public event InvestigateHandler Investigate;
	// Use this for initialization
	void Start () {
		inverseMoveTime = 1f / moveTime; // We will use inverse time it requires less CPU
		coordinates = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		int xDir = 0;
		int yDir = 0;
		if (Input.GetMouseButtonDown(0)) {
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float deltaX = target.x - transform.position.x;
			float deltaY = target.y - transform.position.y;
			if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY)) 
				xDir = deltaX > 0 ? 1 : -1;
			else
				yDir = deltaY > 0 ? 1 : -1;
			Move(xDir, yDir);
			xDir = 0;
			yDir = 0;
		}
	
	}

	void Move(int xDir, int yDir) {
		if (isMoving) {
			Vector2 start = transform.position;
			Vector2 end = start + new Vector2(xDir, yDir);
			if (end.x < 0 || end.y < 0 || end.x > GameManager.instance.worldMapScript.columns - 1 || end.y > GameManager.instance.worldMapScript.rows - 1)
				return;
			coordinates = end;
			StartCoroutine(SmoothMovement(end));
			Investigate(coordinates, discoverRadius);
			Debug.Log("Coordinates: " + coordinates);
		}
	}

	protected IEnumerator SmoothMovement(Vector3 end)
	{
		//Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
		//Square magnitude is used instead of magnitude because it's computationally cheaper.
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		
		//While that distance is greater than a very small amount (Epsilon, almost zero):
		while(sqrRemainingDistance > float.Epsilon)
		{
			//Find a new position proportionally closer to the end, based on the moveTime
			transform.position = Vector3.MoveTowards(transform.position, end, inverseMoveTime * Time.deltaTime);
			
			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.

			
			//Recalculate the remaining distance after moving.
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			
			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
			yield return null;
		}
	}

	public void StopMoving() {
		isMoving = false;
	}

	public void ContinueMoving() {
		isMoving = true;
	}
}
