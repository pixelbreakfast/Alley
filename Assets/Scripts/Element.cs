using UnityEngine;
using System.Collections;

public class Element {

	public string ElementTexturePath {get; private set;}
	public int x;
	public int y;
	public int z;
	public int moveSpeed = 10;
	public bool isControllable = false;
	float moveCounter = 0;

	protected Vector3 destination;

	public Element(string ElementTexturePath, int x, int y, int z) {
		this.ElementTexturePath = ElementTexturePath;
		this.x = x;
		this.y = y;
		this.z = z;
		SetDestination(new Vector3(x, y, z));
		
		//Add this to the map registry
		Map.Instance.AddElement(this);
	
		Messenger.AddListener("step", Step);
	}

	public void Step() {
		moveCounter++;
		if(moveCounter >= moveSpeed) {

			moveCounter = 0;

			Move ();
			 
		}

	}
	
	public void Move() {
		if(x == destination.x && y == destination.y) return;

		if(x != destination.x) {
			int direction = (int) Mathf.Sign((float)destination.x - (float)x);
			if(Map.Instance.CanWalk(x + (int) direction,y,z)) {

				Map.Instance.MoveElement(this, x + (int) direction, y ,z);

			}
			return;
		}

		if(y != destination.y) {
			int direction = (int) Mathf.Sign((float)destination.y - (float)y);

			if(Map.Instance.GetTileAt(x,y + direction,z).walkable = true) {
				
				Map.Instance.MoveElement(this, x, y + direction, z);
				
			}

			return;
		}

	}


	public void SetDestination(Vector3 destination) {

		this.destination = destination;
	}
}
