using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public enum PlayerOption
{
    NONE, //0
    X, // 1
    O // 2
}

public class TTT : MonoBehaviour
{
    public int Rows;
    public int Columns;
    int emptySpaces = 0;
    [SerializeField] BoardView board;


    PlayerOption currentPlayer = PlayerOption.X;
    Cell[,] cells;

    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[Columns, Rows];

        board.InitializeBoard(Columns, Rows);

        for(int i = 0; i < Rows; i++)
        {
            for(int j = 0; j < Columns; j++)
            {
                cells[j, i] = new Cell();
                cells[j, i].current = PlayerOption.NONE;
            }
        }
    }

    public void MakeOptimalMove()
    {
        CheckSpaces();

        if (emptySpaces == 9)
        {
            ChooseSpace(0, 0);
            emptySpaces = 0;
            return;
        }

        if (emptySpaces == 8)
        {
            if(cells[1, 1].current == PlayerOption.NONE)
            {
                ChooseSpace(1, 1);
                emptySpaces = 0;
                return;
            }
            else
            {
                ChooseSpace(0, 0);
                emptySpaces = 0;
                return;
            }
        }

        if (emptySpaces == 7)
        {
            if (cells[0, 0].current == PlayerOption.X) //First
            {
                if (cells[1, 1].current == PlayerOption.O) //Second
                {
                    ChooseSpace(2, 2);
                    emptySpaces = 0;
                    return;
                }

                if (cells[0, 1].current == PlayerOption.O || cells[1, 0].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O) //Second
                {
                    ChooseSpace(1, 1);
                    emptySpaces = 0;
                    return;
                }

                if (cells[0, 2].current == PlayerOption.O || cells[2, 2].current == PlayerOption.O) //Second
                {
                    ChooseSpace(2, 0);
                    emptySpaces = 0;
                    return;
                }

                if (cells[2, 0].current == PlayerOption.O) //Second
                {
                    ChooseSpace(0, 2);
                    emptySpaces = 0;
                    return;
                }
            }


        }

        if (emptySpaces == 6)
        {
            if(cells[1, 1].current == PlayerOption.X)
            {
                if(cells[0, 0].current == PlayerOption.O)
                {
                    if(cells[1, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if(cells[0, 0].current == PlayerOption.X)
            {
                if (cells[1,1].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[2,2].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[0, 2].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[2, 0].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[1, 0].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[0, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[0,1].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[2,1].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[1,2].current == PlayerOption.X)
            {
                if (cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

        }

        if (emptySpaces == 5)
        {
            if (cells[0, 0].current == PlayerOption.X)  //First
            {
                if (cells[1, 1].current == PlayerOption.X)   //Second
                {
                    if (cells[1, 0].current == PlayerOption.O) //Third
                    {
                        if (cells[2, 0].current == PlayerOption.O || cells[0, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0, 1].current == PlayerOption.O)  //Third
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[2, 0].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2, 1].current == PlayerOption.O)  //Third
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[2, 0].current == PlayerOption.O || cells[0, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1, 2].current == PlayerOption.O)  //Third
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[2, 0].current == PlayerOption.O || cells[0, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0, 2].current == PlayerOption.X) //Second
                {
                    if (cells[2, 0].current == PlayerOption.O) //Third
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[1, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O || cells[2, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }

                        else
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 0].current == PlayerOption.X) //Second
                {
                    if (cells[0, 2].current == PlayerOption.O) //Third
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[1, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O || cells[2, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }

                        else
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2, 2].current == PlayerOption.O) //Third
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[1, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }

                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 2].current == PlayerOption.X) //Second
                {
                    if (cells[1, 1].current == PlayerOption.O) //Third
                    {
                        if (cells[1, 0].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }

                        if (cells[2, 0].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }

                        if (cells[0, 1].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }

                        if (cells[2, 1].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }

                        if (cells[0, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }

                        if (cells[1, 2].current == PlayerOption.O) //Fourth
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
            }
        }

        if (emptySpaces == 4)
        {
            if (cells[1, 1].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
            {
                if (cells[1, 0].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                {
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[2, 0].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                {
                    if (cells[0, 1].current == PlayerOption.X || cells[2, 1].current == PlayerOption.X || cells[0, 2].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[0, 1].current == PlayerOption.X && cells[2, 1].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[2, 1].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X || cells[2, 0].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[0, 2].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 1].current == PlayerOption.X || cells[2, 1].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1, 2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[1, 2].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                {
                    if (cells[0, 1].current == PlayerOption.X || cells[2, 1].current == PlayerOption.X || cells[0, 2].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[2, 2].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X || cells[2, 0].current == PlayerOption.X || cells[2, 1].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[0,0].current == PlayerOption.X && cells[1,1].current == PlayerOption.O)
            {
                if (cells[1, 0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[2, 0].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[2,1].current == PlayerOption.X && cells[2, 2].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[2, 1].current == PlayerOption.X && cells[2, 2].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[1,2].current == PlayerOption.X && cells[2, 2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X || cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[2, 2].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }

                }
            }

            if (cells[2,2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X || cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X || cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }

                }
            }

            if (cells[0,2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X || cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X || cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }

                }
            }

            if (cells[2, 0].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[2,1].current == PlayerOption.X && cells[2, 2].current == PlayerOption.O)
                {
                    if (cells[0, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0, 0);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[2, 2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[1,0].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                }

                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X || cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X || cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }

                }

                if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }

                }
            }

            if (cells[1, 0].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[0, 0].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2, 0].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
                {
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2, 2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2, 2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,1].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,2].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[1, 2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if (cells[0, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0, 1);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,2].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2, 0].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 1].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(0, 2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2, 1].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0, 2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[0,1].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[0,2].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2, 1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,2].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X || cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1, 2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,1].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X || cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[2,1].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[2,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X || cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,1].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(1,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,0].current == PlayerOption.X || cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[1,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                }
            }

            if (cells[1, 2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[2,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[2,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X)
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(2,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X || cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[1,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,0);
                        emptySpaces = 0;
                        return;
                    }
                    else
                    {
                        ChooseSpace(2,1);
                        emptySpaces = 0;
                        return;
                    }
                }
                if (cells[0,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X)
                    {
                        ChooseSpace(0,1);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,1].current == PlayerOption.X || cells[1,0].current == PlayerOption.X)
                    {
                        ChooseSpace(2,0);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[0,1].current == PlayerOption.X)
                    {
                        ChooseSpace(0,2);
                        emptySpaces = 0;
                        return;
                    }
                    if (cells[2,0].current == PlayerOption.X)
                    {
                        ChooseSpace(1,0);
                        emptySpaces = 0;
                        return;
                    }
                }
            }
        }

        if (emptySpaces == 3)
        {
            if (cells[0, 0].current == PlayerOption.X)  //First
            {
                if (cells[1, 1].current == PlayerOption.X && cells[2, 0].current == PlayerOption.X)
                {
                    if (cells[0, 1].current == PlayerOption.O && cells[2, 2].current == PlayerOption.O)
                    {
                        if (cells[2, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 0].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2, 1].current == PlayerOption.O && cells[2, 2].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 0].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1, 1].current == PlayerOption.X && cells[0, 2].current == PlayerOption.X)
                {
                    if (cells[1, 0].current == PlayerOption.O && cells[2, 2].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1, 2].current == PlayerOption.O && cells[2, 2].current == PlayerOption.O)
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[2, 0].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 0].current == PlayerOption.X && cells[2, 2].current == PlayerOption.X)
                {
                    if (cells[1, 0].current == PlayerOption.O && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[1, 1].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 0].current == PlayerOption.X && cells[0, 2].current == PlayerOption.X)
                {
                    if (cells[1, 0].current == PlayerOption.O && cells[2, 2].current == PlayerOption.O)
                    {
                        if (cells[1, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0, 2].current == PlayerOption.X && cells[2, 2].current == PlayerOption.X)
                {
                    if (cells[2, 0].current == PlayerOption.O && cells[0, 1].current == PlayerOption.O)
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[1, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }

                        if (cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
                {
                    if (cells[1, 2].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.O || cells[0, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0, 2].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 0].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2, 1].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0, 1].current == PlayerOption.X && cells[2, 1].current == PlayerOption.O)
                    {
                        if (cells[1, 0].current == PlayerOption.O || cells[2, 0].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                        }
                    }

                    if (cells[2, 0].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O)
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 0].current == PlayerOption.O || cells[1, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1, 0].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.O || cells[2, 1].current == PlayerOption.O || cells[0, 2].current == PlayerOption.O)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                        }
                    }
                }


                
            }
        }

        if(emptySpaces  == 2)
        {
            if (cells[1, 1].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
            {
                if(cells[1, 0].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                {
                    if(cells[2, 0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if(cells[0, 1].current == PlayerOption.X || cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if(cells[0,1].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if(cells[2, 0].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2, 1].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0, 2].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2, 2].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.X || cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 0].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                {
                    if(cells[0,1].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if(cells[1,0].current == PlayerOption.X || cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,1].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if(cells[1, 0].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 2].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2, 0].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[1, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1,0].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if(cells[0,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 0].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1, 2].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0,2].current == PlayerOption.X || cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1, 2].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[1, 0].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0, 2].current == PlayerOption.X || cells[1, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 1].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                {
                    if(cells[0,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[1, 2].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[0,1].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1,2].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[2, 0].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[2, 1].current == PlayerOption.X || cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2, 2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        if (cells[2,0].current == PlayerOption.X || cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
            }

            if (cells[0,0].current == PlayerOption.X && cells[1,1].current == PlayerOption.O)
            {
                if (cells[1, 0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[1, 2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,1].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                {
                    if (cells[2, 0].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2, 0].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[1, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1, 2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[1, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1, 2].current == PlayerOption.X && cells[2, 2].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2, 0].current == PlayerOption.X && cells[1, 0].current == PlayerOption.O)
                    {
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0, 1].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,2].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,2].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                {
                    if (cells[1, 0].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

            }

            if (cells[2,2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

            }

            if (cells[0,2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

            }

            if (cells[2,0].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[2,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                {
                    if (cells[0,1].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[2,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                    if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

                if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }

            }

            if (cells[1, 0].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[0, 0].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 2].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                    {
                        if (cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2, 0].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
                {
                    if (cells[2, 2].current == PlayerOption.X && cells[2, 1].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2, 2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,1].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 2].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
                    {
                        if (cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,2].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                {
                    if (cells[0, 0].current == PlayerOption.X && cells[0, 1].current == PlayerOption.O)
                    {
                        if (cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0, 1].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
                    {
                        if (cells[2, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[1, 2].current == PlayerOption.X && cells[2, 1].current == PlayerOption.O)
                {
                    if (cells[0, 1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,2].current == PlayerOption.X && cells[0, 0].current == PlayerOption.O)
                {
                    if (cells[2, 0].current == PlayerOption.X && cells[2, 1].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(1, 2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0, 1].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[2, 0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2, 1].current == PlayerOption.X && cells[2, 0].current == PlayerOption.O)
                    {
                        if (cells[0, 2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0, 2].current == PlayerOption.X && cells[1, 2].current == PlayerOption.O)
                    {
                        if (cells[2, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1, 2].current == PlayerOption.X && cells[0, 2].current == PlayerOption.O)
                    {
                        if (cells[0, 1].current == PlayerOption.X)
                        {
                            ChooseSpace(2, 0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0, 1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
            }

            if (cells[0,1].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[0,2].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,2].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0, 0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,1].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                {
                    if (cells[1,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
            }

            if (cells[2,1].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[2,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,1].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                {
                    if (cells[1,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,2].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X && cells[1,2].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[1,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[1,0].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
            }

            if (cells[1,2].current == PlayerOption.X && cells[1, 1].current == PlayerOption.O)
            {
                if (cells[2,2].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,2].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[2,0].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                {
                    if (cells[2,2].current == PlayerOption.X && cells[2,1].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,1].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                    {
                        if (cells[0,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[2,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,0].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[1,0].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                {
                    if (cells[2,1].current == PlayerOption.X && cells[0,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(2,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
                if (cells[0,0].current == PlayerOption.X && cells[2,2].current == PlayerOption.O)
                {
                    if (cells[0,2].current == PlayerOption.X && cells[0,1].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,1].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[0,2].current == PlayerOption.X)
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[0,1].current == PlayerOption.X && cells[0,2].current == PlayerOption.O)
                    {
                        if (cells[2,0].current == PlayerOption.X)
                        {
                            ChooseSpace(1,0);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,0);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[2,0].current == PlayerOption.X && cells[1,0].current == PlayerOption.O)
                    {
                        if (cells[0,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(0,1);
                            emptySpaces = 0;
                            return;
                        }
                    }

                    if (cells[1,0].current == PlayerOption.X && cells[2,0].current == PlayerOption.O)
                    {
                        if (cells[2,1].current == PlayerOption.X)
                        {
                            ChooseSpace(0,2);
                            emptySpaces = 0;
                            return;
                        }
                        else
                        {
                            ChooseSpace(2,1);
                            emptySpaces = 0;
                            return;
                        }
                    }
                }
            }

        }

        if (emptySpaces == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[j, i].current == PlayerOption.NONE)
                    {
                        ChooseSpace(j, i);
                    }
                }
            }
        }
    }

    public void CheckSpaces()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (cells[j, i].current == PlayerOption.NONE)
                {
                    emptySpaces += 1;
                }
            }
        }
        Debug.Log(emptySpaces);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("TTT");
    }


    public void ChooseSpace(int column, int row)
    {
        // can't choose space if game is over
        if (GetWinner() != PlayerOption.NONE)
            return;

        // can't choose a space that's already taken
        if (cells[column, row].current != PlayerOption.NONE)
            return;

        // set the cell to the player's mark
        cells[column, row].current = currentPlayer;

        // update the visual to display X or O
        board.UpdateCellVisual(column, row, currentPlayer);

        // if there's no winner, keep playing, otherwise end the game
        if(GetWinner() == PlayerOption.NONE)
            EndTurn();
        else
        {
            Debug.Log("GAME OVER!");
        }
    }

    public void EndTurn()
    {
        // increment player, if it goes over player 2, loop back to player 1
        currentPlayer += 1;
        if ((int)currentPlayer > 2)
            currentPlayer = PlayerOption.X;
    }

    public PlayerOption GetWinner()
    {
        // sum each row/column based on what's in each cell X = 1, O = -1, blank = 0
        // we have a winner if the sum = 3 (X) or -3 (O)
        int sum = 0;

        // check rows
        for (int i = 0; i < Rows; i++)
        {
            sum = 0;
            for (int j = 0; j < Columns; j++)
            {
                var value = 0;
                if (cells[j, i].current == PlayerOption.X)
                    value = 1;
                else if (cells[j, i].current == PlayerOption.O)
                    value = -1;

                sum += value;
            }

            if (sum == 3)
                return PlayerOption.X;
            else if (sum == -3)
                return PlayerOption.O;

        }

        // check columns
        for (int j = 0; j < Columns; j++)
        {
            sum = 0;
            for (int i = 0; i < Rows; i++)
            {
                var value = 0;
                if (cells[j, i].current == PlayerOption.X)
                    value = 1;
                else if (cells[j, i].current == PlayerOption.O)
                    value = -1;

                sum += value;
            }

            if (sum == 3)
                return PlayerOption.X;
            else if (sum == -3)
                return PlayerOption.O;

        }

        // check diagonals
        // top left to bottom right
        sum = 0;
        for(int i = 0; i < Rows; i++)
        {
            int value = 0;
            if (cells[i, i].current == PlayerOption.X)
                value = 1;
            else if (cells[i, i].current == PlayerOption.O)
                value = -1;

            sum += value;
        }

        if (sum == 3)
            return PlayerOption.X;
        else if (sum == -3)
            return PlayerOption.O;

        // top right to bottom left
        sum = 0;
        for (int i = 0; i < Rows; i++)
        {
            int value = 0;

            if (cells[Columns - 1 - i, i].current == PlayerOption.X)
                value = 1;
            else if (cells[Columns - 1 - i, i].current == PlayerOption.O)
                value = -1;

            sum += value;
        }

        if (sum == 3)
            return PlayerOption.X;
        else if (sum == -3)
            return PlayerOption.O;

        return PlayerOption.NONE;
    }
}
