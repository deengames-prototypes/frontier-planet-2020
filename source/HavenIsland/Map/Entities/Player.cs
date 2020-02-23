using DeenGames.HavenIsland.Events;
using DeenGames.HavenIsland.Model;
using Puffin.Core.Ecs;
using Puffin.Core.Events;
using Puffin.Core.IO;
using System.IO;

namespace DeenGames.HavenIsland.Map.Entities
{
    public class Player : Entity
    {
        internal static Player LatestInstance { get; private set; }
        private PlayerModel model;

        public Player(PlayerModel model)
        {
            Player.LatestInstance = this;
            this.model = model;
            
            this.Spritesheet(Path.Combine("Content", "Images", "Characters", "Protagonist.png"), 26, 32);

            this.Keyboard((data) =>
            {
                if (data is PuffinAction)
                {
                    var moveKey = (PuffinAction)data;
                    if (moveKey == PuffinAction.Up)
                    {
                        GameWorld.Instance.AreaMap.TryToMovePlayerBy(0, -1);
                    }
                    else if (moveKey == PuffinAction.Down)
                    {
                        GameWorld.Instance.AreaMap.TryToMovePlayerBy(0, 1);
                    }
                    else if (moveKey == PuffinAction.Left)
                    {
                        GameWorld.Instance.AreaMap.TryToMovePlayerBy(-1, 0);
                    }
                    else if (moveKey == PuffinAction.Right)
                    {
                        GameWorld.Instance.AreaMap.TryToMovePlayerBy(1, 0);
                    }

                    this.X = this.model.X * Constants.TILE_WIDTH;
                    this.Y = this.model.Y * Constants.TILE_HEIGHT;
                }
            });
        }
    }
}