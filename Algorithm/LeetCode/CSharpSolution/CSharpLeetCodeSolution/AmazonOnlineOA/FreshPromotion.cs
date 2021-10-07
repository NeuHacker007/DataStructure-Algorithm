/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-07-2021 09:59:54
 * LastEditTime: 10-07-2021 10:42:56
 * FilePath: \AmazonOnlineOA\FreshPromotion.cs
 * Description: 
 */
using System.Collections.Generic;
namespace AmazonOA
{
    public class FreshPromotion
    {

        public static int FreshPromotionWinner(string[][] codeList, string[] shoppingCart)
        {
            if (shoppingCart == null || shoppingCart.Length == 0) return 0;
            if (codeList == null || codeList.Length == 0) return 1;

            int codeListPointer = 0; int shoppingCartPointer = 0;

            // hoppingCartPointer + codeList[codeListPointer].Length <= shoppingCart.Length
            // 如果codelist 的长度超出了shopping cart 长度 那么就不会有winner
            while (codeListPointer < codeList.Length && shoppingCartPointer + codeList[codeListPointer].Length <= shoppingCart.Length)
            {
                bool match = true;

                for (int k = 0; k < codeList[codeListPointer].Length; k++)
                {
                    if (!codeList[codeListPointer][k].Equals("anything") && !shoppingCart[shoppingCartPointer + k].Equals(codeList[codeListPointer][k]))
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    shoppingCartPointer += codeList[codeListPointer].Length;
                    codeListPointer++;
                }
                else
                {
                    shoppingCartPointer++; // move shopping cart point 
                }
            }

            return codeListPointer == codeList.Length ? 1 : 0;

        }

    }

}
