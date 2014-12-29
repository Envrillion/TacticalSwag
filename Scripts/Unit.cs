using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public int xCoord;
	public int yCoord;

	// Use this for initialization
	void Start () {
	}

	public void move(int newXCoord, int newYCoord){
		xCoord = newXCoord;
		yCoord = newYCoord;
		
		transform.position = new Vector3(newXCoord + newXCoord * (Grid.distanceBetweenTiles - 1), // 1 = the size of a tile
		                                 newYCoord + newYCoord * (Grid.distanceBetweenTiles - 1),
                                  		 -2);
	}

	public void showRange(){
		if(Grid.inBounds(xCoord + 1, yCoord)){
			Grid.allTiles[xCoord + 1, yCoord].blueTile();
		}
		if(Grid.inBounds(xCoord - 1, yCoord)){
			Grid.allTiles[xCoord - 1, yCoord].blueTile();
		}
		if(Grid.inBounds(xCoord, yCoord + 1)){
			Grid.allTiles[xCoord, yCoord + 1].blueTile();
		}
		if(Grid.inBounds(xCoord, yCoord - 1)){
			Grid.allTiles[xCoord, yCoord - 1].blueTile();
		}
	}

	public void undoShowRange(){
		if(Grid.inBounds(xCoord + 1, yCoord)){
			Grid.allTiles[xCoord + 1, yCoord].resetTileColor();
		}
		if(Grid.inBounds(xCoord - 1, yCoord)){
			Grid.allTiles[xCoord - 1, yCoord].resetTileColor();
		}
		if(Grid.inBounds(xCoord, yCoord + 1)){
			Grid.allTiles[xCoord, yCoord + 1].resetTileColor();
		}
		if(Grid.inBounds(xCoord, yCoord - 1)){
			Grid.allTiles[xCoord, yCoord - 1].resetTileColor();
		}	
	}

//	void recursiveShowRange(int xRCoord, int yRCoord){
//		if(Grid.inBounds(xRCoord + 1, yRCoord)){
//			Grid.allTiles[xRCoord + 1, yRCoord].blueTile();
//		}
//		if(Grid.inBounds(xRCoord - 1, yRCoord)){
//			Grid.allTiles[xRCoord - 1, yRCoord].blueTile();
//		}
//		if(Grid.inBounds(xRCoord, yRCoord + 1)){
//			Grid.allTiles[xRCoord, yRCoord + 1].blueTile();
//		}
//		if(Grid.inBounds(xRCoord, yRCoord - 1)){
//			Grid.allTiles[xRCoord, yRCoord - 1].blueTile();
//		}
//	}
}
