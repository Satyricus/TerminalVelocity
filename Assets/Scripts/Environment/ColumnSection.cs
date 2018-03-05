using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSection : SectionGenerator {

    private const int COLUMN_SPACING = 10;

    private const int MIN_NUMBER_ROWS_TO_SPAWN = 5;
    private const int MAX_NUMBER_ROWS_TO_SPAWN = 15;

    private const int FLOOR_LEVEL = 6;
    private const int NUMBER_OF_COLUMNS_TO_SPAWN = 5;
    private const int ROW_DISTANCE = 10;

    public override void Init(int ZPosition) {
        this.ZPosition = ZPosition;
        this.EnvObject = Resources.Load("Prefabs/Environment/EnvColumn");
        this.SingleRowDistance = ROW_DISTANCE;
    }

    public override void CreateSection() {
        int NumberOfRows = Random.Range(MIN_NUMBER_ROWS_TO_SPAWN, MAX_NUMBER_ROWS_TO_SPAWN);
        for (var i = 0; i < NumberOfRows; i++) {
            for (var j = 0; j < NUMBER_OF_COLUMNS_TO_SPAWN * 2; j++) {
                var x = COLUMN_SPACING * j;
                Vector3 position = new Vector3(x, FLOOR_LEVEL, this.ZPosition);
                Instantiate(this.EnvObject, position, Quaternion.identity);
            }
            this.IncreaseDistanceUsed();
        }
    }

}
