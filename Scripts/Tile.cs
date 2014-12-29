using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public int xCoord;
	public int yCoord;

	// is there a unit on the tile?
	private bool occupied;
	public bool Occupied{
		get { return occupied;}
		set { occupied = value;}
	}

	private Unit unit;
	public Unit Unit{
		get { return unit;}
		set { unit = value;}
	}
	
	private bool selected;
	public bool Selected{
		get { return selected;}
		set { selected = value;}
	}

	//test
	public bool isBlueTile;

	// Materials
	public Material materialIdle;
	public Material materialLightup;
	public Material materialBlueTileIdle;
	public Material materialBlueTileLightup;

	// Use this for initialization
	void Start () {
		selected = false;
		isBlueTile = false;
	}

	void OnMouseDown(){
		if(!selected) {		// if tile was not already selected, select it
			selectTile();	
		} else {				// else deselect it
			selected = false;
			Grid.currentTileSelected = null;

			// Reset tiles color (Undo showrange, unit did not move) 
			if(occupied){
				unit.undoShowRange();
			}
		}
	}

	void OnMouseOver() {
		if(!selected){
			if (!isBlueTile){
				renderer.material = materialLightup;
			} else {
				renderer.material = materialBlueTileLightup;
			}
		}
	}

	void OnMouseExit() {
		if(!selected){
			if(!isBlueTile){
				renderer.material = materialIdle;
			} else {
				renderer.material = materialBlueTileIdle;
			}
		}
	}

	void selectTile(){
		selected = true;
		Grid.previousTileSelected = Grid.currentTileSelected;
		Grid.currentTileSelected = this;
		
		if(Grid.previousTileSelected != null && Grid.previousTileSelected != this){
			Grid.previousTileSelected.Selected = false;
			Grid.previousTileSelected.OnMouseExit();
		}

		// if a unit is on the tile
		if(occupied == true){
			renderer.material.color = Color.red;

			// Show unit movement range
			unit.showRange();

		} else {
			if(isBlueTile){
				// Reset tiles color (Undo showrange)
				Grid.previousTileSelected.unit.undoShowRange();

				// Move unit
				Grid.previousTileSelected.Unit.move(xCoord, yCoord);
				occupied = true;
				Grid.previousTileSelected.Occupied = false;
				unit = Grid.previousTileSelected.Unit;
				Grid.previousTileSelected.Unit = null;
				
				// Deselect
				selected = false;
				Grid.currentTileSelected = null;
			} else if (Grid.previousTileSelected != null && Grid.previousTileSelected.Occupied == true){
				// Reset tiles color (Undo showrange, the user selected an empty tile out of unit movement range with the previous tile selected being a unit)
				Grid.previousTileSelected.unit.undoShowRange();
			}


			renderer.material.color = Color.white;
		}

	}

	public void blueTile(){
		if(!occupied){
			renderer.material = materialBlueTileIdle;
			isBlueTile = true;
		}
	}

	public void resetTileColor(){
		renderer.material = materialIdle;
		isBlueTile = false;
	}
}
