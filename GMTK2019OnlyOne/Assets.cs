using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.TextureAtlases;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne
{
    public static class Assets
    {
        public static Dictionary<string, SpriteFont> Fonts;

        public static Dictionary<string, NezSpriteFont> NFonts;

        public static Dictionary<string, TiledMap> Maps;

        public static Dictionary<string, Texture2D> Sprites;

        public static Dictionary<string, TextureAtlas> SpriteSheets;

        public static void Load()
        {
            SpriteSheets = LoadList<TextureAtlas>(new string[]
            {
                //
            });

            Sprites = LoadList<Texture2D>(new string[]
            {
                "onlyone",
            });

            Maps = LoadList<TiledMap>(new string[]
            {
                "test-map",
                "level1",
                "level2",
            });

            Fonts = LoadList<SpriteFont>(new string[]
            {
                "PressStart2P",
            });

            CreateNFonts();
        }

        private static Dictionary<string, T> LoadList<T>(string[] _List)
        {
            Dictionary<string, T> Return = new Dictionary<string, T>();

            foreach (string Item in _List)
            {
                Return.Add(Item, Game1.content.Load<T>(Item));
            }

            return Return;
        }

        private static void CreateNFonts()
        {
            NFonts = new Dictionary<string, NezSpriteFont>();

            foreach (string Key in Fonts.Keys)
            {
                NFonts.Add(Key, new NezSpriteFont(Fonts[Key]));
            }
        }
    }
}
