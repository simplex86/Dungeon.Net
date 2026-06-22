using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimplexLab.Dungeon
{
    public class DungeonReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public RectangularDungeonField Read(MemoryStream stream)
        {
            using BinaryReader reader = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true);

            // 第1个字节：验证固定字母 'D'
            var magic = reader.ReadByte();
            if (magic != (byte)'D')
            {
                throw new InvalidDataException("Invalid dungeon file: magic byte is not 'D'.");
            }

            // 4字节：地牢宽度（小端序）
            var width = reader.ReadInt32();

            // 4字节：地牢高度（小端序）
            var height = reader.ReadInt32();

            // 4字节：地牢数据总字节数（小端序）
            var dataBytes = reader.ReadInt32();
            var fieldLength = dataBytes / sizeof(int);

            // 重建地牢场地（构造函数会通过 Utils.Odd 保证宽高为奇数）
            var field = new RectangularDungeonField(width, height);

            // 读取地牢数据
            for (int i = 0; i < fieldLength; i++)
            {
                field.Field[i] = reader.ReadInt32();
            }

            // 4字节：总字节数校验（不含该字段本身）
            var totalBytes = reader.ReadInt32();
            var expected = 1 + sizeof(int) * 3 + dataBytes;
            if (totalBytes != expected)
            {
                throw new InvalidDataException($"Invalid dungeon file: total bytes mismatch (expected {expected}, got {totalBytes}).");
            }

            return field;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public async Task<RectangularDungeonField> ReadAsync(MemoryStream stream)
        {
            return await Task.Run(() => Read(stream));
        }
    }
}
