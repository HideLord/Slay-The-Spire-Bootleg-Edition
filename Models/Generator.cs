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
		/// <summary>
		/// Binding of Isaac type map
		/// The tree is bi-directional
		/// </summary>
		/// <returns> Tile which is the spawn point and the starting node of the map tree.</returns>
		[Obsolete]
		public static Tile GenerateMap(int NumTiles, int NumTreasures, int NumElites)
		{
			Debug.Assert(NumTiles > NumElites+NumTreasures+1); // Check if the number of tiles can contain all of the Elites, Treasures and the final boss

			Tile Spawn = new Tile();
			Queue<Tile> MapTree = new Queue<Tile>();
			MapTree.Enqueue(Spawn);

			List<int> tileIndexer = new List<int>();
			for (int i = 0; i < NumTiles; i++) tileIndexer.Add(1);
			NumTiles -= 1;

			for (int i = 0; i < NumTreasures; i++)
			{
				int randomPos = GenerateRandomInt(1,NumTiles);
				while (tileIndexer[randomPos] != 1) { randomPos = GenerateRandomInt(NumTiles); }
				tileIndexer[randomPos] = 2;
			}
			for (int i = 0; i < NumElites; i++)
			{
				int randomPos = GenerateRandomInt(1,NumTiles);
				while (tileIndexer[randomPos]!=1){ randomPos = GenerateRandomInt(NumTiles); }
				tileIndexer[randomPos] = 3;
			}
			tileIndexer[0] = 4;

			while(MapTree.Count != 0)
			{
				Tile curr = MapTree.Dequeue();
				int NeighbourNum = Math.Min(NumTiles, GenerateRandomInt(1, 5 - curr.Neighbours.Count));
				for(int i = 0; i < NeighbourNum; i++, NumTiles--)
				{
					switch (tileIndexer[NumTiles-1])
					{
						case 1:// Default Tile
							curr.Neighbours.Add(new EnemyTile());
							curr.Neighbours[curr.Neighbours.Count - 1].Neighbours.Add(curr);

							MapTree.Enqueue(curr.Neighbours[curr.Neighbours.Count - 1]);

							break;
						case 2:// Treasure Tile
							curr.Neighbours.Add(new TreasureTile());
							curr.Neighbours[curr.Neighbours.Count - 1].Neighbours.Add(curr);

							MapTree.Enqueue(curr.Neighbours[curr.Neighbours.Count - 1]);
							break;
						case 3:// Elite Tile
							curr.Neighbours.Add(new EliteTile());
							curr.Neighbours[curr.Neighbours.Count - 1].Neighbours.Add(curr);

							MapTree.Enqueue(curr.Neighbours[curr.Neighbours.Count - 1]);
							break;
						case 4:
							curr.Neighbours.Add(new BossTile()); //Since it's a boss cell it shouldn't have any Neighbours
							curr.Neighbours[curr.Neighbours.Count - 1].Neighbours.Add(curr);

							break;
					}
				}
				
			}
			
			return Spawn;
		}

		delegate void PlaceOnMap(int Entities, int EntCode);

		public static Tile GenerateMapSpire(int levels, int maxTilesPerLevel, int numElites, int numTreasures, int numEvents)
		{
			Debug.Assert(2 * levels >= numElites + numTreasures + numEvents);

			Tile Spawn = new Tile();

			List<List<int>> MapLayout = new List<List<int>>();
			for (int _ = 0; _ < levels; _++)
			{
				MapLayout.Add(new List<int>());
				int NumberOfNodesThisLevel = GenerateRandomInt(2, 6); // [2;5]
				for (int j = 0; j < NumberOfNodesThisLevel; j++) MapLayout.Last().Add(1);
			}

			PlaceOnMap placeLambda = delegate (int numEntities, int EntCode) {
				for (int _ = 0; _ < numEntities; _++)
				{
					while (true)
					{
						int SpawnOnLevel = GenerateRandomInt(0, levels);
						//Check if level has free spot
						bool isFree = false;
						for (int i = 0; i < MapLayout[SpawnOnLevel].Count; i++) if (MapLayout[SpawnOnLevel][i] == 1) isFree = true;
						if (!isFree) continue;
						while (isFree)
						{
							int SpawnOnNode = GenerateRandomInt(0, MapLayout[SpawnOnLevel].Count);
							if (MapLayout[SpawnOnLevel][SpawnOnNode] == 1)
							{
								MapLayout[SpawnOnLevel][SpawnOnNode] = EntCode;
								break;
							}
						}
						break;
					}
				}
			};

			placeLambda(numTreasures, 2);
			placeLambda(numEvents, 3);
			placeLambda(numElites, 4);

			List<Tile> PrevLevel = new List<Tile>();

			for (int level = 0; level < levels; level++)
			{
				List<Tile> CurrLevel = new List<Tile>();

				for (int i = 0; i < MapLayout[level].Count; i++)
				{
					switch(MapLayout[level][i]){
						case 1:
							CurrLevel.Add(new EnemyTile());
							CurrLevel.Last().LayerInd = level;
							CurrLevel.Last().NodeInd = i;
							break;
						case 2:
							CurrLevel.Add(new TreasureTile());
							CurrLevel.Last().LayerInd = level;
							CurrLevel.Last().NodeInd = i;
							break;
						case 3:
							CurrLevel.Add(new EventTile());
							CurrLevel.Last().LayerInd = level;
							CurrLevel.Last().NodeInd = i;
							break;
						case 4:
							CurrLevel.Add(new EliteTile());
							CurrLevel.Last().LayerInd = level;
							CurrLevel.Last().NodeInd = i;
							break;
					}
				}

				if (level == 0)
				{
					for(int i = 0; i < CurrLevel.Count(); i++)
					{
						Spawn.Neighbours.Add(CurrLevel[i]);
					}
				}
				else if(CurrLevel.Count < PrevLevel.Count)
				{
					double coef = (double)CurrLevel.Count / (double)PrevLevel.Count;
					List<bool> CurrLevelConn = new List<bool>(CurrLevel.Count);
					for (int i = 0; i < CurrLevel.Count; i++) CurrLevelConn.Add(false);

					int maxForward = 0;

					for (int i = 1; i <= PrevLevel.Count; i++)
					{
						bool isConn = false;
						int prev = (int)Math.Round((i - 1) * coef);
						int curr = (int)Math.Round(i * coef);
						int next = Math.Max(1, (int)Math.Round((i + 1) * coef));

						if(maxForward <= prev && prev > 0)
						{
							if (GenerateRandomInt(0, 2) == 1 || !CurrLevelConn[prev - 1])
							{
								maxForward = prev;
								isConn = true;
								CurrLevelConn[prev - 1] = true;

								PrevLevel[i - 1].Neighbours.Add(CurrLevel[prev - 1]);
							}
						}
						if(maxForward <= curr && curr > 0 && curr <= CurrLevel.Count)
						{
							if (!isConn || GenerateRandomInt(0, 2) == 1 || !CurrLevelConn[curr-1])
							{
								maxForward = curr;
								isConn = true;
								CurrLevelConn[curr - 1] = true;

								PrevLevel[i-1].Neighbours.Add(CurrLevel[curr - 1]);
							}
						}
						if (maxForward <= next && next <= CurrLevel.Count)
						{
							if (!isConn || GenerateRandomInt(0, 2) == 1 || !CurrLevelConn[curr - 1])
							{
								maxForward = next;
								isConn = true;
								CurrLevelConn[next - 1] = true;

								PrevLevel[i-1].Neighbours.Add(CurrLevel[next - 1]);
							}
						}
						Debug.Assert(isConn);
					}

					//for (int i = 0; i < CurrLevelConn.Count; i++) Debug.Assert(CurrLevelConn[i]);
				} else
				{
					double coef = (double)PrevLevel.Count / (double)CurrLevel.Count;
					List<bool> PrevLevelConn = new List<bool>(PrevLevel.Count);
					for (int i = 0; i < PrevLevel.Count; i++) PrevLevelConn.Add(false);

					int maxForward = 0;

					for (int i = 1; i <= CurrLevel.Count; i++)
					{
						bool isConn = false;
						int prev = (int)Math.Round((i - 1) * coef);
						int curr = (int)Math.Round(i * coef);
						int next = Math.Max(1, (int)Math.Round((i + 1) * coef));

						if (maxForward <= prev && prev > 0)
						{
							if (GenerateRandomInt(0, 2) == 1 || !PrevLevelConn[prev - 1])
							{
								maxForward = prev;
								isConn = true;
								PrevLevelConn[prev - 1] = true;

								PrevLevel[prev - 1].Neighbours.Add(CurrLevel[i - 1]);
							}
						}
						if (maxForward <= curr && curr > 0 && curr <= PrevLevel.Count)
						{
							if (!isConn || GenerateRandomInt(0, 2) == 1 || !PrevLevelConn[curr - 1])
							{
								maxForward = curr;
								isConn = true;
								PrevLevelConn[curr - 1] = true;

								PrevLevel[curr - 1].Neighbours.Add(CurrLevel[i - 1]);
							}
						}
						if (maxForward <= next && next <= PrevLevel.Count)
						{
							if (!isConn || GenerateRandomInt(0, 2) == 1 || !PrevLevelConn[curr - 1])
							{
								maxForward = next;
								isConn = true;
								PrevLevelConn[next - 1] = true;

								PrevLevel[next - 1].Neighbours.Add(CurrLevel[i - 1]);
							}
						}
						Debug.Assert(isConn);
					}

					//for (int i = 0; i < CurrLevelConn.Count; i++) Debug.Assert(CurrLevelConn[i]);
				}
				PrevLevel = CurrLevel;
			}

			BossTile TheBoss = new BossTile();
			for(int i = 0; i < PrevLevel.Count; i++)
			{
				PrevLevel[i].Neighbours.Add(TheBoss);
			}

			return Spawn;
		}

	}
}
