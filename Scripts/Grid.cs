using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// Prefabs
	public Tile tilePrefab;
	public Unit unitPrefab;

	// Grid Info
	public static int tilesPerRow;
	public static int tilesPerColumn;
	public static float distanceBetweenTiles;

	public int maxNbOfUnits = 10;

	// array that contains all tiles
	public static Tile[,] allTiles;

	// Selected tiles
	public static Tile currentTileSelected;
	public static Tile previousTileSelected;

	void Start () {
		tilesPerRow = 10;
		tilesPerColumn = 10;
		distanceBetweenTiles = 1.5f;
		allTiles = new Tile[tilesPerColumn, tilesPerRow];
		CreateTiles ();
		CreateUnits ();
	}
	
	void CreateTiles() {
		float xOffset = 0.0f;
		float yOffset = 0.0f;

		for (int i = 0; i < tilesPerColumn; i++) {
			for (int j = 0; j < tilesPerRow; j++){

				Tile newTile = (Tile)Instantiate (tilePrefab,
		             						new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z),
			             					transform.rotation);	
				newTile.name = "Tile (" + j.ToString() + ", " + i.ToString() + ")";
				newTile.xCoord = j;
				newTile.yCoord = i;
				allTiles[j, i] = newTile;

				xOffset += distanceBetweenTiles;
			}
			yOffset += distanceBetweenTiles;
			xOffset = 0.0f;
		}
	}

	void CreateUnits(){
		Unit newUnit = (Unit)Instantiate (unitPrefab, 
		                                  new Vector3(transform.position.x, transform.position.y, transform.position.z -2),
		                                  transform.rotation);	
		newUnit.xCoord = 0;
		newUnit.yCoord = 0;

		allTiles[newUnit.xCoord, newUnit.yCoord].Occupied = true;
		allTiles[newUnit.xCoord, newUnit.yCoord].Unit = newUnit;
	}

	public static bool inBounds(int xTileCoord, int yTileCoord) {
		if(xTileCoord < 0 				||
		   xTileCoord >= tilesPerColumn ||
		   yTileCoord < 0 				|| 
		   yTileCoord >= tilesPerRow) 
			return false;
		else 
			return true;
	}
	
}