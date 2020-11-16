using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution
{
    //n a given grid, each cell can have one of three values:

    //the value 0 representing an empty cell;
    //the value 1 representing a fresh orange;
    //the value 2 representing a rotten orange.

    //Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

    //Return the minimum number of minutes that must elapse until no cell has a fresh orange.If this is impossible, return -1 instead.



    //Example 1:

    //Input: [[2,1,1], [1,1,0], [0,1,1]]
    //Output: 4

    //Example 2:

    //Input: [[2,1,1],[0,1,1],[1,0,1]]
    //Output: -1
    //Explanation:  The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.

    //Example 3:

    //Input: [[0,2]]
    //Output: 0
    //Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.

 

    //Note:

    //1 <= grid.length <= 10
    //1 <= grid[0].length <= 10
    //grid[i][j] is only 0, 1, or 2.


    public class LeetCode994
    {

        public static int OrangeRotting(int[][] grid)
        {
            // in the dictionary, we keeps the key as row and value as col
            Queue<Dictionary<int, int>> queue = new Queue<Dictionary<int, int>>();

            var Rows = grid.Length;
            var Cols = grid[0].Length;

            var freshOranges = 0;
            var timeElapsed = -1;

            for (var r = 0; r < Rows; r++)
            {
                for (var c = 0; c < Cols; c++)
                {
                    
                    if (grid[r][c] == 2)
                    {
                        // in this cell the orange is rotten 
                        queue.Enqueue(new Dictionary<int, int>() {{r,c}});   
                    }
                    else if (grid[r][c] == 1)
                    {
                        // in this cell the orange is fresh
                        freshOranges++;
                    }
                    // if cell = 0, don't process                    
                }
            }

            // this line add a record to mark this level is finished
            queue.Enqueue(new Dictionary<int, int>(){{-1, -1}});

            //represent the 4 directions down {-1, 0}, up {1, 0}, right {0, 1}, left {0, -1} 
            var directions = new int[][] {new int[] {-1, 0}, new int[] {1, 0 } , new int[] {0, 1 } , new int[] {0, -1 } };
            while (queue.Count != 0)
            {
                // pop up an bad orange position and start to process
                var p = queue.Dequeue();

                var row = p.Keys.First();
                var col = p[row];

                if (row == -1)
                {
                    timeElapsed++;
                    if (queue.Count != 0)
                    {
                        queue.Enqueue(new Dictionary<int, int>() {{-1, -1}});
                    }
                }
                else
                {
                    // this is a rotten orange and we start to rot neighbors 

                    foreach (var direction in directions)
                    {
                        var neighborRow = row + direction[0];
                        var neighborCol = col + direction[1];

                        if (neighborRow >= 0 
                            && neighborRow < Rows
                            && neighborCol >= 0
                            && neighborCol < Cols
                        )
                        {
                            if (grid[neighborRow][neighborCol] == 1)
                            {
                                grid[neighborRow][neighborCol] = 2;
                                freshOranges--;
                                // add this rot orange to current queue. to infect other oranges
                                queue.Enqueue(new Dictionary<int, int>() {{neighborRow, neighborCol}});
                            }
                        }
                    }
                }
            }
            return freshOranges == 0 ? timeElapsed : -1;
        }
    }
}
