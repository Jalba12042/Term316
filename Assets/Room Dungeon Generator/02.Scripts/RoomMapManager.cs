using UnityEngine;
using System.Collections;
using ooparts.dungen;
using Unity.AI.Navigation;
using UnityEngine.AI;

namespace ooparts.dungen
{
	public class RoomMapManager : MonoBehaviour
	{
		public Map mapPrefap;
		private Map mapInstance;

		public int MapSizeX;
		public int MapSizeZ;
		public int MaxRooms;
		public int MinRoomSize;
		public int MaxRoomSize;

		public int TileSizeFactor = 1;
		public static int TileSize;

		void Start()
		{
			TileSize = TileSizeFactor;
			BeginGame();
		}


		private void BeginGame()
		{
			mapInstance = Instantiate(mapPrefap);
			mapInstance.RoomCount = MaxRooms;
			mapInstance.MapSize = new IntVector2(MapSizeX, MapSizeZ);
			mapInstance.RoomSize.Min = MinRoomSize;
			mapInstance.RoomSize.Max = MaxRoomSize;
			TileSize = TileSizeFactor;

			StartCoroutine(GenerateMapAndNavMesh());

			
           
        }

        private IEnumerator GenerateMapAndNavMesh()
        {
            yield return StartCoroutine(mapInstance.Generate());

            // After dungeon generation, add NavMeshSurface component to the mapInstance
            NavMeshSurface navMeshSurface = mapInstance.gameObject.AddComponent<NavMeshSurface>();
            // Set the size of the NavMeshSurface to cover the entire generated dungeon
            navMeshSurface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
            navMeshSurface.BuildNavMesh();
        }

        private void RestartGame()
		{
			StopAllCoroutines();
			Destroy(mapInstance.gameObject);
			BeginGame();
		}
	}
}