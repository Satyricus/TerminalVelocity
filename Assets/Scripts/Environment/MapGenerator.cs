using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private const int FLOOR_LEVEL_CUBE = 3;
    private const int FLOOR_LEVEL_COLUMN = 6;
    private const int NUMBER_OF_ROWS_TO_SPAWN = 10;
    private const int NUMBER_OF_COLUMNS_TO_SPAWN = 10;

    private const int NUMBER_OF_ROW_TYPES = 3;

    private int ZDistanceUsed = 0;

    void Start () {
        SpawnObjects();
    }

    /// <summary>
    /// Spawn objects in the worlds in rows and columns
    /// </summary>
    void SpawnObjects() {
        for (var i = 0; i < NUMBER_OF_ROWS_TO_SPAWN; i++) {
            int RandomRow = Random.Range(1, NUMBER_OF_ROW_TYPES + 1);
            ChooseColumnToSpawn(RandomRow);
        }
    }

    /// <summary>
    /// Choose which row to spawn for a column and call the function incharge of spawning that row
    /// </summary>
    void ChooseColumnToSpawn(int RandomRow) {
        switch (RandomRow) {
            case 1:
                this.SpawnCubeRow();
                break;
            case 2:
                this.SpawnColumnRows();
                break;
            case 3:
                this.SpawnTunnelRow();
                break;
        }
    }

    /// <summary>
    /// Initiate a new SectionGenerator of type cube and create section
    /// </summary>
    void SpawnCubeRow() {
        CubeSection CubeRow = ScriptableObject.CreateInstance<CubeSection>();
        CubeRow.Init(this.ZDistanceUsed);
        CubeRow.CreateSection();
        this.IncreaseDistanceUsed(CubeRow.getSectionLength());
    }

    /// <summary>
    /// Spawn a row of columns
    /// </summary>
    void SpawnColumnRows() {
        ColumnSection ColumnRows = ScriptableObject.CreateInstance<ColumnSection>();
        ColumnRows.Init(this.ZDistanceUsed);
        ColumnRows.CreateSection();
        this.IncreaseDistanceUsed(ColumnRows.getSectionLength());
    }

    void SpawnTunnelRow() {
        Tunnel TunnelRow = ScriptableObject.CreateInstance<Tunnel>();
        TunnelRow.Init(this.ZDistanceUsed);
        TunnelRow.CreateSection();
        this.IncreaseDistanceUsed(TunnelRow.getSectionLength());
    }

    /// <summary>
    /// Increase distance we have used this map generation
    /// </summary>
    private void IncreaseDistanceUsed(int distance) {
        this.ZDistanceUsed += distance;
    }
}
