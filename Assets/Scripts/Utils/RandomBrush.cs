using System;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor {

    [CustomGridBrush(false, true, false, "Random Brush")]
    public class RandomBrush : GridBrush {
        public TileBase[] randomTiles;

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position) {
            if (randomTiles != null && randomTiles.Length > 0) {
                Vector3Int min = position - pivot;
                SetRandomTilemapTiles(brushTarget, new BoundsInt(min, size));
            }
            else {
                base.Paint(gridLayout, brushTarget, position);
            }
        }

        public override void BoxFill(GridLayout gridLayout, GameObject brushTarget, BoundsInt position) {
            if (randomTiles != null && randomTiles.Length > 0) {
                SetRandomTilemapTiles(brushTarget, position);
            }
            else {
                base.BoxFill(gridLayout, brushTarget, position);
            }
        }

        public void SetRandomTilemapTiles(GameObject brushTarget, BoundsInt bounds) {
            if (brushTarget == null)
                return;

            var tilemap = brushTarget.GetComponent<Tilemap>();
            if (tilemap == null)
                return;

            foreach (Vector3Int location in bounds.allPositionsWithin) {
                var randomTile = randomTiles[(int)(randomTiles.Length * UnityEngine.Random.value)];
                tilemap.SetTile(location, randomTile);
            }
        }

        [MenuItem("Assets/Create/Brushes/Random Brush")]
        public static void CreateBrush() {
            string path = EditorUtility.SaveFilePanelInProject("Save Random Brush", "New Random Brush", "asset", "Save Random Brush", "Assets/Brushes");

            if (path == "")
                AssetDatabase.CreateFolder("Assets", "Brushes");

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<RandomBrush>(), path);
        }
    }

    [CustomEditor(typeof(RandomBrush))]
    public class RandomBrushEditor : GridBrushEditor {
        private RandomBrush randomBrush { get { return target as RandomBrush; } }
        private GameObject lastBrushTarget;

        public override void PaintPreview(GridLayout gridLayout, GameObject brushTarget, Vector3Int position) {
            if (randomBrush.randomTiles != null && randomBrush.randomTiles.Length > 0) {
                base.PaintPreview(gridLayout, null, position);

                Vector3Int min = position - randomBrush.pivot;
                SetRandomEditorPreviewTiles(brushTarget, new BoundsInt(min, randomBrush.size));

                lastBrushTarget = brushTarget;
            }
            else {
                base.PaintPreview(gridLayout, brushTarget, position);
            }
        }

        public override void BoxFillPreview(GridLayout gridLayout, GameObject brushTarget, BoundsInt position) {
            if (randomBrush.randomTiles != null && randomBrush.randomTiles.Length > 0) {
                base.BoxFillPreview(gridLayout, null, position);

                SetRandomEditorPreviewTiles(brushTarget, position);

                lastBrushTarget = brushTarget;
            }
            else {
                base.BoxFillPreview(gridLayout, brushTarget, position);
            }
        }

        public void SetRandomEditorPreviewTiles(GameObject brushTarget, BoundsInt bounds) {
            if (brushTarget == null)
                return;

            var tilemap = brushTarget.GetComponent<Tilemap>();
            if (tilemap == null)
                return;

            foreach (Vector3Int location in bounds.allPositionsWithin) {
                var randomTile = randomBrush.randomTiles[(int)(randomBrush.randomTiles.Length * UnityEngine.Random.value)];
                tilemap.SetEditorPreviewTile(location, randomTile);
            }
        }

        public override void ClearPreview() {
            if (lastBrushTarget != null) {
                var tilemap = lastBrushTarget.GetComponent<Tilemap>();
                if (tilemap == null)
                    return;

                tilemap.ClearAllEditorPreviewTiles();

                lastBrushTarget = null;
            }
            else {
                base.ClearPreview();
            }
        }

        public override void OnPaintInspectorGUI() {
            EditorGUI.BeginChangeCheck();

            int count = EditorGUILayout.IntField("Number of Tiles", randomBrush.randomTiles != null ? randomBrush.randomTiles.Length : 0);
            count = Mathf.Clamp(count, 0, count);

            if (randomBrush.randomTiles == null || randomBrush.randomTiles.Length != count) {
                Array.Resize<TileBase>(ref randomBrush.randomTiles, count);
            }

            if (count == 0)
                return;

            EditorGUILayout.LabelField("Place random tiles.");
            EditorGUILayout.Space();

            for (int i = 0; i < count; i++) {
                randomBrush.randomTiles[i] = (TileBase)EditorGUILayout.ObjectField("Tile " + (i + 1), randomBrush.randomTiles[i], typeof(TileBase), false, null);
            }

            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(randomBrush);
        }
    }
}