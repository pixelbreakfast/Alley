using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	public static Map Instance {get; private set;}

	public string fileName;
	public int height = 100;
	public int width = 100;
	public int maxDepth = 50;
	Tile[,,] tiles;
	Element[,,] elements;

	float minStepTime = 2f;
	float timeAtLastFrame = 0;

	void Awake() {
		if(Map.Instance != null && Map.Instance != this) {
			Destroy(this);
		}

		Map.Instance = this;

		if (tiles == null) tiles = new Tile[width, height, maxDepth];
		if (elements == null) elements = new Element[width, height, maxDepth];

	}


	// Use this for initialization
	void Start () {
	

		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				string name = Tile.GetRandomTileName();
				Tile tile = new Tile(name, x, y, 0);
				if(name == "Wall") tile.walkable = false;
			}

		}

		Element element = new Actor("Actors/sample", 3, 3, 0);
		element.isControllable = true;

	}

	void FixedUpdate() {
		GameTime.Step();
	}

	public void MoveElement(Element element, int newX, int newY, int newZ) {
		elements[element.x, element.y, element.z] = null;
		element.x = newX;
		element.y = newY;
		element.z = newZ;
		elements[newX, newY, newZ] = element;

	}

	public void AddElement(Element element) {
	
		elements[element.x,element.y,element.z] = element;
		

	}

	public void AddTile(Tile tile, int x, int y, int z) {

		tiles[x,y,z] = tile;

	}

	public bool CanWalk(int x, int y, int z) {
		if(elements[x,y,z] != null) return false;
		if(tiles[x,y,z].walkable == false) return false;

		return true;
	}

	public Tile GetTileAt(int x, int y, int z) {
		if(tiles[x,y,z] != null) {
			return tiles[x,y,z];
		} else {
			return null;
		}
	}

	public Tile GetTileAt(Vector3 position) {
		if(tiles[(int)position.x, (int)position.y, (int)position.z] != null)
		{
			return tiles[ (int)position.x, (int)position.y, (int)position.z];
		} else {
			return null;
		}
	}
	
	public Element GetElementAt(int x, int y, int z) {
		if(elements[x,y,z] != null)
			return elements[x,y,z];
		else
			return null;
	}

	public Element GetElementAt(Vector3 position) {
		if(elements[(int)position.x, (int)position.y, (int)position.z] != null)
			return elements[(int)position.x, (int)position.y, (int)position.z];
		else
			return null;
	}

}
