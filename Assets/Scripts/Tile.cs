using UnityEngine;
using System.Collections;

public class Tile {

	public string tileName;
	public string tileTextureName {get; set;}
	public bool walkable = true;
	public bool seeThrough = true;

	public static string GetRandomTileName() {
		int rand = Random.Range(0,1);
		
		switch (rand) {
		case 0:
			return "Ground";
			break;
		case 1:
			return "Wall";
			break;
		default:
			return "Ground";
		}
	}

	public Tile (string tileName, int x, int y, int z) {
		this.tileName = tileName;
		tileTextureName = tileName;
		//Add it to the map registry
		Map.Instance.AddTile(this, x, y, z);

	}

	public Tile (string tileTextureName, int x, int y, int z, bool walkable) {
		tileTextureName = tileTextureName;
		this.walkable = walkable;
		//Add it to the map registry
		Map.Instance.AddTile(this, x, y, z);

	}

	public Tile (string tileTextureName, int x, int y, int z, bool walkable, bool seeThrough) {
		tileTextureName = tileTextureName;
		this.walkable = walkable;
		this.seeThrough = seeThrough;

		//Add it to the map registry
		Map.Instance.AddTile(this, x, y, z);

	}



}
