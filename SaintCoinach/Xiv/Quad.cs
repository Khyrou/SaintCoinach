using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SaintCoinach.Xiv {
    [Serializable]
    public struct Quad {
        public ushort Value1;
        public ushort Value2;
        public ushort Value3;
        public ushort Value4;

        public Quad(long data) {
            Value1 = (ushort)data;
            Value2 = (ushort)(data >> 16);
            Value3 = (ushort)(data >> 32);
            Value4 = (ushort)(data >> 48);
        }

        public static Quad Read(byte[] buffer, int offset, bool bigEndian) {
            var data = OrderedBitConverter.ToInt64(buffer, offset, bigEndian);
            return new Quad(data);
        }

        public override string ToString() {
            return Value1 + ", " + Value2 + ", " + Value3 + ", " + Value4;
        }

        public Int64 ToInt64() {
            return (Int64)Value1 + ((Int64)Value2 << 16) + ((Int64)Value3 << 32) + ((Int64)Value4 << 48);
        }

        public bool IsEmpty {
            get { return Value1 == 0 && Value2 == 0 && Value3 == 0 && Value4 == 0; }
        }

        #region Operators

        public static bool operator==(Quad lhs, Quad rhs) {
            return rhs.Value1 == lhs.Value1 && rhs.Value2 == lhs.Value2 && rhs.Value3 == lhs.Value3 && rhs.Value4 == lhs.Value4;
        }

        public static bool operator!=(Quad lhs, Quad rhs) {
            return rhs.Value1 != lhs.Value1 || rhs.Value2 != lhs.Value2 || rhs.Value3 != lhs.Value3 || rhs.Value4 != lhs.Value4;
        }

        public override bool Equals(object obj) {
            if (obj is Quad)
                return (Quad)obj == this;
            return false;
        }

        public override int GetHashCode() {
            return ToInt64().GetHashCode();
        }

        #endregion
    }
}
