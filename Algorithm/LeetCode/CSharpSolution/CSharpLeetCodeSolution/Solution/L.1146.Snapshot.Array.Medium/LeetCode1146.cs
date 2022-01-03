/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 01-03-2022 09:20:10
 * LastEditTime: 01-03-2022 09:37:03
 * FilePath: \CSharpLeetCodeSolution\Solution\L.1146.Snapshot.Array.Medium\LeetCode1146.cs
 * Description: 
 */
using System.Collections.Generic;
namespace DesignSolution
{
    public class LeetCode1146
    {
        private SnapshotArray map;

        public LeetCode1146(int length)
        {
            map = new SnapshotArray(length);
        }

        public void Set(int index, int val)
        {
            map.Set(index, val);
        }

        public int SnapShot()
        {
            return map.Snap();
        }

        public int Get(int index, int snap_id)
        {
            return map.Get(index, snap_id);
        }
        private class SnapshotArray
        {
            private int _snapshotID = 0;
            private Dictionary<int, int>[] map;
            public SnapshotArray(int Length)
            {
                map = new Dictionary<int, int>[Length];
            }

            public void Set(int index, int val)
            {
                if (map[index] == null)
                {
                    map[index] = new Dictionary<int, int>();
                }

                if (map[index].ContainsKey(_snapshotID))
                {
                    map[index][_snapshotID] = val;
                }
                else
                {
                    map[index].Add(_snapshotID, val);
                }
            }

            public int Snap()
            {
                return _snapshotID++;
            }

            public int Get(int index, int snap_id)
            {
                if (map[index] == null) return 0;
                if (map[index].ContainsKey(snap_id))
                {
                    return map[index][snap_id];
                }
                // TODO: Test here why we need use while not if
                // ["SnapshotArray","set","snap","snap","snap","get","snap","snap","get"]
                // [[1],[0,15],[],[],[],[0,2],[],[],[0,0]]
                while (!map[index].ContainsKey(snap_id) && snap_id != -1)
                {
                    snap_id--;
                }

                return snap_id == -1 ? 0 : map[index][snap_id];
            }
        }
    }

}