using System;
using Microsoft.Xna.Framework;
using Voage_Engine.Assets.Scripts.Player;
using Voyage_Engine.Game_Engine.TileMap;

namespace Voyage_Engine.Game_Engine.Objects.Scripts.BoardUI;

public class BoardHandler
{
    public event Action<Tile> OnPocEatnd;
    
    public TileMap.TileMap TileMap { get; }
    

    public BoardHandler()
    {
        TileMap = new TileMap.TileMap(8, 8, new Vector2(70, 70));
    }

    public bool MovePoc(int colum, int raw, int newColum, int newRaw, int id)
    {
        if (!IsValidMove(colum, raw, ref newColum, ref newRaw, id))
            return false;

        var tile = TileMap[colum, raw].GetComponent<Tile>();

        if (!tile.IsHaveValue)
            return false;

        var temp = tile.TileObject.GetComponent<CheckersPoc>();

        if (temp.Id != id)
            return false;

        var gameObject = tile.RemoveTileObject();
        TileMap[newColum, newRaw].GetComponent<Tile>().TryAssiagGameObject(gameObject);
        return true;
    }

    private bool IsValidMove(int colum, int raw, ref int newColum, ref int newRaw, int id)
    {
        var isDiagonal = false;
        var isForward = false;

        var rawRemainder = newRaw - raw;
        var columnRemainder = newColum - colum;

        if (Math.Abs(columnRemainder) == Math.Abs(rawRemainder))
            isDiagonal = true;

        switch (id)
        {
            case 1:
                if (newRaw < raw)
                    isForward = true;
                break;
            case 2:
                if (newRaw > raw)
                    isForward = true;
                break;
        }

        var nextRaw = raw + rawRemainder / Math.Abs(rawRemainder);
        var nextColum = colum + columnRemainder / Math.Abs(columnRemainder);

        var nextTile = TileMap[nextColum, nextRaw].GetComponent<Tile>();

        if (nextTile.IsHaveValue && nextTile.TileObject.GetComponent<CheckersPoc>().Id != id)
        {
            OnPocEatnd?.Invoke(nextTile);

            return isDiagonal && isForward;
        }

        newRaw = nextRaw;
        newColum = nextColum;

        return isDiagonal && isForward;
    }

    public void AddBlackPlayerPoc(params CheckersPoc[] checkersPocs)
    {
        var count = 0;
        var startColumn = 1;

        for (var j = 0; j < 3; j++)
        {
            for (var i = startColumn; i < 8; i += 2)
            {
                var tile = TileMap[i, j].GetComponent<Tile>();

                if (tile.IsHaveValue)
                    return;

                tile.TryAssiagGameObject(checkersPocs[count].GameObject);
                count++;
            }

            startColumn = startColumn == 1 ? 0 : 1;
        }
    }

    public void AddWhitePlayerPoc(params CheckersPoc[] checkersPocs)
    {
        var count = 0;
        var startColumn = 0;

        for (var j = 5; j < 8; j++)
        {
            for (var i = startColumn; i < 8; i += 2)
            {
                var tile = TileMap[i, j].GetComponent<Tile>();

                if (tile.IsHaveValue)
                    return;

                tile.TryAssiagGameObject(checkersPocs[count].GameObject);
                count++;
            }

            startColumn = startColumn == 1 ? 0 : 1;
        }
    }
}