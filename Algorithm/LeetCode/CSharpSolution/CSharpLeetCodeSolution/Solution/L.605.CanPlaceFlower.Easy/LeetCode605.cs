// Project: Solution
// Author:yfeva
// Date: 05/04/2024 12:05
// Created: 05/04/2024 12:05
// FileName: LeetCode605.cs
// Description:

namespace Solution.L._605.CanPlaceFlower.Easy;

public class LeetCode605
{
    public static bool CanPlaceFlower(int[] flowerbed, int n)
    {
        int placesCanBePlaced = 0;

        for(int i = 0; i < flowerbed.Length; i++) {

            if (flowerbed[i] == 0) {
                bool isLeftCanPlace = i == 0 || flowerbed[i-1] == 0;
                bool isRightCanPlace = i == flowerbed.Length - 1 || flowerbed[i+1] == 0;

                if (isLeftCanPlace && isRightCanPlace ) {
                    flowerbed[i] = 1;
                    placesCanBePlaced++;
                }
            }
            
        }

        return placesCanBePlaced >= n;
    }

    public static bool CanPlaceFlower2(int[] flowerBed, int n)
    {
        // DP[i] represents number of pots can be fufilled 


        return false;
    }
}