using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : SectionGenerator {
    private const int COLUMN_SPACING = 20;

    private const int NUMBER_ROWS_TO_SPAWN = 1;

    private const int FLOOR_LEVEL = 2;
    private const int NUMBER_OF_COLUMNS_TO_SPAWN = 10;
    private const int ROW_DISTANCE = 50;

    public override void Init(int ZPosition) {
        this.ZPosition = ZPosition;
        this.EnvObject = Resources.Load("Prefabs/Environment/Tunnel");
        this.SingleRowDistance = ROW_DISTANCE;
    }

    public override void CreateSection() {
        for (var i = 0; i < NUMBER_OF_COLUMNS_TO_SPAWN; i++) {
            var x = COLUMN_SPACING * i;
            Vector3 position = new Vector3(x, FLOOR_LEVEL, this.ZPosition);
            Instantiate(this.EnvObject, position, Quaternion.identity);
        }
        this.IncreaseDistanceUsed();
    }
}
