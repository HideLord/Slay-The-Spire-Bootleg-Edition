using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	public static class Generator
	{
		public static Random r = new Random(Guid.NewGuid().GetHashCode());

		public static int GenerateRandomInt(int high)
		{
			return r.Next(high);
		}

		public static int GenerateRandomInt(int low, int high)
		{
			return r.Next(low, high);
		}

		public static Card GenerateRandomWeapon()
		{
			throw new NotImplementedException();
		}

		public static Card GenerateRandomUtility()
		{
			throw new NotImplementedException();
		}

		public static Card GenerateRandomDefence()
		{
			throw new NotImplementedException();
		}
		public static Tile GenerateMap(int NumTiles, int NumTreasures, int NumBosses)
		{
			Debug.Assert(NumTiles > 1);
			Debug.Assert(NumTreasures > 0);
			Debug.Assert(NumBosses > 0);

			Tile Spawn = new Tile();
			Queue<Tile> MapTree = new Queue<Tile>();
			MapTree.Enqueue(Spawn);

			List<int> tileIndexer = new List<int>();
			for (int i = 0; i < NumTiles; i++) tileIndexer.Add(1);
			NumTiles -= 1;

			for (int i = 0; i < NumTreasures; i++)
			{
				int randomPos = GenerateRandomInt(NumTiles);
				while (tileIndexer[randomPos] != 1) { randomPos = GenerateRandomInt(NumTiles); }
				tileIndexer[randomPos] = 2;
			}
			for (int i = 0; i < NumBosses; i++)
			{
				int randomPos = GenerateRandomInt(NumTiles);
				while (tileIndexer[randomPos]!=1){ randomPos = GenerateRandomInt(NumTiles); }
				tileIndexer[randomPos] = 3;
			}

			while(MapTree.Count != 0)
			{
				Tile curr = MapTree.Dequeue();
				int NeighbourNum = Math.Min(NumTiles, GenerateRandomInt(1, 5 - curr.Neighbours.Count));
				for(int i = 0; i < NeighbourNum; i++, NumTiles--)
				{
					switch (tileIndexer[NumTiles])
					{
						case 1:// Default Tile
							curr.Neighbours.Add(new Tile());
							MapTree.Enqueue(curr.Neighbours[curr.Neighbours.Count - 1]);
							break;
						case 2:// Treasure Tile
							curr.Neighbours.Add(new TreasureTile());
							MapTree.Enqueue(curr.Neighbours[curr.Neighbours.Count - 1]);
							break;
						case 3:// Boss Tile
							curr.Neighbours.Add(new BossTile());
							MapTree.Enqueue(curr.Neighbours[curr.Neighbours.Count - 1]);
							break;
					}
				}
			}

			return Spawn;
		}

	}
}
