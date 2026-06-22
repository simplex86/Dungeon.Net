using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimplexLab.Dungeon
{
    /// <summary>
    /// 
    /// </summary>
    public class DungeonWriter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public bool Write(RectangularDungeonField field, MemoryStream stream)
        {
            using BinaryWriter writer = new BinaryWriter(stream, Encoding.ASCII, leaveOpen: true);

            // 第1个字节：固定字母 'D'
            writer.Write((byte)'D');

            // 4字节：地牢宽度（小端序）
            writer.Write(field.Width);

            // 4字节：地牢高度（小端序）
            writer.Write(field.Height);

            // 4字节：地牢数据总字节数（小端序）
            int dataBytes = field.Field.Length * sizeof(int);
            writer.Write(dataBytes);

            // 若干字节：地牢数据（每个 int 4字节，小端序）
            for (int i = 0; i < field.Field.Length; i++)
            {
                writer.Write(field.Field[i]);
            }

            // 4字节：总字节数，不含该字段本身（小端序）
            int totalBytes = 1 + sizeof(int) * 3 + dataBytes;
            writer.Write(totalBytes);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public async Task<bool> WriteAsync(RectangularDungeonField field, MemoryStream stream)
        {
            return await Task.Run(() => Write(field, stream));
        }
}
}
