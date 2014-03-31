using UnityEngine;
using System.Collections;

public class MapViewer : MonoBehaviour {

	public float refreshRate = 0.1f;
	public Map map;
	int x = 0;
	int y = 0;
	int z = 0;
	public int width = 20;
	public int height = 15;

	GameObject[,] tileViewers;
	GameObject[,] elementViewers;
	bool canUpdate = true;

	// Use this for initialization
	void Start () {
		tileViewers = new GameObject[width, height];
		elementViewers = new GameObject[width, height];

		GameObject mapViewer = new GameObject("MapViewer");
		GameObject tiles = new GameObject("Tiles");
		GameObject elements = new GameObject("Elements");

		tiles.transform.parent = mapViewer.transform;
		elements.transform.parent = mapViewer.transform;

		for(int Y = 0; Y < height; Y++) {
			
			for(int X = 0; X < width; X++) {

				GameObject newTile = Instantiate(Resources.Load ("Tiles/Tile")) as GameObject;
				newTile.transform.position = new Vector3(X, -Y, 0);
				newTile.name = "Tile " + X + ", " + Y;
				newTile.transform.parent = tiles.transform;
				tileViewers[X,Y] = newTile;
				
				GameObject newElement = Instantiate(Resources.Load ("Tiles/Tile")) as GameObject;
				newElement.transform.position = new Vector3(X, -Y, -1);
				newElement.name = "Element " + X + ", " + Y;
				newElement.transform.parent = elements.transform;
				elementViewers[X,Y] = newElement;
			}
		} 

		InvokeRepeating("Refresh", 0, refreshRate);

	}
	
	void Update() {

			if(Input.GetKey(KeyCode.W)) {
				if(y > 0) {
					y--; 

				}
			}
			if(Input.GetKey(KeyCode.S)) {
				if(y < map.height - height)  {
					y++;

				}
			}
			if(Input.GetKey(KeyCode.A)) {
				if(x > 0)  {
					x--;

				}
			}
			if(Input.GetKey(KeyCode.D)) {
				if(x < map.width - width) {
					x++;

				}
			} 
			
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			if(z < map.maxDepth) z++;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			if(z > 0) z--;
		}
	


	}


	void Refresh() {

		for(int Y = 0; Y < height; Y++) {
			
			for(int X = 0; X < width; X++) {

				Tile tile = map.GetTileAt(x + X, y + Y,z);
				Element element = map.GetElementAt(x + X, y + Y,z);

				if(tile == null) {
					tileViewers[X, Y].renderer.material.mainTexture = null;

				} else {
					Texture texture = Resources.Load ("Tiles/" + tile.tileTextureName) as Texture;
					tileViewers[X, Y].renderer.material.mainTexture = texture;
				}

				if(element == null) {

					elementViewers[X, Y].renderer.enabled = false;

				} else {

					Texture texture = Resources.Load ("Elements/" + element.ElementTexturePath) as Texture;
					elementViewers[X, Y].renderer.enabled = true;
					elementViewers[X, Y].renderer.material.mainTexture = texture;

				}
			}
		} 

	}

	public Vector3 GetPosition() {
		return new Vector3(x, y, z);
	}

}
